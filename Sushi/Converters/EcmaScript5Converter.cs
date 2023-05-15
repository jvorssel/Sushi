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
		public override IEnumerable<string> ConvertToScript()
		{
			foreach (var model in Models.Flatten())
				yield return Compile(model);
		}

		public EcmaScript5Converter IncludeUnderscoreMapper()
		{
			_includeUnderscoreExtend = true;
			return this;
		}

		private string Compile(ClassDescriptor model)
		{
			var summary = ExcludeComments || XmlDocument == null ? string.Empty : XmlDocument.JsDocClassSummary(model) + "\n";
			var properties = new StringBuilder();
			foreach (var prop in model.Properties)
				properties.AppendLine($"{Indent}this.{ApplyCasingStyle(prop.Name)} = value.{ApplyCasingStyle(prop.Name)};");

			var template =
				$@"{summary}function {model.Name}(obj) {{
{Indent}var value = obj;
{Indent}if (!(value instanceof Object)) 
{Indent}{Indent}value = {{}};

{properties}
}}
";
			if (_includeUnderscoreExtend)
			{
				template += 
					$@"
{model.Name}.prototype.mapFrom = function(obj) {{
{Indent}return _.extend(new {model.Name}(), obj); 
}};
";
			}
			
			return template;
		}
	}
}