using Sushi.Extensions;
using Sushi.Interfaces;

namespace Sushi;

public static class SushiExtensions
{
    /// <summary>
    ///     If the given <paramref name="type" /> is discovered by the <see cref="IConvertModels" />.
    /// </summary>
    public static bool IsSushiType(this IConvertModels converter, Type? type, out Type? resolvedType)
    {
        if (type is null)
            throw new ArgumentNullException(nameof(type));

        var classType = type.GetBaseType(converter.Models);
        var enumType = type.GetBaseType(converter.EnumModels);
        resolvedType = classType ?? enumType;
        
        return resolvedType is not null;
    }
}