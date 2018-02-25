using System;
using System.Threading.Tasks;
using Common.Utility.Enum;
using ModelConverter.Languages;

namespace ModelConverter.Interfaces
{
    /// <summary>
    ///     What and how to format specific property(s) for the related code-language.
    /// </summary>
    /// <inheritdoc />
    public interface ILanguageSpecification : IEquatable<LanguageSpecification>
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
        Version Version { get; set; }

        /// <summary>
        ///     If this <see cref="ILanguageSpecification"/> refers to a isolated model instance.
        /// </summary>
        bool IsIsolated { get; set; }

        /// <summary>
        ///     What object path the generated model should be assinged to.
        /// </summary>
        string TargetObject { get; set; }

        /// <summary>
        ///     Format the property of <paramref name="type"/> and <paramref name="name"/>
        ///     to compile for the current <see cref="LanguageSpecification"/>.
        ///  </summary>
        string FormatProperty(CSharpNativeType type, string name);

        /// <summary>
        ///     Format the validation for <paramref name="type"/> and <paramref name="name"/>
        ///     to compile for the current <see cref="LanguageSpecification"/>.
        ///  </summary>
        string FormatRecognition(CSharpNativeType type, string name, string body);

        /// <summary>
        ///     If this <see cref="LanguageSpecification"/> has a template ready.
        /// </summary>
        bool IsLoaded { get; }

        /// <summary>
        ///     Load the file that the <see cref="LanguageSpecification.FilePath"/> directs to.
        /// </summary>
        LanguageSpecification LoadFile();

        /// <summary>
        ///     Start a new <see cref="Task"/> for loading the file that the <see cref="LanguageSpecification.FilePath"/> directs to.
        /// </summary>
        Task<LanguageSpecification> LoadFileAsync();

        /// <summary>
        ///     Use the given <paramref name="template"/>.
        /// </summary>
        LanguageSpecification UseTemplate(string template);
    }
}
