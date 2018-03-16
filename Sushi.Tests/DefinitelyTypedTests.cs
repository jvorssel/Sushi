using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.DefinitelyTyped;
using Sushi.Extensions;

namespace Sushi.Tests
{
    [TestClass]
    public class DefinitelyTypedTests : TestBase
    {
        public TestContext Context { get; set; }

        [TestMethod]
        public void CompileFileTest()
        {
            var assembly = typeof(ModelToConvertTests).Assembly;
            using (var kernel = new ConversionKernel(assembly))
            {
                // Make sure the XML documentation is loaded
                var assemblyName = assembly.GetProjectName();
                var xmlDocPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{assemblyName}.xml");
                kernel.LoadXmlDocumentation(xmlDocPath);

                var converter = kernel.CreateConverterForDefinitelyTyped();
                var converted = converter.Convert();

                var writer = new FileWriter(converter, FilePath, ".d.ts");
                writer.FlushToFile(converted, @"reference");
            }
        }
    }
}