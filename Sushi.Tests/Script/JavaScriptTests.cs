using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.JavaScript;
using Sushi.JavaScript.Enum;
using Sushi.TestModels;

namespace Sushi.Tests.Script
{
    [TestClass]
    public class JavaScriptTests : TestBase
    {
        public TestContext Context { get; set; }

        [TestMethod]
        public void CompileJavaScriptFileTest()
        {
            var assembly = typeof(NameModel).Assembly;
            using (var kernel = new ConversionKernel(assembly).LoadXmlDocumentation())
            {
                foreach (var model in kernel.Models)
                {
                    var converter = kernel.CreateConverterForJavaScript(JavaScriptVersion.V5, Wrap.SIAF);
                    var converted = converter.Convert(x => x.Type == model.Type);
                    var fileName = model.Name + ".model";

                    converter.WriteToFile(converted, FilePath, fileName);
                }
            }
        }
    }
}