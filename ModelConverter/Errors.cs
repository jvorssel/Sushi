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

        public static Exception NonExistentLanguageFile(string path)
            => new InvalidOperationException($"The {nameof(path)} to the language template does not direct to a existing file. \n\r Path '{path}'.");

        public static Exception LanguageNotFound(Version version, bool useIsolateScope)
            => new ArgumentException($@"No default or custom {nameof(ILanguageSpecification)} found for given arguments '{version}' and '{nameof(useIsolateScope)}:{useIsolateScope}'.");
    }
}