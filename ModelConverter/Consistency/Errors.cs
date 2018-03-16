using System;
using ModelConverter.Interfaces;

namespace ModelConverter.Consistency
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

        public static Exception LanguageNotFound()
            => new ArgumentException($@"No default or custom {nameof(ILanguageSpecification)} found.");

        public static ArgumentException OnlyInlineCommentsSupported(string comment)
            => new ArgumentException($"Only single-line comments are supported. \n\rGiven comment: \r\n\r\n{comment}", nameof(comment));

        public static InvalidOperationException LanguageVersionMismatch(Version version)
            => new InvalidOperationException($@"Unexpected version '{version}' type wasn't processed properly.");

        public static InvalidOperationException PropertyTypeNotSupported(string typeName)
            => new InvalidOperationException($@"Given {typeName} is not processed by the current {nameof(LanguageSpecification)}.");
    }
}