// /***************************************************************************\
// Module Name:       ConverterOptions.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 15-05-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

using Sushi.Enum;
using Sushi.Interfaces;

namespace Sushi
{
	public sealed class ConverterOptions : IConverterOptions
	{
		/// <inheritdoc />
		public string Indent { get; set; }

		/// <inheritdoc />
		public PropertyNameCasing CasingStyle { get; set; }

		public ConverterOptions(string indent = "    ",
			PropertyNameCasing casing = PropertyNameCasing.CamelCase)
		{
			Indent = indent;
			CasingStyle = casing;
		}
	}
}