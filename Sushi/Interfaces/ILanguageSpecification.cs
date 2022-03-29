using System.Collections.Generic;
using Sushi.Consistency;
using Sushi.Descriptors;
using Sushi.Enum;

namespace Sushi.Interfaces
{
    /// <summary>
    ///     What and how to format specific property(s) for the related code-language.
    /// </summary>
    public interface ILanguageSpecification
    {
        /// <summary>
        ///     What file extension should be used for this <see cref="ILanguageSpecification"/>.
        /// </summary>
        string Extension { get; }

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
        ///     The <see cref="ConditionPipeline"/> used to format different validation / recognition statements.
        /// </summary>
        ConditionPipeline ConditionPipeline { get; }

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
        ///     Format the <paramref name="property"/> to compile for the current <see cref="LanguageSpecification"/>.
        ///  </summary>
        IEnumerable<string> FormatProperty(ConversionKernel kernel, PropertyDescriptor property);

        /// <summary>
        ///     Format the validation for the <paramref name="properties"/> to compile for the current <see cref="LanguageSpecification"/>.
        ///  </summary>
        IEnumerable<ScriptConditionDescriptor> FormatStatements(ConversionKernel kernel, List<PropertyDescriptor> properties);

        /// <summary>
        ///     Get the default <see cref="string"/> value that reflects the given <see cref="NativeType"/> 
        ///     for the current Language.
        /// </summary>
        string GetDefaultForProperty(ConversionKernel kernel, PropertyDescriptor property);

        /// <summary>
        ///     Apply formatting to the given <paramref name="value"/> of <see cref="NativeType"/>.
        /// </summary>
        string FormatValueForProperty(ConversionKernel kernel, PropertyDescriptor property, object value);

        /// <summary>
        ///     Format the given <see cref="property"/> to be defined in the current Language.
        /// </summary>
        IEnumerable<string> FormatPropertyDefinition(ConversionKernel kernel,PropertyDescriptor property);

        /// <summary>
        ///     Format the given <paramref name="comment"/> for this Language.
        /// </summary>
        ScriptConditionDescriptor FormatComment(string comment, ConditionType relatedType);

        /// <summary>
        ///     Remove comments from the <see cref="ClassDescriptor.Script"/>.
        /// </summary>
        string RemoveComments(ClassDescriptor model);
    }
}
