using System;
using Common.Utility.Enum;
using Common.Utility.Enum.ECMAScript;

namespace Common.Utility {
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
    }
}