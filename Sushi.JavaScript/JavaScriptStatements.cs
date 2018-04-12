using System;
using System.Collections.Generic;
using System.Linq;
using Sushi.Enum;
using Sushi.JavaScript.Enum;
using Sushi.Models;

namespace Sushi.JavaScript
{
    /// <inheritdoc />
    public class JavaScriptStatements : StatementPipeline
    {
        #region Overrides of StatementPipeline

        /// <inheritdoc />
        public override Statement CreateUndefinedStatement(ConversionKernel kernel, Property property)
        {
            var isDefinedStatement = $@"{kernel.ArgumentName}['{property.Name}'] === void 0 || {kernel.ArgumentName}['{property.Name}'] === null";
            return new Statement(isDefinedStatement, StatementType.Type);
        }

        /// <inheritdoc />
        public override Statement ArgumentDefinedStatement(ConversionKernel kernel)
        {
            var isDefinedStatement = $@"{kernel.ArgumentName} !== void 0 && {kernel.ArgumentName} !== null";
            return new Statement(isDefinedStatement, StatementType.Type);
        }

        /// <inheritdoc />
        public override Statement ArgumentUndefinedStatement(ConversionKernel kernel)
        {
            var isDefinedStatement = $@"{kernel.ArgumentName} === void 0 || {kernel.ArgumentName} === null";
            return new Statement(isDefinedStatement, StatementType.Type);
        }

        /// <inheritdoc />
        public override Statement CreateKeyCheckStatement(ConversionKernel kernel, Property property)
        {
            var doesKeyExistStatement = $"if (!{kernel.ArgumentName}.hasOwnProperty('{property.Name}')) throw new TypeError(\"{string.Format(kernel.ObjectPropertyMissing, property.Name)}\");";

            return new Statement(doesKeyExistStatement, StatementType.Key);
        }

        /// <inheritdoc />
        public override Statement CreateInstanceCheckStatement(ConversionKernel kernel, Property property, IEnumerable<DataModel> dataModels)
        {
            var instanceCheck = $"if (!({CreateUndefinedStatement(kernel, property)}) && !({kernel.ArgumentName}['{{0}}'] instanceof {{1}})) throw new TypeError(\"{kernel.PropertyInstanceMismatch}\");";

            var models = dataModels.ToList();
            var script = string.Empty;
            var scriptType = property.NativeType.ToJavaScriptType();
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
                    var propertyWithName = models.FirstOrDefault(x => x.FullName == property.Type.FullName);
                    if (!ReferenceEquals(propertyWithName, null))
                        script = string.Format(instanceCheck, property.Name, propertyWithName.Name);

                    break;
                case JavaScriptType.Decimal:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return new Statement(script, StatementType.Instance);
        }

        /// <inheritdoc />
        public override Statement CreateTypeCheckStatement(ConversionKernel kernel, Property property)
        {
            var typeCheck = $"if (typeof ({kernel.ArgumentName}['{{0}}']) !== '{{1}}') throw new TypeError(\"{kernel.PropertyTypeMismatch}\");";

            var script = string.Empty;
            var scriptType = property.NativeType.ToJavaScriptType();
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

            return new Statement(script, StatementType.Type);
        }

        #endregion
    }
}