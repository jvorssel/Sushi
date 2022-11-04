// /***************************************************************************\
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
using System.Collections.Generic;
using System.Linq;
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
			SetScriptTypes();
		}

		public void AddPropertySummary(IPropertyDescriptor prop, StringBuilder builder)
		{
			var propertySummary = Converter.Documentation.JsDocPropertySummary(prop);
			if (!propertySummary.IsEmpty())
				builder.AppendLine($"\t{propertySummary}");
		}

		public void SetScriptTypes()
		{
			foreach (var model in Models.Flatten())
			{
				foreach (var prop in model.Properties)
				{
					var nativeType = prop.NativeType.IncludeOverride(Converter, prop.Type);
					var type = Nullable.GetUnderlyingType(prop.Type) ?? prop.Type;
					var isArray = type.IsTypeOrInheritsOf(typeof(IEnumerable<>)) && type != typeof(string);

					// Check if any of the available models have the same name and should be used.
					var dataModel = Models.FirstOrDefault(x => x.FullName == type.FullName);
					if (!ReferenceEquals(dataModel, null))
						prop.ScriptTypeValue = dataModel.Name;
					else if (type == typeof(DateTime))
						prop.ScriptTypeValue = "Date";
					else
						prop.ScriptTypeValue = ToScriptType(nativeType);
					if (isArray)
						prop.ScriptTypeValue = $"Array<{prop.ScriptTypeValue}>";
				}
			}
		}

		public static string ToScriptType(NativeType type)
		{
			switch (type)
			{
				case NativeType.Undefined:
					return @"void";
				case NativeType.Bool:
					return @"boolean";
				case NativeType.Enum:
				case NativeType.Byte:
				case NativeType.Short:
				case NativeType.Long:
				case NativeType.Int:
				case NativeType.Double:
				case NativeType.Float:
				case NativeType.Decimal:
					return @"number";
				case NativeType.Object:
					return @"any";
				case NativeType.Char:
				case NativeType.String:
					return @"string";
				case NativeType.Null:
					return @"null";
				default:
					throw new ArgumentOutOfRangeException(nameof(type), type, null);
			}
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