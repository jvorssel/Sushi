// /***************************************************************************\
// Module Name:       ISushiConverterOptions.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 15-05-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using Sushi.Enum;

#endregion


namespace Sushi.Interfaces
{
	public interface IConverterOptions
	{
		/// <summary>
		///		Indentation style, default is 4 spaces.
		/// </summary>
		string Indent { get; set; }
		
		/// <summary>
		///		Casing style for properties, default is camel case.
		/// </summary>
		PropertyNameCasing CasingStyle { get; set; }
		
		/// <summary>
		///		A list of headers written at the start of the file.
		///		Can be used to suppress es-lint warnings or add licence(s).
		/// </summary>
		List<string> Headers { get; set; }
	}
}