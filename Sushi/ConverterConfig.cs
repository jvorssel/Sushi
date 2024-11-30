using Sushi.Enum;
using Sushi.Interfaces;

namespace Sushi;

public class ConverterConfig : IConverterConfig
{
    /// <inheritdoc />
    public string Indent { get; set; }

    /// <inheritdoc />
    public PropertyNameCasing CasingStyle { get; }

    /// <inheritdoc />
    public List<string> Headers { get; } = new();

    public Dictionary<Type, ITypeConverter> TypeConverters { get; set; } = new();

    public ConverterConfig(string indent = "    ",
        PropertyNameCasing casing = PropertyNameCasing.CamelCase)
    {
        Indent = indent;
        CasingStyle = casing;
    }
}