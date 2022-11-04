// /***************************************************************************\
// Module Name:       IPropertyDescriptor.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 02-04-2022
// Copyright:              Royaldesk @ 2022
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

using System;
using Sushi.Enum;

namespace Sushi.Interfaces
{
	public interface IPropertyDescriptor
	{
		/// <summary>
		///		The <see cref="Name"/> of the described property or field.
		/// </summary>
		string Name { get; }
		
		/// <summary>
		///		If the described property or field is readonly. 
		/// </summary>
		bool IsReadonly { get; }
		
		/// <summary>
		///		The actual type.
		/// </summary>
		Type Type { get; }
		
		/// <summary>
		///		The type of the class that the property or field belongs to. 
		/// </summary>
		Type ClassType { get; }
		
		/// <summary>
		///		If the <see cref="Type"/> is nullable.
		/// </summary>
		bool IsNullable { get; }
		
		/// <summary>
		///		The simple <see cref="NativeType"/> enum.
		/// </summary>
		NativeType NativeType { get; }
		
		/// <summary>
		///		The <see cref="DefaultValue"/> used by the class.
		/// </summary>
		object DefaultValue { get; }

		string ScriptTypeValue { get; set; }
	}
}