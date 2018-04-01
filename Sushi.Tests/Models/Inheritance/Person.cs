using Sushi.Interfaces;

namespace Sushi.Tests.Models.Inheritance
{

	public class PersonModel:IScriptModel
	{
		public string Name { get; set; } = "Jeroen";
		public string Surname { get; set; } = "Vorsselman";

	}
}
