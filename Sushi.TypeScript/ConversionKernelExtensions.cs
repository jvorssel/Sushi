using System;
using Sushi.Consistency;
using Sushi.Extensions;
using Sushi.Interfaces;
using Sushi.TypeScript.Properties;

namespace Sushi.TypeScript
{
    public static class ConversionKernelExtensions
    {
        /// <summary>
        ///     Initialize a <see cref="ModelConverter"/> to work with TypeScript.
        /// </summary>
        /// <param name="this">The <see cref="ConversionKernel"/> to use.</param>
        /// <returns></returns>
        public static ModelConverter CreateConverterForTypeScript(this ConversionKernel @this)
        {
            ILanguageSpecification language = new TypeScriptSpecification().UseTemplate(Resources.template.GetString());

            var converter = @this.CreateConverterForTemplate(language);
            return converter;
        }
    }
}
