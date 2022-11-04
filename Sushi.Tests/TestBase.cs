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

using System.IO;
using Sushi.Enum;

#endregion

namespace Sushi.Tests
{
	public class TestBase
	{
		protected static readonly string FilePath =
			Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"Compiled\");

        /// <summary>
        ///     Compile a model for JavaScript.
        /// </summary>
        protected static void CompileJavaScript(SushiConverter converter, JavaScriptVersion version)
		{
			var jsConverter = converter.JavaScript(version)
				.Convert();

			var fileName = $"models.{version}.js".ToLowerInvariant();
			jsConverter.WriteToFile(FilePath + fileName);
		}

        /// <summary>
        ///     Compile a model for TypeScript.
        /// </summary>
        protected static void CompileTypeScript(SushiConverter converter, TypeScriptVersion version)
		{
			var tsConverter = converter.TypeScript(version)
				.ConvertEnums()
				.Convert();

			const string fileName = "models.latest.ts";
			tsConverter.WriteToFile(FilePath + fileName);
		}
	}
}