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
using Sushi.Extensions;
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
		public EcmaScript6Converter(SushiConverter converter, string indent) : base(converter, indent)
		{
		}

		/// / <inheritdoc />
		public override EcmaScript6Converter Convert()
		{
			foreach (var model in Models.Flatten())
				model.Script = Compile(model);

			return this;
		}

		private string CreatePropertyDeclaration(IEnumerable<IPropertyDescriptor> properties)
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

				builder.AppendLine($"{Indent}{prop.Name};");
			}

			return builder.ToString();
		}

		private string CreateConstructorDeclaration(IEnumerable<IPropertyDescriptor> properties, bool hasParent)
		{
			var builder = new StringBuilder();
			builder.AppendLine(Indent + "constructor(value) {");
			if (hasParent)
			{
				builder.AppendLine(Indent + Indent + "super(value);");
				builder.AppendLine("");
			}

			builder.AppendLine(Indent + Indent + "if (!(value instanceof Object))");
			builder.AppendLine(Indent + Indent + Indent + "return;");
			builder.AppendLine();

			foreach (var prop in properties)
				builder.AppendLine(Indent + Indent + $"this.{prop.Name} = value.{prop.Name};");

			builder.Append(Indent + "}");
			return builder.ToString();
		}

		private string Compile(ClassDescriptor model)
		{
			var properties = model.GetProperties(true).ToList();
			var summary = ExcludeComments || XmlDocument == null? string.Empty : XmlDocument.JsDocClassSummary(model) + "\n";
			var parentClass = model.Parent == null ? string.Empty : $" extends {model.Parent.Name}";
			var propertyDeclaration = CreatePropertyDeclaration(properties);
			var constructorDeclaration = CreateConstructorDeclaration(properties, model.Parent != null);

			var template =
				@$"{summary}export class {model.Name}{parentClass} {{
{propertyDeclaration}
{constructorDeclaration}

{Indent}static mapFrom(obj) {{
{Indent}{Indent}return Object.assign(new {model.Name}(), obj);
{Indent}}}
}}
";
			return template;
		}
	}
}