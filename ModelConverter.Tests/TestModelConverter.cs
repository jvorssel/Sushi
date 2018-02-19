using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ModelConverter.Tests
{
    [TestClass]
    public class TestModelConverter
    {
        [TestMethod]
        public void TestFindModelsInAssembly()
        {
            // ACT
            var converter = ConversionKernel.Initialize(typeof(TestModelConverter).Assembly);

            Assert.IsTrue(converter.ModelCount > 0);
        }
    }
}
