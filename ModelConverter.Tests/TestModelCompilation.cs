using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelConverter.JavaScript;
using ModelConverter.JavaScript.Enum;
using ModelConverter.Models;
using ModelConverter.Tests.Models.Inheritance;

namespace ModelConverter.Tests
{
	[TestClass]
	public class TestModelCompilation
	{
		public TestContext Context { get; set; }

		private static void Compile(ConversionKernel kernel,
			JavaScriptVersion version,
			bool isolated,
			Func<DataModel, bool> predicate)
		{
			var isolatedText = isolated ? " isolated" : string.Empty;
			var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Result\Compiled\");

			var converter = kernel.CreateConverterForJavaScript(version, isolated);
			var converted = converter.Convert(predicate);

			var writer = new FileWriter(converter, path, false);
			writer.FlushToFile(converted, $@"result {version}{isolatedText}.js");
		}

		[TestMethod]
		public void CompileAvailableVersionsToFileTest()
		{
			using (var kernel = new ConversionKernel(typeof(TestModelConverter).Assembly))
			{
				Compile(kernel, JavaScriptVersion.V5, false, null);
				Compile(kernel, JavaScriptVersion.V5, true, null);
				Compile(kernel, JavaScriptVersion.V6, false, null);
			}
		}

		[TestMethod]
		public void CompileInheritanceTest()
		{
			using (var kernel = new ConversionKernel(typeof(TestModelConverter).Assembly))
			{
				Func<DataModel, bool> predicate = x => x == typeof(PersonModel) || x == typeof(StudentModel);
				Compile(kernel, JavaScriptVersion.V5, false, predicate);
				Compile(kernel, JavaScriptVersion.V5, true, predicate);
				Compile(kernel, JavaScriptVersion.V6, false, predicate);
			}
		}
	}
}