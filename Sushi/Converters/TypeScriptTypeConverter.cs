// /***************************************************************************\
// Module Name:       TypeScriptTypeConverter.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 03-01-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using Sushi.Descriptors;
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

		/// <summary>
		///     Resolve the TypeScript type that matches the given <paramref name="type" />.
		/// </summary>
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
			{
				return type.IsGenericType
					? $"{classModel.Name}<{genericTypeArgs}> | null"
					: $"{classModel.Name} | null";
			}

			var enumModel = Enums.SingleOrDefault(x => x.Name == actualType.Name);
			if (type.IsEnum && enumModel != null)
				return $"{enumModel.Name} | number";

			// Date
			if (actualType == typeof(DateTime))
				return @"Date | string | null";

			var scriptType = actualType.ToNativeScriptType().ToScriptType();
			return type.IsNullable() ? $"{scriptType} | null" : scriptType;
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