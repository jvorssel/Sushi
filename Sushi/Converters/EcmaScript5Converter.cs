// /***************************************************************************\
// Module Name:       JavaScriptConverter.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 01-01-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System.Runtime.InteropServices;
using System.Text;
using Sushi.Descriptors;
using Sushi.Documentation;
using Sushi.Enum;
using Sushi.Interfaces;

#endregion

namespace Sushi.Converters
{
	/// <summary>
	///     Add the JavaScript class declaration to the <see cref="SushiConverter.Models" />.
	/// </summary>
	public sealed class EcmaScript5Converter : ModelConverter
	{
		private bool _includeUnderscoreExtend = false;
		
		/// <inheritdoc />
		public EcmaScript5Converter(SushiConverter converter, IConverterOptions options) : base(converter, options)
		{}

		/// / <inheritdoc />
		protected override IEnumerable<string> ConvertToScript(IEnumerable<ClassDescriptor> descriptors)
		{
			foreach (var model in descriptors)
				yield return Compile(model);
		}

		public EcmaScript5Converter IncludeUnderscoreMapper()
		{
			_includeUnderscoreExtend = true;
			return this;
		}

		private string Compile(ClassDescriptor model)
		{
			var builder = new StringBuilder();
			
			builder.AppendJsDoc(XmlDocument, model);

			builder.AppendLine($"function {model.Name}(obj) {{");
			builder.AppendLine(Indent + "let value = obj;");
			builder.AppendLine(Indent + "if (!(value instanceof Object)) ");
			builder.AppendLine(Indent + Indent + "value = {};");
			builder.AppendLine();
			
			foreach (var prop in model.Properties)
				builder.AppendLine($"{Indent}this.{ApplyCasingStyle(prop.Name)} = value.{ApplyCasingStyle(prop.Name)};");
			builder.AppendLine("}");

			if (!_includeUnderscoreExtend) 
				return builder.ToString();
			
			builder.AppendLine();
			builder.AppendLine($"{model.Name}.prototype.mapFrom = function(obj) {{");
			builder.AppendLine($"{Indent}return _.extend(new {model.Name}(), obj); ");
			builder.AppendLine("};");

			return builder.ToString();
		}
	}
}