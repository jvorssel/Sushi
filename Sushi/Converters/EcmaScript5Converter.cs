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

using System;
using System.Text;
using Sushi.Descriptors;
using Sushi.Documentation;
using Sushi.Enum;

#endregion

namespace Sushi.Converters
{
	/// <summary>
	///     Add the JavaScript class declaration to the <see cref="SushiConverter.Models" />.
	/// </summary>
	public class EcmaScript5Converter : ModelConverter<EcmaScript5Converter>
	{
		/// <inheritdoc />
		public EcmaScript5Converter(SushiConverter converter) : base(converter)
		{}

		/// / <inheritdoc />
		public override EcmaScript5Converter ConvertClasses()
		{
			foreach (var model in Converter.Models.Flatten())
			{
				model.Script = Compile(model);
			}

			return this;
		}

		private string Compile(ClassDescriptor model)
		{
			var summary = ExcludeComments ? string.Empty : Converter.JsDocClassSummary(model) + "\n";
			var properties = new StringBuilder();
			foreach (var prop in model.Properties)
				properties.AppendLine($"\tthis.{prop.Name} = value.{prop.Name};");

			var template =
				$@"{summary}function {model.Name}(obj) {{
	var value = obj;
	if (!(value instanceof Object)) 
		value = {{}};

{properties}
}}
";
			return template;
		}
	}
}