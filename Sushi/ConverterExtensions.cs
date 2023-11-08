// /***************************************************************************\
// Module Name:       ConverterExtensions.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 15-05-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using Sushi.Converters;
using Sushi.Interfaces;

// ReSharper disable InconsistentNaming

#endregion

namespace Sushi
{
	public static class ConverterExtensions
	{
		/// <summary>
		///     Create the converter for ECMAScript 5.
		/// </summary>
		public static EcmaScript5Converter ECMAScript5(this SushiConverter converter, IConverterOptions options = null)
			=> new EcmaScript5Converter(converter, options ?? new ConverterOptions());

		/// <summary>
		///     Create the converter for ECMAScript 6.
		/// </summary>
		public static EcmaScript6Converter ECMAScript6(this SushiConverter converter, IConverterOptions options = null)
			=> new EcmaScript6Converter(converter, options ?? new ConverterOptions());

		/// <summary>
		///     Create the converter for TypeScript.
		/// </summary>
		public static TypeScriptConverter TypeScript(this SushiConverter converter, IConverterOptions options = null)
			=> new TypeScriptConverter(converter, options ?? new TypescriptConverterOptions());
	}
}