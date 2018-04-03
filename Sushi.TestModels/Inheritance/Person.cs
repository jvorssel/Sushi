using Sushi.Interfaces;

namespace Sushi.TestModels.Inheritance
{
	/// <summary>
	///		The <see cref="PersonModel"/> that represents a Person.
	/// </summary>
	public class PersonModel : IScriptModel
	{
		/// <summary>
		///		 The <see cref="Name"/> of the person.
		/// </summary>
		public string Name { get; set; } = "Jeroen";

		/// <summary>
		///		The <see cref="Surname"/> of the person.
		/// </summary>
		public string Surname { get; set; } = "Vorsselman";

	}
}
