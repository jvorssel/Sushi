using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelConverter.JavaScript;
using ModelConverter.JavaScript.Enum;
using ModelConverter.Tests.Models;

namespace ModelConverter.Tests
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
                Compile(kernel, JavaScriptVersion.V5, false, "summary", null);
            }
        }
    }
}
