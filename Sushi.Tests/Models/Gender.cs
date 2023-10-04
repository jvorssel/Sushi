// ReSharper disable UnusedMember.Global

using Sushi.Attributes;

namespace Sushi.Tests.Models
{
	/// <summary>
	///     Specify a biological Sex / <see cref="Gender" />.
	/// </summary>
	[ConvertToScript]
	public enum Gender
	{
		/// <summary>
		///     No <see cref="Gender" /> specified.
		/// </summary>
		Undefined = 0,

		/// <summary>
		///     The <see cref="Male" /> <see cref="Gender" />.
		/// </summary>
		Male = 1,

		/// <summary>
		///     The <see cref="Female" /> <see cref="Gender" />.
		/// </summary>
		Female = 2
	}
}
