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
        Property,

        /// <summary>
        ///     Member redirects to a specific <see cref="Method"/> (M).
        /// </summary>
        Method
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
                case "M":
                    return FieldType.Method;
                default:
                    throw new ArgumentOutOfRangeException(nameof(specifier));
            }
        }
    }
}