// /***************************************************************************\
// Module Name:       TypeModel.cs
// Project:                   Sushi.TestModels
// Author:                   Jeroen Vorsselman 02-04-2022
// Copyright:              Royaldesk @ 2022
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System;

#endregion

namespace Sushi.TestModels
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

		/// <summary>
		///     Should declare this property twice.
		/// </summary>
		public new Guid Guid { get; set; } = Guid.NewGuid();
	}
}