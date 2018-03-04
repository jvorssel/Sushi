using System;
using Common.Utility.Enum;

namespace Common.Utility
{
    public static class TypeConversionHelper
    {
        /// <summary>
        ///     Convert the given <paramref name="type"/> to its corresponding <see cref="CSharpNativeType"/>.
        /// </summary>
        public static CSharpNativeType ToCSharpNativeType(this Type type)
        {
            if (type == null)
                return CSharpNativeType.Undefined;

            if (type == typeof(bool))
                return CSharpNativeType.Bool;

            if (type == typeof(byte))
                return CSharpNativeType.Byte;

            if (type == typeof(short))
                return CSharpNativeType.Short;

            if (type == typeof(long))
                return CSharpNativeType.Long;

            if (type == typeof(int))
                return CSharpNativeType.Int;

            if (type == typeof(float))
                return CSharpNativeType.Float;

            if (type == typeof(double))
                return CSharpNativeType.Double;

            if (type == typeof(decimal))
                return CSharpNativeType.Decimal;

            if (type == typeof(string))
                return CSharpNativeType.String;

            if (type == typeof(char))
                return CSharpNativeType.Char;

            // Null value already defined above, use Object as default.
            return CSharpNativeType.Object;
        }
    }
}