// /***************************************************************************\
// Module Name:       TypeConverter.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 04-11-2022
// Copyright:              Royaldesk @ 2022
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using Sushi.Descriptors;
using Sushi.Enum;
using Sushi.Extensions;

#endregion

namespace Sushi.Converters
{
	public static class TypeConverter
	{
		public static void AssignScriptTypes(this SushiConverter converter)
		{
			var flat = converter.Models.Flatten().ToList();
			foreach (var model in flat)
			foreach (var prop in model.Properties)
			{
				var nativeType = prop.NativeType;
				var actualType = prop.Type.GetBaseType();

				// Check if any of the available models have the same name and should be used.
				var classModel = flat.SingleOrDefault(x => x.Name               == actualType.Name);
				var enumModel = converter.EnumModels.SingleOrDefault(x => x.Name == actualType.Name);
				if (!ReferenceEquals(classModel, null))
					prop.ScriptTypeValue = $"{classModel.Name} | null";
				else if (enumModel != null)
					prop.ScriptTypeValue = $"{enumModel.Name} | number";
				else if (actualType == typeof(DateTime))
					prop.ScriptTypeValue = "Date";
				else
					prop.ScriptTypeValue = ToScriptType(nativeType);

				var type = prop.Type;
				while (type?.IsArray() ?? false)
				{
					prop.ScriptTypeValue = $"Array<{prop.ScriptTypeValue}>";
					type = type?.GetGenericArguments().SingleOrDefault() ?? type?.BaseType;
				}
			}
		}

		public static Type GetBaseType(this Type @this)
		{
			var type = Nullable.GetUnderlyingType(@this) ?? @this;

			while (type.IsGenericType)
			{
				var genericType = type.GenericTypeArguments.SingleOrDefault() ?? type.BaseType;
				if (genericType == null)
					return type;

				type = genericType;
			}

			return type;
		}

		public static string ToScriptType(this NativeType type)
		{
			switch (type)
			{
				case NativeType.Undefined:
					return @"undefined";
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
	}
}