namespace Sushi.Extensions;

internal static class TypeExtensions
{
    /// <summary>
    /// Checks if the type is numeric.
    /// </summary>
    internal static bool IsNumericType(this Type? type)
    {
        if (type == null) return false;

        var nonNullableType = Nullable.GetUnderlyingType(type) ?? type;

        // Process enum values as numbers.
        if (nonNullableType.BaseType == typeof(System.Enum) || nonNullableType.IsEnum)
            return true;

        return nonNullableType == typeof(byte) || nonNullableType == typeof(sbyte) ||
               nonNullableType == typeof(short) || nonNullableType == typeof(ushort) ||
               nonNullableType == typeof(int) || nonNullableType == typeof(uint) ||
               nonNullableType == typeof(long) || nonNullableType == typeof(ulong) ||
               nonNullableType == typeof(float) || nonNullableType == typeof(double) ||
               nonNullableType == typeof(decimal);
    }

    /// <summary>
    /// Checks if the type is a boolean.
    /// </summary>
    internal static bool IsBooleanType(this Type? type)
    {
        if (type == null) return false;

        var nonNullableType = Nullable.GetUnderlyingType(type) ?? type;
        return nonNullableType == typeof(bool);
    }

    /// <summary>
    /// Checks if the type is a string.
    /// </summary>
    internal static bool IsStringType(this Type type)
    {
        return type == typeof(string) || type == typeof(Guid);
    }

    /// <summary>
    /// Checks if the type is a date or time type.
    /// </summary>
    internal static bool IsDateType(this Type? type)
    {
        if (type == null) return false;

        var nonNullableType = Nullable.GetUnderlyingType(type) ?? type;
        return nonNullableType == typeof(DateTime) || nonNullableType == typeof(DateTimeOffset);
    }
}