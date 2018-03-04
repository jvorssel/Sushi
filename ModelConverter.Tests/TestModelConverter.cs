using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelConverter.JavaScript;
using ModelConverter.JavaScript.Enum;
using ModelConverter.Tests.Models;

namespace ModelConverter.Tests
{
    [TestClass]
    public class TestModelConverter
    {
        public TestContext Context { get; set; }

        [TestInitialize]
        public void BeforeTest()
        {
        }

        [TestMethod]
        public void TestFindModelsInAssembly()
        {
            using (var kernel = new ConversionKernel(typeof(TestModelConverter).Assembly))
            {
                Assert.IsTrue(kernel.ModelCount > 0);
                Assert.IsTrue(kernel.Models.Any(x => x.Name == nameof(NameModel)));
            }
        }

        [TestMethod]
        public void TestFieldFindingInModel()
        {
            using (var kernel = new ConversionKernel(typeof(TestModelConverter).Assembly))
            {
                var firstModel = kernel.Models.First();

                Assert.IsTrue(firstModel.Properties.Count >= 3);
                var name = firstModel.Properties.Single(x => x.Name.ToLower() == "name");
                var insertion = firstModel.Properties.Single(x => x.Name.ToLower() == "insertion");
                var surname = firstModel.Properties.Single(x => x.Name.ToLower() == "surname");

                Assert.IsNotNull(name);
                Assert.IsNotNull(insertion);
                Assert.IsNotNull(surname);

                Assert.AreEqual(name.Value.ToString(), "Jeroen");
                Assert.AreEqual(surname.Value.ToString(), "Vorsselman");
            }
        }

        [TestMethod]
        public void TestBasicModelCompilation()
        {
            using (var kernel = new ConversionKernel(typeof(TestModelConverter).Assembly))
            {
                var converter = kernel.CreateConverterForJavaScript(JavaScriptVersion.V5,true);
                var result = converter.Convert();

                Console.WriteLine(result);

                Assert.IsTrue(result != string.Empty);
            }
        }
    }
}
