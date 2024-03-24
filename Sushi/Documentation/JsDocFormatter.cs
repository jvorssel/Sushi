// /***************************************************************************\
// Module Name:       JsDocComment.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 16-05-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System.Text;
using Sushi.Descriptors;
using Sushi.Extensions;
using Sushi.Helpers;
using Sushi.Interfaces;

#endregion

namespace Sushi.Documentation;

public static class JsDocFormatter
{
    public static void AppendJsDoc(this StringBuilder builder, XmlDocumentationReader? doc,
        IPropertyDescriptor descriptor, string prefix = "", string scriptType = "")
    {
        if (doc == null)
            return;

        // Return the rows for the js-doc
        var summary = doc.GetDocumentationForProperty(descriptor);
        if (summary == null)
            return;

        builder.AppendLine(prefix + "/**");
        builder.AppendLine(prefix + $" * {summary.Summary}");
        if (!scriptType.IsEmpty())
            builder.AppendLine(prefix + $" * @type ({scriptType})");
        builder.AppendLine(prefix + " */");
    }

    public static void AppendJsDoc(this StringBuilder builder, XmlDocumentationReader? doc, ClassDescriptor descriptor,
        string prefix = "")
    {
        // Return the rows for the js-doc
        builder.AppendLine(prefix + "/**");

        if (doc != null)
        {
            var typeDoc = doc.GetDocumentationForType(descriptor.Type);
            builder.AppendLine(prefix + $" * {typeDoc?.Summary ?? descriptor.FullName}");
        }
        else
        {
            builder.AppendLine(prefix + $" * {descriptor.FullName}");
        }

        if (descriptor.Parent != null)
            builder.AppendLine(prefix + $" * @extends {descriptor.Parent.Name}");

        builder.AppendLine(prefix + " */");
    }
}