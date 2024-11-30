using System.Globalization;
using Sushi.Converters.TypeScript;
using Sushi.Interfaces;

namespace Sushi.Converters;

public static class TypeConverterExtensions
{
    public static ITypeConverter ThrowIfNull(this Dictionary<Type, ITypeConverter> dictionary, Type type)
    {
        var actualType = type.IsEnum ? typeof(System.Enum) : type;
        var exception = new NullReferenceException($"{actualType.FullName} type is unavailable.");
        if (!dictionary.TryGetValue(actualType, out var @null))
            throw exception;

        return @null ?? throw exception;
    }

    public static ITypeConverter AnyIfNull(this Dictionary<Type, ITypeConverter> dictionary, Type type)
    {
        return dictionary.TryGetValue(type, out var converter)
            ? converter
            : new TypeConverter<string>(type.IsEnum ? "number" : "any");
    }

    public static string GetDefaultValue(this ITypeConverter converter, IPropertyDescriptor prop)
    {
        switch (converter.Value)
        {
            case DefaultConverterConfig.Number:
            {
                if (prop.DefaultValue == null)
                    return string.Empty;

                var asDecimal = Convert.ToDecimal(prop.DefaultValue).ToString(CultureInfo.InvariantCulture);
                return asDecimal.Length > 15 ? asDecimal.Substring(0, 15) : asDecimal;
            }
            case DefaultConverterConfig.String:
                return $"\"{prop.DefaultValue}\"";
            case DefaultConverterConfig.Boolean:
                return prop.IsNullable ? "null" : prop.DefaultValue as bool? == true ? "true" : "false";
            default:
                return prop.IsNullable ? "null" : string.Empty;
        }
    }
}