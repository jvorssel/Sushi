// /***************************************************************************\
// Module Name:       TypeModel.cs
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
	///     Simple model to verify complex types.
	/// </summary>
	public sealed class TypeModel : ViewModel
	{
		/// <summary>
		///     A nullable boolean.
		/// </summary>
		public bool? NullableBool { get; set; } = null;

		/// <summary>
		///     A readonly string.
		/// </summary>
		public readonly string ReadonlyString = "readonly";

		/// <inheritdoc cref="Guid"/>
		public new Guid Guid { get; set; } = Guid.NewGuid();
	}
}