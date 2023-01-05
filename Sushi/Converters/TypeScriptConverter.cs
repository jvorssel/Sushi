// /***************************************************************************\
// Module Name:       TypeScriptConverter.cs
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
using Sushi.Extensions;
using Sushi.Interfaces;

#endregion

namespace Sushi.Converters
{
	/// <summary>
	///     Add the TypeScript class declaration to the <see cref="SushiConverter.Models" />.
	/// </summary>
	public sealed class TypeScriptConverter : ModelConverter<TypeScriptConverter>
	{
		/// <inheritdoc />
		public TypeScriptConverter(SushiConverter converter)
			: base(converter)
		{
			ScriptTypeConverter = new TypeScriptTypeConverter(converter);
		}

		/// <inheritdoc />
		public override TypeScriptConverter Convert()
		{
			foreach (var model in Models.Flatten())
				model.Script = ToTypeScriptClass(model);

			return this;
		}

		public TypeScriptConverter ConvertEnums()
		{
			foreach (var model in EnumModels)
			{
				var builder = new StringBuilder();
				builder.AppendLine($"export enum {model.Name} {{");
				var lastKey = model.Values.Last().Key;
				foreach (var kvp in model.Values)
				{
					var value = $"\t{kvp.Key} = {kvp.Value}";
					if (lastKey != kvp.Key)
						value += ",";

					builder.AppendLine(value);
				}

				builder.AppendLine("}");

				model.Script = builder.ToString();
			}

			return this;
		}

		internal string CreatePropertyDeclaration(IEnumerable<IPropertyDescriptor> properties, string indent = "\t")
		{
			var builder = new StringBuilder();
			foreach (var prop in properties)
			{
				if (!ExcludeComments && XmlDocument != null)
				{
					var summary = XmlDocument.JsDocPropertySummary(prop);
					if (!summary.IsEmpty())
						builder.AppendLine(indent + summary);
				}

				var scriptType = ScriptTypeConverter.ResolveScriptType(prop.Type);
				builder.AppendLine($"{indent}{prop.Name}: {scriptType};");
			}

			return builder.ToString();
		}

		internal string CreateConstructorDeclaration(IEnumerable<IPropertyDescriptor> properties, bool hasParent, string indent = "\t")
		{
			var builder = new StringBuilder();
			builder.AppendLine(indent + "constructor();");
			builder.AppendLine(indent + "constructor(value?: any) {");
			if (hasParent)
			{
				builder.AppendLine(indent + indent + "super();");
				builder.AppendLine();
			}

			builder.AppendLine(indent + indent + "if (!(value instanceof Object))");
			builder.AppendLine(indent + indent + indent + "return;");
			builder.AppendLine();

			foreach (var prop in properties)
				builder.AppendLine($"{indent + indent}this.{prop.Name} = value.{prop.Name};");
			builder.Append(indent + "}");
			return builder.ToString();
		}

		private string ToTypeScriptClass(ClassDescriptor model)
		{
			var properties = model.GetProperties(true).ToList();

			var summary = ExcludeComments || XmlDocument == null ? string.Empty : XmlDocument.JsDocClassSummary(model) + "\n";
			var parentClass = model.Parent == null ? string.Empty : $" extends {model.Parent.Name}";
			var propertyDeclaration = CreatePropertyDeclaration(properties);
			var constructorDeclaration = CreateConstructorDeclaration(properties, model.Parent != null);
			var template =
				@$"{summary}export class {model.Name}{parentClass} {{
{propertyDeclaration}
{constructorDeclaration}

	static mapFrom(obj: any): {model.Name} {{
		return Object.assign(new {model.Name}(), obj);
	}}
}}
";

			return template;
		}
	}
}