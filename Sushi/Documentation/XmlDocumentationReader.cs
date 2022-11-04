﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Sushi.Consistency;
using Sushi.Descriptors;
using Sushi.Extensions;
using Sushi.Interfaces;
#pragma warning disable CS1591

namespace Sushi.Documentation
{
    /// <summary>
    ///     Reads the given XML document and populates 
    ///     its <see cref="Members"/> with <see cref="XmlSummaryDescriptor"/>(s) that
    ///     describe property / field / method / class documentation.
    /// </summary>
    public sealed class XmlDocumentationReader
    {
        private string Path { get; }
        private string AssemblyName { get; set; }

        public List<XmlSummaryDescriptor> Members { get; private set; } = new List<XmlSummaryDescriptor>();

        public bool Initialized { get; private set; }

        private XDocument _doc;

        public static readonly Regex RemoveMethodArgs = new Regex(@"^([a-zA-Z.]*)");

        public XmlDocumentationReader(string path)
        {
            if (!File.Exists(path))
                throw Errors.NonExistentFile(path);

            Path = path;
            Initialized = false;
        }

        private string ResolveXmlBody(XElement element)
        {
            var body = string.Empty;
            var nodes = element.Nodes().ToList();
            if (!nodes.Any())
                return element.Value;

            var text = "";
            foreach (var node in nodes)
            {
                if (node is XText textNode)
                    text += textNode.Value;
                else if (node is XElement elementNode)
                {
                    var crefValue = elementNode.Attribute("cref")?.Value ?? string.Empty;
                    text += crefValue.Split('.').Last();
                }
            }

            return text.Trim().RemoveEscapedCharacters();
        }

        private void ProcessXmlFileContents()
        {
            if (Members.Any())
                throw new InvalidOperationException(
                    $@"This {nameof(XmlDocumentationReader)} has already been initialized.");

            var root = _doc.Element("doc");
            if (root == null)
                throw Errors.IncompatibleXmlDocument("doc");

            var assembly = root.Element("assembly");
            if (assembly == null)
                throw Errors.IncompatibleXmlDocument("doc > assembly");

            AssemblyName = assembly.Element("name")?.Value;

            var membersElement = root.Element("members");
            if (membersElement == null)
                throw Errors.IncompatibleXmlDocument("doc > members");

            var members = membersElement.Elements("member").ToList();
            foreach (var member in members)
            {
                var @namespace = member.Attribute("name")?.Value ?? string.Empty;
                var split = @namespace.Split(':');
                var fieldType = split[0].GetFieldType();
                if (fieldType == ReferenceType.Method)
                    continue;

                var descendants = member.Descendants().ToList();
                var dict = new Dictionary<string, string>();
                foreach (var desc in descendants)
                {
                    // Process the inner elements
                    dict[desc.Name.LocalName] = ResolveXmlBody(desc);
                }

                var model = new XmlSummaryDescriptor(split[1], fieldType, dict);
                Members.Add(model);
            }

            Members = Members.OrderBy(x => x.FieldType).ToList();
            Initialized = true;
        }

        /// <summary>
        ///     Read the given <see cref="Path"/> and process its contents.
        /// </summary>
        public XmlDocumentationReader Initialize()
        {
            _doc = XDocument.Load(Path);

            ProcessXmlFileContents();

            return this;
        }

        /// <summary>
        ///     Try to resolve the <see cref="XmlSummaryDescriptor"/> for the given <see cref="Type"/>.
        /// </summary>
        public XmlSummaryDescriptor GetDocumentationForType(Type type)
        {
            // No members, initialize.
            if (!Initialized)
                Initialize();

            var typeMembers = Members.Where(x => x.FieldType == ReferenceType.Type);
            var doc = typeMembers.SingleOrDefault(x => x == type);

            if (!(doc is null) && !doc.IsInherited)
                return doc;

            var interfaces = type.GetInterfaces();
            foreach (var interfaceType in interfaces)
            {
                var interfaceNamespace = interfaceType?.Namespace?.Split(',')[0];
                doc = Members.SingleOrDefault(x => x.FieldType == ReferenceType.Type && x == interfaceType);

                if (!(doc is null))
                    return doc;
            }

            return null;
        }

        /// <summary>
        ///     Try to resolve the <see cref="XmlSummaryDescriptor"/> for the selected <paramref name="property"/>.
        /// </summary>
        public XmlSummaryDescriptor GetDocumentationForProperty<T>(T instance, Expression<Func<T, object>> property)
        {
            // Get the PropertyInfo that the given expression selects.
            var info = instance.GetPropertyInfo(property);

            var doc = GetDocumentationForProperty(new PropertyDescriptor(info));
            return doc;
        }

        /// <summary>
        ///     Try to resolve the <see cref="XmlSummaryDescriptor"/> for the given <see cref="PropertyInfo"/>.
        /// </summary>
        public XmlSummaryDescriptor GetDocumentationForProperty(IPropertyDescriptor descriptor)
        {
            // No members, initialize.
            if (!Initialized)
                Initialize();

            var type = descriptor.ClassType;
            if (type == null)
                return null;

            var members = Members.Where(x => x.DeclaringTypeName == type.Name);
            var doc = members.SingleOrDefault(x => x.Name == descriptor.Name);
            if (!(doc is null) && !doc.IsInherited)
                return doc;

            var interfaces = type.GetInterfaces();
            foreach (var interfaceType in interfaces)
            {
                var properties = interfaceType.GetProperties();

                // Check if a interface has the expected summary.
                if (properties.All(x => x.Name != descriptor.Name))
                    continue;

                var membersWithInterface = Members.Where(x => x.DeclaringTypeName == interfaceType.Name);
                doc = membersWithInterface.SingleOrDefault(x => x.Name == descriptor.Name);
                if (!(doc is null))
                    return doc;
            }

            // Not found, return null.
            return null;
        }
    }
}
