using System;
using System.Collections;
using System.Collections.Generic;
using Sushi.Enum;
using Sushi.Extensions;
using Sushi.Interfaces;

namespace Sushi.Javascript
{
    public class JavaScriptSpecification : ILanguageSpecification
    {
        #region Overrides of LanguageSpecification

        /// <inheritdoc />
        public virtual string Extension => ".js";

        /// <inheritdoc />
        public virtual IEnumerable<string> FormatProperty(SushiConverter converter, IPropertyDescriptor descriptor)
        {
            // Specify the body of the property declaration.
            var propertySpec = GetDefaultForProperty(converter, descriptor);
            yield return $"this.{descriptor.Name} = {propertySpec};";
        }

        /// <inheritdoc />
        public virtual string GetDefaultForProperty(SushiConverter converter, IPropertyDescriptor descriptor)
        {
            var type = Nullable.GetUnderlyingType(descriptor.Type) ?? descriptor.Type;
            if (type == typeof(DateTime))
                return "new Date(\"0001-01-01T00:00:00.000Z\")"; // Default date value should be 0001-01-01

            // Always return null if the given property is nullable.
            if (descriptor.IsNullable)
                return "null";

            // Check if a different type is supposed to be used.
            var csType = descriptor.NativeType.IncludeOverride(converter, type);

            // A string also inherits the IEnumerable interface, exclude.
            if (type.IsTypeOrInheritsOf(typeof(IEnumerable)) && type != typeof(string))
                return "[]";

            // Check the native type with certain exceptions.
            switch (csType)
            {
                case NativeType.Undefined:
                    return "void 0";
                case NativeType.Bool:
                    return "false";
                case NativeType.Byte:
                case NativeType.Decimal:
                case NativeType.Double:
                case NativeType.Float:
                case NativeType.Int:
                case NativeType.Long:
                case NativeType.Short:
                    return "-1";
                case NativeType.Char:
                case NativeType.String:
                    return "''";
                case NativeType.Enum:
                    return "0";
                default:
                case NativeType.Null:
                case NativeType.Object:
                    return "null";
            }
        }

        #endregion

        /// <inheritdoc />
        public JavaScriptSpecification()
        {
        }
    }
}