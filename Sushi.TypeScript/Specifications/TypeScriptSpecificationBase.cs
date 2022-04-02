using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sushi.Descriptors;
using Sushi.Enum;
using Sushi.Extensions;
using Sushi.Interfaces;
using Sushi.JavaScript;

namespace Sushi.TypeScript.Specifications
{
    public abstract class TypeScriptSpecificationBase : JavaScriptSpecification
    {
        #region Overrides of LanguageSpecification

        internal string FormatPropertyType(Converter converter, IPropertyDescriptor descriptor)
        {
            var tsTypeName = GetBaseType(descriptor.NativeType.IncludeOverride(converter, descriptor.Type));
            var type = Nullable.GetUnderlyingType(descriptor.Type) ?? descriptor.Type;
            if (type == typeof(DateTime))
                tsTypeName = "Date";
            else
            {
                // Check if any of the available models have the same name and should be used.
                var dataModel = converter.Models.FirstOrDefault(x => x.FullName == type.FullName);
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
        public override IEnumerable<string> FormatPropertyDefinition(Converter converter, IPropertyDescriptor descriptor)
        {

            // Return the rows for the js-doc
            var summary = converter.Documentation?.GetDocumentationForProperty(descriptor);
            if (summary?.Summary.Length > 0)
                yield return $"/** {summary.Summary} */";

            // Apply formatting for TypeScript its Array type.
            var type = FormatPropertyType(converter, descriptor);
            var name = descriptor.Name;

            if (descriptor.Type.IsNullable())
                name += "?";

            var statement = descriptor.IsReadonly ?
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