using System;

namespace Sushi.Documentation.Models
{
    public enum FieldType
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
        Method = 3
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
                    return FieldType.Undefined;
            }
        }
    }
}