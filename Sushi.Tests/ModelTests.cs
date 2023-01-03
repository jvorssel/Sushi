using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.Descriptors;
using Sushi.Tests.Models;

namespace Sushi.Tests
{
	[TestClass]
	public class ModelTests
	{
		private readonly Assembly _assembly = typeof(PersonViewModel).Assembly;

		[TestMethod]
		public void ModelsInAssemblyTest()
		{
			var converter = new SushiConverter(_assembly);
			Assert.IsTrue(converter.Models.Count > 0, "Expected at least one model to be available.");
			Assert.IsTrue(converter.Models.Any(x => x.Name == nameof(ViewModel)), "Expected at least one ");
		}

		[TestMethod]
		public void ModelPropertyRecognitionTest()
		{
			var converter = new SushiConverter(_assembly);

			var personModel = converter.Models.Flatten().SingleOrDefault(x => x.Name == nameof(PersonViewModel));
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