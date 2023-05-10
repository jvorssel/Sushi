// /***************************************************************************\
// Module Name:       TypeScriptTypeConverter.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 10-05-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System.Globalization;
using Sushi.Descriptors;
using Sushi.Enum;
using Sushi.Extensions;
using Sushi.Helpers;
using Sushi.Interfaces;

#endregion

namespace Sushi.Converters
{
	public sealed class TypeScriptTypeConverter : IScriptTypeConverter
	{
		public readonly ICollection<ClassDescriptor> Classes = new List<ClassDescriptor>();
		public readonly ICollection<EnumDescriptor> Enums = new List<EnumDescriptor>();

		public TypeScriptTypeConverter() { }

		public TypeScriptTypeConverter(SushiConverter converter)
		{
			Classes = converter.Models.Flatten().ToList();
			Enums = converter.EnumModels;
		}

		/// <inheritdoc />
		public string ResolveScriptType(Type type)
		{
			var genericTypeArgs = type.IsGenericType ? GetGenericType(type) : string.Empty;

			// Array
			if (type.IsArray())
				return $"Array<{genericTypeArgs}>";

			var actualType = GetBaseType(type);

			// Check if any of the available models have the same name and should be used.
			var classModel = Classes.SingleOrDefault(x => x.Name == actualType.Name);
			if (classModel != null)
				return type.IsGenericType ? $"{classModel.Name}<{genericTypeArgs}>" : classModel.Name;

			var enumModel = Enums.SingleOrDefault(x => x.Name == actualType.Name);
			if (type.IsEnum && enumModel != null)
				return $"{enumModel.Name} | number";

			// Date
			if (actualType == typeof(DateTime))
				return @"Date | string | null";

			var scriptType = actualType.ToNativeScriptType().ToScriptType();
			return type.IsNullable() ? $"{scriptType} | null" : scriptType;
		}

		/// <inheritdoc />
		public string ResolveDefaultValue(IPropertyDescriptor prop)
		{
			if (prop.Type.IsArray())
				return "[]";

			if (prop.DefaultValue == null)
				return string.Empty;

			if (prop.Type.IsNullable())
				return "null";

			var defaultValueType = prop.DefaultValue.GetType();
			var descriptor = Classes.SingleOrDefault(x => x.Type == defaultValueType);
			if (descriptor != null )
				return $"{{}} as {descriptor.Name}";
			
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

		public Type GetBaseType(Type @this)
		{
			var type = Nullable.GetUnderlyingType(@this) ?? @this;

			while (type.IsGenericType)
			{
				// Move to the single generic argument or its base type.
				var genericType = type.GenericTypeArguments.SingleOrDefault() ?? type.BaseType;
				if (genericType == null)
					return type;

				type = genericType;
			}

			return type;
		}

		public string GetGenericType(Type type)
		{
			if (!type.IsGenericType)
				throw new ArgumentException("Expected given type to be generic.");

			var genericTypeArgs = type.GenericTypeArguments.Select(ResolveScriptType).Glue(", ");
			return genericTypeArgs;
		}
	}
}