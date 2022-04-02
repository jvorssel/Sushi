using System;
using Sushi.Extensions;
using Sushi.Interfaces;
using Sushi.TypeScript.Properties;
using Sushi.TypeScript.Specifications;

namespace Sushi.TypeScript
{
    public static class ConverterExtensions
    {
        /// <summary>
        ///     Initialize a <see cref="ModelConverter"/> to work with TypeScript.
        /// </summary>
        /// <param name="this">The <see cref="Converter"/> to use.</param>
        /// <param name="specification">What <see cref="TypeScriptSpecification"/> you want to use.</param>
        /// <returns></returns>
        public static ModelConverter CreateConverterForTypeScript(this Converter @this, Enum.TypeScriptSpecification specification)
        {
            ILanguageSpecification language;
            switch (specification)
            {
                case Enum.TypeScriptSpecification.TypeScript:
                    language = new TypeScriptSpecification()
                        .UseTemplate(Resources.template.GetString());
                    break;
                case Enum.TypeScriptSpecification.Declaration:
                    language = new DefinitelyTypedSpecification()
                        .UseTemplate(Resources.reference.GetString());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(specification), specification, null);
            }

            var converter = @this.CreateConverterForTemplate(language);
            return converter;
        }
    }
}
