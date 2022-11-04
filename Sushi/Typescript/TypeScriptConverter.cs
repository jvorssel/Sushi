// /***************************************************************************\
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
using Sushi.Interfaces;
using Sushi.Javascript;

#endregion

namespace Sushi.Typescript
{
	/// <summary>
	///     Add the TypeScript class declaration to the <see cref="SushiConverter.Models" />.
	/// </summary>
	public class TypeScriptConverter : JavaScriptConverter
	{
		private readonly TypeScriptVersion _version;

		/// <inheritdoc />
		public TypeScriptConverter(SushiConverter converter, ILanguageSpecification language, TypeScriptVersion version)
			: base(converter, language, JavaScriptVersion.ES6)
			=> _version = version;

		/// <inheritdoc />
		public override void Convert()
		{
			foreach (var model in Converter.Models.Flatten())
			{
				switch (_version)
				{
					case TypeScriptVersion.Latest:
						model.Script = CompileTypeScriptClasses(model);
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}

		private string CompileTypeScriptClasses(ClassDescriptor model)
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