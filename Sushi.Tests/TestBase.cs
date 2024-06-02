// /***************************************************************************\
// Module Name:       TestBase.cs
// Project:                   Sushi.Tests
// Author:                   Jeroen Vorsselman 05-11-2022
// Copyright:              Royaldesk @ 2022
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.Extensions;

#endregion

namespace Sushi.Tests;

public abstract class TestBase
{
	public TestContext TestContext { get; set; } = null!;
		
	/// <summary>
	///     Write the generated script values to the file.
	/// </summary>
	internal void WriteToFile(string script, string path, Encoding? encoding = null)
	{
		if (path.IsEmpty())
			throw new ArgumentNullException(nameof(path));

		var directory = Path.GetDirectoryName(path) ?? string.Empty;
		if (!Directory.Exists(directory))
			Directory.CreateDirectory(directory);

		File.WriteAllText(path, script, encoding ?? Encoding.Default);
	}
}