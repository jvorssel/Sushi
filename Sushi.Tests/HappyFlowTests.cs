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
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
		public void LoadCorrectlyTest()
		{
			// Arrange
			var assembly = typeof(SushiConverter).Assembly;

			// Act
			var converter = new SushiConverter(assembly, XmlDocPath);

			// Assert
			Assert.IsNotNull(converter.Documentation);
			Assert.IsTrue(converter.Documentation.Members.Any());
		}

		[TestMethod]
		public void ECMAScript5_CompileTest()
		{
			// Arrange
			var assembly = typeof(PersonViewModel).Assembly;
			var converter = new SushiConverter(assembly, XmlDocPath);

			// Act
			var script = converter.ECMAScript5().Convert().ToString();

			WriteToFile(script, GetFilePath("models.es5.js"));
		}

		[TestMethod]
		public void ECMAScript5_WithUnderscore_CompileTest()
		{
			// Arrange
			var assembly = typeof(PersonViewModel).Assembly;
			var converter = new SushiConverter(assembly, XmlDocPath);

			// Act
			var script = converter.ECMAScript5()
				.IncludeUnderscoreMapper()
				.Convert()
				.ToString();

			WriteToFile(script, GetFilePath("models.es5.map.js"));
		}

		[TestMethod]
		public void ECMAScript6_CompileTest()
		{
			// Arrange
			var assembly = typeof(PersonViewModel).Assembly;
			var converter = new SushiConverter(assembly, XmlDocPath);

			// Act
			var script = converter.ECMAScript6()
				.Convert()
				.ToString();
			WriteToFile(script, GetFilePath("models.es6.js"));
		}

		[TestMethod]
		public void Typescript_CompileTest()
		{
			// Arrange
			var assembly = typeof(PersonViewModel).Assembly;
			var converter = new SushiConverter(assembly, XmlDocPath);

			// Act
			var script = converter.TypeScript()
				.Convert()
				.ConvertEnums()
				.ToString();

			WriteToFile(script, GetFilePath("models.latest.ts"));
		}

		[TestMethod]
		public void Typescript_WithoutComments_CompileTest()
		{
			// Arrange
			var huh = AppDomain.CurrentDomain.BaseDirectory;
			var assembly = typeof(PersonViewModel).Assembly;
			var converter = new SushiConverter(assembly, XmlDocPath);

			// Act
			// Convert the available models and look if the result is as expected.
			var script = converter.TypeScript()
				.NoComments()
				.ConvertEnums()
				.Convert()
				.ToString();

			WriteToFile(script, GetFilePath("models.no-comments.ts"));
		}
	}
}