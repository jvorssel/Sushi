using ModelConverter.Interfaces;

namespace ModelConverter.Tests.Models.Inheritance
{
	public class StudentModel : PersonModel, IModelToConvert
	{
		public int Grade { get; set; } = 9;
		public string School { get; set; } = @"Sint Jan";
		public Gender Gender { get; set; } = Gender.Undefined;
	}
}