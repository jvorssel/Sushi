using System;

namespace Sushi.Documentation.Models
{
    public enum FieldType
    {
        /// <summary>
        ///     Member redirects to a specific <see cref="Type"/> (T).
        /// </summary>
        Type,

        /// <summary>
        ///     Member redirects to a specific <see cref="Property"/> (P).
        /// </summary>
        Property
    }

    public static class SummaryFieldTypeExtensions
    {
        public static FieldType GetFieldType(this string specifier)
        {
            switch (specifier)
            {
                case "T":
                    return FieldType.Type;
                case "P":
                    return FieldType.Property;
                default:
                    throw new ArgumentOutOfRangeException(nameof(specifier));
            }
        }
    }
}