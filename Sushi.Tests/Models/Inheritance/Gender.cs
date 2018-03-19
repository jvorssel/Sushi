using Sushi.Attributes;

namespace Sushi.Tests.Models.Inheritance
{
	[ConvertToScript]
	public enum Gender
	{
		Undefined = 0,
		Male = 1,
		Female = 2,
		Other = 3,
	}
}