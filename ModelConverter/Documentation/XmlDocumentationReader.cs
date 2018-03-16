using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using ModelConverter.Consistency;
using ModelConverter.Documentation.Models;

namespace ModelConverter.Documentation
{
    /// <summary>
    ///     Reads the given XML document and populates 
    ///     its <see cref="Members"/> with <see cref="MemberSummary"/>(s) that
    ///     describe property / field / method / class documentation.
    /// </summary>
    public class XmlDocumentationReader
    {
        private readonly List<MemberSummary> _members = new List<MemberSummary>();

        public string Path { get; }
        public string AssemblyName { get; private set; }

        public IEnumerable<MemberSummary> Members => _members;

        public bool Initialized { get; private set; }

        private XDocument _doc;

        public XmlDocumentationReader(string path)
        {
            if (!File.Exists(path))
                throw Errors.NonExistentFile(path);

            Path = path;
            Initialized = false;
        }

        private void ProcessXmlFileContents()
        {
            if (_members.Any())
                throw new InvalidOperationException(
                    $@"This {nameof(XmlDocumentationReader)} has already been initialized.");

            var root = _doc.Element("doc");
            if (root == null)
                throw Errors.IncompatibleXmlDocument("doc");

            var assembly = root.Element("assembly");
            if (assembly == null)
                throw Errors.IncompatibleXmlDocument("doc > assembly");

            AssemblyName = assembly.Element("name")?.Value;

            var members = root.Element("members");
            if (members == null)
                throw Errors.IncompatibleXmlDocument("doc > members");

            foreach (var member in members.Elements("member"))
            {
                var @namespace = member.Attribute("name")?.Value ?? string.Empty;
                var summary = member.Element("summary")?.Value ?? string.Empty;
                var split = @namespace.Split(':');

                _members.Add(new MemberSummary(split[1], summary, split[0].GetFieldType()));
            }

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
            _members.Clear();
            Initialized = false;

            return this;
        }
    }
}
