using Sushi.Descriptors;
using Sushi.Extensions;

namespace Sushi.DefaultTypeResolver;

public class TypeMap
{
    public virtual string GetClassType(ClassDescriptor classDescriptor, string genericArguments)
    {
        return classDescriptor.Type.IsGenericType
            ? $"{classDescriptor.Name}<{genericArguments}>"
            : classDescriptor.Name;
    }

    public virtual string GetArrayType(string genericArguments)
    {
        return $"Array<{genericArguments}>";
    }

    public virtual string GetDictionaryType(IList<string> genericArguments)
    {
        var keyType = genericArguments[0];
        var valueType = genericArguments[1];

        // Only allow string/numeric key types
        return keyType is "string" or "number"
            ? $"{{ [key: string]: {valueType} }}"
            : "any";
    }

    public virtual string GetEnumType(EnumDescriptor enumDescriptor)
    {
        return $"{enumDescriptor.Name} | number";
    }

    public virtual string GetSimpleType(Type type)
    {
        return type.IsNumericType() ? "number" :
            type.IsStringType() ? "string" :
            type.IsBooleanType() ? "boolean" : "any";
    }

    public string GetDateType()
    {
        return "string";
    }
}