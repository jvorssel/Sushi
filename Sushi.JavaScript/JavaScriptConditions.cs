using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Sushi.Descriptors;
using Sushi.Enum;
using Sushi.JavaScript.Enum;

namespace Sushi.JavaScript
{
    /// <inheritdoc />
    public sealed class JavaScriptConditions : ConditionPipeline
    {
        public const string IS_DEFINED_STATEMENT = @"{0} !== void 0 && {0} !== null";
        public const string IS_UNDEFINED_STATEMENT = @"{0} === void 0 || {0} === null";
        public const string IS_PROPERTY_DEFINED_STATEMENT = @"{0}.{1} !== void 0 && {0}.{1} !== null";
        public const string IS_PROPERTY_UNDEFINED_STATEMENT = @"{0}.{1} === void 0 || {0}.{1} === null";

        #region Overrides of StatementPipeline

        /// <inheritdoc />
        public override ScriptConditionDescriptor CreateUndefinedCheck(ConversionKernel kernel, PropertyDescriptor property)
        {
            var statement = string.Format(IS_PROPERTY_UNDEFINED_STATEMENT, kernel.ArgumentName, property.Name);
            return new ScriptConditionDescriptor(statement, ConditionType.Type);
        }

        /// <inheritdoc />
        public override ScriptConditionDescriptor CreateDefinedCheck(ConversionKernel kernel, PropertyDescriptor property)
        {
            var statement = string.Format(IS_PROPERTY_DEFINED_STATEMENT, kernel.ArgumentName, property.Name);
            return new ScriptConditionDescriptor(statement, ConditionType.Type);
        }

        /// <inheritdoc />
        public override ScriptConditionDescriptor ArgumentUndefinedCheck(ConversionKernel kernel)
        {
            var statement = string.Format(IS_UNDEFINED_STATEMENT, kernel.ArgumentName);
            return new ScriptConditionDescriptor(statement, ConditionType.Type);
        }

        /// <inheritdoc />
        public override ScriptConditionDescriptor ArgumentDefinedCheck(ConversionKernel kernel)
        {
            var statement = string.Format(IS_DEFINED_STATEMENT, kernel.ArgumentName);
            return new ScriptConditionDescriptor(statement, ConditionType.Type);
        }

        /// <inheritdoc />
        public override ScriptConditionDescriptor CreateKeyExistsCheck(ConversionKernel kernel, PropertyDescriptor property)
        {
            var doesKeyExistStatement = $"if (!{kernel.ArgumentName}.hasOwnProperty('{property.Name}')) throw new TypeError(\"{string.Format(kernel.ObjectPropertyMissing, property.Name)}\");";

            return new ScriptConditionDescriptor(doesKeyExistStatement, ConditionType.Key);
        }

        /// <inheritdoc />
        public override ScriptConditionDescriptor CreateInstanceCheck(ConversionKernel kernel, PropertyDescriptor property)
        {
            var instanceCheck = $"if ({CreateDefinedCheck(kernel, property)} && !{{1}}.tryParse({kernel.ArgumentName}.{{0}})) throw new TypeError(\"{kernel.PropertyInstanceMismatch}\");";

            var script = string.Empty;
            var scriptType = property.NativeType
                .IncludeOverride(kernel, property.Type)
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
                    script = string.Format(instanceCheck, property.Name, "Date");
                    break;
                case JavaScriptType.RegExp:
                    script = string.Format(instanceCheck, property.Name, "Regexp");
                    break;
                case JavaScriptType.Array:
                    script = string.Format(instanceCheck, property.Name, "Array");
                    break;
                case JavaScriptType.Object:
                    var propertyWithName = kernel.Models.FirstOrDefault(x => x.FullName == property.Type.FullName);
                    if (!ReferenceEquals(propertyWithName, null))
                        script = string.Format(instanceCheck, property.Name, propertyWithName.Name);

                    break;
                case JavaScriptType.Decimal:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return new ScriptConditionDescriptor(script, ConditionType.Instance);
        }

        /// <inheritdoc />
        public override ScriptConditionDescriptor CreateTypeCheck(ConversionKernel kernel, PropertyDescriptor property)
        {
            var typeCheck = $"if (typeof {kernel.ArgumentName}.{{0}} !== '{{1}}') throw new TypeError(\"{kernel.PropertyTypeMismatch}\");";

            var script = string.Empty;
            var scriptType = property.NativeType
                .IncludeOverride(kernel, property.Type)
                .ToJavaScriptType();

            switch (scriptType)
            {
                case JavaScriptType.Undefined:
                case JavaScriptType.Null:
                    break;
                case JavaScriptType.Boolean:
                    script = string.Format(typeCheck, property.Name, "boolean");
                    break;
                case JavaScriptType.Number:
                    script = string.Format(typeCheck, property.Name, "number");
                    break;
                case JavaScriptType.String:
                    script = string.Format(typeCheck, property.Name, "string");
                    break;
                case JavaScriptType.Decimal:
                case JavaScriptType.Date:
                case JavaScriptType.RegExp:
                case JavaScriptType.Array:
                case JavaScriptType.Object:
                    script = string.Format(typeCheck, property.Name, property.Type == typeof(Guid) ? "string" : "object");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return new ScriptConditionDescriptor(script, ConditionType.Type);
        }

        #endregion
    }
}