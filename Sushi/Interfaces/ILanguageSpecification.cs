using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sushi.Consistency;
using Sushi.Descriptors;
using Sushi.Enum;

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
        ///     The <see cref="WrapTemplate"/> text that will be used to place the <see cref="TemplateKeys"/>
        /// </summary>
        string WrapTemplate { get; }

        /// <summary>
        ///     When the <see cref="WrapTemplate"/> is used.
        /// </summary>
        WrapTemplateUsage WrapUsage { get; }

        /// <summary>
        ///     The <see cref="StatementPipeline"/> used to format different validation / recognition statements.
        /// </summary>
        ConditionPipeline StatementPipeline { get; }

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
        ///     Use the given <paramref name="template"/> to wrap around the generated <see cref="TemplateKeys.SCRIPT_MODELS"/>.
        /// </summary>
        /// <remarks>
        ///     Requires the <see cref="TemplateKeys.SCRIPT_MODELS"/> placeholder to be available.
        /// </remarks>
        LanguageSpecification UseWrapTemplate(string template, WrapTemplateUsage usage);

        /// <summary>
        ///     List the <see cref="TemplateKeys"/> that are not used by the given <paramref name="template"/>.
        /// </summary>
        IEnumerable<string> ValidateTemplate(string template);

        /// <summary>
        ///     Format the <paramref name="property"/> to compile for the current <see cref="LanguageSpecification"/>.
        ///  </summary>
        IEnumerable<string> FormatProperty(ConversionKernel kernel, PropertyDescriptor property);

        /// <summary>
        ///     Format the validation for the <paramref name="properties"/> to compile for the current <see cref="LanguageSpecification"/>.
        ///  </summary>
        IEnumerable<ScriptConditionDescriptor> FormatStatements(ConversionKernel kernel, List<PropertyDescriptor> properties);

        /// <summary>
        ///     Get the default <see cref="string"/> value that reflects the given <see cref="NativeType"/> 
        ///     for the current <see cref="Language"/>.
        /// </summary>
        string GetDefaultForProperty(ConversionKernel kernel, PropertyDescriptor property);

        /// <summary>
        ///     Apply formatting to the given <paramref name="value"/> of <see cref="NativeType"/>.
        /// </summary>
        string FormatValueForProperty(ConversionKernel kernel, PropertyDescriptor property, object value);

        /// <summary>
        ///     Format the given <see cref="property"/> to be defined in the current <see cref="Language"/>.
        /// </summary>
        IEnumerable<string> FormatPropertyDefinition(ConversionKernel kernel,PropertyDescriptor property);

        /// <summary>
        ///     Format the given <paramref name="comment"/> for this <see cref="Language"/>.
        /// </summary>
        ScriptConditionDescriptor FormatComment(string comment, ConditionType relatedType);

        /// <summary>
        ///     Remove comments from the <see cref="ClassDescriptor.Script"/>.
        /// </summary>
        string RemoveComments(ClassDescriptor model);
    }
}
