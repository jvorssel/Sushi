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
	public class ViewModel : IScriptModel
	{
		public Guid Guid { get; set; } = Guid.NewGuid();

		public DateTime CreatedOn { get; set; }
	}
}