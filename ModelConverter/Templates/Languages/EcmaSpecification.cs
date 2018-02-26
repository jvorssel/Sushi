using System;
using Common.Utility;
using Common.Utility.Enum;
using ModelConverter.Consistency;
using ModelConverter.Models;

namespace ModelConverter.Templates.Languages
{
    public class EcmaSpecification : LanguageSpecification
    {
        #region Overrides of LanguageSpecification

        /// <inheritdoc />
        public override string FormatProperty(Property property)
        {
            var indent = string.Empty;
            foreach (var line in Template.GetLines())
            {
                if (indent != string.Empty)
                    continue;

                if (line.Contains(TemplateKeys.VALUES_KEY))
                    indent = line.Substring(0, line.IndexOf(TemplateKeys.VALUES_KEY, StringComparison.InvariantCultureIgnoreCase));
            }


            var value = FormatValueForType(property.NativeType, property.Value);
            return $@"{indent}this.{property.Name} = {value};";
        }

        /// <inheritdoc />
        public override string FormatRecognition(Property property)
        {
            return string.Empty;
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

        public EcmaSpecification()
        {

        }

        public EcmaSpecification(string scriptLanguage, Version version, bool isIsolated = false)
            : base(scriptLanguage, version, isIsolated)
        {

        }

        public EcmaSpecification(string scriptLanguage, string version, bool isIsolated = false)
            : base(scriptLanguage, Version.Parse(version), isIsolated)
        {

        }

        public EcmaSpecification(string path, string scriptLanguage, string version, bool isIsolated = false)
            : base(path, scriptLanguage, Version.Parse(version), isIsolated)
        {

        }

        public EcmaSpecification(string path, string scriptLanguage, Version version, bool isIsolated = false)
            : base(path, scriptLanguage, version, isIsolated)
        {

        }

        #endregion Initializers
    }
}