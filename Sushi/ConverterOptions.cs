using Sushi.Enum;
using Sushi.Interfaces;

namespace Sushi;

public class ConverterOptions : IConverterOptions
{
    /// <inheritdoc />
    public string Indent { get; set; }

    /// <inheritdoc />
    public PropertyNameCasing CasingStyle { get; set; }

    /// <inheritdoc />
    public List<string> Headers { get; set; } = new();

    public ConverterOptions(string indent = "    ",
        PropertyNameCasing casing = PropertyNameCasing.CamelCase)
    {
        Indent = indent;
        CasingStyle = casing;
    }
}