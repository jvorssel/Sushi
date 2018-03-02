using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Utility;
using Common.Utility.Enum.ECMAScript;
using Common.Utility.Helpers;
using ModelConverter.Consistency;
using ModelConverter.Interfaces;
using ModelConverter.Models;
using ModelConverter.Templates.Languages;
using static ModelConverter.Consistency.TemplateKeys;

namespace ModelConverter.Templates
{
    /// <summary>
    ///     Manages the expected file code-templates.
    /// </summary>
    public class TemplateManager
    {
        private readonly ConversionKernel _kernel;
        public ILanguageSpecification Language { get; }

        private string _result = string.Empty;

        public TemplateManager(ILanguageSpecification language, ConversionKernel kernel)
        {
            _kernel = kernel;
            Language = language;
        }

        /// <summary>
        ///     Compile the given <paramref name="model"/> with the current <see cref="LanguageSpecification"/>.
        /// </summary>
        /// <param name="model">The <see cref="DataModel"/> to convert to the given <see cref="Language"/>.</param>
        /// <param name="referenceDataModels">Check type reference for found <see cref="DataModel"/>(s).</param>
        public TemplateManager Compile(DataModel model, IEnumerable<DataModel> referenceDataModels)
        {
            var builder = new StringBuilder();
            var template = Language.Template
                .Replace(TYPE_NAME_KEY, model.Name)
                .Replace(ARGUMENT_NAME, _kernel.ArgumentName)
                ;

            var enumerator = new StringEnumerator(template);
            while (enumerator.MoveNext())
            {
                var row = enumerator.Current;
                if (row.Contains(VALUES_KEY))
                {
                    // Define each property in the template.
                    var indent = row.Before(VALUES_KEY);
                    var propertyBuilder = new StringBuilder();
                    foreach (var property in model.Properties)
                    {
                        var assignStatement = Language.FormatProperty(property);
                        propertyBuilder.AppendLine(indent + assignStatement);
                    }

                    builder.Append(propertyBuilder);
                }
                else if (row.Contains(VALIDATION_KEY))
                {
                    var indent = row.Before(VALIDATION_KEY);
                    var recognitionBuilder = new StringBuilder();
                    foreach (var property in model.Properties)
                    {
                        var recognizeStatements = Language.FormatRecognition(property, referenceDataModels).ToList();
                        property.Script = recognizeStatements;

                        foreach (var line in recognizeStatements)
                            recognitionBuilder.AppendLine(indent + line);
                    }

                    builder.Append(recognitionBuilder);
                }
                else
                    builder.Append(enumerator.Current);
            }

            // Set the model name in the template.
            _result = builder.ToString();
            model.Script = _result;

            return this;
        }

        /// <inheritdoc />
        public override string ToString() => _result;

        #region Initializers

        /// <summary>
        ///     Initialize a <see cref="TemplateManager"/> to work with ECMAScript with a specific <paramref name="version"/>.
        /// </summary>
        /// <param name="kernel">The base <see cref="ConversionKernel"/> instance.</param>
        /// <param name="version">The ECMAScript <paramref name="version"/>.</param>
        /// <param name="useIsolateScope">If the model should be generated in a <paramref name="useIsolateScope"/>.</param>
        /// <returns></returns>
        public static TemplateManager ForJavaScript(ConversionKernel kernel, EcmaVersion version, bool useIsolateScope = false)
        {
            var languageEnumerable = kernel.Languages.Where(x => x.Language == @"JavaScript");

            Version langVersion;
            switch (version)
            {
                case EcmaVersion.V6:
                    langVersion = new Version(6, 0);
                    break;
                case EcmaVersion.V5:
                    langVersion = new Version(5, 0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(version), version, null);
            }

            var language = languageEnumerable.FirstOrDefault(x => x.Version == langVersion && x.IsIsolated == useIsolateScope);
            if (language == null)
                throw Errors.LanguageNotFound(langVersion, useIsolateScope);

            var manager = new TemplateManager(language.UseKernel(kernel), kernel);
            return manager;
        }

        public static TemplateManager ForTypeScript(string version)
        {
            throw new NotImplementedException();
        }

        #endregion Initializers
    }
}