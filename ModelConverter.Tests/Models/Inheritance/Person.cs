using ModelConverter.Interfaces;

namespace ModelConverter.Tests.Models.Inheritance
{

	public class PersonModel:IModelToConvert
	{
		public string Name { get; set; } = "Jeroen";
		public string Surname { get; set; } = "Vorsselman";

	}
}
