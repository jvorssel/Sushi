// /***************************************************************************\
// Module Name:       TypeScriptConverter.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 15-05-2023
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
///     Add the TypeScript class declaration to the <see cref="SushiConverter.Models" />.
/// </summary>
public sealed class TypeScriptConverter : ModelConverter
{
    /// <inheritdoc />
    public TypeScriptConverter(SushiConverter converter, IConverterOptions options) : base(converter, options)
    {
    }

    /// <inheritdoc />
    protected override IEnumerable<string> ConvertToScript(IEnumerable<ClassDescriptor> descriptors)
    {
        foreach (var line in HeaderLines)
            yield return line;

        foreach (var model in EnumModels)
            yield return ToTypeScriptEnum(model);

        foreach (var model in descriptors)
            yield return ToTypeScriptClass(model);
    }

    private string ConvertProperty(IPropertyDescriptor property)
    {
        var scriptType = ResolveScriptType(property.Type, string.Empty);
        var defaultValue = ResolveDefaultValue(property);

        var name = ApplyCasingStyle(property.Name);
        var nameSuffix = defaultValue.IsEmpty() ? "!" : string.Empty;

        var modifiers = GetPropertyModifiers(property);
        var valueSuffix = defaultValue.IsEmpty() ? string.Empty : $" = {defaultValue}";

        return $"{Indent}{modifiers}{name}{nameSuffix}: {scriptType}{valueSuffix};";
    }

    private string GetPropertyModifiers(IPropertyDescriptor property)
    {
        var readonlyPrefix = property.Readonly ? "readonly " : string.Empty;
        var staticPrefix = property.IsStatic ? "static " : string.Empty;

        return $"{staticPrefix}{readonlyPrefix}";
    }

    public string ResolveScriptType(Type type, string prefix = "")
    {
        // Check if any of the available models have the same name and should be used.
        var classModel =
            Models.SingleOrDefault(x => x.Type == (type.IsGenericType ? type.GetGenericTypeDefinition() : type));

        var genericTypeArgs = type.IsGenericType ? GetGenericTypeArguments(type, prefix).ToList() : new List<string>();
        if (classModel != null)
            return type.IsGenericType
                ? $"{prefix}{classModel.Name}<{genericTypeArgs.Glue(", ")}>"
                : prefix + classModel.Name;

        // Array
        var actualType = type.GetBaseType();
        var isDictionary = type.IsDictionary();
        if (type.IsArrayType() && !isDictionary)
        {
            var typeName = type.IsGenericType ? genericTypeArgs.Glue(", ") : ResolveScriptType(actualType, prefix);
            return $"Array<{typeName}>";
        }

        if (isDictionary && genericTypeArgs.Count == 2)
        {
            var keyType = genericTypeArgs[0];
            if (keyType != NativeType.String.ToScriptType() && keyType != NativeType.Int.ToScriptType())
                return "any"; // Unsupported, default to any.

            return $"{{ [key: string]: {genericTypeArgs[1]} }}";
        }

        var enumModel = EnumModels.SingleOrDefault(x => x.Name == actualType.Name);
        if (type.IsEnum && enumModel != null)
            return $"{prefix}{enumModel.Name} | number";

        // Date
        if (actualType == typeof(DateTime))
            return "Date | string | null";

        var scriptType = actualType.ToNativeScriptType().ToScriptType();
        return type.IsNullable() ? $"{scriptType} | null" : scriptType;
    }

    public string ResolveDefaultValue(IPropertyDescriptor prop)
    {
        if (prop.Type?.IsArrayType() ?? false)
            return "[]";

        if (prop.Type?.IsNullable() ?? false)
            return "null";

        if (prop.DefaultValue == null)
            return string.Empty;

        var defaultValueType = prop.DefaultValue.GetType();
        var descriptor = Models.SingleOrDefault(x => x.Type == defaultValueType && x.HasParameterlessCtor);
        if (descriptor != null)
            return $"new {descriptor.Name}()";

        if (defaultValueType.IsClass && defaultValueType != typeof(string))
            return defaultValueType.IsDictionary() ? "{}" : string.Empty;

        var nativeType = prop.Type.ToNativeScriptType();
        switch (nativeType)
        {
            case NativeType.Bool:
                return (bool)prop.DefaultValue ? "true" : "false";
            case NativeType.Enum:
            case NativeType.Byte:
            case NativeType.Short:
            case NativeType.Long:
            case NativeType.Int:
            case NativeType.Double:
            case NativeType.Float:
            case NativeType.Decimal:
            {
                var asDecimal = Convert.ToDecimal(prop.DefaultValue).ToString(CultureInfo.InvariantCulture);
                return asDecimal.Substring(0, Math.Min(asDecimal.Length, 15));
            }
            case NativeType.Char:
            case NativeType.String:
                return $"\"{prop.DefaultValue}\"";
            case NativeType.Null:
            case NativeType.Object:
                return "null";
            case NativeType.Undefined:
            default:
                return string.Empty;
        }
    }

