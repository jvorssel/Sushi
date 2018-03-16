using Sushi.Attributes;

namespace Sushi.Tests.Models.Ignore {
	public class DoNotIgnoreMe : IgnoreTestRoot
	{
		public string ShouldExist { get; set; }

		[IgnoreForScript]
		public string ShouldNotExist { get; set; }
	}
}