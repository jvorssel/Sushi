using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sushi.Tests.Script
{
    [TestClass]
    public class TypeScriptTests : TestBase
    {
        public TestContext Context { get; set; }

        [TestMethod]
        public void CompileTypeScriptFileTest()
        {
            using (var kernel = new ConversionKernel(typeof(ModelTests).Assembly))
            {
                CompileTypeScript(kernel, "typescript", null);
            }
        }

    }
}