    internal IEnumerable<string> GetGenericTypeArguments(Type type, string prefix)
    {
        if (!type.IsGenericType)
            throw new ArgumentException("Expected given type to be generic.");

        var genericTypeArgs = type.GenericTypeArguments
            .Select(x => x.IsGenericParameter ? x.Name : ResolveScriptType(x, prefix));
        return genericTypeArgs;
    }

    private string CreatePropertyDeclaration(IEnumerable<IPropertyDescriptor> properties)
    {
        var builder = new StringBuilder();
        foreach (var prop in properties)
        {
            if (XmlDocument != null)
            {
                var summary = XmlDocument.JsDocPropertySummary(prop);
                if (!summary.IsEmpty())
                    builder.AppendLine(Indent + summary);
            }

            var property = ConvertProperty(prop);
            builder.AppendLine(property);
        }

        return builder.ToString();
    }

    public string CreateConstructorDeclaration(ClassDescriptor model)
    {
        if (!model.GenerateConstructor)
            return string.Empty;

        var builder = new StringBuilder();
        builder.AppendLine($"{Indent}constructor(value: any = null) {{");
        if (model.Parent != null)
        {
            var hasCtorArguments = model.Parent.GenerateConstructor ? "value" : string.Empty;
            builder.AppendLine(Indent + Indent + $"super({hasCtorArguments});");
            builder.AppendLine();
        }

        // Skip properties without a setter.
        foreach (var prop in model.Properties.Where(x => !x.Readonly))
        {
            var name = ApplyCasingStyle(prop.Name);
            builder.AppendLine($"{Indent + Indent}if (value?.hasOwnProperty('{name}'))");
            builder.AppendLine($"{Indent + Indent + Indent}this.{name} = value.{name};");
            builder.AppendLine();
        }

        builder.Append(Indent + "}");
        return builder.ToString();
    }

    private static string FormatClassName(ClassDescriptor descriptor)
    {
        if (!descriptor.GenericParameterNames.Any())
            return descriptor.Name;

        var genericTypeArgs = $"<{descriptor.GenericParameterNames.Glue(", ")}>";
        return $"{descriptor.Name}{genericTypeArgs}";
    }

    internal string ToTypeScriptEnum(EnumDescriptor descriptor)
    {
        var builder = new StringBuilder();
        builder.AppendLine($"export enum {descriptor.Name} {{");
        var lastKey = descriptor.Values.Last().Key;
        foreach (var kvp in descriptor.Values)
        {
            var value = $"{Indent}{kvp.Key} = {kvp.Value}";
            if (lastKey != kvp.Key)
                value += ",";

            builder.AppendLine(value);
        }

        builder.AppendLine("}");

        return builder.ToString();
    }

    internal string ToTypeScriptClass(ClassDescriptor model)
    {
        var className = FormatClassName(model);
        var properties = model.GetProperties(true).ToList();

        var summary = XmlDocument == null
            ? string.Empty
            : XmlDocument.JsDocClassSummary(model) + "\n";
        var parentClass = model.Parent == null ? string.Empty : $" extends {model.Parent.Name}";
        var @override = model.Parent != null ? "override " : string.Empty;
        var propertyDeclaration = CreatePropertyDeclaration(properties);
        var constructorDeclaration = CreateConstructorDeclaration(model);
        var template =
            $@"{summary}export class {className}{parentClass} {{
{propertyDeclaration}
{constructorDeclaration}
}}
";

        return template;
    }
}