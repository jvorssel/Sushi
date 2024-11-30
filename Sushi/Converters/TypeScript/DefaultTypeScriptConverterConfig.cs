using Sushi.Enum;
using Sushi.Interfaces;

namespace Sushi.Converters.TypeScript;

public class DefaultTypeScriptConverterConfig : IConverterConfig
{
    public string Indent { get; } = "    ";
    public PropertyNameCasing CasingStyle { get; } = PropertyNameCasing.CamelCase;
    public List<string> Headers { get; } = new();
    public Dictionary<Type, ITypeConverter> TypeConverters { get; set; } = new();
}