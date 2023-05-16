// /***************************************************************************\
// Module Name:       Extensions.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 16-05-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System.Text;
using Sushi.Enum;

#endregion

namespace Sushi.Helpers
{
	public static class Extensions
	{
		/// <summary>
		///     Convert the given <paramref name="type" /> to its corresponding <see cref="NativeType" />.
		/// </summary>
		public static NativeType ToNativeScriptType(this Type type)
		{
			if (type == null)
				return NativeType.Undefined;

			if (type == typeof(bool))
				return NativeType.Bool;

			if (type == typeof(byte))
				return NativeType.Byte;

			if (type == typeof(short))
				return NativeType.Short;

			if (type == typeof(long))
				return NativeType.Long;

			if (type == typeof(int))
				return NativeType.Int;

			if (type == typeof(float))
				return NativeType.Float;

			if (type == typeof(double))
				return NativeType.Double;

			if (type == typeof(decimal))
				return NativeType.Decimal;

			if (type == typeof(string) || type == typeof(Guid))
				return NativeType.String;

			if (type == typeof(char))
				return NativeType.Char;

			if (type == typeof(System.Enum) || type.BaseType == typeof(System.Enum))
				return NativeType.Enum;

			// Null value already defined above, use Object as default.
			return NativeType.Object;
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

		/// <summary>
		///     Glue the contents of the given <see cref="string" /> <see cref="IEnumerable{T}" /> together using the separator.
		/// </summary>
		/// <param name="parts">The <see cref="IEnumerable{T}" /> of string values.</param>
		/// <param name="separator">The optional separator value.</param>
		/// <returns>The resulting string.</returns>
		public static string Glue(this IEnumerable<string> parts, string separator)
		{
			var list = parts.ToList();
			var builder = new StringBuilder();
			foreach (var value in list)
			{
				builder.Append(value);
				if (value != list.Last())
					builder.Append(separator);
			}

			return builder.ToString();
		}

		public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer = null)
			=> new HashSet<T>(source, comparer);
	}
}