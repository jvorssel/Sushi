// /***************************************************************************\
// Module Name:       PersonViewModel.cs
// Project:                   Sushi.Tests
// Author:                   Jeroen Vorsselman 04-11-2022
// Copyright:              Royaldesk @ 2022
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

using System;

namespace Sushi.Tests.Models
{
	/// <summary>
	///		The <see cref="PersonViewModel"/> that represents a Person.
	/// </summary>
	public class PersonViewModel : ViewModel
	{
		/// <summary>
		///     The <see cref="Identifier"/> that this Model refers to.
		/// </summary>
		public Guid Identifier { get; set; } = Guid.NewGuid();

		/// <summary>
		///		 The <see cref="Name"/> of the person.
		/// </summary>
		public string Name { get; set; } = "Jeroen";

		/// <summary>
		///		The <see cref="Surname"/> of the person.
		/// </summary>
		public string Surname { get; set; } = "Vorsselman";

		/// <summary>
		///		The <see cref="Gender"/> of the person.
		/// </summary>
		public Gender Gender { get; set; } = Gender.Undefined;

	}
}