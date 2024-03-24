// /***************************************************************************\
// Module Name:       JavaScriptConverter.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 01-01-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System.Globalization;
using System.Text;
using Sushi.Descriptors;
using Sushi.Documentation;
using Sushi.Enum;
using Sushi.Extensions;
using Sushi.Helpers;
using Sushi.Interfaces;

#endregion

namespace Sushi.Converters;

/// <summary>
///     Add the JavaScript class declaration to the <see cref="SushiConverter.Models" />.
/// </summary>
public sealed class EcmaScript6Converter : ModelConverter
{
    /// <inheritdoc />
    public EcmaScript6Converter(SushiConverter converter, IConverterOptions options) : base(converter, options)
    {
    }

    /// / <inheritdoc />
    protected override IEnumerable<string> ConvertToScript(IEnumerable<ClassDescriptor> descriptors)
    {
        foreach (var model in descriptors)
            yield return Compile(model);
    }

    private string CreatePropertyDeclaration(IEnumerable<IPropertyDescriptor> properties)
    {
        var builder = new StringBuilder();
        foreach (var prop in properties)
        {
            builder.AppendJsDoc(XmlDocument, prop, Indent);
            builder.AppendLine($"{Indent}{prop.Name};");
        }

        return builder.ToString();
    }

    private string CreateConstructorDeclaration(IEnumerable<IPropertyDescriptor> properties, bool hasParent)
    {
        var builder = new StringBuilder();
        builder.AppendLine(Indent + "constructor(value) {");
        if (hasParent)
        {
            builder.AppendLine(Indent + Indent + "super(value);");
            builder.AppendLine("");
        }

        builder.AppendLine(Indent + Indent + "if (!(value instanceof Object))");
        builder.AppendLine(Indent + Indent + Indent + "return;");
        builder.AppendLine();

        foreach (var prop in properties)
            builder.AppendLine(Indent + Indent +
                               $"this.{ApplyCasingStyle(prop.Name)} = value.{ApplyCasingStyle(prop.Name)};");

        builder.Append(Indent + "}");
        return builder.ToString();
    }

    private string Compile(ClassDescriptor model)
    {
        var properties = model.GetProperties(true).ToList();
        var builder = new StringBuilder();
        builder.AppendJsDoc(XmlDocument, model);

        var parentClass = model.Parent == null ? string.Empty : $" extends {model.Parent.Name}";
        var propertyDeclaration = CreatePropertyDeclaration(properties);
        var constructorDeclaration = CreateConstructorDeclaration(properties, model.Parent != null);

        builder.AppendLine($"export class {model.Name}{parentClass} {{");
        builder.AppendLine(propertyDeclaration);
        builder.AppendLine(constructorDeclaration);
        builder.AppendLine(Indent + "static mapFrom(obj) {");
        builder.AppendLine(Indent + Indent + "return Object.assign(new {model.Name}(), obj);");
        builder.AppendLine(Indent + "}");
        builder.AppendLine("}");

        return builder.ToString();
    }
}