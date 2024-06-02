// /***************************************************************************\
// Module Name:       StudentViewModel.cs
// Project:                   Sushi.Tests
// Author:                   Jeroen Vorsselman 04-11-2022
// Copyright:              Royaldesk @ 2022
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

namespace Sushi.Tests.Models;

/// <summary>
///		Represents a Student in a school.
/// </summary>
public class StudentViewModel : PersonViewModel
{
	/// <summary>
	///		What <see cref="Grade"/> the Student is in.
	/// </summary>
	public int Grade { get; set; } = 9;

	/// <summary>
	///		The name of the <see cref="School"/>.
	/// </summary>
	public SchoolViewModel School { get; set; }

	public StudentViewModel() : base("John", "Doe")
	{
			
	}
		
	/// <inheritdoc />
	public StudentViewModel(string name, string surname) : base(name, surname)
	{
			
	}
}