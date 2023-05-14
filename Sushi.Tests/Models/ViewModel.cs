// /***************************************************************************\
// Module Name:       ViewModel.cs
// Project:                   Sushi.Tests
// Author:                   Jeroen Vorsselman 04-11-2022
// Copyright:              Royaldesk @ 2022
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System;
using Sushi.Interfaces;

#endregion

namespace Sushi.Tests.Models
{
	/// <summary>
	///		The view model base class.
	/// </summary>
	public abstract class ViewModel : IScriptModel
	{
		/// <summary>
		///		The view model identifier.
		/// </summary>
		public Guid Guid { get; set; } = Guid.NewGuid();

		/// <summary>
		///		When this view model was created.
		/// </summary>
		public DateTime CreatedOn { get; set; } = DateTime.Now;
	}
}