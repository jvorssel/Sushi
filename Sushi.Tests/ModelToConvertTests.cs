using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.TestModels;
using Sushi.TestModels.Inheritance;

namespace Sushi.Tests
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
			using (var kernel = new ConversionKernel(typeof(PersonModel).Assembly))
			{
				// NameModel inherits the interface, should be true.
				Assert.IsTrue(kernel.Models.Any(x => x.Name == nameof(NameModel)));
			}
		}

		
	}
}