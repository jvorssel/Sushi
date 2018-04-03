using Sushi.Attributes;

namespace Sushi.TestModels.Inheritance
{
	[ConvertToScript]
	public enum Gender
	{
		/// <summary>
		///		No <see cref="Gender"/> specified.
		/// </summary>
		Undefined = 0,

		/// <summary>
		///		The <see cref="Male"/> <see cref="Gender"/>.
		/// </summary>
		Male = 1,

		/// <summary>
		///		The <see cref="Female"/> <see cref="Gender"/>.
		/// </summary>
		Female = 2,

		/// <summary>
		///		 An odd <see cref="Gender"/>.
		/// </summary>
		Other = 3,
	}
}