using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using Common.Utility.Enum;
using ModelConverter.Consistency;
using ModelConverter.Models;

namespace ModelConverter.JavaScript
{
    public class JavaScriptSpecification : LanguageSpecification
    {
        #region Overrides of LanguageSpecification

        /// <inheritdoc />
        public override string FormatProperty(ConversionKernel kernel, Property property)
        {
            var value = FormatValueForProperty(property, property.Value);
            return $@"this.{property.Name} = {kernel.ArgumentName}.{property.Name} || {value};";
        }

        /// <inheritdoc />
        public override string RemoveComments(DataModel model)
        {
            var script = model.Script;

            // Remove single-line comments
            script = new Regex(@"([/]{2})(.*)$", RegexOptions.Multiline | RegexOptions.Compiled).Replace(script, "");

            // Remove multi-line comments
            script = new Regex(@"(\/\*)(.|[\r\n])*?(\*\/)", RegexOptions.Compiled | RegexOptions.Multiline).Replace(script, "");
            
            model.Script = script;
            return script;
        }

        /// <inheritdoc />
        public override IEnumerable<Statement> FormatStatements(ConversionKernel kernel, List<Property> properties, List<DataModel> dataModels)
        {
            // Key check
            yield return FormatComment(kernel, "Check property keys", StatementType.Key);
            foreach (var prop in properties)
                yield return StatementPipeline.CreateKeyCheckStatement(kernel, prop);

            // Type check
            yield return new Statement(string.Empty, StatementType.Type, false, true);
            yield return FormatComment(kernel, "Check property type match", StatementType.Type);
            foreach (var prop in properties)
                yield return StatementPipeline.CreateTypeCheckStatement(kernel, prop);

            // Instance check
            yield return new Statement(string.Empty, StatementType.Instance, false, true);
            yield return FormatComment(kernel, "Check property class instance match", StatementType.Instance);
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
            switch (type)
            {
                case CSharpNativeType.Undefined:
                    return @"undefined";
                case CSharpNativeType.Byte:
                case CSharpNativeType.Float:
                case CSharpNativeType.Int:
                case CSharpNativeType.Long:
                case CSharpNativeType.Short:
                case CSharpNativeType.Object:
                    if (value is DateTime d)
                        return $"new Date({d.Year}, {d.Month}, {d.Day}, {d.Hour}, {d.Minute}, {d.Second}, {d.Millisecond})";
                    if (value is Guid g)
                        return $@"'{g.ToString()}'";
                    return value.ToString();
                case CSharpNativeType.Char:
                case CSharpNativeType.String:
                    return $"\"{value}\"";
                case CSharpNativeType.Bool:
                    return value.ToString().ToLowerInvariant();
                case CSharpNativeType.Double:
                    var dbl = (double)value;
                    return dbl.ToString(numberFormat);
                case CSharpNativeType.Decimal:
                    var dec = (decimal)value;
                    return dec.ToString(numberFormat);
                case CSharpNativeType.Null:
                    return @"null";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        /// <inheritdoc />
        public override Statement FormatComment(ConversionKernel kernel, string comment, StatementType relatedType)
        {
            if (comment.Contains("\n"))
                throw Errors.OnlyInlineCommentsSupported(comment);

            if (comment.EndsWith("."))
                comment = comment.Substring(0, comment.Length - 1);

            return new Statement($@"// {comment}.", relatedType, true);
        }

        #endregion

        #region Initializers
        
        public JavaScriptSpecification()
        {
            StatementPipeline = new JavaScriptStatements();
        }

        public JavaScriptSpecification(string scriptLanguage, Version version, bool isIsolated = false)
             : base(scriptLanguage, version, isIsolated)
        {
            StatementPipeline = new JavaScriptStatements();
        }

        public JavaScriptSpecification(string scriptLanguage, string version, bool isIsolated = false)
            : base(scriptLanguage, Version.Parse(version), isIsolated)
        {
            StatementPipeline = new JavaScriptStatements();
        }

        public JavaScriptSpecification(string path, string scriptLanguage, string version, bool isIsolated = false)
            : base(path, scriptLanguage, Version.Parse(version), isIsolated)
        {
            StatementPipeline = new JavaScriptStatements();
        }

        public JavaScriptSpecification(string path, string scriptLanguage, Version version, bool isIsolated = false)
            : base(path, scriptLanguage, version, isIsolated)
        {
            StatementPipeline = new JavaScriptStatements();
        }

        #endregion Initializers
    }
}