using System.Globalization;
using System.Text;
using Sushi.Descriptors;
using Sushi.Documentation;
using Sushi.Enum;
using Sushi.Extensions;
using Sushi.Helpers;
using Sushi.Interfaces;

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


        var name = ApplyCasingStyle(property.Name);
        var defaultValue = ResolveDefaultValue(property);
        if (defaultValue.IsEmpty())
            name += "!";
        
        var readonlyPrefix = property is { Readonly: true, DefaultValue: not null } ? "readonly " : string.Empty;
        var staticPrefix = property.IsStatic ? "static " : string.Empty;
        var overridePrefix = classDescriptor.IsPropertyInherited(property.Name) ? "override " : string.Empty;
        var valueSuffix = defaultValue.IsEmpty() ? string.Empty : $" = {defaultValue}";

        builder.AppendJsDoc(XmlDocument, property, Indent, scriptType);
        builder.Append($"{Indent}{staticPrefix}{overridePrefix}{readonlyPrefix}{name}: {scriptType}{valueSuffix};");
    }

    public string ResolveScriptType(Type type, string prefix = "", bool isNullable = false)
    {
        // Check if any of the available models have the same name and should be used.
        var baseType = type.IsGenericType ? type.GetGenericTypeDefinition() : type;
        var genericTypeArgs = type.IsGenericType
            ? GetGenericTypeArguments(type, prefix, isNullable).ToList()
            : new List<string>();

        var classModel = Models.SingleOrDefault(x => x.Type == baseType);
        if (classModel != null)
        {
            var className = type.IsGenericType
                ? $"{prefix}{classModel.Name}<{string.Join(", ", genericTypeArgs)}>"
                : $"{prefix}{classModel.Name}";
            return isNullable ? $"{className} | null" : className;
        }

        if (type.IsGenericParameter)
            return type.Name;

        // Array
        var actualType = type.GetBaseType(deep: false)!;
        var isDictionaryType = type.IsDictionary();
        if (type.IsArrayType() && !isDictionaryType)
        {
            var typeName = type.IsGenericType
                ? string.Join(", ", genericTypeArgs)
                : ResolveScriptType(actualType, prefix, isNullable);
            return $"Array<{typeName}>";
        }

        if (isDictionaryType && genericTypeArgs.Count == 2)
        {
            var keyType = genericTypeArgs[0];
            var valueType = genericTypeArgs[1];

            // Only allow string/numeric key types
            return keyType == NativeType.String.ToScriptType() || keyType == NativeType.Int.ToScriptType()
                ? $"{{ [key: string]: {valueType} }}"
                : "any";
        }

        var enumModel = EnumModels.SingleOrDefault(x => x.Name == actualType.Name);
        if (type.IsEnum && enumModel != null)
            return $"{prefix}{enumModel.Name} | number";

        // Date
        if (actualType == typeof(DateTime))
            return isNullable ? "string | null" : "string";

        var scriptType = actualType.ToNativeScriptType().ToScriptType();
        return isNullable ? $"{scriptType} | null" : scriptType;
    }

    public string ResolveDefaultValue(IPropertyDescriptor prop)
    {
        if (prop.Type.IsGenericParameter)
            return string.Empty;

        if (prop.Type.IsArrayType())
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

        return GetNativeTypeValue(prop);
    }

    private string GetNativeTypeValue(IPropertyDescriptor prop)
    {
        var nativeType = prop.Type.ToNativeScriptType();
        switch (nativeType)
        {
            case NativeType.Bool:
                return prop.DefaultValue as bool? ?? false ? "true" : "false";
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
                return asDecimal.Length > 15 ? asDecimal.Substring(0, 15) : asDecimal;
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

    private string CreatePropertyDeclaration(ClassDescriptor classDescriptor,
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

    private string CreateConstructorDeclaration(string className, ClassDescriptor model)
    {
        var builder = new StringBuilder();
        builder.AppendLine($"{Indent}constructor(value: Partial<{className}> = {{}}) {{");
        if (model.Parent != null)
        {
            builder.AppendLine(Indent + Indent +
                               (model.HasParameterizedSuperConstructor() ? "super(value);" : "super();"));
            builder.AppendLine();
        }

        // Skip properties without a setter.
        var properties = model.Properties
            .Select(x => x.Value)
            .Where(x => !x.Readonly)
            .ToList();

        foreach (var name in properties.Select(prop => ApplyCasingStyle(prop.Name)))
            builder.AppendLine($"{Indent + Indent}if (value.{name} !== undefined) this.{name} = value.{name};");

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

    private string ToTypeScriptEnum(EnumDescriptor descriptor)
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

    private string ToTypeScriptClass(ClassDescriptor model)
    {
        var className = FormatClassName(model);
        var properties = model.GetProperties().ToList();
        var parentClass = model.Parent == null ? string.Empty : $" extends {model.Parent.Name}";

        var builder = new StringBuilder();
        builder.AppendJsDoc(XmlDocument, model);
        builder.AppendLine($"export class {className}{parentClass} {{");

        // Add properties
        builder.AppendLine(CreatePropertyDeclaration(model, properties));

        // Add constructor if available
        if (model.GenerateConstructor)
            builder.AppendLine(CreateConstructorDeclaration(className, model));

        builder.AppendLine("}");
        return builder.ToString();
    }
}