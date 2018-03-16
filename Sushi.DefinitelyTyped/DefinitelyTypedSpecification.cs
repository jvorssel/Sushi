using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sushi.Enum;
using Sushi.Extensions;
using Sushi.Helpers;
using Sushi.Models;

namespace Sushi.DefinitelyTyped
{
    public class DefinitelyTypedSpecification : LanguageSpecification
    {
        #region Overrides of LanguageSpecification

        internal string GetBaseType(CSharpNativeType type)
        {
            switch (type)
            {
                case CSharpNativeType.Undefined:
                    return @"void";
                case CSharpNativeType.Bool:
                    return @"boolean";
                case CSharpNativeType.Enum:
                case CSharpNativeType.Byte:
                case CSharpNativeType.Short:
                case CSharpNativeType.Long:
                case CSharpNativeType.Int:
                case CSharpNativeType.Double:
                case CSharpNativeType.Float:
                case CSharpNativeType.Decimal:
                    return @"number";
                case CSharpNativeType.Object:
                    return @"any";
                case CSharpNativeType.Char:
                case CSharpNativeType.String:
                    return @"string";
                case CSharpNativeType.Null:
                    return @"null";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        /// <inheritdoc />
        public override IEnumerable<string> FormatProperty(ConversionKernel kernel, Property property)
        {
            var type = GetBaseType(property.NativeType);
            var enumerable = property.Type.GetInterfaces().FirstOrDefault(x => x == typeof(IEnumerable));

            // Return the rows for the js-doc
            var summary = kernel.Documentation?.Members.SingleOrDefault(x => x.Namespace == property.Namespace);
            if (summary != null)
            {
                yield return $"/**";
                yield return $"  * {summary.Summary}";
                yield return $"  */";
            }

            if (property.Type.IsArray())
            {
                var underlyingType = property.Type.GetUnderlyingPrimitiveType();
                var underlyingCsType = GetBaseType(underlyingType.ToCSharpNativeType());

                type = enumerable == null ? $@"Array<{type}>" : $@"Array<{underlyingCsType}>";
            }

            var statement = property.IsReadonly ?
                $@"readonly {property.Name}: {type};" :
                $@"{property.Name}: {type};";

            yield return statement;
        }

        /// <inheritdoc />
        public override IEnumerable<Statement> FormatStatements(ConversionKernel kernel, List<Property> properties, List<DataModel> dataModels)
        {
            yield break;
        }

        /// <inheritdoc />
        public override Statement FormatInheritanceStatement(DataModel model, DataModel inherits)
            => new Statement($@" extends {inherits.Name}Constructor", StatementType.Inheritance);

        /// <inheritdoc />
        public override string GetDefaultForProperty(Property property)
            => string.Empty;

        /// <inheritdoc />
        public override string FormatValueForProperty(Property property, object value)
            => string.Empty;

        /// <inheritdoc />
        public override string RemoveComments(DataModel model)
            => model.Script;

        /// <inheritdoc />
        public override Statement FormatComment(string comment, StatementType relatedType)
            => SpecificationDefaults.FormatInlineComment(comment, relatedType);

        #endregion

        #region Initializers

        public DefinitelyTypedSpecification()
        {
            StatementPipeline = new DefinitelyTypedStatements();
        }

        public DefinitelyTypedSpecification(string scriptLanguage, Version version, bool isIsolated = false)
            : base(scriptLanguage, version, isIsolated)
        {
            StatementPipeline = new DefinitelyTypedStatements();
        }

        public DefinitelyTypedSpecification(string scriptLanguage, string version, bool isIsolated = false)
            : base(scriptLanguage, Version.Parse(version), isIsolated)
        {
            StatementPipeline = new DefinitelyTypedStatements();
        }

        public DefinitelyTypedSpecification(string path, string scriptLanguage, string version, bool isIsolated = false)
            : base(path, scriptLanguage, Version.Parse(version), isIsolated)
        {
            StatementPipeline = new DefinitelyTypedStatements();
        }

        public DefinitelyTypedSpecification(string path, string scriptLanguage, Version version, bool isIsolated = false)
            : base(path, scriptLanguage, version, isIsolated)
        {
            StatementPipeline = new DefinitelyTypedStatements();
        }

        #endregion Initializers
    }
}
