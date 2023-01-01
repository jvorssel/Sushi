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
	public class TypeScriptConverter : ModelConverter<TypeScriptConverter>
	{
		private readonly TypeScriptVersion _version;

		/// <inheritdoc />
		public TypeScriptConverter(SushiConverter converter, TypeScriptVersion version)
			: base(converter)
			=> _version = version;

		/// <inheritdoc />
		public override TypeScriptConverter ConvertClasses()
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

		protected virtual string CreatePropertyDeclaration(ClassDescriptor model, string indent = "\t")
		{
			var builder = new StringBuilder();
			foreach (var prop in model.Properties)
			{
				if (!ExcludeComments)
					builder.Append(Converter.JsDocPropertySummary(prop));

				builder.AppendLine($"{indent}{prop.Name}: {prop.ScriptTypeValue};");
			}
			
			return builder.ToString();
		}

		protected virtual string CreateConstructorDeclaration(ClassDescriptor model, string indent = "\t")
		{
			var builder = new StringBuilder();
			builder.AppendLine(indent + "constructor();");
			builder.AppendLine(indent + "constructor(value?: any) {");
			if (model.HasParent)
			{
				builder.AppendLine(indent + indent + "super();");
				builder.AppendLine();
			}

			builder.AppendLine(indent + indent + "if (!(value instanceof Object))");
			builder.AppendLine(indent + indent + indent + "return;");
			builder.AppendLine();

			foreach (var prop in model.Properties)
				builder.AppendLine($"{indent + indent}this.{prop.Name} = value.{prop.Name};");
			builder.Append(indent + "}");
			return builder.ToString();
		}
		
		private string ToTypeScriptClass(ClassDescriptor model)
		{
			if (model.Properties.All(x => x.ScriptTypeValue.IsEmpty()))
				throw new InvalidOperationException(
					"Script type declaration missing on model properties, invoke converter.AssignScriptTypes() first.");

			var summary = ExcludeComments ? string.Empty : Converter.JsDocClassSummary(model) + "\n";
			var parentClass = !model.HasParent ? string.Empty : $" extends {model.Parent.Name}";
			var propertyDeclaration = CreatePropertyDeclaration(model);
			var constructorDeclaration  = CreateConstructorDeclaration(model);
			var template = 
@$"{summary}export class {model.Name}{parentClass} {{
{propertyDeclaration}
{constructorDeclaration}

	static from(obj: any): {model.Name} {{
		return Object.assign(new {model.Name}(), obj);
	}}
}}
";
			
			return template;
		}
	}
}