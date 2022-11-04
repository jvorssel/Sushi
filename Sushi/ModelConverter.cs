// /***************************************************************************\
// Module Name:       ModelConverter.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 04-11-2022
// Copyright:              Royaldesk @ 2022
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Sushi.Consistency;
using Sushi.Descriptors;
using Sushi.Documentation;
using Sushi.Extensions;
using Sushi.Interfaces;

#endregion

namespace Sushi
{
	public abstract class ModelConverter
	{
		protected readonly SushiConverter Converter;
		protected readonly XmlDocumentationReader XmlDocument;
		protected readonly ILanguageSpecification Language ;
		protected readonly HashSet<ClassDescriptor> Models;

		/// <summary>
		///     The amount of <see cref="Models" /> found in the given <see cref="Assembly" />.
		/// </summary>
		public ModelConverter(SushiConverter converter, ILanguageSpecification language)
		{
			Language = language;
			Converter = converter;
			XmlDocument = Converter.Documentation;
			Models = converter.Models;
		}


		/// <summary>
		///     Join one or more given <paramref name="models" /> and maybe <paramref name="minify" />
		///     them to create one <see cref="string" />.
		/// </summary>
		public string MergeModelsToString()
		{
			var builder = new StringBuilder();
			foreach (var model in Models.Flatten())
				builder.AppendLine(model.Script);

			var result = builder.ToString();
			return result;
		}


		/// <summary>
		///     Compile the models in the converter with the given <paramref name="version"/>.
		/// </summary>
		public abstract void Convert();

		/// <summary>
		///     Write the given <see cref="ClassDescriptor" /> <paramref name="models" /> to the
		///     <paramref name="fileName" /> in the given folder <paramref name="path" />.
		/// </summary>
		/// <param name="models">The <see cref="ClassDescriptor" /> <see cref="IEnumerable{T}" /> with the models to write.</param>
		/// <param name="path">The <paramref name="path" /> to the folder to store the file in.</param>
		/// <param name="fileName">The <paramref name="fileName" /> for the generated file.</param>
		/// <param name="minify">If the comments, newline, tabs, etc should be removed from the file contents.</param>
		/// <param name="encoding">What <see cref="Encoding" /> method should be used to create the file.</param>
		public void WriteToFile(string path, Encoding encoding = null)
		{
			if (path.IsEmpty())
				throw new ArgumentNullException(nameof(path));

			if (Models.EmptyIfNull().All(x => x.Script?.IsEmpty() ?? true))
				throw Errors.NoScriptAvailableInModels(nameof(Models));

			var fileContent = MergeModelsToString();
			File.WriteAllText(path, fileContent, encoding ?? Encoding.Default);
		}
	}
}