// /***************************************************************************\
// Module Name:       ISchoolViewModel.cs
// Project:                   Sushi.Tests
// Author:                   Jeroen Vorsselman 14-05-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

namespace Sushi.Tests.Models;

/// <summary>
///		Basic information about a School.
/// </summary>
public interface ISchoolViewModel
{
	/// <summary>
	///     The <see cref="Name" /> of this <see cref="SchoolViewModel" />.
	/// </summary>
	string Name { get; set; }

	/// <summary>
	///     The <see cref="AmountOfStudents" /> of this <see cref="SchoolViewModel" />.
	/// </summary>
	long AmountOfStudents { get; set; }
}