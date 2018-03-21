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
        public static TypeScriptType ToTypeScriptType(this CSharpNativeType @this)
        {
            switch (@this)
            {
                case CSharpNativeType.Undefined:
                    return TypeScriptType.Undefined;
                case CSharpNativeType.Bool:
                    return TypeScriptType.Boolean;
                case CSharpNativeType.String:
                case CSharpNativeType.Char:
                    return TypeScriptType.String;
                case CSharpNativeType.Byte:
                case CSharpNativeType.Decimal:
                case CSharpNativeType.Double:
                case CSharpNativeType.Float:
                case CSharpNativeType.Int:
                case CSharpNativeType.Long:
                case CSharpNativeType.Short:
                    return TypeScriptType.Number;
                case CSharpNativeType.Object:
                    return TypeScriptType.Object;
                case CSharpNativeType.Null:
                    return TypeScriptType.Null;
                case CSharpNativeType.Enum:
                    return TypeScriptType.Enum;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@this), @this, null);
            }
        }
    }
}
