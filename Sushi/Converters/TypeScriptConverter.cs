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

        yield return string.Empty;

        foreach (var model in EnumModels)
            yield return ToTypeScriptEnum(model);

        foreach (var model in descriptors)
            yield return ToTypeScriptClass(model);
    }

    internal void ConvertProperty(StringBuilder builder, ClassDescriptor classDescriptor, IPropertyDescriptor property)
    {
        var scriptType = ResolveScriptType(property.Type, string.Empty, property.IsNullable);
        if (property.Type.IsGenericParameter && !classDescriptor.GenericParameterNames.Contains(scriptType))
            throw new InvalidOperationException($"Generic parameter {scriptType} not resolved.");

        var defaultValue = ResolveDefaultValue(property);

        var name = ApplyCasingStyle(property.Name);
        var nameSuffix = defaultValue.IsEmpty() ? "!" : string.Empty;
        
        var @override = classDescriptor.IsPropertyInherited(property.Name) ? "override " : string.Empty;
        
        var readonlyPrefix = property is { Readonly: true, DefaultValue: not null } ? "readonly " : string.Empty;
        var staticPrefix = property.IsStatic ? "static " : string.Empty;

        var modifiers = $"{staticPrefix}{@override}{readonlyPrefix}";
        var valueSuffix = defaultValue.IsEmpty() ? string.Empty : $" = {defaultValue}";

        builder.AppendJsDoc(XmlDocument, property, Indent, scriptType);
        builder.Append($"{Indent}{modifiers}{name}{nameSuffix}: {scriptType}{valueSuffix};");
    }

    public string ResolveScriptType(Type type, string prefix = "", bool isNullable = false)
    {
        // Check if any of the available models have the same name and should be used.
        var classModel =
            Models.SingleOrDefault(x => x.Type == (type.IsGenericType ? type.GetGenericTypeDefinition() : type));

        var genericTypeArgs = type.IsGenericType
            ? GetGenericTypeArguments(type, prefix, isNullable).ToList()
            : new List<string>();
        if (classModel != null)
        {
            var className = type.IsGenericType
                ? $"{prefix}{classModel.Name}<{string.Join(", ", genericTypeArgs)}>"
                : prefix + classModel.Name;

            return isNullable ? $"{className} | null" : className;
        }

        if (type.IsGenericParameter)
            return type.Name;

        // Array
        var actualType = type.GetBaseType();
        var isDictionary = type.IsDictionary();
        if (type.IsArrayType() && !isDictionary)
        {
            var typeName = type.IsGenericType
                ? string.Join(", ", genericTypeArgs)
                : ResolveScriptType(actualType, prefix, isNullable);
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
        return isNullable ? $"{scriptType} | null" : scriptType;
    }

    public string ResolveDefaultValue(IPropertyDescriptor prop)
    {
        if (prop.Type.IsGenericParameter)
            return string.Empty;
        
        if (prop.Type?.IsArrayType() ?? false)
            return "[]";

        var isNullableString = prop.Type == typeof(string) && prop.DefaultValue == null;
        if (prop.IsNullable || isNullableString)
            return "null";

        if (prop.DefaultValue != null)
        {
            var defaultValueType = prop.DefaultValue.GetType();
            var descriptor = Models.SingleOrDefault(x => x.Type == defaultValueType && x.HasParameterlessCtor);
            if (descriptor != null)
                return $"new {descriptor.Name}()";

            if (defaultValueType.IsClass && defaultValueType != typeof(string))
                return defaultValueType.IsDictionary() ? "{}" : string.Empty;
        }

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
                if (prop.DefaultValue == null)
                    return string.Empty;

                var asDecimal = Convert.ToDecimal(prop.DefaultValue).ToString(CultureInfo.InvariantCulture);
                return asDecimal.Substring(0, Math.Min(asDecimal.Length, 15));
            }
            case NativeType.Char:
            case NativeType.String:
                return $"\"{prop.DefaultValue}\"";
            case NativeType.Null:
                return "null";
            case NativeType.Object:
            case NativeType.Undefined:
            default:
                return string.Empty;
        }
    }

    internal IEnumerable<string> GetGenericTypeArguments(Type type, string prefix, bool isNullable)
    {
        if (!type.IsGenericType)
            throw new ArgumentException("Expected given type to be generic.");

        var genericTypeArgs = type.GenericTypeArguments
            .Select(x => x.IsGenericParameter ? x.Name : ResolveScriptType(x, prefix, isNullable));
        return genericTypeArgs;
    }

    internal string CreatePropertyDeclaration(ClassDescriptor classDescriptor,
        IEnumerable<IPropertyDescriptor> properties)
    {
        var builder = new StringBuilder();
        foreach (var prop in properties)
        {
            ConvertProperty(builder, classDescriptor, prop);
            builder.AppendLine();
        }

        return builder.ToString();
    }

    public string CreateConstructorDeclaration(string className, ClassDescriptor model)
    {
        if (!model.GenerateConstructor)
            return string.Empty;

        var builder = new StringBuilder();
        builder.AppendLine($"{Indent}constructor(value: Partial<{className}> = {{}}) {{");
        if (model.Parent != null)
        {
            var hasCtorArguments = model.HasParameterizedSuperConstructor() ? "value" : string.Empty;
            builder.AppendLine(Indent + Indent + $"super({hasCtorArguments});");
            builder.AppendLine();
        }

        // Skip properties without a setter.
        foreach (var prop in model.Properties.Select(x=>x.Value).Where(x => !x.Readonly))
        {
            var name = ApplyCasingStyle(prop.Name);
            builder.AppendLine($"{Indent + Indent}if (value.{name} !== undefined) this.{name} = value.{name};");
        }

        builder.Append(Indent + "}");
        return builder.ToString();
    }

    private static string FormatClassName(ClassDescriptor descriptor)
    {
        if (!descriptor.GenericParameterNames.Any())
            return descriptor.Name;

        var genericTypeArgs = $"<{string.Join(", ", descriptor.GenericParameterNames)}>";
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
        var properties = model.GetProperties().ToList();

        var builder = new StringBuilder();
        builder.AppendJsDoc(XmlDocument, model);

        var parentClass = model.Parent == null ? string.Empty : $" extends {model.Parent.Name}";
        var propertyDeclaration = CreatePropertyDeclaration(model, properties);
        var constructorDeclaration = CreateConstructorDeclaration(className, model);
        builder.AppendLine($"export class {className}{parentClass} {{");
        builder.AppendLine(propertyDeclaration);
        builder.AppendLine(constructorDeclaration);
        builder.AppendLine("}");

        return builder.ToString();
    }
}