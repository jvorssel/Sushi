using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Sushi.Descriptors;
using Sushi.Enum;
using Sushi.Extensions;
using Sushi.Interfaces;

namespace Sushi.JavaScript
{
    public class JavaScriptSpecification : ILanguageSpecification
    {
        #region Overrides of LanguageSpecification

        /// <inheritdoc />
        public virtual string Extension => ".js";

        /// <inheritdoc />
        public string Template { get; }

        /// <inheritdoc />
        public string WrapTemplate { get; }

        /// <inheritdoc />
        public WrapTemplateUsage WrapUsage { get; }

        /// <inheritdoc />
        public IConditionSpecification ConditionSpecification { get; set; }

        /// <inheritdoc />
        public ILanguageSpecification UseTemplate(string template)
            => throw new NotImplementedException();

        /// <inheritdoc />
        public ILanguageSpecification UseWrapTemplate(string template, WrapTemplateUsage usage)
            => throw new NotImplementedException();

        /// <inheritdoc />
        public virtual IEnumerable<string> FormatProperty(Converter converter, IPropertyDescriptor descriptor)
        {
            // Return the rows for the js-doc
            var summary = converter.Documentation?.GetDocumentationForProperty(descriptor);
            if (summary?.Summary.Length > 0)
                yield return $"/** {summary.Summary} */";

            // Specify the body of the property declaration.
            var propertySpec = GetDefaultForProperty(converter, descriptor);
            yield return $"this.{descriptor.Name} = {propertySpec};";
        }

        /// <inheritdoc />
        public virtual IEnumerable<string> FormatPropertyDefinition(Converter converter, IPropertyDescriptor descriptor)
        {
            yield break;
        }

        /// <inheritdoc />
        public virtual string RemoveComments(ClassDescriptor model)
            => SpecificationDefaults.RemoveCommentsFromModel(model);

        /// <inheritdoc />
        public virtual IEnumerable<ScriptConditionDescriptor> FormatStatements(Converter converter, List<IPropertyDescriptor> properties)
        {
            // Key check
            yield return FormatComment(@"Check property keys", ConditionType.Key);
            foreach (var prop in properties)
                yield return ConditionSpecification.CreateKeyExistsCheck(converter, prop);

            // Type check
            yield return new ScriptConditionDescriptor(string.Empty, ConditionType.Type, false, true);
            yield return FormatComment(@"Check property type match", ConditionType.Type);
            foreach (var prop in properties)
                yield return ConditionSpecification.CreateTypeCheck(converter, prop);

            // Instance check
            yield return new ScriptConditionDescriptor(string.Empty, ConditionType.Instance, false, true);
            yield return FormatComment(@"Check property class instance match", ConditionType.Instance);
            foreach (var prop in properties)
                yield return ConditionSpecification.CreateInstanceCheck(converter, prop);
        }
        
        /// <inheritdoc />
        public virtual string GetDefaultForProperty(Converter converter, IPropertyDescriptor descriptor)
        {
            var type = Nullable.GetUnderlyingType(descriptor.Type) ?? descriptor.Type;
            if (type == typeof(DateTime))
                return "new Date(\"0001-01-01T00:00:00.000Z\")"; // Default date value should be 0001-01-01

            // Always return null if the given property is nullable.
            if (descriptor.IsNullable)
                return "null";

            // Check if a different type is supposed to be used.
            var csType = descriptor.NativeType.IncludeOverride(converter, type);

            // A string also inherits the IEnumerable interface, exclude.
            if (type.IsTypeOrInheritsOf(typeof(IEnumerable)) && type != typeof(string))
                return "[]";

            // Check the native type with certain exceptions.
            switch (csType)
            {
                case NativeType.Undefined:
                    return "void 0";
                case NativeType.Bool:
                    return "false";
                case NativeType.Byte:
                case NativeType.Decimal:
                case NativeType.Double:
                case NativeType.Float:
                case NativeType.Int:
                case NativeType.Long:
                case NativeType.Short:
                    return "-1";
                case NativeType.Char:
                case NativeType.String:
                    return "''";
                case NativeType.Enum:
                    return "0";
                default:
                case NativeType.Null:
                case NativeType.Object:
                    return "null";
            }
        }
        
        /// <inheritdoc />
        public virtual string FormatValueForProperty(Converter converter, PropertyDescriptor property, object value)
        {
            // What default (fallback) value is suppossed to be used?
            var defaultValue = GetDefaultForProperty(converter, property);

            // Correct the formatting for numeric values.
            var numberFormat = new NumberFormatInfo { CurrencyDecimalSeparator = "." };

            // Get the underlying type if the property is nullable.
            var type = Nullable.GetUnderlyingType(property.Type) ?? property.Type;

            // Date values should be parsed to a date-instance.
            if (type == typeof(DateTime))
                return $"!isNaN(Date.parse({converter.ArgumentName}.{property.Name})) ? new Date({converter.ArgumentName}.{property.Name}) : {defaultValue}";

            // Use the converter to get the formatted string value.
            var dataModel = converter.Models.FirstOrDefault(x => x.FullName == type.FullName);
            if (!ReferenceEquals(dataModel, null))
                return $@"new {dataModel.Name}({converter.ArgumentName}.{property.Name}) || null";

            return $"{converter.ArgumentName}.{property.Name} || {defaultValue}";
        }

        /// <inheritdoc />
        public virtual ScriptConditionDescriptor FormatComment(string comment, ConditionType relatedType)
            => SpecificationDefaults.FormatInlineComment(comment, relatedType);

        #endregion

        /// <inheritdoc />
        public JavaScriptSpecification()
        {
            ConditionSpecification = new JavaScriptConditions();
        }
    }
}