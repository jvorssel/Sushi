namespace Sushi.TestModels;

/// <inheritdoc cref="ISchoolViewModel" />
public sealed class SchoolViewModel : ViewModel, ISchoolViewModel
{
	/// <inheritdoc />
	public string Name { get; set; }

	/// <inheritdoc />
	public long AmountOfStudents { get; set; }

	/// <summary>
	///     The <see cref="Owner" /> of this <see cref="SchoolViewModel" />.
	/// </summary>
	public PersonViewModel Owner { get; set; }

	/// <summary>
	///     The <see cref="Address" /> of this <see cref="SchoolViewModel" />.
	/// </summary>
	public string Address { get; set; } = "";

	/// <summary>
	///     The <see cref="ZipCode" /> of this <see cref="SchoolViewModel" />.
	/// </summary>
	public string ZipCode { get; set; }

	/// <summary>
	///     The <see cref="HouseNumber" /> of this <see cref="SchoolViewModel" />.
	/// </summary>
	public int HouseNumber { get; set; }

	/// <summary>
	///     The <see cref="HouseNumberAddition" /> of this <see cref="SchoolViewModel" />.
	/// </summary>
	public string HouseNumberAddition { get; set; }

	/// <summary>
	///     The school student aren't doing too great ...
	/// </summary>
	public decimal AverageGrade { get; set; } = 2.666666666666666666666666666666666m;

	/// <summary>
	///     The <see cref="Students" /> of this <see cref="SchoolViewModel" />.
	/// </summary>
	public List<StudentViewModel> Students { get; set; } = new List<StudentViewModel>();

	public StudentViewModel Timmy { get; set; } = new StudentViewModel();
}