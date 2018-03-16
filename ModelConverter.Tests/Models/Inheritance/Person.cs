using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelConverter.Interfaces;

namespace ModelConverter.Tests.Models.Inheritance
{

	public class PersonModel:IModelToConvert
	{
		public string Name { get; set; } = "Jeroen";
		public string Surname { get; set; } = "Vorsselman";

	}
}
