using System;
using System.Collections.Generic;
using System.IO;
using Common.Utility;
using ModelConverter.Interfaces;
using ModelConverter.Languages;
using ModelConverter.Properties;

namespace ModelConverter.Templates
{
    public class DefaultTemplates
    {
        /// <summary>
        ///     Load the <see cref="ILanguageSpecification"/>(s) for the files available by default.
        /// </summary>
        public static IEnumerable<ILanguageSpecification> EcmaScript()
        {
            var directory = Path.Combine(Environment.CurrentDirectory, @"Templates\");

            yield return new EcmaSpecification("JavaScript", new Version(5, 0), true).UseTemplate(Resources.V5_Isolated.GetString());

            yield return new EcmaSpecification("JavaScript", new Version(5, 0)).UseTemplate(Resources.V5.GetString());

            yield return new EcmaSpecification("JavaScript", new Version(6, 0)).UseTemplate(Resources.V6.GetString());
        }

    }
}
