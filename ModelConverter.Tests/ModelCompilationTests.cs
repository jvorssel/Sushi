﻿using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelConverter.JavaScript;
using ModelConverter.JavaScript.Enum;
using ModelConverter.Models;
using ModelConverter.Tests.Models.Inheritance;

namespace ModelConverter.Tests
{
	[TestClass]
	public class ModelCompilationTests : TestBase
	{
		public TestContext Context { get; set; }

		

		[TestMethod]
		public void CompileAvailableVersionsToFileTest()
		{
			using (var kernel = new ConversionKernel(typeof(ModelTests).Assembly))
			{
				Compile(kernel, JavaScriptVersion.V5, false, "complete", null);
				Compile(kernel, JavaScriptVersion.V5, true, "complete", null);
				Compile(kernel, JavaScriptVersion.V6, false, "complete", null);
			}
		}

		[TestMethod]
		public void CompileInheritanceTest()
		{
			using (var kernel = new ConversionKernel(typeof(ModelTests).Assembly))
			{
				Func<DataModel, bool> predicate = x => x == typeof(PersonModel) || x == typeof(StudentModel);
				Compile(kernel, JavaScriptVersion.V5, false, "inherits", predicate);
				Compile(kernel, JavaScriptVersion.V5, true, "inherits", predicate);
				Compile(kernel, JavaScriptVersion.V6, false, "inherits", predicate);
			}
		}
	}
}