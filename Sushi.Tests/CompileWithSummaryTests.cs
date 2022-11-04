using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.Enum;
using Sushi.Tests.Models;

namespace Sushi.Tests
{
	[TestClass]
	public class HappyFlowTests : TestBase
	{
		public const string XML_FILE_NAME = "Sushi.tests.xml";
		private string XmlDocPath => Path.Combine(Environment.CurrentDirectory, XML_FILE_NAME);
		
		[TestMethod]
		public void LoadCorrectlyTest()
		{
			var assembly = typeof(SushiConverter).Assembly;
			var converter = new SushiConverter(assembly);
			
			// Make sure the XML documentation is loaded
			converter.LoadXmlDocumentation(XmlDocPath);

			Assert.IsNotNull(converter.Documentation);
			Assert.IsTrue(converter.Documentation.Initialized);
			Assert.IsTrue(converter.Documentation.Members.Any());
		}

		[TestMethod]
		public void JavascriptEs5_CompileTest()
		{
			var assembly = typeof(PersonViewModel).Assembly;
			var converter = new SushiConverter(assembly);
			
			// Make sure the XML documentation is loaded
			converter.LoadXmlDocumentation(XmlDocPath);

			// Convert the available models and look if the result is as expected.
			converter.JavaScript(JavaScriptVersion.Es5)
				.ConvertClasses()
				.WriteToFile(FilePath + "models.es5.js");
		}
		
		[TestMethod]
		public void JavascriptEs6_CompileTest()
		{
			var assembly = typeof(PersonViewModel).Assembly;
			var converter = new SushiConverter(assembly);
			
			// Make sure the XML documentation is loaded
			converter.LoadXmlDocumentation(XmlDocPath);

			// Convert the available models and look if the result is as expected.
			converter.JavaScript(JavaScriptVersion.Es6)
				.ConvertClasses()
				.WriteToFile(FilePath + "models.es6.js");
		}
		
		[TestMethod]
		public void Typescript_CompileTest()
		{
			var assembly = typeof(PersonViewModel).Assembly;
			var converter = new SushiConverter(assembly);
			
			// Make sure the XML documentation is loaded
			converter.LoadXmlDocumentation(XmlDocPath);

			// Convert the available models and look if the result is as expected.
			converter.TypeScript(TypeScriptVersion.Latest)
				.ConvertClasses()
				.ConvertEnums()
				.WriteToFile(FilePath + "models.latest.ts");
			
			converter.TypeScript(TypeScriptVersion.Latest)
				.NoComments()
				.ConvertEnums()
				.ConvertClasses()
				.WriteToFile(FilePath + "models.no-comments.ts");
		}

	}
}