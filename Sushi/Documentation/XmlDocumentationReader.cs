using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Sushi.Descriptors;
using Sushi.Extensions;
using Sushi.Interfaces;


namespace Sushi.Documentation;

/// <summary>
///     Reads the given XML document and populates
///     its <see cref="Members" /> with <see cref="XmlSummaryDescriptor" />(s) that
///     describe property / field / method / class documentation.
/// </summary>
internal sealed class XmlDocumentationReader
{
    private readonly XDocument _doc;

    private string Path { get; }

    public List<XmlSummaryDescriptor> Members { get; private set; } = new();

    public static readonly Regex RemoveMethodArgs = new("^([a-zA-Z0-9.]*)");

    public XmlDocumentationReader(string path)
    {
        Path = path;
        _doc = XDocument.Load(Path);
        var parseSuccessful = TryParseXmlDoc();
        if (!parseSuccessful)
            throw new InvalidOperationException("Given xml doc is invalid.");
    }

    private static string ResolveXmlBody(XElement element)
    {
        var nodes = element.Nodes().ToList();
        if (!nodes.Any())
            return element.Value;

        var text = "";
        foreach (var node in nodes)
            switch (node)
            {
                case XText textNode:
                    text += textNode.Value;
                    break;
                case XElement elementNode:
                {
                    var crefValue = elementNode.Attribute("cref")?.Value ?? string.Empty;
                    text += crefValue.Split('.').Last();
                    break;
                }
            }

        return text.Trim().RemoveEscapedCharacters();
    }

    private bool TryParseXmlDoc()
    {
        var root = _doc.Element("doc");
        if (root == null)
            return false;

        var assembly = root.Element("assembly");
        if (assembly == null)
            return false;

        var membersElement = root.Element("members");
        if (membersElement == null)
            return false;

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
                // Process the inner elements
                dict[desc.Name.LocalName] = ResolveXmlBody(desc);

            var model = new XmlSummaryDescriptor(split[1], fieldType, dict);
            Members.Add(model);
        }

        Members = Members.OrderBy(x => x.FieldType).ToList();
        return true;
    }

    /// <summary>
    ///     Try to resolve the <see cref="XmlSummaryDescriptor" /> for the given <see cref="Type" />.
    /// </summary>
    public XmlSummaryDescriptor? GetDocumentationForType(Type type)
    {
        var typeMembers = Members.Where(x => x.FieldType == ReferenceType.Type);
        var doc = typeMembers.SingleOrDefault(x => x.IsSameType(type));

        if (!doc?.IsInherited ?? true)
            return doc;

        var interfaces = type.GetInterfaces();
        foreach (var interfaceType in interfaces)
        {
            var interfaceDoc = Members.SingleOrDefault(x => x.IsSameType(interfaceType));
            if (interfaceDoc == null)
                continue;

            return doc.UseInheritedSummary(interfaceDoc.Summary, interfaceType);
        }

        return doc;
    }

    /// <summary>
    ///     Try to resolve the <see cref="XmlSummaryDescriptor" /> for the selected <paramref name="property" />.
    /// </summary>
    public XmlSummaryDescriptor? GetDocumentationForProperty<T>(T instance, Expression<Func<T, object>> property)
    {
        // Get the PropertyInfo that the given expression selects.
        var info = instance.GetPropertyInfo(property);

        var doc = GetDocumentationForProperty(new PropertyDescriptor(info));
        return doc;
    }

    /// <summary>
    ///     Try to resolve the <see cref="XmlSummaryDescriptor" /> for the given <see cref="PropertyInfo" />.
    /// </summary>
    public XmlSummaryDescriptor? GetDocumentationForProperty(IPropertyDescriptor? descriptor)
    {
        if (descriptor?.ClassType == null)
            throw new ArgumentNullException(nameof(descriptor));

        var members = Members.Where(x => x.DeclaringTypeName == descriptor.ClassType.Name);
        var doc = members.SingleOrDefault(x => x.Name == descriptor.Name);
        if (!doc?.IsInherited ?? true)
            return doc;

        var inheritedProperty = descriptor.ClassType.GetInterfaces()
            .SelectMany(x => x.GetProperties())
            .FirstOrDefault(x => x.Name == doc.Name);

        if (inheritedProperty == null)
            return doc;

        var inheritedSummary = Members.SingleOrDefault(x =>
            x.DeclaringTypeName == inheritedProperty.DeclaringType.Name && x.Name == inheritedProperty.Name);
        return inheritedSummary == null ? doc : doc.UseInheritedSummary(inheritedSummary.Summary, inheritedProperty.DeclaringType);
    }
}