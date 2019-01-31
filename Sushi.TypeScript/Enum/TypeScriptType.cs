using System;
using Sushi.Enum;

namespace Sushi.TypeScript.Enum
{
    /// <summary>
    ///     Enum for different base-types for TypeScript.
    /// </summary>
    public enum TypeScriptType
    {
        /// <summary>
        ///     Represents a TypeScript <see cref="Number" />.
        /// </summary>
        Number,

        /// <summary>
        ///     Represents a TypeScript <see cref="Boolean" />.
        /// </summary>
        Boolean,

        /// <summary>
        ///     Represents a TypeScript <see cref="Object" /> / any / class.
        /// </summary>
        Object,

        /// <summary>
        ///     Represents a TypeScript <see cref="Array" />.
        /// </summary>
        Array,

        /// <summary>
        ///     Represents a TypeScript <see cref="Enum" />.
        /// </summary>
        Enum,

        /// <summary>
        ///     Represents a TypeScript <see cref="String" />.
        /// </summary>
        String,

        /// <summary>
        ///     Represents a TypeScript <see cref="Undefined" />.
        /// </summary>
        Undefined,

        /// <summary>
        ///     Represents a TypeScript <see cref="Null" />.
        /// </summary>
        Null,

        /// <summary>
        ///     Represents a TypeScript <see cref="RegExp" />.
        /// </summary>
        RegExp
    }

    public static class TypeScriptTypeExtensions
    {
        public static TypeScriptType ToTypeScriptType(this NativeType @this)
        {
            switch (@this)
            {
                case NativeType.Undefined:
                    return TypeScriptType.Undefined;
                case NativeType.Bool:
                    return TypeScriptType.Boolean;
                case NativeType.String:
                case NativeType.Char:
                    return TypeScriptType.String;
                case NativeType.Byte:
                case NativeType.Decimal:
                case NativeType.Double:
                case NativeType.Float:
                case NativeType.Int:
                case NativeType.Long:
                case NativeType.Short:
                    return TypeScriptType.Number;
                case NativeType.Object:
                    return TypeScriptType.Object;
                case NativeType.Null:
                    return TypeScriptType.Null;
                case NativeType.Enum:
                    return TypeScriptType.Enum;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@this), @this, null);
            }
        }
    }
}
