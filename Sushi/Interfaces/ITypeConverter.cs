namespace Sushi.Interfaces;

public interface ITypeConverter
{
    Type Type { get; set; }
    string ToScriptType();
}