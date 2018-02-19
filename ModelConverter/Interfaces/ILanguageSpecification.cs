using System.Threading.Tasks;
using Common.Utility.Enum;
using ModelConverter.Languages;

namespace ModelConverter.Interfaces
{
    /// <summary>
    ///     What and how to format specific property(s) for the related code-language.
    /// </summary>
    public interface ILanguageSpecification
    {
        /// <summary>
        ///     The directory path to the template file.
        /// </summary>
        string FilePath { get; set; }

        /// <summary>
        ///     The <see cref="Language"/> (key) for this <see cref="LanguageSpecification"/>.
        /// </summary>
        string Language { get; set; }

        /// <summary>
        ///     The <see cref="Version"/> (key) for this <see cref="LanguageSpecification"/>.
        /// </summary>
        string Version { get; set; }

        /// <summary>
        ///     Format the property of <paramref name="type"/> and <paramref name="name"/>
        ///     to compile for the current <see cref="LanguageSpecification"/>.
        ///  </summary>
        string FormatProperty(CSharpNativeType type, string name);

        /// <summary>
        ///     Format the validation for <paramref name="type"/> and <paramref name="name"/>
        ///     to compile for the current <see cref="LanguageSpecification"/>.
        ///  </summary>
        string FormatValidation(CSharpNativeType type, string name, string body);

        /// <summary>
        ///     If this <see cref="LanguageSpecification"/> has a template ready.
        /// </summary>
        bool IsLoaded();

        /// <summary>
        ///     Load the file that the <see cref="LanguageSpecification.FilePath"/> directs to.
        /// </summary>
        LanguageSpecification LoadFile();

        /// <summary>
        ///     Start a new <see cref="Task"/> for loading the file that the <see cref="LanguageSpecification.FilePath"/> directs to.
        /// </summary>
        Task<LanguageSpecification> LoadFileAsync();
    }
}
