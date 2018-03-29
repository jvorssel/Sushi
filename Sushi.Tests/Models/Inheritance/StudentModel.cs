﻿namespace Sushi.Tests.Models.Inheritance
{
	public class StudentModel : PersonModel
	{
		public int Grade { get; set; } = 9;
		public string School { get; set; } = @"Sint Jan";
		public Gender Gender { get; set; } = Gender.Undefined;
	}
}