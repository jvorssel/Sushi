using Common.Utility.Enum;

namespace ModelConverter
{
    /// <summary>
    ///     Manage the recognition method used when an object is parsed to the generated constructor.
    /// </summary>
    /// <remarks>
    ///     These templates are not type-specific (yet). 
    ///     Will be used for every generated file with matching property type(s).
    /// </remarks>
    internal class RecognitionPipeline
    {
        internal static RecognitionPipeline ForType(CSharpNativeType type)
        {
            return new RecognitionPipeline();
        }
    }
}