using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Sushi.Enum;
using Sushi.Models;
using Sushi.Extensions;

namespace Sushi.TypeScript.Specifications
{
    public class TypeScriptSpecification : TypeScriptSpecificationBase
    {
        #region Overrides of LanguageSpecification

        /// <inheritdoc />
        public override IEnumerable<string> FormatProperty(ConversionKernel kernel, Property property)
        {
            var value = FormatValueForProperty(property, property.Value);

            // Return the rows for the js-doc
            var summary = kernel.Documentation?.Members.SingleOrDefault(x => x.Namespace == property.Namespace);
            if (summary != null)
            {
                yield return $"/**";
                yield return $"  * @summary {summary.Summary}";
                yield return $"  */";
            }

            yield return $"this.{property.Name} = {kernel.ArgumentName}.{property.Name} || {value};";
        }

        #region Overrides of TypeScriptSpecificationBase

        /// <inheritdoc />
        public override Statement FormatInheritanceStatement(DataModel model, DataModel inherits)
        {
            var script = $@" implements {inherits.Name}";
            var statement = new Statement(script, StatementType.Inheritance);

            return statement;
        }

        #endregion

        /// <inheritdoc />
        public override string RemoveComments(DataModel model)
            => SpecificationDefaults.RemoveCommentsFromModel(model);

        /// <inheritdoc />
        public override IEnumerable<Statement> FormatStatements(ConversionKernel kernel, List<Property> properties, List<DataModel> dataModels)
        {
            // Key check
            yield return FormatComment(@"Check property keys", StatementType.Key);
            foreach (var prop in properties)
                yield return StatementPipeline.CreateKeyCheckStatement(kernel, prop);

            // Type check
            yield return new Statement(string.Empty, StatementType.Type, false, true);
            yield return FormatComment(@"Check property type match", StatementType.Type);
            foreach (var prop in properties)
                yield return StatementPipeline.CreateTypeCheckStatement(kernel, prop);

            // Instance check
            yield return new Statement(string.Empty, StatementType.Instance, false, true);
            yield return FormatComment(@"Check property class instance match", StatementType.Instance);
            foreach (var prop in properties)
                yield return StatementPipeline.CreateInstanceCheckStatement(kernel, prop, dataModels);
        }

        /// <inheritdoc />
        public override string GetDefaultForProperty(Property property)
        {
            var type = property.NativeType;
            switch (type)
            {
                case CSharpNativeType.Undefined:
                    return "void 0";
                case CSharpNativeType.Bool:
                    return "false";
                case CSharpNativeType.Byte:
                case CSharpNativeType.Decimal:
                case CSharpNativeType.Double:
                case CSharpNativeType.Float:
                case CSharpNativeType.Int:
                case CSharpNativeType.Long:
                case CSharpNativeType.Short:
                    return "-1";
                case CSharpNativeType.Null:
                case CSharpNativeType.Object:
                    return "null";
                case CSharpNativeType.Char:
                case CSharpNativeType.String:
                    return "''";
                case CSharpNativeType.Enum:
                    return "0";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        /// <inheritdoc />
        public override string FormatValueForProperty(Property property, object value)
        {
            if (value == null)
                return GetDefaultForProperty(property);

            var type = property.NativeType;
            return JsonConvert.SerializeObject(value);
        }

        /// <inheritdoc />
        public override Statement FormatComment(string comment, StatementType relatedType)
            => SpecificationDefaults.FormatInlineComment(comment, relatedType);

        #endregion

        #region Initializers

        public TypeScriptSpecification(Version version, bool isIsolated = false)
            : base("TypeScript", version, isIsolated)
        {
            StatementPipeline = new TypeScriptStatements();
        }



        #endregion Initializers
    }
}