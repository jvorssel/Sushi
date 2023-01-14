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

using Sushi.Converters;
using Sushi.Enum;

// ReSharper disable InconsistentNaming

#endregion

namespace Sushi
{
	public static class ConverterExtensions
	{
		private const string INDENT = @"    ";
		private const PropertyNameCasing CASING = PropertyNameCasing.CamelCase;
		
        /// <summary>
        ///     Create the converter for ECMAScript 5.
        /// </summary>
        public static EcmaScript5Converter ECMAScript5(this SushiConverter converter, string indent = INDENT, PropertyNameCasing casing = CASING)
			=> new(converter, indent, casing);
        
        /// <summary>
        ///     Create the converter for ECMAScript 6.
        /// </summary>
        public static EcmaScript6Converter ECMAScript6(this SushiConverter converter, string indent = INDENT, PropertyNameCasing casing = CASING)
	        => new(converter, indent, casing);

        /// <summary>
        ///		Create the converter for TypeScript.
        /// </summary>
        public static TypeScriptConverter TypeScript(this SushiConverter converter, string indent = INDENT, PropertyNameCasing casing = CASING)
	        => new(converter, indent, casing);
	}
}