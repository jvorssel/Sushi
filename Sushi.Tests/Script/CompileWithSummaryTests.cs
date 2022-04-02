using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.Extensions;
using Sushi.JavaScript.Enum;
using Sushi.TestModels;

namespace Sushi.Tests
{
	[TestClass]
	public class CompileWithSummaryTests : TestBase
	{
		public TestContext Context { get; set; }

		[TestMethod]
		public void LoadCorrectlyTest()
		{
			var assembly = typeof(SchoolViewModel).Assembly;
			var converter = new Converter(assembly);
			
			// Make sure the XML documentation is loaded
			var assemblyName = assembly.GetProjectName();
			var xmlDocPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{assemblyName}.xml");
			converter.LoadXmlDocumentation(xmlDocPath);

			Assert.IsNotNull(converter.Documentation);
			Assert.IsTrue(converter.Documentation.Initialized);
			Assert.IsTrue(converter.Documentation.Members.Any());
		}

		[TestMethod]
		public void CompileTest()
		{
			var assembly = typeof(SchoolViewModel).Assembly;
			var converter = new Converter(assembly);
			
			// Make sure the XML documentation is loaded
			var assemblyName = assembly.GetProjectName();
			var xmlDocPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{assemblyName}.xml");
			converter.LoadXmlDocumentation(xmlDocPath);

			// Convert the available models and look if the result is as expected.
			CompileJavaScript(converter, JavaScriptVersion.V5);
			CompileTypeScript(converter);
			CompileDefinitelyTyped(converter);
		}
	}
}