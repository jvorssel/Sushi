using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sushi.Enum;
using Sushi.Extensions;
using Sushi.Helpers;
using Sushi.Models;

namespace Sushi.TypeScript.Specifications
{
    public abstract class TypeScriptSpecificationBase : LanguageSpecification
    {
        #region Overrides of LanguageSpecification

        internal string FormatArrayType(Property property, string baseType)
        {
            if (!property.Type.IsArray())
                return baseType;

            var enumerable = property.Type.GetInterfaces().FirstOrDefault(x => x == typeof(IEnumerable));
            var underlyingType = property.Type.GetUnderlyingPrimitiveType();
            var underlyingCsType = GetBaseType(underlyingType.ToCSharpNativeType());

            return enumerable == null ? $@"Array<{baseType}>" : $@"Array<{underlyingCsType}>";
        }

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
        public override IEnumerable<string> FormatPropertyDefinition(ConversionKernel kernel,
            Property property,
            ICollection<DataModel> relatedTypes)
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

            // Apply formatting for TypeScript its Array type.
            type = FormatArrayType(property, type);

            var statement = property.IsReadonly ?
                $@"readonly {property.Name}: {type};" :
                $@"{property.Name}: {type};";

            yield return statement;
        }

        /// <inheritdoc />
        public override Statement FormatInheritanceStatement(DataModel model, DataModel inherits)
            => new Statement($@" extends {inherits.Name}Constructor", StatementType.Inheritance);

        /// <inheritdoc />
        public override Statement FormatComment(string comment, StatementType relatedType)
            => SpecificationDefaults.FormatInlineComment(comment, relatedType);

        #endregion

        protected TypeScriptSpecificationBase(string scriptName, Version version, bool isIsolated = false)
            : base(scriptName, version, isIsolated)
        {

        }
    }
}