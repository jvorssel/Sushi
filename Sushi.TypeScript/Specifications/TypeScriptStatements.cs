using System;
using System.Collections.Generic;
using System.Linq;
using Sushi.Enum;
using Sushi.Models;
using Sushi.TypeScript.Enum;

namespace Sushi.TypeScript.Specifications
{
    /// <inheritdoc />
    public class TypeScriptStatements : StatementPipeline
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
            var doesKeyExistStatement = $"if (!{kernel.ArgumentName}.hasOwnProperty('{property.Name}'))" +
                $"\n\tthrow new TypeError(\"{string.Format(kernel.ObjectPropertyMissing, property.Name)}\"); ";

            return new Statement(doesKeyExistStatement, StatementType.Key);
        }

        /// <inheritdoc />
        public override Statement CreateInstanceCheckStatement(ConversionKernel kernel, Property property, IEnumerable<DataModel> dataModels)
        {
            var instanceCheck =
                $@"if (!({CreateUndefinedStatement(kernel, property)}) && !({kernel.ArgumentName}['{{0}}'] instanceof {{1}}))" +
                $"\n\tthrow new TypeError(\"{kernel.PropertyInstanceMismatch}\");";

            var models = dataModels.ToList();
            var script = string.Empty;
            var scriptType = property.NativeType.ToTypeScriptType();
            switch (scriptType)
            {
                case TypeScriptType.Number:
                case TypeScriptType.Boolean:
                case TypeScriptType.Null:
                case TypeScriptType.Undefined:
                case TypeScriptType.String:
                case TypeScriptType.Object:
                    break;
                case TypeScriptType.Array:
                    script = string.Format(instanceCheck, property.Name, "Array");
                    break;
                case TypeScriptType.Enum:
                    script = string.Format(instanceCheck, property.Name, property.Type.Name);
                    break;
                case TypeScriptType.RegExp:
                    script = string.Format(instanceCheck, property.Name, "RegExp");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return new Statement(script, StatementType.Instance);
        }

        /// <inheritdoc />
        public override Statement CreateTypeCheckStatement(ConversionKernel kernel, Property property)
        {
            var typeCheck =
                $@"if (typeof ({kernel.ArgumentName}['{{0}}']) !== '{{1}}')" +
                $"\n\tthrow new TypeError(\"{kernel.PropertyTypeMismatch}\");";

            var script = string.Empty;
            var scriptType = property.NativeType.ToTypeScriptType();
            switch (scriptType)
            {
                case TypeScriptType.Number:
                    script = string.Format(typeCheck, property.Name, "number");
                    break;
                case TypeScriptType.Boolean:
                    script = string.Format(typeCheck, property.Name, "boolean");
                    break;
                case TypeScriptType.String:
                    script = string.Format(typeCheck, property.Name, "string");
                    break;
                case TypeScriptType.Object:
                case TypeScriptType.Array:
                case TypeScriptType.Enum:
                case TypeScriptType.Undefined:
                case TypeScriptType.Null:
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