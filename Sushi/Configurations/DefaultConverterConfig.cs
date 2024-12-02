using Sushi.DefaultTypeResolver;
using Sushi.Enum;
using Sushi.Interfaces;

namespace Sushi.Configurations;

public class DefaultConverterConfig : IConverterConfig
{
    public string Indent { get; set; } = "    ";
    public PropertyNameCasing CasingStyle { get; set; } = PropertyNameCasing.CamelCase;
    public List<string> Headers { get; set; } = new();

    public IDefaultValueMap DefaultValueMap { get; set; } = new DefaultValueMap();
    public ITypeMap TypeMap { get; set; } = new DefaultTypeMap();
    public bool Strict { get; set; } = true;
}