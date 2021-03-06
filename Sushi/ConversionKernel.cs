﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Sushi.Attributes;
using Sushi.Consistency;
using Sushi.Descriptors;
using Sushi.Documentation;
using Sushi.Enum;
using Sushi.Extensions;
using Sushi.Interfaces;

namespace Sushi
{
	/// <summary>
	///     Root <see cref="ConversionKernel"/> for converting given <see cref="Models"/> to one of the specified <see cref="Languages"/>.
	/// </summary>
	public class ConversionKernel : IDisposable
	{
		public HashSet<ClassDescriptor> Models { get; } = new HashSet<ClassDescriptor>();

		public XmlDocumentationReader Documentation { get; set; }

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
		///     Used to specify custom <see cref="NativeType"/> handling.
		/// </summary>
		public Dictionary<Type, NativeType> CustomTypeHandling { get; set; }
			= new Dictionary<Type, NativeType>
			{
				{typeof(Guid), NativeType.String},
				{typeof(DateTime), NativeType.String},
				{typeof(TimeSpan), NativeType.String},
			};

		/// <summary>
		///     Add the given <paramref name="types"/> to use for conversion.
		/// </summary>
		public ConversionKernel AddModes(IEnumerable<Type> types)
		{
			foreach (var model in types.Select(x => new ClassDescriptor(x)))
				Models.Add(model);

			return this;
		}

		/// <summary>
		///     Add the given <paramref name="types"/> to use for conversion.
		/// </summary>
		public ConversionKernel AddModels(params Type[] types)
		{
			foreach (var model in types.Select(x => new ClassDescriptor(x)))
				Models.Add(model);

			return this;
		}

		/// <summary>
		///     Initialize a new <see cref="ConversionKernel"/> with given <paramref name="types"/> for <see cref="Models"/>.
		/// </summary>
		public ConversionKernel(IEnumerable<Type> types)
		{
			_assembly = types.First().Assembly;
			if (types.Any(x => x.Assembly != _assembly))
				throw Errors.OneAssemblyExpected();

			foreach (var type in types)
			{
				var hasScriptAttr = type.GetCustomAttributes(typeof(ConvertToScriptAttribute)).Any();
				var isScriptModel = type.IsTypeOrInheritsOf(typeof(IScriptModel));
				var attrs = type.GetCustomAttributes(typeof(IgnoreForScript), true);
				if (attrs.Any() || (!isScriptModel && !hasScriptAttr))
					continue;

				Models.Add(new ClassDescriptor(type));
			}
		}

		/// <summary>
		///     Initialize a new <see cref="ConversionKernel"/> with given <paramref name="models"/>.
		/// </summary>
		public ConversionKernel(IEnumerable<ClassDescriptor> models)
		{
			Models = new HashSet<ClassDescriptor>(models);
		}

		/// <summary>
		///     Initialize a new <see cref="ConversionKernel"/> with models that 
		///     inherit <see cref="IScriptModel"/> in the given <paramref name="assembly"/>.
		/// </summary>
		public ConversionKernel(Assembly assembly)
		{
			_assembly = assembly;
			// Find the models in the given assembly.
			var models = assembly.ExportedTypes
				.Where(x => x.IsTypeOrInheritsOf(typeof(IScriptModel)) ||
					x.GetCustomAttributes(typeof(ConvertToScriptAttribute), true).Any())
				.Where(x => !x.GetCustomAttributes(typeof(IgnoreForScript), true).Any())
				.Where(x => !x.IsInterface && x.BaseType != typeof(System.Enum))
				.ToList();

			Models = new HashSet<ClassDescriptor>(models.Select(x => new ClassDescriptor(x)));
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
		public void Dispose() { }

		~ConversionKernel()
		{
			Dispose();
		}

		#endregion
	}
}