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
	public class JavaScriptConverter : ModelConverter<JavaScriptConverter>
	{
		private readonly JavaScriptVersion _version;

		/// <inheritdoc />
		public JavaScriptConverter(SushiConverter converter, JavaScriptVersion version) : base(converter)
			=> _version = version;

		/// <inheritdoc />
		public override JavaScriptConverter ConvertClasses()
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

			return this;
		}

		protected virtual string CreatePropertyDeclaration(ClassDescriptor model, string indent = "\t")
		{
			var builder = new StringBuilder();
			foreach (var prop in model.Properties)
			{
				if (!ExcludeComments)
					builder.Append(Converter.JsDocPropertySummary(prop));

				builder.AppendLine($"{indent}{prop.Name};");
			}

			return builder.ToString();
		}

		protected virtual string CreateConstructorDeclaration(ClassDescriptor model, string indent = "\t")
		{
			var builder = new StringBuilder();
			builder.AppendLine(indent + "constructor(value) {");
			if (model.HasParent)
			{
				builder.AppendLine(indent + indent + "super(value);");
				builder.AppendLine("");
			}

			builder.AppendLine(indent + indent + "if (!(value instanceof Object))");
			builder.AppendLine(indent + indent + indent + "return;");
			builder.AppendLine();

			foreach (var prop in model.Properties)
				builder.AppendLine(indent + indent + $"this.{prop.Name} = value.{prop.Name};");

			builder.Append(indent + "}");
			return builder.ToString();
		}

		private string CompileEcmaScript5Classes(ClassDescriptor model)
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

		private string CompileEcmaScript6Classes(ClassDescriptor model)
		{
			var summary = ExcludeComments ? string.Empty : Converter.JsDocClassSummary(model) + "\n";
			var parentClass = !model.HasParent ? string.Empty : $" extends {model.Parent.Name}";
			var propertyDeclaration = CreatePropertyDeclaration(model);
			var constructorDeclaration = CreateConstructorDeclaration(model);

			var template =
				@$"{summary}export class {model.Name}{parentClass} {{
{propertyDeclaration}
{constructorDeclaration}

	static from(obj) {{
		return Object.assign(new {model.Name}(), obj);
	}}
}}
";
			return template;
		}
	}
}