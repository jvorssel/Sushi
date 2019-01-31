using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Sushi.Consistency;
using Sushi.Descriptors;
using Sushi.Enum;
using Sushi.Extensions;

namespace Sushi.JavaScript
{
    public class JavaScriptSpecification : LanguageSpecification
    {
        #region Overrides of LanguageSpecification

        /// <inheritdoc />
        public override string Extension { get; } = ".js";

        /// <inheritdoc />
        public override IEnumerable<string> FormatProperty(ConversionKernel kernel, PropertyDescriptor property)
        {
            // Return the rows for the js-doc
            var summary = kernel.Documentation?.GetDocumentationForProperty(property.Property);
            if (summary?.Summary.Length > 0)
                yield return $"/** {summary.Summary} */";

            // Specify the body of the property declaration.
            var propertySpec = FormatValueForProperty(kernel, property, property.Value);
            yield return $"this.{property.Name} = {propertySpec};";
        }

        /// <inheritdoc />
        public override IEnumerable<string> FormatPropertyDefinition(ConversionKernel kernel, PropertyDescriptor property)
        {
            yield break;
        }

        /// <inheritdoc />
        public override string RemoveComments(ClassDescriptor model)
            => SpecificationDefaults.RemoveCommentsFromModel(model);

        /// <inheritdoc />
        public override IEnumerable<ScriptConditionDescriptor> FormatStatements(ConversionKernel kernel, List<PropertyDescriptor> properties)
        {
            // Key check
            yield return FormatComment(@"Check property keys", StatementType.Key);
            foreach (var prop in properties)
                yield return StatementPipeline.CreateKeyCheckStatement(kernel, prop);

            // Type check
            yield return new ScriptConditionDescriptor(string.Empty, StatementType.Type, false, true);
            yield return FormatComment(@"Check property type match", StatementType.Type);
            foreach (var prop in properties)
                yield return StatementPipeline.CreateTypeCheckStatement(kernel, prop);

            // Instance check
            yield return new ScriptConditionDescriptor(string.Empty, StatementType.Instance, false, true);
            yield return FormatComment(@"Check property class instance match", StatementType.Instance);
            foreach (var prop in properties)
                yield return StatementPipeline.CreateInstanceCheckStatement(kernel, prop);
        }
        
        /// <inheritdoc />
        public override string GetDefaultForProperty(ConversionKernel kernel, PropertyDescriptor property)
        {
            var type = Nullable.GetUnderlyingType(property.Type) ?? property.Type;
            if (type == typeof(DateTime))
                return "new Date(\"0001-01-01T00:00:00.000Z\")"; // Default date value should be 0001-01-01

            // Always return null if the given property is nullable.
            if (property.IsNullable)
                return "null";

            // Check if a different type is supposed to be used.
            var csType = property.NativeType.IncludeOverride(kernel, type);

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
        public override string FormatValueForProperty(ConversionKernel kernel, PropertyDescriptor property, object value)
        {
            // What default (fallback) value is suppossed to be used?
            var defaultValue = GetDefaultForProperty(kernel, property);

            // Correct the formatting for numeric values.
            var numberFormat = new NumberFormatInfo { CurrencyDecimalSeparator = "." };

            // Get the underlying type if the property is nullable.
            var type = Nullable.GetUnderlyingType(property.Type) ?? property.Type;

            // Date values should be parsed to a date-instance.
            if (type == typeof(DateTime))
                return $"!isNaN(Date.parse({kernel.ArgumentName}.{property.Name})) ? new Date({kernel.ArgumentName}.{property.Name}) : {defaultValue}";

            // Use the converter to get the formatted string value.
            var dataModel = kernel.Models.FirstOrDefault(x => x.FullName == type.FullName);
            if (!ReferenceEquals(dataModel, null))
                return $@"new {dataModel.Name}({kernel.ArgumentName}.{property.Name}) || null";

            return $"{kernel.ArgumentName}.{property.Name} || {defaultValue}";
        }

        /// <inheritdoc />
        public override ScriptConditionDescriptor FormatComment(string comment, StatementType relatedType)
            => SpecificationDefaults.FormatInlineComment(comment, relatedType);

        #endregion

        #region Initializers

        public JavaScriptSpecification()
        {
            StatementPipeline = new JavaScriptStatements();
        }

        public JavaScriptSpecification(string scriptLanguage, Version version)
             : base(scriptLanguage, version)
        {
            StatementPipeline = new JavaScriptStatements();
        }

        public JavaScriptSpecification(string scriptLanguage, string version)
            : base(scriptLanguage, Version.Parse(version))
        {
            StatementPipeline = new JavaScriptStatements();
        }

        public JavaScriptSpecification(string path, string scriptLanguage, string version)
            : base(path, scriptLanguage, Version.Parse(version))
        {
            StatementPipeline = new JavaScriptStatements();
        }

        public JavaScriptSpecification(string path, string scriptLanguage, Version version)
            : base(path, scriptLanguage, version)
        {
            StatementPipeline = new JavaScriptStatements();
        }

        #endregion Initializers
    }
}