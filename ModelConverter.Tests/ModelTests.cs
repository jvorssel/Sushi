using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelConverter.Tests.Models;
using ModelConverter.Tests.Models.Inheritance;

namespace ModelConverter.Tests
{
    [TestClass]
    public class ModelTests
    {
        public TestContext Context { get; set; }

        [TestMethod]
        public void ModelsInAssemblyTest()
        {
            using (var kernel = new ConversionKernel(typeof(ModelTests).Assembly))
            {
                Assert.IsTrue(kernel.ModelCount > 0);
                Assert.IsTrue(kernel.Models.Any(x => x.Name == nameof(NameModel)));
            }
        }

        [TestMethod]
        public void ModelPropertyRecognitionTest()
        {
            using (var kernel = new ConversionKernel(typeof(ModelTests).Assembly))
            {
                var personModel = kernel.Models.SingleOrDefault(x => x.Name == nameof(PersonModel));
                Assert.IsNotNull(personModel);

                // PersonModel has 2 properties
                Assert.AreEqual(2, personModel.Properties.Count);

                // The name property
                var name = personModel.Properties.SingleOrDefault(x => x.Name == nameof(PersonModel.Name));
                Assert.IsNotNull(name);

                // The surname property
                var surname = personModel.Properties.SingleOrDefault(x => x.Name == nameof(PersonModel.Surname));
                Assert.IsNotNull(surname);

                // Check their default values
                Assert.AreEqual("Jeroen", name.Value.ToString());
                Assert.AreEqual("Vorsselman", surname.Value.ToString());
            }
        }
    }
}
