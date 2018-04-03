using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using Sushi.Consistency;
using Sushi.Documentation.Models;
using Sushi.Enum;
using Sushi.Extensions;

namespace Sushi.Documentation
{
    /// <summary>
    ///     Reads the given XML document and populates 
    ///     its <see cref="Members"/> with <see cref="FieldDocumentation"/>(s) that
    ///     describe property / field / method / class documentation.
    /// </summary>
    public class XmlDocumentationReader
    {
        public string Path { get; }
        public string AssemblyName { get; private set; }

        public List<FieldDocumentation> Members { get; private set; } = new List<FieldDocumentation>();

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

                var model = new FieldDocumentation(split[1], fieldType, dict);
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
        ///     Clear the stored values.
        /// </summary>
        public XmlDocumentationReader Clear()
        {
            Members.Clear();
            Initialized = false;

            return this;
        }

        /// <summary>
        ///     Try to resolve the <see cref="FieldDocumentation"/> for the given <see cref="Type"/>.
        /// </summary>
        public FieldDocumentation GetDocumentationForType(Type type)
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
        ///     Try to resolve the <see cref="FieldDocumentation"/> for the selected <paramref name="property"/>.
        /// </summary>
        public FieldDocumentation GetDocumentationForProperty<T>(T instance, Expression<Func<T, object>> property)
        {
            // Get the PropertyInfo that the given expression selects.
            var info = instance.GetPropertyInfo(property);

            var doc = GetDocumentationForProperty(info);
            return doc;
        }

        /// <summary>
        ///     Try to resolve the <see cref="FieldDocumentation"/> for the given <see cref="PropertyInfo"/>.
        /// </summary>
        public FieldDocumentation GetDocumentationForProperty(PropertyInfo property)
        {
            // No members, initialize.
            if (!Initialized)
                Initialize();

            var type = property.DeclaringType;
            if (type == null)
                return null;

            var members = Members.Where(x => x.DeclaringTypeName == type.Name);
            var doc = members.SingleOrDefault(x => x.Name == property.Name);
            if (!(doc is null) && !doc.IsInherited)
                return doc;

            var interfaces = type.GetInterfaces();
            foreach (var interfaceType in interfaces)
            {
                var properties = interfaceType.GetProperties();

                // Check if a interface has the expected summary.
                if (properties.All(x => x.Name != property.Name))
                    continue;

                var membersWithInterface = Members.Where(x => x.DeclaringTypeName == interfaceType.Name);
                doc = membersWithInterface.SingleOrDefault(x => x.Name == property.Name);
                if (!(doc is null))
                    return doc;
            }

            // Not found, return null.
            return null;
        }
    }
}
