using System;
using System.Collections.Generic;
using System.Reflection;
using Common.Utility.Enum.ECMAScript;

namespace ModelConverter
{
    public class ModelConverter
    {
        internal List<Type> Models { get; }
        internal TemplateManager Template;
        
        /// <summary>
        ///     The amount of <see cref="Models"/> found in the given <see cref="Assembly"/>.
        /// </summary>
        public long ModelCount => Models.Count;

        public ModelConverter(List<Type> models)
        {
            Models = models;
        }

        /// <summary>
        ///     Tell the <see cref="ModelConverter"/> to export the <see cref="Models"/> to the given <see cref="EcmaVersion"/>.
        /// </summary>
        public ModelConverter ForEcmaVersion(EcmaVersion version = EcmaVersion.V6, bool useIsolateScope = true)
        {
            if (Template != null)
                throw Errors.LanguageAlreadyDefined();

            Template = TemplateManager.ForEcmaScript(version, useIsolateScope);

            return this;
        }

        /// <summary>
        ///     Tell the <see cref="ModelConverter"/> to export the <see cref="Models"/> to the given <paramref name="version"/>.
        /// </summary>
        public ModelConverter ForTypeScriptVersion(string version)
        {
            if (Template != null)
                throw Errors.LanguageAlreadyDefined();

            Template = TemplateManager.ForTypeScript(version);

            return this;
        }
    }
}