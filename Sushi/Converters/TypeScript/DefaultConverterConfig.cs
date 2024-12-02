using Sushi.DefaultTypeResolver;
using Sushi.Enum;
using Sushi.Interfaces;

namespace Sushi.Converters.TypeScript;

public class DefaultConverterConfig : IConverterConfig
{
    public string Indent { get; set; } = "    ";
    public PropertyNameCasing CasingStyle { get; set; } = PropertyNameCasing.CamelCase;
    public List<string> Headers { get; set; } = new();

    public IDefaultValueResolver DefaultValueResolver { get; set; } = new DefaultValueResolver();
    public TypeMap ValueResolver { get; set; } = new();
    public bool Strict { get; set; } = true;
}