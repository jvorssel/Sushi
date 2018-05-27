using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sushi.Enum;
using Sushi.Extensions;
using Sushi.Helpers;
using Sushi.JavaScript;
using Sushi.Models;

namespace Sushi.TypeScript.Specifications
{
    public abstract class TypeScriptSpecificationBase : JavaScriptSpecification
    {
        #region Overrides of LanguageSpecification

        internal string FormatPropertyType(ConversionKernel kernel, Property property)
        {
            var tsTypeName = GetBaseType(property.NativeType.IncludeOverride(kernel, property.Type));
            var type = Nullable.GetUnderlyingType(property.Type) ?? property.Type;
            if (type == typeof(DateTime))
                tsTypeName = "Date";
            else
            {
                // Check if any of the available models have the same name and should be used.
                var dataModel = kernel.Models.FirstOrDefault(x => x.FullName == type.FullName);
                if (!ReferenceEquals(dataModel, null))
                    tsTypeName = dataModel.Name;
            }

            return type.IsTypeOrInheritsOf(typeof(IEnumerable)) && type != typeof(string) ? $@"Array<{tsTypeName}>" : tsTypeName;
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
        public override IEnumerable<string> FormatPropertyDefinition(ConversionKernel kernel, Property property)
        {

            // Return the rows for the js-doc
            var summary = kernel.Documentation?.GetDocumentationForProperty(property.PropertyType);
            if (summary?.Summary.Length > 0)
                yield return $"/** {summary.Summary} */";

            // Apply formatting for TypeScript its Array type.
            var type = FormatPropertyType(kernel, property);
            var name = property.Name;

            if (property.Type.IsNullable())
                name += "?";

            var statement = property.IsReadonly ?
                $@"readonly {name}: {type};" :
                $@"{name}: {type};";

            yield return statement;
        }

        /// <inheritdoc />
        public override Statement FormatComment(string comment, StatementType relatedType)
            => SpecificationDefaults.FormatInlineComment(comment, relatedType);

        #endregion

        protected TypeScriptSpecificationBase(string scriptName, Version version)
            : base(scriptName, version)
        {

        }
    }
}