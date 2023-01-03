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
using Sushi.Interfaces;

#endregion

namespace Sushi.Converters
{
	/// <summary>
	///     Add the JavaScript class declaration to the <see cref="SushiConverter.Models" />.
	/// </summary>
	public sealed class EcmaScript6Converter : ModelConverter<EcmaScript6Converter>
	{
		/// <inheritdoc />
		public EcmaScript6Converter(SushiConverter converter) : base(converter)
		{
		}

		/// / <inheritdoc />
		public override EcmaScript6Converter Convert()
		{
			foreach (var model in Converter.Models.Flatten())
				model.Script = Compile(model);

			return this;
		}

		private string CreatePropertyDeclaration(IEnumerable<IPropertyDescriptor> properties, string indent = "\t")
		{
			var builder = new StringBuilder();
			foreach (var prop in properties)
			{
				if (!ExcludeComments)
					builder.Append(Converter.JsDocPropertySummary(prop));

				builder.AppendLine($"{indent}{prop.Name};");
			}

			return builder.ToString();
		}

		private string CreateConstructorDeclaration(IEnumerable<IPropertyDescriptor> properties, bool hasParent, string indent = "\t")
		{
			var builder = new StringBuilder();
			builder.AppendLine(indent + "constructor(value) {");
			if (hasParent)
			{
				builder.AppendLine(indent + indent + "super(value);");
				builder.AppendLine("");
			}

			builder.AppendLine(indent + indent + "if (!(value instanceof Object))");
			builder.AppendLine(indent + indent + indent + "return;");
			builder.AppendLine();

			foreach (var prop in properties)
				builder.AppendLine(indent + indent + $"this.{prop.Name} = value.{prop.Name};");

			builder.Append(indent + "}");
			return builder.ToString();
		}

		private string Compile(ClassDescriptor model)
		{
			var properties = model.GetProperties(true).ToList();
			var summary = ExcludeComments ? string.Empty : Converter.JsDocClassSummary(model) + "\n";
			var parentClass = !model.HasParent ? string.Empty : $" extends {model.Parent.Name}";
			var propertyDeclaration = CreatePropertyDeclaration(properties);
			var constructorDeclaration = CreateConstructorDeclaration(properties, model.HasParent);

			var template =
				@$"{summary}export class {model.Name}{parentClass} {{
{propertyDeclaration}
{constructorDeclaration}

	static mapFrom(obj) {{
		return Object.assign(new {model.Name}(), obj);
	}}
}}
";
			return template;
		}
	}
}