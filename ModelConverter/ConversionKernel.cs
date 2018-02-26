using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Common.Utility;
using ModelConverter.Consistency;
using ModelConverter.Interfaces;
using ModelConverter.Interfaces.Models;
using ModelConverter.Templates;

namespace ModelConverter
{
    public class ConversionKernel : IDisposable
    {
        private ModelConverter _instance = null;
        public List<ILanguageSpecification> Languages { get; } = new List<ILanguageSpecification>();

        public string ArgumentName { get; set; }
            = @"value";

        public string ObjectPropertyMissing { get; set; }
            = @"Given object is expected to have a property with name: '{0}'.";

        public string PropertyTypeMismatch { get; set; }
            = @"Given object property '{0}' is expected to be a {1}.";

        public string PropertyInstanceMismatch { get; set; }
            = @"Given object property '{0}' is expected to be an instance of the '{1}' constructor.";

        public ConversionKernel AddLanguage(ILanguageSpecification language)
        {
            if (Languages.Any(x => x == language))
                throw Errors.DuplicateLanguageSpecification(language);

            Languages.Add(language);
            return this;
        }

        public ConversionKernel()
        {
            Languages.AddRange(DefaultTemplates.JavaScript());
        }

        /// <summary>
        ///     Create a instance of a <see cref="ModelConverter"/> for a specific <paramref name="template"/>.
        /// </summary>
        public ModelConverter CreateConverter(Assembly assembly, TemplateManager template)
        {
            var models = assembly.ExportedTypes
                .Where(x => x.IsTypeOrInheritsOf(typeof(IModelToConvert)))
                .ToList();

            _instance = new ModelConverter(this, models, template);
            return _instance;
        }

        #region IDisposable

        /// <inheritdoc />
        public void Dispose()
        {
        }

        ~ConversionKernel()
        {
            Dispose();
        }

        #endregion
    }

    public enum ResourceType
    {
        ObjectPropertyMissing,
    }
}
