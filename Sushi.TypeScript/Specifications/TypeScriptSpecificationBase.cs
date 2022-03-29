using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sushi.Descriptors;
using Sushi.Enum;
using Sushi.Extensions;
using Sushi.JavaScript;

namespace Sushi.TypeScript.Specifications
{
    public abstract class TypeScriptSpecificationBase : JavaScriptSpecification
    {
        #region Overrides of LanguageSpecification

        internal string FormatPropertyType(ConversionKernel kernel, PropertyDescriptor property)
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

        internal string GetBaseType(NativeType type)
        {
            switch (type)
            {
                case NativeType.Undefined:
                    return @"void";
                case NativeType.Bool:
                    return @"boolean";
                case NativeType.Enum:
                case NativeType.Byte:
                case NativeType.Short:
                case NativeType.Long:
                case NativeType.Int:
                case NativeType.Double:
                case NativeType.Float:
                case NativeType.Decimal:
                    return @"number";
                case NativeType.Object:
                    return @"any";
                case NativeType.Char:
                case NativeType.String:
                    return @"string";
                case NativeType.Null:
                    return @"null";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        /// <inheritdoc />
        public override IEnumerable<string> FormatPropertyDefinition(ConversionKernel kernel, PropertyDescriptor property)
        {

            // Return the rows for the js-doc
            var summary = kernel.Documentation?.GetDocumentationForProperty(property.Property);
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
        public override ScriptConditionDescriptor FormatComment(string comment, ConditionType relatedType)
            => SpecificationDefaults.FormatInlineComment(comment, relatedType);

        #endregion
    }
}