using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.TestModels;

namespace Sushi.Tests
{
	[TestClass]
	public class ModelToConvertTests
	{
		public TestContext Context { get; set; }

		[TestInitialize]
		public void BeforeTest() { }

		[TestMethod]
		public void FindModelWithInterfaceTest()
		{
			var kernel = new ConversionKernel(typeof(PersonViewModel).Assembly);
			// NameModel inherits the interface, should be true.
			Assert.IsTrue(kernel.Models.Any(x => x.Name == nameof(SchoolViewModel)));
		}
	}
}