using ModelConverter.Attributes;

namespace ModelConverter.Tests.Models.Ignore {
	public class DoNotIgnoreMe : IgnoreTestRoot
	{
		public string ShouldExist { get; set; }

		[IgnoreForScript]
		public string ShouldNotExist { get; set; }
	}
}