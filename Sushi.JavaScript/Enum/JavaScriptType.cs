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
        ///     Convert given <see cref="NativeType"/> to its corresponding <see cref="JavaScriptType"/>.
        /// </summary>
        public static JavaScriptType ToJavaScriptType(this NativeType type)
        {
            switch (type)
            {
                case NativeType.Bool:
                    return JavaScriptType.Boolean;
                case NativeType.Short:
                case NativeType.Long:
                case NativeType.Int:
                case NativeType.Float:
                case NativeType.Double: // TODO Create a default base-model for showing a decimal correctly.
                case NativeType.Decimal:
                case NativeType.Byte:
                case NativeType.Enum:
                    return JavaScriptType.Number;
                case NativeType.String:
                case NativeType.Char:
                    return JavaScriptType.String;
                case NativeType.Object:
                    return JavaScriptType.Object;
                case NativeType.Undefined:
                    return JavaScriptType.Undefined;
                case NativeType.Null:
                    return JavaScriptType.Null;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
