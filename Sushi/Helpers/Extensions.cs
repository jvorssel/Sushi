﻿// /***************************************************************************\
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

using Sushi.Enum;

#endregion

namespace Sushi.Helpers;

public static class Extensions
{
    /// <summary>
    ///     Convert the given <paramref name="type" /> to its corresponding <see cref="NativeType" />.
    /// </summary>
    public static NativeType ToNativeScriptType(this Type? type)
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
        return type switch
        {
            NativeType.Undefined => "undefined",
            NativeType.Bool => "boolean",
            NativeType.Enum or NativeType.Byte or NativeType.Short or NativeType.Long or NativeType.Int
                or NativeType.Double or NativeType.Float or NativeType.Decimal => "number",
            NativeType.Object => "any",
            NativeType.Char or NativeType.String => "string",
            NativeType.Null => "null",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }

    internal static HashSet<T> ToHashSet<T>(this IEnumerable<T> source, IEqualityComparer<T>? comparer = null)
    {
        return new HashSet<T>(source, comparer);
    }
}