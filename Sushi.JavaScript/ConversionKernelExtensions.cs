using System;
using Sushi.Consistency;
using Sushi.Enum;
using Sushi.Interfaces;
using Sushi.JavaScript.Enum;
using Sushi.JavaScript.Properties;

namespace Sushi.JavaScript
{
    public static class ConversionKernelExtensions
    {
        /// <summary>
        ///     Initialize a <see cref="ModelConverter"/> to work with ECMAScript with a specific <paramref name="version"/>.
        /// </summary>
        /// <param name="this">The <see cref="ConversionKernel"/> to use.</param>
        /// <param name="version">The ECMAScript <paramref name="version"/>.</param>
        /// <param name="wrap">If a specific <see cref="Wrap"/> should be used for the generated script model(s).</param>
        /// <returns></returns>
        public static ModelConverter CreateConverterForJavaScript(this ConversionKernel @this, JavaScriptVersion version, Wrap wrap = Wrap.None)
        {
            ILanguageSpecification language;
            switch (version)
            {
                case JavaScriptVersion.V6:
                    language = new JavaScriptSpecification().UseTemplate(Resources.V6);
                    break;
                case JavaScriptVersion.V5:
                    language = new JavaScriptSpecification().UseTemplate(Resources.V5);
                    break;
                default:
                    throw Errors.LanguageNotFound();
            }

            switch (wrap)
            {
                case Wrap.AMD:
                    language = language.UseWrapTemplate(Resources.dependency_injection, WrapTemplateUsage.Global);
                    break;
                case Wrap.SIAF:
                    language = language.UseWrapTemplate(Resources.isolated_self_invokation, WrapTemplateUsage.Global);
                    break;
                case Wrap.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(wrap), wrap, null);
            }

            var converter = @this.CreateConverterForTemplate(language);
            return converter;
        }

        /// <summary>
        ///     Simple fix to include the <see cref="ConversionKernel.CustomTypeHandling"/>.
        /// </summary>
        public static NativeType IncludeOverride(this NativeType @this, ConversionKernel kernel, Type type) 
            => kernel.CustomTypeHandling.ContainsKey(type) ? kernel.CustomTypeHandling[type] : @this;
    }
}
