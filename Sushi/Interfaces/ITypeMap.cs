using Sushi.Descriptors;

namespace Sushi.Interfaces;

/// <summary>
///     Get the script type.
/// </summary>
public interface ITypeMap
{
    public string GetClassType(ClassDescriptor classDescriptor, string genericArguments);
    public string GetArrayType(string genericArguments);
    public string GetDictionaryType(IList<string> genericArguments);
    public string GetEnumType(EnumDescriptor enumDescriptor);
    public string GetSimpleType(Type type);
    public string GetDateType();
}