namespace Sushi.Documentation;

public enum ReferenceType
{
    /// <summary>
    ///     <see cref="Undefined"/> field type
    /// </summary>
    Undefined = 0,

    /// <summary>
    ///     Member redirects to a specific <see cref="Type"/> (T).
    /// </summary>
    Type = 1,

    /// <summary>
    ///     Member redirects to a specific <see cref="Property"/> (P).
    /// </summary>
    Property = 2,

    /// <summary>
    ///     Member redirects to a specific <see cref="Method"/> (M).
    /// </summary>
    Method = 3,

    /// <summary>
    ///		References namespace.
    /// </summary>
    Namespace = 4,

    /// <summary>
    ///		References field.
    /// </summary>
    Field = 5,

    /// <summary>
    ///		Event property.
    /// </summary>
    Event = 6,

    /// <summary>
    ///		References an Error.
    /// </summary>
    Error = 7
}

public static class ReferenceTypeExtensions
{
    /// <summary>
    ///		What <see cref="ReferenceType"/> belongs to the given <paramref name="specifier"/>.
    /// </summary>
    public static ReferenceType GetFieldType(this string specifier)
    {
        return specifier switch
        {
            "N" => ReferenceType.Namespace,
            "T" => ReferenceType.Type,
            "F" => ReferenceType.Field,
            "P" => ReferenceType.Property,
            "M" => ReferenceType.Method,
            "E" => ReferenceType.Event,
            "!" => ReferenceType.Error,
            _ => ReferenceType.Undefined
        };
    }
}