// /***************************************************************************\
// Module Name:       ModelConverter.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 03-01-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System.Reflection;
using System.Text;
using Sushi.Descriptors;
using Sushi.Documentation;
using Sushi.Interfaces;

#endregion

namespace Sushi.Converters
{
	public abstract class ModelConverter<TConverter> where TConverter : ModelConverter<TConverter>
	{
		protected readonly SushiConverter Converter;
		protected readonly XmlDocumentationReader XmlDocument;
		protected readonly HashSet<ClassDescriptor> Models;
		protected readonly HashSet<EnumDescriptor> EnumModels;
		protected IScriptTypeConverter ScriptTypeConverter = null;

		protected bool ExcludeComments { get; set; }

		/// <summary>
		///     The amount of <see cref="Models" /> found in the given <see cref="Assembly" />.
		/// </summary>
		protected ModelConverter(SushiConverter converter)
		{
			Converter = converter;
			XmlDocument = Converter.Documentation;
			Models = converter.Models;
			EnumModels = converter.EnumModels;
		}


		public TConverter NoComments()
		{
			ExcludeComments = true;
			return (TConverter)this;
		}

		/// <summary>
		///     Join one or more given <paramref name="models" /> and maybe <paramref name="minify" />
		///     them to create one <see cref="string" />.
		/// </summary>
		public override string ToString()
		{
			var builder = new StringBuilder();
			foreach (var enumModel in EnumModels)
				builder.AppendLine(enumModel.Script);

			foreach (var model in Models.Flatten())
				builder.AppendLine(model.Script);

			var result = builder.ToString();
			return result;
		}

		/// <summary>
		///     Compile the models in the converter.
		/// </summary>
		public abstract TConverter Convert();
	}
}