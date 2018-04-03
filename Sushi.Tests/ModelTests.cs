using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.TestModels;
using Sushi.TestModels.Inheritance;

namespace Sushi.Tests
{
    [TestClass]
    public class ModelTests
    {
        private readonly Assembly _assembly = typeof(PersonModel).Assembly;
        public TestContext Context { get; set; }

        [TestMethod]
        public void ModelsInAssemblyTest()
        {
            using (var kernel = new ConversionKernel(_assembly))
            {
                Assert.IsTrue(kernel.ModelCount > 0, "Expected atleast one model to be available.");
                Assert.IsTrue(kernel.Models.Any(x => x.Name == nameof(NameModel)), "Expected atleast one ");
            }
        }

        [TestMethod]
        public void ModelPropertyRecognitionTest()
        {
            using (var kernel = new ConversionKernel(_assembly))
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
