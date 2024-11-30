namespace Sushi.Interfaces;

public interface ITypeConverter
{
    public Type Type { get; }
    public string Value { get; }
    public string ToScriptType();
}