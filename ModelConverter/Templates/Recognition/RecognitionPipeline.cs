using System.Collections.Generic;
using ModelConverter.Models;
using ModelConverter.Templates.Languages;

namespace ModelConverter.Templates.Recognition
{
    /// <summary>
    ///     Manage the recognition method used when an object is parsed to the generated constructor.
    /// </summary>
    /// <remarks>
    ///     These templates are not type-specific (yet). 
    ///     Will be used for every generated file with matching property type(s).
    /// </remarks>
    public abstract class RecognitionPipeline
    {
        public abstract IEnumerable<string> CreateStatements(LanguageSpecification language, ConversionKernel kernel, Property property);
    }
}