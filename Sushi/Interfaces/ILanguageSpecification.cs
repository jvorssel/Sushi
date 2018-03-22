using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sushi.Consistency;
using Sushi.Enum;
using Sushi.Models;

namespace Sushi.Interfaces
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
        string FilePath { get; }

        /// <summary>
        ///     What file extension should be used for this <see cref="ILanguageSpecification"/>.
        /// </summary>
        string Extension { get; }

        /// <summary>
        ///     The <see cref="Language"/> (key) for this <see cref="LanguageSpecification"/>.
        /// </summary>
        string Language { get; }

        /// <summary>
        ///     The <see cref="Version"/> (key) for this <see cref="LanguageSpecification"/>.
        /// </summary>
        Version Version { get; }

        /// <summary>
        ///     If this <see cref="ILanguageSpecification"/> refers to a isolated model instance.
        /// </summary>
        bool IsIsolated { get; }

        /// <summary>
        ///     What object path the generated model should be assigned to.
        /// </summary>
        string TargetObject { get; set; }

        /// <summary>
        ///     If this <see cref="LanguageSpecification"/> has a template ready.
        /// </summary>
        bool IsLoaded { get; }

        /// <summary>
        ///     The <see cref="Template"/> text that has been loaded into this <see cref="ILanguageSpecification"/>.
        /// </summary>
        string Template { get; }

        /// <summary>
        ///     The <see cref="StatementPipeline"/> used to format different validation / recognition statements.
        /// </summary>
        StatementPipeline StatementPipeline { get; }

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

        /// <summary>
        ///     List the <see cref="TemplateKeys"/> that are not used by the given <paramref name="template"/>.
        /// </summary>
        IEnumerable<string> ValidateTemplate(string template);

        /// <summary>
        ///     Format the <paramref name="property"/> to compile for the current <see cref="LanguageSpecification"/>.
        ///  </summary>
        IEnumerable<string> FormatProperty(ConversionKernel kernel, Property property);

        /// <summary>
        ///     Format the validation for the <paramref name="properties"/> to compile for the current <see cref="LanguageSpecification"/>.
        ///  </summary>
        IEnumerable<Statement> FormatStatements(ConversionKernel kernel, List<Property> properties, List<DataModel> referenceDataModels);

        /// <summary>
        ///     Format the given <see cref="DataModel"/> <paramref name="inherits"/>
        ///     to be available on the current <see cref="DataModel"/>.
        /// </summary>
        Statement FormatInheritanceStatement(DataModel model, DataModel inherits);

        /// <summary>
        ///     Get the default <see cref="string"/> value that reflects the given <see cref="CSharpNativeType"/> 
        ///     for the current <see cref="Language"/>.
        /// </summary>
        string GetDefaultForProperty(Property property);

        /// <summary>
        ///     Apply formatting to the given <paramref name="value"/> of <see cref="CSharpNativeType"/>.
        /// </summary>
        string FormatValueForProperty(Property property, object value);

        /// <summary>
        ///     Format the given <see cref="property"/> to be defined in the current <see cref="Language"/>.
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="property"></param>
        /// <param name="relatedTypes"></param>
        /// <returns></returns>
        IEnumerable<string> FormatPropertyDefinition(ConversionKernel kernel,
            Property property,
            ICollection<DataModel> relatedTypes);

        /// <summary>
        ///     Format the given <paramref name="comment"/> for this <see cref="Language"/>.
        /// </summary>
        Statement FormatComment(string comment, StatementType relatedType);

        /// <summary>
        ///     Remove comments from the <see cref="DataModel.Script"/>.
        /// </summary>
        string RemoveComments(DataModel model);
    }
}
