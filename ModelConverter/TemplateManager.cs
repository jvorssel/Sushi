using System;
using System.Collections.Generic;
using System.Linq;
using Common.Utility.Enum.ECMAScript;
using ModelConverter.Interfaces;
using ModelConverter.Languages;

namespace ModelConverter
{
    /// <summary>
    ///     Manages the expected file code-templates.
    /// </summary>
    public class TemplateManager
    {
        public ILanguageSpecification Language { get; }

        private const string TYPENAME_KEY = @"$$TYPENAME$$";
        private const string VALIDATION_KEY = @"$$VALIDATE_OBJECT$$";
        private const string VALUES_KEY = @"$$SET_VALUES$$";

        private string _template = string.Empty;

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
    }
}