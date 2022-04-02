using System;
using System.Collections.Generic;
using Sushi.Enum;

namespace Sushi.Helpers
{
    public static class TypeConversionHelper
    {
        /// <summary>
        ///     Convert the given <paramref name="type"/> to its corresponding <see cref="NativeType"/>.
        /// </summary>
        public static NativeType ToNativeTypeEnum(this Type type)
        {
            if (type == null)
                return NativeType.Undefined;

            if (type == typeof(bool))
                return NativeType.Bool;

            if (type == typeof(byte))
                return NativeType.Byte;

            if (type == typeof(short))
                return NativeType.Short;

            if (type == typeof(long))
                return NativeType.Long;

            if (type == typeof(int))
                return NativeType.Int;

            if (type == typeof(float))
                return NativeType.Float;

            if (type == typeof(double))
                return NativeType.Double;

            if (type == typeof(decimal))
                return NativeType.Decimal;

            if (type == typeof(string) || type == typeof(Guid))
                return NativeType.String;

            if (type == typeof(char))
                return NativeType.Char;

            if (type == typeof(System.Enum) || type.BaseType == typeof(System.Enum))
                return NativeType.Enum;

            
            // Null value already defined above, use Object as default.
            return NativeType.Object;
        }
    }
}