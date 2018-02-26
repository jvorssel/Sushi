using System;
using System.Linq;
using System.Text;
using Common.Utility.Enum.ECMAScript;
using Common.Utility.Helpers;
using ModelConverter.Consistency;
using ModelConverter.Interfaces;
using ModelConverter.Models;
using ModelConverter.Templates.Languages;

namespace ModelConverter.Templates
{
    /// <summary>
    ///     Manages the expected file code-templates.
    /// </summary>
    public class TemplateManager
    {
        public ILanguageSpecification Language { get; }

        private string _result = string.Empty;

        public TemplateManager(ILanguageSpecification language)
        {
            Language = language;
        }

        /// <summary>
        ///     Initialize a <see cref="TemplateManager"/> to work with ECMAScript with a specific <paramref name="version"/>.
        /// </summary>
        /// <param name="kernel">The base <see cref="ConversionKernel"/> instance.</param>
        /// <param name="version">The ECMAScript <paramref name="version"/>.</param>
        /// <param name="useIsolateScope">If the model should be generated in a <paramref name="useIsolateScope"/>.</param>
        /// <returns></returns>
        public static TemplateManager ForEcmaScript(ConversionKernel kernel, EcmaVersion version, bool useIsolateScope)
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

            var manager = new TemplateManager(language);
            return manager;
        }

        public static TemplateManager ForTypeScript(string version)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Compile the given <paramref name="model"/> with the current <see cref="LanguageSpecification"/>.
        /// </summary>
        public TemplateManager Compile(DataModel model)
        {
            var builder = new StringBuilder();
            var template = Language.Template
                .Replace(TemplateKeys.TYPE_NAME_KEY, model.Name);

            var enumerator = new StringEnumerator(template);
            while (enumerator.MoveNext())
            {
                if (enumerator.Current.Contains(TemplateKeys.VALUES_KEY))
                {
                    // Define each property in the template.
                    var propertyBuilder = new StringBuilder();
                    foreach (var property in model.Properties)
                    {
                        var assignStatement = Language.FormatProperty(property);
                        propertyBuilder.AppendLine(assignStatement);
                    }

                    builder.Append(propertyBuilder);
                    
                }else
                    builder.Append(enumerator.Current);
            }

            // Set the model name in the template.


            //builder.Replace(VALUES_KEY, propertyBuilder.ToString());

            _result = builder.ToString();
            return this;
        }

        #region Overrides of Object

        /// <inheritdoc />
        public override string ToString() => _result;

        #endregion
    }
}