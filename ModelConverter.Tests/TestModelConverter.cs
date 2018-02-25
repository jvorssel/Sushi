using System;
using System.Linq;
using Common.Utility.Enum.ECMAScript;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ModelConverter.Tests
{
    [TestClass]
    public class TestModelConverter
    {

        [TestInitialize]
        public void BeforeTest()
        {
        }

        [TestMethod]
        public void TestFindModelsInAssembly()
        {
            using (var kernel = new ConversionKernel())
            {
                var template = TemplateManager.ForEcmaScript(kernel, EcmaVersion.V6, false);
                var converter = kernel.CreateConverter(typeof(TestModelConverter).Assembly, template);

                Assert.IsTrue(converter.ModelCount > 0);
                Assert.AreEqual(converter.Models[0].Name, @"SomeModel");
            }
        }

        [TestMethod]
        public void TestFieldFindingInModel()
        {
            using (var kernel = new ConversionKernel())
            {
                var template = TemplateManager.ForEcmaScript(kernel, EcmaVersion.V6, false);
                var converter = kernel.CreateConverter(typeof(TestModelConverter).Assembly, template);

                var firstModel = converter.Models.First();

                Assert.IsTrue(firstModel.Properties.Count >= 3);
                var name = firstModel.Properties.Single(x => x.Name.ToLower() == "name");
                var insertion = firstModel.Properties.Single(x => x.Name.ToLower() == "insertion");
                var surname = firstModel.Properties.Single(x => x.Name.ToLower() == "surname");

                Assert.IsNotNull(name);
                Assert.IsNotNull(insertion);
                Assert.IsNotNull(surname);

                Assert.AreEqual(name.Default.ToString(), "Jeroen");
                Assert.AreEqual(surname.Default.ToString(), "Vorsselman");
            }
        }
    }
}
