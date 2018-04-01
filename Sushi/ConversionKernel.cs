using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Sushi.Attributes;
using Sushi.Consistency;
using Sushi.Documentation;
using Sushi.Extensions;
using Sushi.Interfaces;
using Sushi.Models;

namespace Sushi
{
    /// <summary>
    ///     Root <see cref="ConversionKernel"/> for converting given <see cref="Models"/> to one of the specified <see cref="Languages"/>.
    /// </summary>
    public class ConversionKernel : IDisposable
    {
        public HashSet<DataModel> Models { get; } = new HashSet<DataModel>();

        public XmlDocumentationReader Documentation { get; private set; } = null;

        public string BaseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
        private readonly Assembly _assembly;

        public long ModelCount => Models.Count;

        public string ArgumentName { get; set; }
            = @"value";

        public string ObjectPropertyMissing { get; set; }
            = @"Given object is expected to have a property with name: '{0}'.";

        public string PropertyTypeMismatch { get; set; }
            = @"Given object property '{0}' is expected to be a {1}.";

        public string PropertyInstanceMismatch { get; set; }
            = @"Given object property '{0}' is expected to be an instance of the '{1}' constructor.";

        /// <summary>
        ///     Add the given <paramref name="types"/> to use for conversion.
        /// </summary>
        public ConversionKernel AddModes(IEnumerable<Type> types)
        {
            foreach (var model in types.Select(x => new DataModel(x)))
                Models.Add(model);

            return this;
        }

        /// <summary>
        ///     Add the given <paramref name="types"/> to use for conversion.
        /// </summary>
        public ConversionKernel AddModels(params Type[] types)
        {
            foreach (var model in types.Select(x => new DataModel(x)))
                Models.Add(model);

            return this;
        }

        /// <summary>
        ///     Initialize a new <see cref="ConversionKernel"/> with given <paramref name="types"/> for <see cref="Models"/>.
        /// </summary>
        public ConversionKernel(IEnumerable<Type> types)
            : this(types.Select(x => new DataModel(x)))
        {
        }

        /// <summary>
        ///     Initialize a new <see cref="ConversionKernel"/> with given <paramref name="models"/>.
        /// </summary>
        public ConversionKernel(IEnumerable<DataModel> models)
        {
            Models = new HashSet<DataModel>(models);
        }

        /// <summary>
        ///     Initialize a new <see cref="ConversionKernel"/> with models that 
        ///     inherit <see cref="IModelToConvert"/> in the given <paramref name="assembly"/>.
        /// </summary>
        public ConversionKernel(Assembly assembly)
        {
            _assembly = assembly;
            // Find the models in the given assembly.
            var models = assembly.ExportedTypes
                .Where(x => x.IsTypeOrInheritsOf(typeof(IModelToConvert)) || x.GetCustomAttributes(typeof(ConvertToScriptAttribute), true).Any())
                .Where(x => !x.GetCustomAttributes(typeof(IgnoreForScript), true).Any())
                .Where(x => !x.IsInterface)
                .ToList();

            Models = new HashSet<DataModel>(models.Select(x => new DataModel(x)));
        }

        /// <summary>
        ///     Create a <see cref="ModelConverter"/> for a custom <see cref="ILanguageSpecification"/>.
        /// </summary>
        public ModelConverter CreateConverterForTemplate(ILanguageSpecification language)
        {
            var converter = new ModelConverter(this, language);
            return converter;
        }

        /// <summary>
        ///     Use the xml documentation file in bin folder for the given <paramref name="assembly"/>.
        /// </summary>
        public ConversionKernel LoadXmlDocumentation()
        {
            var assemblyName = _assembly.GetProjectName();
            var xmlDocPath = Path.Combine(BaseDirectoryPath, $"{assemblyName}.xml");
            return LoadXmlDocumentation(xmlDocPath);
        }

        /// <summary>
        ///     Use the xml documentation generated on build.
        /// </summary>
        public ConversionKernel LoadXmlDocumentation(string path)
        {
            var extension = Path.GetExtension(path);
            if (extension != ".xml")
                throw Errors.XmlDocumentExpected(path);

            Documentation = new XmlDocumentationReader(path).Initialize();

            return this;
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
}
