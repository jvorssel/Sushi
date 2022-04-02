using System;
using System.Linq;
using Sushi.Descriptors;
using Sushi.Enum;
using Sushi.Interfaces;
using Sushi.JavaScript.Enum;

namespace Sushi.JavaScript
{
    /// <inheritdoc />
    public sealed class JavaScriptConditions : IConditionSpecification
    {
        public const string IS_DEFINED_STATEMENT = @"{0} !== void 0 && {0} !== null";
        public const string IS_UNDEFINED_STATEMENT = @"{0} === void 0 || {0} === null";
        public const string IS_PROPERTY_DEFINED_STATEMENT = @"{0}.{1} !== void 0 && {0}.{1} !== null";

        #region Overrides of StatementPipeline

        /// <inheritdoc />
        public ScriptConditionDescriptor CreateDefinedCheck(Converter converter, IPropertyDescriptor descriptor)
        {
            var statement = string.Format(IS_PROPERTY_DEFINED_STATEMENT, converter.ArgumentName, descriptor.Name);
            return new ScriptConditionDescriptor(statement, ConditionType.Type);
        }
        
        /// <inheritdoc />
        public ScriptConditionDescriptor ArgumentUndefinedCheck(Converter converter)
        {
            var statement = string.Format(IS_UNDEFINED_STATEMENT, converter.ArgumentName);
            return new ScriptConditionDescriptor(statement, ConditionType.Type);
        }

        /// <inheritdoc />
        public ScriptConditionDescriptor ArgumentDefinedCheck(Converter converter)
        {
            var statement = string.Format(IS_DEFINED_STATEMENT, converter.ArgumentName);
            return new ScriptConditionDescriptor(statement, ConditionType.Type);
        }

        /// <inheritdoc />
        public ScriptConditionDescriptor CreateKeyExistsCheck(Converter converter, IPropertyDescriptor descriptor)
        {
            var doesKeyExistStatement = $"if (!{converter.ArgumentName}.hasOwnProperty('{descriptor.Name}')) throw new TypeError(\"{string.Format(converter.ObjectPropertyMissing, descriptor.Name)}\");";

            return new ScriptConditionDescriptor(doesKeyExistStatement, ConditionType.Key);
        }

        /// <inheritdoc />
        public ScriptConditionDescriptor CreateInstanceCheck(Converter converter, IPropertyDescriptor descriptor)
        {
            var instanceCheck = $"if ({CreateDefinedCheck(converter, descriptor)} && !{{1}}.tryParse({converter.ArgumentName}.{{0}})) throw new TypeError(\"{converter.PropertyInstanceMismatch}\");";

            var script = string.Empty;
            var scriptType = descriptor.NativeType
                .IncludeOverride(converter, descriptor.Type)
                .ToJavaScriptType();

            switch (scriptType)
            {
                case JavaScriptType.Undefined:
                case JavaScriptType.Null:
                case JavaScriptType.Boolean:
                case JavaScriptType.Number:
                case JavaScriptType.String:
                    break;
                case JavaScriptType.Date:
                    script = string.Format(instanceCheck, descriptor.Name, "Date");
                    break;
                case JavaScriptType.RegExp:
                    script = string.Format(instanceCheck, descriptor.Name, "Regexp");
                    break;
                case JavaScriptType.Array:
                    script = string.Format(instanceCheck, descriptor.Name, "Array");
                    break;
                case JavaScriptType.Object:
                    var propertyWithName = converter.Models.FirstOrDefault(x => x.FullName == descriptor.Type.FullName);
                    if (!ReferenceEquals(propertyWithName, null))
                        script = string.Format(instanceCheck, descriptor.Name, propertyWithName.Name);

                    break;
                case JavaScriptType.Decimal:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return new ScriptConditionDescriptor(script, ConditionType.Instance);
        }

        /// <inheritdoc />
        public ScriptConditionDescriptor CreateTypeCheck(Converter converter, IPropertyDescriptor descriptor)
        {
            var typeCheck = $"if (typeof {converter.ArgumentName}.{{0}} !== '{{1}}') throw new TypeError(\"{converter.PropertyTypeMismatch}\");";

            var script = string.Empty;
            var scriptType = descriptor.NativeType
                .IncludeOverride(converter, descriptor.Type)
                .ToJavaScriptType();

            switch (scriptType)
            {
                case JavaScriptType.Undefined:
                case JavaScriptType.Null:
                    break;
                case JavaScriptType.Boolean:
                    script = string.Format(typeCheck, descriptor.Name, "boolean");
                    break;
                case JavaScriptType.Number:
                    script = string.Format(typeCheck, descriptor.Name, "number");
                    break;
                case JavaScriptType.String:
                    script = string.Format(typeCheck, descriptor.Name, "string");
                    break;
                case JavaScriptType.Decimal:
                case JavaScriptType.Date:
                case JavaScriptType.RegExp:
                case JavaScriptType.Array:
                case JavaScriptType.Object:
                    script = string.Format(typeCheck, descriptor.Name, descriptor.Type == typeof(Guid) ? "string" : "object");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return new ScriptConditionDescriptor(script, ConditionType.Type);
        }

        #endregion
    }
}