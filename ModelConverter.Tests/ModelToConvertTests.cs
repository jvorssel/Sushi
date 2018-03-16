using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelConverter.Tests.Models;
using ModelConverter.Tests.Models.Ignore;

namespace ModelConverter.Tests
{
	[TestClass]
	public class ModelToConvertTests
	{
		public TestContext Context { get; set; }

		[TestInitialize]
		public void BeforeTest()
		{

		}

		[TestMethod]
		public void FindModelWithInterfaceTest()
		{
			using (var kernel = new ConversionKernel(typeof(ModelToConvertTests).Assembly))
			{
				// NameModel inherits the interface, should be true.
				Assert.IsTrue(kernel.Models.Any(x => x.Name == nameof(NameModel)));
			}
		}

		[TestMethod]
		public void FindModelWithAttributeTest()
		{
			using (var kernel = new ConversionKernel(typeof(ModelToConvertTests).Assembly))
			{
				// Have the ConvertToScript attribute, should exist in queue.
				Assert.IsTrue(kernel.Models.Any(x => x.Name == nameof(DoNotIgnoreMe)));
				Assert.IsTrue(kernel.Models.Any(x => x.Name == nameof(IgnoreTestRoot)));

				// IgnoreMe has the ignore attribute, should not exist in queue.
				Assert.IsTrue(kernel.Models.All(x => x.Name != nameof(IgnoreMe)));
			}
		}

		[TestMethod]
		public void ExcludePropertyWithAttributeTest()
		{
			using (var kernel = new ConversionKernel(typeof(ModelToConvertTests).Assembly))
			{
				// Get the model with the properties that should use the Ignore attribute.
				var model = kernel.Models.SingleOrDefault(x => x.Name == nameof(DoNotIgnoreMe));
				Assert.IsNotNull(model);

				Assert.IsTrue(model.Properties.Any(x => x.Name == nameof(DoNotIgnoreMe.ShouldExist)));
				Assert.IsTrue(model.Properties.All(x => x.Name != nameof(DoNotIgnoreMe.ShouldNotExist)));
			}
		}
	}
}