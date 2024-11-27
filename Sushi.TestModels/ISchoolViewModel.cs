namespace Sushi.TestModels;

/// <summary>
///		Basic information about a School.
/// </summary>
public interface ISchoolViewModel
{
	/// <summary>
	///     The <see cref="Name" /> of this <see cref="SchoolViewModel" />.
	/// </summary>
	string Name { get; set; }

	/// <summary>
	///     The <see cref="AmountOfStudents" /> of this <see cref="SchoolViewModel" />.
	/// </summary>
	long AmountOfStudents { get; set; }
}