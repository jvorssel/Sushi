namespace Sushi.TestModels
{
    /// <summary>
    ///		Represents a Student in a school.
    /// </summary>
    public class StudentViewModel : PersonViewModel
    {
        /// <summary>
        ///		What <see cref="Grade"/> the Student is in.
        /// </summary>
        public int Grade { get; set; } = 9;

        /// <summary>
        ///		The name of the <see cref="School"/>.
        /// </summary>
        public SchoolViewModel School { get; set; }
    }
}