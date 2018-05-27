using System.Collections.Generic;

namespace Sushi.TestModels {
	/// <summary>
	///		Basic information about a School.
	/// </summary>
	public class SchoolViewModel : ViewModel
	{
		/// <summary>
		///		The <see cref="Name"/> of this <see cref="SchoolViewModel"/>.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		///		The <see cref="Owner"/> of this <see cref="SchoolViewModel"/>.
		/// </summary>
		public PersonViewModel Owner { get; set; }

		/// <summary>
		///		The <see cref="AmountOfStudents"/> of this <see cref="SchoolViewModel"/>.
		/// </summary>
		public long AmountOfStudents { get; set; }

		/// <summary>
		///		The <see cref="Address"/> of this <see cref="SchoolViewModel"/>.
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		///		The <see cref="ZipCode"/> of this <see cref="SchoolViewModel"/>.
		/// </summary>
		public string ZipCode { get; set; }

		/// <summary>
		///		The <see cref="HouseNumber"/> of this <see cref="SchoolViewModel"/>.
		/// </summary>
		public int HouseNumber { get; set; }

		/// <summary>
		///		The <see cref="HouseNumberAddition"/> of this <see cref="SchoolViewModel"/>.
		/// </summary>
		public string HouseNumberAddition { get; set; }

		/// <summary>
		///     The <see cref="Students"/> of this <see cref="SchoolViewModel"/>.
		/// </summary>
		public virtual List<StudentViewModel> Students { get; set; } = new List<StudentViewModel>();
	}
}