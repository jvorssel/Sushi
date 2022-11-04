using System.Collections.Generic;
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
        ///     Format the <paramref name="descriptor"/> to compile for the current <see cref="BaseLanguageSpecification"/>.
        ///  </summary>
        IEnumerable<string> FormatProperty(SushiConverter converter, IPropertyDescriptor descriptor);

        /// <summary>
        ///     Get the default <see cref="string"/> value that reflects the given <see cref="NativeType"/> 
        ///     for the current Language.
        /// </summary>
        string GetDefaultForProperty(SushiConverter converter, IPropertyDescriptor descriptor);
    }
}
