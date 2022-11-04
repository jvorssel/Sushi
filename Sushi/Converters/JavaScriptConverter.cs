﻿// /***************************************************************************\
// Module Name:       JavaScriptConverter.cs
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
using System.Collections;
using System.Text;
using Sushi.Descriptors;
using Sushi.Documentation;
using Sushi.Enum;
using Sushi.Extensions;
using Sushi.Interfaces;

#endregion

namespace Sushi.Converters
{
	/// <summary>
	///     Add the JavaScript class declaration to the <see cref="SushiConverter.Models" />.
	/// </summary>
	public class JavaScriptConverter : ModelConverter
	{
		private readonly JavaScriptVersion _version;

		/// <inheritdoc />
		public JavaScriptConverter(SushiConverter converter, JavaScriptVersion version) : base(converter)
		{
			_version = version;
			converter.Models.AssignScriptTypes();
		}

		public void AddPropertySummary(IPropertyDescriptor prop, StringBuilder builder)
		{
			var propertySummary = Converter.Documentation.JsDocPropertySummary(prop);
			if (!propertySummary.IsEmpty())
				builder.AppendLine($"\t{propertySummary}");
		}

		/// <inheritdoc />
		public override void Convert()
		{
			foreach (var model in Converter.Models.Flatten())
			{
				switch (_version)
				{
					case JavaScriptVersion.Es5:
						model.Script = CompileEcmaScript5Classes(model);
						break;
					case JavaScriptVersion.Es6:
						model.Script = CompileEcmaScript6Classes(model);
						break;
					default:
						throw new ArgumentOutOfRangeException(nameof(_version), _version, null);
				}
			}
		}

		public string CompileEcmaScript5Classes(ClassDescriptor model)
		{
			var builder = new StringBuilder();
			builder.Append(Converter.JsDocClassSummary(model));
			builder.AppendLine($"function {model.Name}(value) {{");
			builder.AppendLine("\tif (!(value instanceof Object)) value = {};");
			foreach (var prop in model.Properties)
			{
				AddPropertySummary(prop, builder);
				builder.AppendLine($"\tthis.{prop.Name} = value.{prop.Name};");
			}

			builder.AppendLine("}");

			var script = builder.ToString();
			return script;
		}

		public string CompileEcmaScript6Classes(ClassDescriptor model)
		{
			var builder = new StringBuilder();
			builder.Append(Converter.JsDocClassSummary(model));
			var classDeclaration = $"class {model.Name}";
			if (model.Parent != (ClassDescriptor)null)
				classDeclaration += $" extends {model.Parent.Name}";

			classDeclaration += " {";
			builder.AppendLine(classDeclaration);

			foreach (var prop in model.Properties)
			{
				AddPropertySummary(prop, builder);
				builder.AppendLine($"\t{prop.Name};");
			}

			builder.AppendLine("");
			builder.AppendLine("\tconstructor(value) {");
			if (model.Parent != (ClassDescriptor)null)
			{
				builder.AppendLine("\t\tsuper(value);");
				builder.AppendLine("");
			}

			builder.AppendLine("\t\tif (!(value instanceof Object)) value = {};");

			foreach (var prop in model.Properties)
				builder.AppendLine($"\t\tthis.{prop.Name} = value.{prop.Name};");

			builder.AppendLine("\t}");
			builder.AppendLine("}");

			var script = builder.ToString();
			return script;
		}
	}
}