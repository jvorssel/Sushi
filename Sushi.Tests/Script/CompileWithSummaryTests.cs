using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.Extensions;
using Sushi.JavaScript.Enum;

namespace Sushi.Tests
{
    [TestClass]
    public class CompileWithSummaryTests : TestBase
    {
        public TestContext Context { get; set; }

        [TestMethod]
        public void LoadCorrectlyTest()
        {
            var assembly = typeof(ModelToConvertTests).Assembly;
            using (var kernel = new ConversionKernel(assembly))
            {
                // Make sure the XML documentation is loaded
                var assemblyName = assembly.GetProjectName();
                var xmlDocPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{assemblyName}.xml");
                kernel.LoadXmlDocumentation(xmlDocPath);

                Assert.IsNotNull(kernel.Documentation);
                Assert.IsTrue(kernel.Documentation.Initialized);
                Assert.IsTrue(kernel.Documentation.Members.Any());
            }
        }

        [TestMethod]
        public void CompileTest()
        {
            var assembly = typeof(ModelToConvertTests).Assembly;
            using (var kernel = new ConversionKernel(assembly))
            {
                // Make sure the XML documentation is loaded
                var assemblyName = assembly.GetProjectName();
                var xmlDocPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{assemblyName}.xml");
                kernel.LoadXmlDocumentation(xmlDocPath);

                // Convert the available models and look if the result is as expected.
                CompileJavaScript(kernel, JavaScriptVersion.V5);
            }
        }
    }
}
