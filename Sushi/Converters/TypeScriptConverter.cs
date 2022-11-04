﻿// /***************************************************************************\
// Module Name:       TypeScriptConverter.cs
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
using System.Text;
using Sushi.Descriptors;
using Sushi.Documentation;
using Sushi.Enum;

#endregion

namespace Sushi.Converters
{
	/// <summary>
	///     Add the TypeScript class declaration to the <see cref="SushiConverter.Models" />.
	/// </summary>
	public class TypeScriptConverter : JavaScriptConverter
	{
		private readonly TypeScriptVersion _version;

		/// <inheritdoc />
		public TypeScriptConverter(SushiConverter converter, TypeScriptVersion version)
			: base(converter, JavaScriptVersion.Es6)
		{
			_version = version;
		}

		/// <inheritdoc />
		public override void Convert()
		{
			foreach (var model in Converter.Models.Flatten())
			{
				switch (_version)
				{
					case TypeScriptVersion.Latest:
						model.Script = ToTypeScriptClass(model);
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}

		public void ConvertEnums()
		{
			foreach (var model in Converter.EnumModels)
			{
				var builder = new StringBuilder();
				builder.AppendLine($"export enum {model.Name} {{");
				foreach (var kvp in model.Values)
					builder.AppendLine($"\t{kvp.Key} = {kvp.Value},");
			
				builder.AppendLine("}");
				
				model.Script = builder.ToString();
			}
		}

		private string ToTypeScriptClass(ClassDescriptor model)
		{
			var builder = new StringBuilder();
			builder.Append(Converter.JsDocClassSummary(model));
			var classDeclaration = $"export class {model.Name}";
			if (model.Parent != (ClassDescriptor)null)
				classDeclaration += $" extends {model.Parent.Name}";

			classDeclaration += " {";
			builder.AppendLine(classDeclaration);

			foreach (var prop in model.Properties)
			{
				AddPropertySummary(prop, builder);
				builder.AppendLine($"\t{prop.Name}: {prop.ScriptTypeValue};");
			}

			builder.AppendLine("");

			builder.AppendLine("\tconstructor();");
			builder.AppendLine("\tconstructor(value?: any) {");
			if (model.Parent != (ClassDescriptor)null)
			{
				builder.AppendLine("\t\tsuper();");
				builder.AppendLine("\t\t");
			}

			builder.AppendLine("\t\tif (value === null || value === void 0) return;");
			builder.AppendLine("");

			foreach (var prop in model.Properties)
				builder.AppendLine($"\t\tthis.{prop.Name} = value.{prop.Name};");

			builder.AppendLine("\t}");
			builder.AppendLine("}");

			var script = builder.ToString();
			return script;
		}
	}
}