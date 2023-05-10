// /***************************************************************************\
// Module Name:       TypeScriptConverter.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 11-05-2023
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
		public TypeScriptConverter(SushiConverter converter, string indent, PropertyNameCasing casing)
			: base(converter, indent, casing)
			=> ScriptTypeConverter = new TypeScriptTypeConverter(converter);

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
					var value = $"{Indent}{kvp.Key} = {kvp.Value}";
					if (lastKey != kvp.Key)
						value += ",";

					builder.AppendLine(value);
				}

				builder.AppendLine("}");

				model.Script = builder.ToString();
			}

			return this;
		}

		internal string CreatePropertyDeclaration(IEnumerable<IPropertyDescriptor> properties)
		{
			var builder = new StringBuilder();
			foreach (var prop in properties)
			{
				if (!ExcludeComments && XmlDocument != null)
				{
					var summary = XmlDocument.JsDocPropertySummary(prop);
					if (!summary.IsEmpty())
						builder.AppendLine(Indent + summary);
				}

				var scriptType = ScriptTypeConverter.ResolveScriptType(prop.Type);
				var defaultValue = ScriptTypeConverter.ResolveDefaultValue(prop);

				var suffix = string.Empty;
				var nameSuffix = string.Empty;
				if (!defaultValue.IsEmpty())
					suffix = " = " + defaultValue;
				else
					nameSuffix = "!";

				builder.AppendLine($"{Indent}{ApplyCasingStyle(prop.Name)}{nameSuffix}: {scriptType}{suffix};");
			}

			return builder.ToString();
		}

		internal string CreateConstructorDeclaration(ClassDescriptor model)
		{
			var builder = new StringBuilder();
			builder.AppendLine($"{Indent}constructor(value?: any) {{");
			if (model.Parent != null)
			{
				builder.AppendLine(Indent + Indent + "super(value);");
				builder.AppendLine();
			}

			builder.AppendLine(Indent + Indent + "if (value) {");

			foreach (var prop in model.Properties)
				builder.AppendLine(
					$"{Indent + Indent + Indent}this.{ApplyCasingStyle(prop.Name)} = value.{ApplyCasingStyle(prop.Name)};");
			builder.AppendLine(Indent + Indent + "}");
			builder.Append(Indent + "}");
			return builder.ToString();
		}

		private string ToTypeScriptClass(ClassDescriptor model)
		{
			var properties = model.GetProperties(true).ToList();

			var summary = ExcludeComments || XmlDocument == null
				? string.Empty
				: XmlDocument.JsDocClassSummary(model) + "\n";
			var parentClass = model.Parent == null ? string.Empty : $" extends {model.Parent.Name}";
			var @override = model.Parent   != null ? "override " : string.Empty;
			var propertyDeclaration = CreatePropertyDeclaration(properties);
			var constructorDeclaration = CreateConstructorDeclaration(model);
			var template =
				@$"{summary}export class {model.Name}{parentClass} {{
{propertyDeclaration}
{constructorDeclaration}
}}
";

			return template;
		}
	}
}