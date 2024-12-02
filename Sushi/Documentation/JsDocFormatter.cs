using System.Text;
using Sushi.Descriptors;
using Sushi.Extensions;
using Sushi.Interfaces;

namespace Sushi.Documentation;

internal static class JsDocFormatter
{
    internal static void AppendJsDoc(this StringBuilder builder, XmlDocumentationReader? doc,
        IPropertyDescriptor descriptor, string prefix = "", string scriptType = "")
    {
        if (doc == null)
            return;

        // Return the rows for the js-doc
        var summary = doc.GetDocumentationForProperty(descriptor);
        if (summary == null)
            return;

        builder.AppendLine();
        builder.AppendLine(prefix + "/**");
        builder.AppendLine(prefix + $" * {summary.Summary}");
        if (!string.IsNullOrWhiteSpace(scriptType))
            builder.AppendLine(prefix + $" * @type ({scriptType})");
        builder.AppendLine(prefix + " */");
    }

    internal static void AppendJsDoc(this StringBuilder builder, XmlDocumentationReader? doc, ClassDescriptor descriptor,
        string prefix = "")
    {
        if (doc == null)
            return;

        // Return the rows for the js-doc
        builder.AppendLine(prefix + "/**");

        var typeDoc = doc.GetDocumentationForType(descriptor.Type);
        if (typeDoc != null)
            builder.AppendLine(prefix + $" * {typeDoc.Summary}");
        builder.AppendLine(prefix + $" * {descriptor.FullName}");

        if (descriptor.Parent != null)
            builder.AppendLine(prefix + $" * @extends {descriptor.Parent.Name}");

        if (descriptor.GenericParameterNames.Any())
            foreach (var genericArg in descriptor.GenericParameterNames)
                builder.AppendLine(prefix + $" * @template {{any}} {genericArg}");


        builder.AppendLine(prefix + " */");
    }
}