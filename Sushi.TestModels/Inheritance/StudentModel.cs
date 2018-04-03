namespace Sushi.TestModels.Inheritance
{
	/// <summary>
	///		Represents a Student in a school.
	/// </summary>
	public class StudentModel : PersonModel
	{
		/// <summary>
		///		What <see cref="Grade"/> the Student is in.
		/// </summary>
		public int Grade { get; set; } = 9;

		/// <summary>
		///		The name of the <see cref="School"/>.
		/// </summary>
		public string School { get; set; } = @"Sint Jan";

		/// <summary>
		///		The <see cref="Gender"/> of the Student.
		/// </summary>
		public Gender Gender { get; set; } = Gender.Undefined;
	}
}