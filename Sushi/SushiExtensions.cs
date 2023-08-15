using Sushi.Extensions;
using Sushi.Interfaces;

namespace Sushi;

public static class SushiExtensions
{
    /// <summary>
    ///     If the given <paramref name="type" /> is discovered by the <see cref="IConvertModels" />.
    /// </summary>
    public static bool IsSushiType(this IConvertModels converter, Type type, out Type resolvedType)
    {
        var actualType = type.GetBaseType();
        resolvedType = actualType;

        var classExists = converter.Models.Any(x => x.Type == actualType);
        var enumExists = converter.EnumModels.Any(x => x.Type == actualType);
        return classExists || enumExists;
    }
}