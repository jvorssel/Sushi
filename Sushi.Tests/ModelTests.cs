using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.TestModels;

namespace Sushi.Tests
{
	[TestClass]
	public class ModelTests
	{
		private readonly Assembly _assembly = typeof(PersonViewModel).Assembly;
		public TestContext Context { get; set; }

		[TestMethod]
		public void ModelsInAssemblyTest()
		{
			var kernel = new ConversionKernel(_assembly);
			Assert.IsTrue(kernel.ModelCount > 0, "Expected atleast one model to be available.");
			Assert.IsTrue(kernel.Models.Any(x => x.Name == nameof(SchoolViewModel)), "Expected atleast one ");
		}

		[TestMethod]
		public void ModelPropertyRecognitionTest()
		{
			var kernel = new ConversionKernel(_assembly);

			var personModel = kernel.Models.SingleOrDefault(x => x.Name == nameof(PersonViewModel));
			Assert.IsNotNull(personModel);

			// PersonModel has 2 properties
			Assert.AreEqual(6, personModel.Properties.Count);

			// The name property
			var name = personModel.Properties.SingleOrDefault(x => x.Name == nameof(PersonViewModel.Name));
			Assert.IsNotNull(name);

			// The surname property
			var surname = personModel.Properties.SingleOrDefault(x => x.Name == nameof(PersonViewModel.Surname));
			Assert.IsNotNull(surname);
		}
	}
}