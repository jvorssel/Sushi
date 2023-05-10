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
using Sushi.Enum;
using Sushi.Interfaces;

#endregion

namespace Sushi.Converters
{
	public abstract class ModelConverter<TConverter> where TConverter : ModelConverter<TConverter>
	{
		public string Indent { get; }
		public PropertyNameCasing Casing { get; }
		
		protected readonly XmlDocumentationReader? XmlDocument = null;
		protected readonly HashSet<ClassDescriptor> Models;
		protected readonly HashSet<EnumDescriptor> EnumModels;
		protected IScriptTypeConverter ScriptTypeConverter = null;
		

		protected bool ExcludeComments { get; set; }

		/// <summary>
		///     The amount of <see cref="Models" /> found in the given <see cref="Assembly" />.
		/// </summary>
		protected ModelConverter(SushiConverter converter, string indent, PropertyNameCasing casing)
		{
			Indent = indent;
			Casing = casing;
			XmlDocument = converter.Documentation;
			Models = converter.Models;
			EnumModels = converter.EnumModels;
		}


		public TConverter NoComments()
		{
			ExcludeComments = true;
			return (TConverter)this;
		}

		/// <summary>
		///		Write the resulting script values from the enum and class models to a string.
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

		/// <summary>
		///		Apply the chosen <see cref="Casing"/> to the given <paramref name="value"/>.
		/// </summary>
		public string ApplyCasingStyle(string value)
		{
			switch (Casing)
			{
				case PropertyNameCasing.Default:
					return value;
				case PropertyNameCasing.CamelCase:
					return Char.ToLowerInvariant(value[0]) + value.Substring(1);
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}