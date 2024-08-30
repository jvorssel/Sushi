// /***************************************************************************\
// Module Name:       InheritedViewModel.cs
// Project:                   Sushi.Tests
// Author:                   Jeroen Vorsselman 01-01-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

#endregion

namespace Sushi.TestModels;

public class InheritedViewModel : BaseViewModel
{
	/// <inheritdoc />
	public override string Value { get; set; } = "override";

	public string Addition { get; set; } = "added";
}

public class BaseViewModel : ViewModel
{
	public virtual string Value { get; set; } = "base";

	public Guid Guid { get; set; }

	public bool Base { get; set; } = true;
}