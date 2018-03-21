using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Sushi.Consistency;
using Sushi.Enum;
using Sushi.Models;
using Sushi.TypeScript.Enum;

namespace Sushi.TypeScript.Specifications
{
    public class TypeScriptSpecification : LanguageSpecification
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

        /// <inheritdoc />
        public override IEnumerable<string> FormatPropertyDefinition(ConversionKernel kernel, Property property, ICollection<DataModel> relatedTypes)
        {
            var relatedType = relatedTypes.FirstOrDefault(x => x.Name == property.Type.Name);
            var tsType = property.NativeType.ToTypeScriptType();
            switch (tsType)
            {
                case TypeScriptType.Number:
                    yield return $@"{property.Name}: number;";
                    break;
                case TypeScriptType.Boolean:
                    yield return $@"{property.Name}: boolean;";
                    break;
                case TypeScriptType.Array:
                    yield return $@"{property.Name}: any;";
                    break;
                case TypeScriptType.Enum:
                    if (relatedType is null)
                        throw Errors.EnumUnavailable(property);

                    yield return $@"{property.Name}: {relatedType.Type.Name} | Array<number>;";
                    break;
                case TypeScriptType.String:
                    yield return $@"{property.Name}: string;";
                    break;
                case TypeScriptType.Object:
                    var typeString = relatedType is null ? "any" : $@"{relatedType.Name} | any";
                    yield return $@"{property.Name}: {typeString};";
                    break;
                case TypeScriptType.Null:
                case TypeScriptType.RegExp:
                case TypeScriptType.Undefined:
                    yield return $@"{property.Type.Name}: any;";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

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
        public override Statement FormatInheritanceStatement(DataModel model, DataModel inherits)
        {
            var script = $@" extends {inherits.Name}";
            var statement = new Statement(script, StatementType.Inheritance);

            return statement;
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

            var numberFormat = new NumberFormatInfo { CurrencyDecimalSeparator = "." };
            var type = property.NativeType;
            return JsonConvert.SerializeObject(value);
        }

        /// <inheritdoc />
        public override Statement FormatComment(string comment, StatementType relatedType)
            => SpecificationDefaults.FormatInlineComment(comment, relatedType);

        #endregion

        #region Initializers

        public TypeScriptSpecification()
        {
            StatementPipeline = new TypeScriptStatements();
        }

        public TypeScriptSpecification(string scriptLanguage, Version version, bool isIsolated = false)
             : base(scriptLanguage, version, isIsolated)
        {
            StatementPipeline = new TypeScriptStatements();
        }

        public TypeScriptSpecification(string scriptLanguage, string version, bool isIsolated = false)
            : base(scriptLanguage, Version.Parse(version), isIsolated)
        {
            StatementPipeline = new TypeScriptStatements();
        }

        public TypeScriptSpecification(string path, string scriptLanguage, string version, bool isIsolated = false)
            : base(path, scriptLanguage, Version.Parse(version), isIsolated)
        {
            StatementPipeline = new TypeScriptStatements();
        }

        public TypeScriptSpecification(string path, string scriptLanguage, Version version, bool isIsolated = false)
            : base(path, scriptLanguage, version, isIsolated)
        {
            StatementPipeline = new TypeScriptStatements();
        }

        #endregion Initializers
    }
}