using System;
using System.Linq;
using Sushi.Descriptors;
using Sushi.Enum;
using Sushi.Interfaces;
using Sushi.JavaScript.Enum;

namespace Sushi.JavaScript
{
    /// <inheritdoc />
    public sealed class JavaScriptConditions : ConditionPipeline
    {
        public const string IS_DEFINED_STATEMENT = @"{0} !== void 0 && {0} !== null";
        public const string IS_UNDEFINED_STATEMENT = @"{0} === void 0 || {0} === null";
        public const string IS_PROPERTY_DEFINED_STATEMENT = @"{0}.{1} !== void 0 && {0}.{1} !== null";

        #region Overrides of StatementPipeline

        /// <inheritdoc />
        public override ScriptConditionDescriptor CreateDefinedCheck(ConversionKernel kernel, IPropertyDescriptor descriptor)
        {
            var statement = string.Format(IS_PROPERTY_DEFINED_STATEMENT, kernel.ArgumentName, descriptor.Name);
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
        public override ScriptConditionDescriptor CreateKeyExistsCheck(ConversionKernel kernel, IPropertyDescriptor descriptor)
        {
            var doesKeyExistStatement = $"if (!{kernel.ArgumentName}.hasOwnProperty('{descriptor.Name}')) throw new TypeError(\"{string.Format(kernel.ObjectPropertyMissing, descriptor.Name)}\");";

            return new ScriptConditionDescriptor(doesKeyExistStatement, ConditionType.Key);
        }

        /// <inheritdoc />
        public override ScriptConditionDescriptor CreateInstanceCheck(ConversionKernel kernel, IPropertyDescriptor descriptor)
        {
            var instanceCheck = $"if ({CreateDefinedCheck(kernel, descriptor)} && !{{1}}.tryParse({kernel.ArgumentName}.{{0}})) throw new TypeError(\"{kernel.PropertyInstanceMismatch}\");";

            var script = string.Empty;
            var scriptType = descriptor.NativeType
                .IncludeOverride(kernel, descriptor.Type)
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
                    var propertyWithName = kernel.Models.FirstOrDefault(x => x.FullName == descriptor.Type.FullName);
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
        public override ScriptConditionDescriptor CreateTypeCheck(ConversionKernel kernel, IPropertyDescriptor descriptor)
        {
            var typeCheck = $"if (typeof {kernel.ArgumentName}.{{0}} !== '{{1}}') throw new TypeError(\"{kernel.PropertyTypeMismatch}\");";

            var script = string.Empty;
            var scriptType = descriptor.NativeType
                .IncludeOverride(kernel, descriptor.Type)
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