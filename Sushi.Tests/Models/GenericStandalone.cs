// /***************************************************************************\
// Module Name:       GenericStandalone.cs
// Project:                   Sushi.Tests
// Author:                   Jeroen Vorsselman 14-05-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System.Collections.Generic;
using Sushi.Attributes;

#endregion

namespace Sushi.Tests.Models;

/// <summary>
///     A Generic class for a collection and a total amount of available entries.
/// </summary>
[ConvertToScript]
public sealed class GenericStandalone<TEntry>
{
	/// <summary>
	///     The list of values.
	/// </summary>
	public List<TEntry> Values { get; set; } = new();

	/// <summary>
	///     The total amount of available entries.
	/// </summary>
	public long TotalAmount { get; set; }
}