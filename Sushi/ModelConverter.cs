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

#endregion

namespace Sushi
{
	public abstract class ModelConverter
	{
		protected readonly SushiConverter Converter;
		protected readonly XmlDocumentationReader XmlDocument;
		protected readonly HashSet<ClassDescriptor> Models;
		protected readonly HashSet<EnumDescriptor> EnumModels;

		/// <summary>
		///     The amount of <see cref="Models" /> found in the given <see cref="Assembly" />.
		/// </summary>
		public ModelConverter(SushiConverter converter)
		{
			Converter = converter;
			XmlDocument = Converter.Documentation;
			Models = converter.Models;
			EnumModels = converter.EnumModels;
		}


		/// <summary>
		///     Join one or more given <paramref name="models" /> and maybe <paramref name="minify" />
		///     them to create one <see cref="string" />.
		/// </summary>
		public string MergeModelsToString()
		{
			var builder = new StringBuilder();
			foreach(var enumModel in EnumModels)
				builder.AppendLine(enumModel.Script);
			
			foreach (var model in Models.Flatten())
				builder.AppendLine(model.Script);

			var result = builder.ToString();
			return result;
		}


		/// <summary>
		///     Compile the models in the converter.
		/// </summary>
		public abstract void Convert();

		/// <summary>
		///     Write the generated script values to the file.
		/// </summary>
		/// <param name="path">The <paramref name="path" /> to the folder to store the file in.</param>
		/// <param name="encoding">What <see cref="Encoding" /> method should be used to create the file.</param>
		public void WriteToFile(string path, Encoding encoding = null)
		{
			if (path.IsEmpty())
				throw new ArgumentNullException(nameof(path));

			if (Models.All(x => x.Script?.IsEmpty() ?? true))
				throw Errors.NoScriptAvailableInModels(nameof(Models));

			var fileContent = MergeModelsToString();
			File.WriteAllText(path, fileContent, encoding ?? Encoding.Default);
		}
	}
}