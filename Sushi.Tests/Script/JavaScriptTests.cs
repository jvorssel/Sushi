using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.JavaScript.Enum;
using Sushi.Models;
using Sushi.Tests.Models.Inheritance;

namespace Sushi.Tests.Script
{
    [TestClass]
    public class JavaScriptTests : TestBase
    {
        public TestContext Context { get; set; }

        [TestMethod]
        public void CompileJavaScriptFileTest()
        {
            var assembly = typeof(JavaScriptTests).Assembly;
            using (var kernel = new ConversionKernel(assembly).LoadXmlDocumentation())
            {
                CompileJavaScript(kernel, JavaScriptVersion.V5);
                CompileJavaScript(kernel, JavaScriptVersion.V5, true);
                CompileJavaScript(kernel, JavaScriptVersion.V6);
            }
        }

        [TestMethod]
        public void CompileMinifiedJavaScriptFileTest()
        {
            var assembly = typeof(JavaScriptTests).Assembly;
            using (var kernel = new ConversionKernel(assembly).LoadXmlDocumentation())
            {
                CompileJavaScript(kernel, JavaScriptVersion.V5, minify: true);
                CompileJavaScript(kernel, JavaScriptVersion.V5, true, minify: true);
                CompileJavaScript(kernel, JavaScriptVersion.V6, minify: true);
            }
        }
    }
}