using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.Extensions;
using Sushi.TestModels;
using Sushi.TypeScript;
using Sushi.TypeScript.Enum;

namespace Sushi.Tests.Script
{
    [TestClass]
    public class TypeScriptTests : TestBase
    {
        public TestContext Context { get; set; }

        [TestMethod]
        public void CompileTypeScriptFileTest()
        {
            // 1: Create an instance of the ConversionKernel
            var assembly = typeof(NameModel).Assembly;
            using (var kernel = new ConversionKernel(assembly).LoadXmlDocumentation())
            {
                // 2: Create the ModelConverter instance for the requested script-language
                var converter = kernel.CreateConverterForTypeScript(TypeScriptSpecification.TypeScript);

                // 3: Invoke the Convert method to generate the script.
                var converted = converter.Convert();

                // Merge the generated script model(s) to one string.
                var contents = converter.MergeModelsToString(converted);

                var fileName = "typescript";

                converter.WriteToFile(converted, FilePath, fileName);
            }
        }

        [TestMethod]
        public void CompileMinifiedTypeScriptFileTest()
        {
            var assembly = typeof(NameModel).Assembly;
            using (var kernel = new ConversionKernel(assembly).LoadXmlDocumentation())
            {
                CompileTypeScript(kernel, minify: true);
            }
        }

        [TestMethod]
        public void CompileDefinitelyTypedFileTest()
        {
            var assembly = typeof(NameModel).Assembly;
            using (var kernel = new ConversionKernel(assembly).LoadXmlDocumentation())
            {
                CompileDefinitelyTyped(kernel);
            }
        }
    }
}