// /***************************************************************************\
// Module Name:       ConverterExtensions.cs
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
using Sushi.Converters;
using Sushi.Descriptors;
using Sushi.Enum;

#endregion

namespace Sushi
{
	public static class ConverterExtensions
	{
        /// <summary>
        ///     Initialize a <see cref="ModelConverter" /> to work with ECMAScript with a specific <paramref name="version" />.
        /// </summary>
        public static JavaScriptConverter JavaScript(this SushiConverter converter, JavaScriptVersion version)
			=> new(converter, version);

        /// <summary>
        ///     Initialize a <see cref="ModelConverter" /> to work with TypeScript with a specific <paramref name="version" />.
        /// </summary>
        public static TypeScriptConverter TypeScript(this SushiConverter converter, TypeScriptVersion version)
			=> new(converter, version);

        /// <summary>
        ///		Find the  <see cref="ClassDescriptor"/> of <paramref name="type"/> in the descriptor tree.
        /// </summary>
		public static ClassDescriptor FindDescriptor(this ICollection<ClassDescriptor> tree, Type type)
		{
			foreach (var d in tree)
			{
				if (d.Type == type)
					return d;

				var child = FindDescriptor(d.Children, type);
				if (child != (ClassDescriptor)null)
					return child;
			}

			return null;
		}

        /// <summary>
        ///		Flatten the <see cref="ClassDescriptor"/> tree to a flat list.
        /// </summary>
        public static IEnumerable<ClassDescriptor> Flatten(this ICollection<ClassDescriptor> tree)
        {
	        foreach (var cd in tree)
	        {
		        yield return cd;
		        foreach (var cdc in cd.Children.Flatten())
			        yield return cdc;
	        }
        }
	}
}