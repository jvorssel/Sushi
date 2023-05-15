// /***************************************************************************\
// Module Name:       TypeScriptConverter.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 15-05-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System.Globalization;
using System.Text;
using Sushi.Descriptors;
using Sushi.Documentation;
using Sushi.Enum;
using Sushi.Extensions;
using Sushi.Helpers;
using Sushi.Interfaces;

#endregion

namespace Sushi.Converters
{
	/// <summary>
	///     Add the TypeScript class declaration to the <see cref="SushiConverter.Models" />.
	/// </summary>
	public sealed class TypeScriptConverter : ModelConverter
	{
		/// <inheritdoc />
		public TypeScriptConverter(SushiConverter converter, IConverterOptions options) : base(converter, options) { }

		/// <inheritdoc />
		protected override IEnumerable<string> ConvertToScript(IEnumerable<ClassDescriptor> descriptors)
		{
			foreach (var enumScript in ConvertEnums())
				yield return enumScript;

			foreach (var model in descriptors)
				yield return ToTypeScriptClass(model);
		}

		public IEnumerable<string> ConvertEnums()
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

				yield return builder.ToString();
			}
		}

		public string ConvertProperty(IPropertyDescriptor property)
		{
			var scriptType = ResolveScriptType(property.Type);
			var defaultValue = ResolveDefaultValue(property);

			var suffix = string.Empty;
			var nameSuffix = string.Empty;
			if (!defaultValue.IsEmpty())
				suffix = " = " + defaultValue;
			else
				nameSuffix = "!";

			return $"{Indent}{ApplyCasingStyle(property.Name)}{nameSuffix}: {scriptType}{suffix};";
		}

		public string ResolveScriptType(Type type)
		{
			var genericTypeArgs = type.IsGenericType ? GetGenericTypeArguments(type) : string.Empty;

			// Array
			if (type.IsArray())
				return $"Array<{genericTypeArgs}>";

			var actualType = GetGenericType(type);

			// Check if any of the available models have the same name and should be used.
			var classModel = Models.SingleOrDefault(x => x.Name == actualType.Name);
			if (classModel != null)
				return type.IsGenericType ? $"{classModel.Name}<{genericTypeArgs}>" : classModel.Name;

			var enumModel = EnumModels.SingleOrDefault(x => x.Name == actualType.Name);
			if (type.IsEnum && enumModel != null)
				return $"{enumModel.Name} | number";

			// Date
			if (actualType == typeof(DateTime))
				return @"Date | string | null";

			var scriptType = actualType.ToNativeScriptType().ToScriptType();
			return type.IsNullable() ? $"{scriptType} | null" : scriptType;
		}

		public string ResolveDefaultValue(IPropertyDescriptor prop)
		{
			if (prop.Type.IsArray())
				return "[]";

			if (prop.DefaultValue == null)
				return string.Empty;

			if (prop.Type.IsNullable())
				return "null";

			var defaultValueType = prop.DefaultValue.GetType();
			var descriptor = Models.SingleOrDefault(x => x.Type == defaultValueType);
			if (descriptor != null && descriptor.HasParameterlessCtor)
				return $"new {descriptor.Name}()";

			if (defaultValueType.IsClass && defaultValueType != typeof(string))
				return string.Empty;

			var nativeType = prop.Type.ToNativeScriptType();
			switch (nativeType)
			{
				case NativeType.Bool:
					return (bool)(prop.DefaultValue ?? false) ? "true" : "false";
				case NativeType.Enum:
				case NativeType.Byte:
				case NativeType.Short:
				case NativeType.Long:
				case NativeType.Int:
				case NativeType.Double:
				case NativeType.Float:
				case NativeType.Decimal:
				{
					var asDecimal = Convert.ToDecimal(prop.DefaultValue).ToString(CultureInfo.InvariantCulture);
					return asDecimal.Substring(0, Math.Min(asDecimal.Length, 15));
				}
				case NativeType.Char:
				case NativeType.String:
					return $"\"{prop.DefaultValue}\"";
				case NativeType.Null:
				case NativeType.Object:
					return "null";
				case NativeType.Undefined:
				default:
					throw new ArgumentOutOfRangeException(nameof(nativeType), nativeType, null);
			}
		}

		public static Type GetGenericType(Type @this)
		{
			var type = Nullable.GetUnderlyingType(@this) ?? @this;

			while (type.IsGenericType)
			{
				// Move to the single generic argument or its base type.
				var genericType = type.GenericTypeArguments.SingleOrDefault();
				if (genericType == null)
					return type;

				type = genericType;
			}

			return type;
		}

		public string GetGenericTypeArguments(Type type)
		{
			if (!type.IsGenericType)
				throw new ArgumentException("Expected given type to be generic.");

			var genericTypeArgs = type.GenericTypeArguments.Select(x => x.IsGenericTypeParameter ? x.Name : ResolveScriptType(x)).Glue(", ");
			return genericTypeArgs;
		}

		internal string CreatePropertyDeclaration(IEnumerable<IPropertyDescriptor> properties)
		{
			var builder = new StringBuilder();
			foreach (var prop in properties)
			{
				if (XmlDocument != null)
				{
					var summary = XmlDocument.JsDocPropertySummary(prop);
					if (!summary.IsEmpty())
						builder.AppendLine(Indent + summary);
				}

				var property = ConvertProperty(prop);
				builder.AppendLine(property);
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
			{
				builder.AppendLine(
					$"{Indent + Indent + Indent}this.{ApplyCasingStyle(prop.Name)} = value.{ApplyCasingStyle(prop.Name)};");
			}

			builder.AppendLine(Indent + Indent + "}");
			builder.Append(Indent     + "}");
			return builder.ToString();
		}

		private static string FormatClassName(ClassDescriptor descriptor)
		{
			if (!descriptor.GenericParameterNames.Any())
				return descriptor.Name;

			var genericTypeArgs = $"<{descriptor.GenericParameterNames.Glue(", ")}>";
			return $"{descriptor.Name}{genericTypeArgs}";
		}

		private string ToTypeScriptClass(ClassDescriptor model)
		{
			var className = FormatClassName(model);
			var properties = model.GetProperties(true).ToList();

			var summary = XmlDocument == null
				? string.Empty
				: XmlDocument.JsDocClassSummary(model) + "\n";
			var parentClass = model.Parent == null ? string.Empty : $" extends {model.Parent.Name}";
			var @override = model.Parent   != null ? "override " : string.Empty;
			var propertyDeclaration = CreatePropertyDeclaration(properties);
			var constructorDeclaration = CreateConstructorDeclaration(model);
			var template =
				@$"{summary}export class {className}{parentClass} {{
{propertyDeclaration}
{constructorDeclaration}
}}
";

			return template;
		}
	}
}