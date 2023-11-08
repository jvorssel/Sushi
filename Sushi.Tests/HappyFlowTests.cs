// /***************************************************************************\
// Module Name:       HappyFlowTests.cs
// Project:                   Sushi.Tests
// Author:                   Jeroen Vorsselman 10-05-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Sushi.Extensions;
using Sushi.Helpers;
using Sushi.Tests.Models;

#endregion

namespace Sushi.Tests
{
	[TestClass]
	public class HappyFlowTests : TestBase
	{
		public string GetFilePath( string fileName)
		{
			var testResultsPath = Path.GetDirectoryName(TestContext.TestDir);
			return testResultsPath + $"/{fileName}";
		}

		public const string XML_FILE_NAME = "Sushi.tests.xml";
		private string XmlDocPath => Path.Combine(Environment.CurrentDirectory, XML_FILE_NAME);

		[TestMethod]
		public void NoTypes_ShouldThrowTest()
		{
			// Act & Assert
			Assert.ThrowsException<ArgumentNullException>(() => new SushiConverter((ICollection<Type>)null));
		}
		
		[TestMethod]
		public void LoadCorrectlyTest()
		{
			// Arrange
			var assembly = typeof(PersonViewModel).Assembly;

			// Act
			var converter = new SushiConverter(assembly).UseDocumentation(XmlDocPath);

			// Assert
			Assert.IsNotNull(converter.Documentation);
			Assert.IsTrue(converter.Documentation.Members.Any());
		}

		[TestMethod]
		public void ECMAScript5_CompileTest()
		{
			// Arrange
			var assembly = typeof(PersonViewModel).Assembly;
			var converter = new SushiConverter(assembly).UseDocumentation(XmlDocPath);

			// Act
			var script = converter.ECMAScript5().ToString();

			WriteToFile(script, GetFilePath("models.es5.js"));
		}

		[TestMethod]
		public void ECMAScript5_WithUnderscore_CompileTest()
		{
			// Arrange
			var assembly = typeof(PersonViewModel).Assembly;
			var converter = new SushiConverter(assembly).UseDocumentation(XmlDocPath);

			// Act
			var script = converter.ECMAScript5()
				.IncludeUnderscoreMapper()
				.ToString();

			WriteToFile(script, GetFilePath("models.es5.map.js"));
		}

		[TestMethod]
		public void ECMAScript6_CompileTest()
		{
			// Arrange
			var assembly = typeof(PersonViewModel).Assembly;
			var converter = new SushiConverter(assembly).UseDocumentation(XmlDocPath);

			// Act
			var script = converter.ECMAScript6().ToString();
			WriteToFile(script, GetFilePath("models.es6.js"));
		}

		[TestMethod]
		public void Typescript_CompileTest()
		{
			// Arrange
			var assembly = typeof(PersonViewModel).Assembly;
			var converter = new SushiConverter(assembly).UseDocumentation(XmlDocPath);

			// Act
			var script = converter.TypeScript().ToString();

			WriteToFile(script, GetFilePath("models.latest.ts"));
		}

		[TestMethod]
		public void Typescript_WithoutComments_CompileTest()
		{
			// Arrange
			// 1) Get the assembly with the exported types.
			var assembly = typeof(PersonViewModel).Assembly;
			var converter = new SushiConverter(assembly);

			// Act
			// 2) Specify conversion options.
			var options = new ConverterOptions();
			
			// 3) Specify the target language and invoke ToString().
			var script = converter.TypeScript(options).ToString();

			// 4) The resulting script can be written to a file(stream).
			WriteToFile(script, GetFilePath("models.no-comments.ts"));
		}
	}
}