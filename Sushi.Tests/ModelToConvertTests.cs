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
			var converter = new Converter(typeof(PersonViewModel).Assembly);
			// NameModel inherits the interface, should be true.
			Assert.IsTrue(converter.Models.Any(x => x.Name == nameof(SchoolViewModel)));
		}
	}
}