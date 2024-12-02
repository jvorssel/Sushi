using System.Text;
using Sushi.Descriptors;
using Sushi.Documentation;
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
    public TypeScriptConverter(SushiConverter converter, IConverterConfig config) : base(converter, config)
    {
    }

    /// <inheritdoc />
    protected override IEnumerable<string> ConvertToScript(IEnumerable<ClassDescriptor> descriptors)
    {
        foreach (var line in Config.Headers)
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
        if (string.IsNullOrWhiteSpace(defaultValue))
            name += "!";

        var readonlyPrefix = property is { Readonly: true, DefaultValue: not null } ? "readonly " : string.Empty;
        var staticPrefix = property.IsStatic ? "static " : string.Empty;
        var overridePrefix = classDescriptor.IsPropertyInherited(property.Name) ? "override " : string.Empty;
        var valueSuffix = string.IsNullOrWhiteSpace(defaultValue) ? string.Empty : $" = {defaultValue}";

        builder.AppendJsDoc(XmlDocument, property, Config.Indent, scriptType);
        builder.Append(
            $"{Config.Indent}{staticPrefix}{overridePrefix}{readonlyPrefix}{name}: {scriptType}{valueSuffix};");
    }

    public string ResolveScriptType(Type type, string prefix = "", bool isNullable = false)
    {
        // Check if any of the available models have the same name and should be used.
        var baseType = type.IsGenericType ? type.GetGenericTypeDefinition() : type;
        var genericTypeArgs = type.IsGenericType
            ? GetGenericTypeArguments(type, prefix, isNullable).ToList()
            : new List<string>();

        var genericArguments = string.Join(", ", genericTypeArgs);
        if (type.IsGenericParameter)
            return type.Name;

        string typeName;
        var inheritsNullable = false;
        var actualType = type.GetBaseType(deep: false)!;
        var isDictionaryType = type.IsDictionary();
        var enumModel = EnumModels.SingleOrDefault(x => x.Name == actualType.Name);
        var classModel = Models.SingleOrDefault(x => x.Type == baseType);

        if (classModel != null)
        {
            typeName = prefix + Config.ValueResolver.GetClassType(classModel, genericArguments);
            inheritsNullable = true;
        }
        else if (type.IsArrayType() && !isDictionaryType)
        {
            var arrayTypeArguments = type.IsGenericType
                ? genericArguments
                : ResolveScriptType(actualType, prefix, isNullable);
            typeName = Config.ValueResolver.GetArrayType(arrayTypeArguments);
            inheritsNullable = true;
        }
        else if (isDictionaryType && genericTypeArgs.Count == 2)
        {
            typeName = Config.ValueResolver.GetDictionaryType(genericTypeArgs);
        }
        else if (type.IsEnum && enumModel != null)
        {
            typeName = Config.ValueResolver.GetEnumType(enumModel);
        }
        else if (type.IsDateType())
        {
            typeName = Config.ValueResolver.GetDateType();
        }
        else
        {
            typeName = Config.ValueResolver.GetSimpleType(actualType);
        }

        return typeName + (isNullable && !inheritsNullable ? " | null" : string.Empty);
    }

    public string ResolveDefaultValue(IPropertyDescriptor prop)
    {
        if (prop.Type.IsGenericParameter)
            return string.Empty;

        if (prop.Type.IsArrayType())
            return Config.DefaultValueResolver.GetArrayValue(prop);

        var isNullableString = prop.Type == typeof(string);
        if ((prop.IsNullable || isNullableString) && prop.DefaultValue == null)
            return Config.DefaultValueResolver.GetNull();

        if (prop.DefaultValue != null)
        {
            var defaultValueType = prop.DefaultValue.GetType();
            var descriptor = Models.SingleOrDefault(x => x.Type == defaultValueType && x.HasParameterlessCtor);
            var defaultValue = Config.DefaultValueResolver.GetClassValue(prop, descriptor);
            if (!string.IsNullOrWhiteSpace(defaultValue))
                return defaultValue;
        }

        if (prop.Type.IsBooleanType())
            return Config.DefaultValueResolver.GetBooleanValue(prop);

        if (prop.Type.IsNumericType())
            return Config.DefaultValueResolver.GetNumericValue(prop);

        if (prop.Type.IsStringType())
            return Config.DefaultValueResolver.GetStringValue(prop);

        if (prop.Type.IsDateType())
            return Config.DefaultValueResolver.GetDateValue(prop);

        return Config.DefaultValueResolver.GetNullOrEmptyValue(prop);
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
        var i = Config.Indent;
        builder.AppendLine($"{i}constructor(value: Partial<{className}> = {{}}) {{");
        if (model.Parent != null)
        {
            builder.AppendLine(i + i +
                               (model.HasParameterizedSuperConstructor() ? "super(value);" : "super();"));
            builder.AppendLine();
        }

        // Skip properties without a setter.
        var properties = model.Properties
            .Select(x => x.Value)
            .Where(x => !x.Readonly)
            .ToList();

        foreach (var name in properties.Select(prop => ApplyCasingStyle(prop.Name)))
            builder.AppendLine($"{i + i}if (value.{name} !== undefined) this.{name} = value.{name};");

        builder.Append(i + "}");
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
            var value = $"{Config.Indent}{kvp.Key} = {kvp.Value}";
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