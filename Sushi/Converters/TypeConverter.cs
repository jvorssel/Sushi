using Sushi.Interfaces;

namespace Sushi.Converters;

public class TypeConverter<T> : ITypeConverter
{
    public Type Type { get; } = typeof(T);
    public string Value { get; }

    public TypeConverter(string value)
    {
        Value = value;
    }

    public string ToScriptType()
    {
        return Value;
    }
}