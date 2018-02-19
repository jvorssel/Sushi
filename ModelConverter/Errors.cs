using System;
using ModelConverter.Interfaces;

namespace ModelConverter
{
    /// <summary>
    ///     Container class to keep the error messages in one place.
    /// </summary>
    public static class Errors
    {
        public static InvalidOperationException LanguageAlreadyDefined()
            => new InvalidOperationException($@"A conversion target has already been specified, use the '{nameof(ConversionKernel)}' to create a new instance.");

        public static InvalidOperationException NoLanguageDefined()
            => new InvalidOperationException(@"Expected a target language to be defined.");

        public static InvalidOperationException DuplicateLanguageSpecification(ILanguageSpecification lang)
            => new InvalidOperationException($@"The language specification '{lang.Language} - V{lang.Version}' is already present.");
    }
}