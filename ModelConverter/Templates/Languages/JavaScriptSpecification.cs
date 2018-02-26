using System;
using System.Text;
using Common.Utility;
using Common.Utility.Enum;
using ModelConverter.Consistency;
using ModelConverter.Models;
using ModelConverter.Templates.Recognition;

namespace ModelConverter.Templates.Languages
{
    public class JavaScriptSpecification : LanguageSpecification
    {
        #region Overrides of LanguageSpecification

        /// <inheritdoc />
        public override string FormatProperty(Property property)
        {
            var value = FormatValueForType(property.NativeType, property.Value);
            return $@"this.{property.Name} = {value};";
        }

        /// <inheritdoc />
        public override string FormatRecognition(Property property)
        {
            var builder = new StringBuilder();
            foreach (var statement in RecognitionPipeline.CreateStatements(this, _kernel, property))
                builder.AppendLine(statement);

            return builder.ToString();
        }

        /// <inheritdoc />
        public override string GetDefaultForType(CSharpNativeType type)
        {
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
                case CSharpNativeType.Object:
                    return "null";
                case CSharpNativeType.Char:
                case CSharpNativeType.String:
                    return "\"\"";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        /// <inheritdoc />
        public override string FormatValueForType(CSharpNativeType type, object value)
        {
            if (value == null)
                return GetDefaultForType(type);

            switch (type)
            {
                case CSharpNativeType.Undefined:
                case CSharpNativeType.Bool:
                case CSharpNativeType.Byte:
                case CSharpNativeType.Decimal:
                case CSharpNativeType.Double:
                case CSharpNativeType.Float:
                case CSharpNativeType.Int:
                case CSharpNativeType.Long:
                case CSharpNativeType.Short:
                case CSharpNativeType.Object:
                    return value.ToString();
                case CSharpNativeType.Char:
                case CSharpNativeType.String:
                    return $"\"{value}\"";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        #endregion

        #region Initializers

        public JavaScriptSpecification()
        {
            RecognitionPipeline = new JavaScriptObjectRecognition();
        }

        public JavaScriptSpecification(string scriptLanguage, Version version, bool isIsolated = false)
            : base(scriptLanguage, version, isIsolated)
        {
            RecognitionPipeline = new JavaScriptObjectRecognition();
        }

        public JavaScriptSpecification(string scriptLanguage, string version, bool isIsolated = false)
            : base(scriptLanguage, Version.Parse(version), isIsolated)
        {
            RecognitionPipeline = new JavaScriptObjectRecognition();
        }

        public JavaScriptSpecification(string path, string scriptLanguage, string version, bool isIsolated = false)
            : base(path, scriptLanguage, Version.Parse(version), isIsolated)
        {
            RecognitionPipeline = new JavaScriptObjectRecognition();
        }

        public JavaScriptSpecification(string path, string scriptLanguage, Version version, bool isIsolated = false)
            : base(path, scriptLanguage, version, isIsolated)
        {
            RecognitionPipeline = new JavaScriptObjectRecognition();
        }

        #endregion Initializers
    }
}