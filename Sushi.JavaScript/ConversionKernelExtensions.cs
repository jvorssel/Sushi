﻿using System;
using Sushi.Consistency;
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
        /// <param name="useIsolateScope">If the model should be generated in a <paramref name="useIsolateScope"/>.</param>
        /// <returns></returns>
        public static ModelConverter CreateConverterForJavaScript(this ConversionKernel @this, JavaScriptVersion version, bool useIsolateScope = false)
        {
            ILanguageSpecification language;
            switch (version)
            {
                case JavaScriptVersion.V6:
                    language = new JavaScriptSpecification("JavaScript", new Version(6, 0)).UseTemplate(Resources.V6);
                    break;
                case JavaScriptVersion.V5:
                    language = new JavaScriptSpecification("JavaScript", new Version(5, 0))
                        .UseTemplate(useIsolateScope ? Resources.V5_Isolated : Resources.V5);
                    break;
                default:
                    throw Errors.LanguageNotFound();
            }

            var converter = @this.CreateConverterForTemplate(language);
            return converter;
        }
    }
}