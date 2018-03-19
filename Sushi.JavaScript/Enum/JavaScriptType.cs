using System;
using Sushi.Enum;

namespace Sushi.JavaScript.Enum
{
    /// <summary>
    ///     What <see cref="JavaScriptType"/> is referenced in ECMA-script.
    /// </summary>
    public enum JavaScriptType
    {
        /// <summary>
        ///     Key or value has not been defined.
        /// </summary>
        Undefined = 1,

        /// <summary>
        ///     Instance of a <see cref="Null"/>.
        /// </summary>
        Null = 2,

        /// <summary>
        ///     Instance of a <see cref="Boolean"/> type.
        /// </summary>
        Boolean = 3,

        /// <summary>
        ///     Instance of a <see cref="Number"/> type.
        /// </summary>
        Number = 4,

        /// <summary>
        ///     Instance of a <see cref="String"/> type.
        /// </summary>
        String = 5,

        /// <summary>
        ///     Represents a <see cref="Date"/> type.
        /// </summary>
        Date = 6,

        /// <summary>
        ///     Represents a <see cref="RegExp"/> type.
        /// </summary>
        RegExp = 7,

        /// <summary>
        ///     Represents a Collection of different variables.
        /// </summary>
        Array = 8,

        /// <summary>
        ///     The base of every value is a <see cref="Object"/>.
        /// </summary>
        Object = 9,

        /// <summary>
        ///     Represents a <see cref="Decimal"/> type.
        /// </summary>
        Decimal = 10,
    }

    public static class JavaScriptTypeExtensions
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
                case CSharpNativeType.Enum:
                    return JavaScriptType.Number;
                case CSharpNativeType.String:
                case CSharpNativeType.Char:
                    return JavaScriptType.String;
                case CSharpNativeType.Object:
                    return JavaScriptType.Object;
                case CSharpNativeType.Undefined:
                    return JavaScriptType.Undefined;
                case CSharpNativeType.Null:
                    return JavaScriptType.Null;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
