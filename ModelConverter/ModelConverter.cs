using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Common.Utility.Enum.ECMAScript;
using ModelConverter.Consistency;
using ModelConverter.Models;
using ModelConverter.Templates;

namespace ModelConverter
{
    public class ModelConverter
    {
        public IReadOnlyList<DataModel> Models { get; }
        public TemplateManager Template;

        /// <summary>
        ///     The amount of <see cref="Models"/> found in the given <see cref="Assembly"/>.
        /// </summary>
        public long ModelCount => Models.Count;

        public ModelConverter(ConversionKernel kernel, IEnumerable<Type> models, TemplateManager template)
        {
            Models = models.Select(x => new DataModel(x)).ToList();
            Template = template;
        }

        /// <summary>
        ///     Tell the <see cref="ModelConverter"/> to export the <see cref="Models"/> to the given <see cref="EcmaVersion"/>.
        /// </summary>
        public ModelConverter ForEcmaVersion(ConversionKernel kernel, EcmaVersion version = EcmaVersion.V6, bool useIsolateScope = true)
        {
            if (Template != null)
                throw Errors.LanguageAlreadyDefined();

            Template = TemplateManager.ForJavaScript(kernel, version, useIsolateScope);

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

        public string Convert(Func<DataModel, bool> predicate = null)
        {
            var builder = new StringBuilder();

            var enumerable = (predicate == null ? Models : Models.Where(predicate)).ToList();

            foreach (var model in enumerable)
            {
                var scriptModel = Template.Compile(model, enumerable).ToString();

                builder.AppendLine(scriptModel);
            }

            return builder.ToString();
        }
    }
}