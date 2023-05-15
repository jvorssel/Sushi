// /***************************************************************************\
// Module Name:       ModelConverter.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 15-05-2023
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
using Sushi.Enum;
using Sushi.Interfaces;

#endregion

namespace Sushi.Converters
{
	public abstract class ModelConverter
	{
		protected string Indent { get; }
		protected PropertyNameCasing CasingStyle { get; }

		protected readonly XmlDocumentationReader? XmlDocument;
		public readonly HashSet<ClassDescriptor> Models;
		public readonly HashSet<EnumDescriptor> EnumModels;

		/// <summary>
		///     The amount of <see cref="Models" /> found in the given <see cref="Assembly" />.
		/// </summary>
		protected ModelConverter(SushiConverter converter, IConverterOptions options)
		{
			Indent = options.Indent;
			CasingStyle = options.CasingStyle;
			XmlDocument = converter.Documentation;
			Models = converter.Models;
			EnumModels = converter.EnumModels;
		}

		/// <summary>
		///     Write the resulting script values from the enum and class models to a string.
		/// </summary>
		public override string ToString()
		{
			var builder = new StringBuilder();
			var descriptors = new DescriptorTreeBuilder(Models)
				.BuildTree()
				.Flatten()
				.ToList();
			
			foreach (var script in ConvertToScript(descriptors))
				builder.AppendLine(script);

			var result = builder.ToString();
			return result;
		}

		/// <summary>
		///     Compile the models in the converter.
		/// </summary>
		protected abstract IEnumerable<string> ConvertToScript(IEnumerable<ClassDescriptor> descriptors);

		/// <summary>
		///     Apply the chosen <see cref="CasingStyle" /> to the given <paramref name="value" />.
		/// </summary>
		public string ApplyCasingStyle(string value)
		{
			return CasingStyle switch
			{
				PropertyNameCasing.Default => value,
				PropertyNameCasing.CamelCase => char.ToLowerInvariant(value[0]) + value.Substring(1),
				_ => throw new ArgumentOutOfRangeException()
			};
		}
	}
}