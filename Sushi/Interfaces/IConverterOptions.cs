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

namespace Sushi.Interfaces;

public interface IConverterOptions
{
	string Indent { get; set; }
	PropertyNameCasing CasingStyle { get; set; }
}