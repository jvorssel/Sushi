// /***************************************************************************\
// Module Name:       GenericComplexStandalone.cs
// Project:                   Sushi.Tests
// Author:                   Jeroen Vorsselman 15-05-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

using Sushi.Attributes;

namespace Sushi.TestModels;

/// <summary>
///     Another Generic class for a collection and a total amount of available entries.
/// </summary>
[ConvertToScript]
public sealed class GenericComplexStandalone<TFirst, TSecond>
{
	/// <summary>
	///     The first list of values.
	/// </summary>
	public List<TFirst> First { get; set; } = new();
	
	/// <summary>
	///     The second list of values.
	/// </summary>
	public List<TSecond> Second { get; set; } = new();

	/// <summary>
	///     The total amount of available entries.
	/// </summary>
	public long TotalAmount { get; set; }
}    