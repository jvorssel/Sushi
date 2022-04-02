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
		string Name { get; }
		bool IsReadonly { get; }
		Type Type { get; }
		Type ClassType { get; }
		bool IsNullable { get; }
		NativeType NativeType { get; }
		object DefaultValue { get; }
	}
}