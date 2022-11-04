// /***************************************************************************\
// Module Name:       TypeScriptConverter.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 05-11-2022
// Copyright:              Royaldesk @ 2022
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System;
using System.Linq;
using System.Text;
using Sushi.Descriptors;
using Sushi.Documentation;
using Sushi.Enum;
using Sushi.Extensions;

#endregion

namespace Sushi.Converters
{
	/// <summary>
	///     Add the TypeScript class declaration to the <see cref="SushiConverter.Models" />.
	/// </summary>
	public sealed class TypeScriptConverter : ModelConverter<TypeScriptConverter>
	{
		private readonly TypeScriptVersion _version;

		/// <inheritdoc />
		public TypeScriptConverter(SushiConverter converter, TypeScriptVersion version)
			: base(converter)
			=> _version = version;

		/// <inheritdoc />
		public override TypeScriptConverter Convert()
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

			return this;
		}

		public TypeScriptConverter ConvertEnums()
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

			return this;
		}

		private string ToTypeScriptClass(ClassDescriptor model)
		{
			if (model.Properties.All(x => x.ScriptTypeValue.IsEmpty()))
				throw new InvalidOperationException(
					"Script type declaration missing on model properties, invoke converter.AssignScriptTypes() first.");

			var builder = new StringBuilder();
			if (!ExcludeComments)
				builder.Append(Converter.JsDocClassSummary(model));
			var classDeclaration = $"export class {model.Name}";
			if (model.Parent != (ClassDescriptor)null)
				classDeclaration += $" extends {model.Parent.Name}";

			classDeclaration += " {";
			builder.AppendLine(classDeclaration);

			foreach (var prop in model.Properties)
			{
				if (!ExcludeComments)
					builder.Append(Converter.JsDocPropertySummary(prop));

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