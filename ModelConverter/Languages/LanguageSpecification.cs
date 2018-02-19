using System;
using System.Threading.Tasks;
using Common.Utility.Enum;
using ModelConverter.Interfaces;

namespace ModelConverter.Languages
{
    /// <inheritdoc />
    public class LanguageSpecification : ILanguageSpecification
    {
        private string _template = string.Empty;

        /// <inheritdoc />
        public string FilePath { get; set; }

        /// <inheritdoc />
        public string Language { get; set; }

        /// <inheritdoc />
        public string Version { get; set; }

        /// <inheritdoc />
        public string FormatProperty(CSharpNativeType type, string name)
        {
            return string.Empty;
        }

        /// <inheritdoc />
        public string FormatValidation(CSharpNativeType type, string name, string body)
        {
            return string.Empty;
        }

        /// <inheritdoc />
        public bool IsLoaded() => _template != string.Empty;

        /// <inheritdoc />
        public LanguageSpecification LoadFile()
        {
            _template = string.Empty;
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<LanguageSpecification> LoadFileAsync()
        {
            _template = string.Empty;
            throw new NotImplementedException();
        }
    }
}