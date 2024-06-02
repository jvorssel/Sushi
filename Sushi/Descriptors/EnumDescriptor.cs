namespace Sushi.Descriptors;

public sealed class EnumDescriptor
{
    public Type Type { get; }
    public string Name => Type.Name;

    public readonly Dictionary<string, int> Values = new();

    public EnumDescriptor(Type type)
    {
        Type = type;
        if (!type.IsEnum)
            throw new ArgumentException($"Given {nameof(type)} must be an enum Type.");

        foreach (var name in System.Enum.GetNames(Type))
            Values[name] = (int)System.Enum.Parse(type, name);
    }
}