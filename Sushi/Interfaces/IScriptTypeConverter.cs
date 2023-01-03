// /***************************************************************************\
// Module Name:       IScriptTypeConverter.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 03-01-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

namespace Sushi.Interfaces;

public interface IScriptTypeConverter
{
	/// <summary>
	///		Resolve the TypeScript type that matches the given <paramref name="type"/>.
	/// </summary>
	string ResolveScriptType(Type type);
}