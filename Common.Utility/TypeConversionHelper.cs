using System;
using Common.Utility.Enum;
using Common.Utility.Enum.ECMAScript;

namespace Common.Utility
{
    public static class TypeConversionHelper
    {
        /// <summary>
        ///     Convert given <see cref="CSharpNativeType"/> to its corresponding <see cref="JavaScriptType"/>.
        /// </summary>
        public static JavaScriptType ToJavaScriptType(this CSharpNativeType type)
        {
            switch (type)
            {
                case CSharpNativeType.Bool:
                    return JavaScriptType.Boolean;
                case CSharpNativeType.Short:
                case CSharpNativeType.Long:
                case CSharpNativeType.Int:
                case CSharpNativeType.Float:
                case CSharpNativeType.Double: // TODO Create a default base-model for showing a decimal correctly.
                case CSharpNativeType.Decimal:
                case CSharpNativeType.Byte:
                    return JavaScriptType.Number;
                case CSharpNativeType.String:
                case CSharpNativeType.Char:
                    return JavaScriptType.String;
                case CSharpNativeType.Object:
                    return JavaScriptType.Object;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

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