using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.Extensions;
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
            var assembly = typeof(TypeScriptTests).Assembly;
            using (var kernel = new ConversionKernel(assembly).LoadXmlDocumentation(assembly))
            {
                CompileTypeScript(kernel);
            }
        }

        [TestMethod]
        public void CompileDefinitelyTypedFileTest()
        {
            var assembly = typeof(TypeScriptTests).Assembly;
            using (var kernel = new ConversionKernel(assembly).LoadXmlDocumentation(assembly))
            {
                CompileDefinitelyTyped(kernel);
            }
        }

    }
}