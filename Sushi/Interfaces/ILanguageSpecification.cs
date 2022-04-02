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
        
        IConditionSpecification ConditionSpecification { get; }

        /// <summary>
        ///     Use the given <paramref name="template"/>.
        /// </summary>
        ILanguageSpecification UseTemplate(string template);

        /// <summary>
        ///     Use the given <paramref name="template"/> to wrap around the generated <see cref="TemplateKeys.SCRIPT_MODELS"/>.
        /// </summary>
        /// <remarks>
        ///     Requires the <see cref="TemplateKeys.SCRIPT_MODELS"/> placeholder to be available.
        /// </remarks>
        ILanguageSpecification UseWrapTemplate(string template, WrapTemplateUsage usage);

        /// <summary>
        ///     Format the <paramref name="descriptor"/> to compile for the current <see cref="BaseLanguageSpecification"/>.
        ///  </summary>
        IEnumerable<string> FormatProperty(Converter converter, IPropertyDescriptor descriptor);

        /// <summary>
        ///     Format the validation for the <paramref name="descriptors"/> to compile for the current <see cref="BaseLanguageSpecification"/>.
        ///  </summary>
        IEnumerable<ScriptConditionDescriptor> FormatStatements(Converter converter, List<IPropertyDescriptor> descriptors);

        /// <summary>
        ///     Get the default <see cref="string"/> value that reflects the given <see cref="NativeType"/> 
        ///     for the current Language.
        /// </summary>
        string GetDefaultForProperty(Converter converter, IPropertyDescriptor descriptor);

        /// <summary>
        ///     Format the given <see cref="descriptor"/> to be defined in the current Language.
        /// </summary>
        IEnumerable<string> FormatPropertyDefinition(Converter converter, IPropertyDescriptor descriptor);

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
