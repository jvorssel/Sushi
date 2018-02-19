using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Common.Utility;
using ModelConverter.Interfaces;
using ModelConverter.Interfaces.Models;

namespace ModelConverter
{
    public class ConversionKernel
    {
        public List<ILanguageSpecification> Languages { get; } = new List<ILanguageSpecification>();

        public ConversionKernel AddLanguage(ILanguageSpecification language)
        {
            if (Languages.Any(x => x.Language == language.Language && x.Version == language.Version))
                throw Errors.DuplicateLanguageSpecification(language);

            Languages.Add(language);
            return this;
        }

        public ConversionKernel()
        {
            // TODO: Load base languages.
        }

        public static ModelConverter Initialize(Assembly assembly)
        {
            var models = assembly.ExportedTypes
                .Where(x => x.IsTypeOrInheritsOf(typeof(IModelToConvert)))
                .ToList();

            return new ModelConverter(models);
        }
    }
}
