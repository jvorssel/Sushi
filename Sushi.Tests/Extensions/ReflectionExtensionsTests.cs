// /***************************************************************************\
// Module Name:       ReflectionExtensionsTests.cs
// Project:                   Sushi.Tests
// Author:                   Jeroen Vorsselman 14-05-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.Extensions;
using Sushi.Tests.Models;

namespace Sushi.Tests.Extensions;

public abstract class ReflectionExtensionsTests
{
	[TestClass]
	public class CreateInstance : ReflectionExtensionsTests
	{
		[TestMethod]
		public void CreateInstance_SimpleViewModel_ShouldInitializeTest()
		{
			// Arrange
			var type = typeof(PersonViewModel);
			
			// Act
			var instance = type.CreateInstance();
			
			// Assert
			Assert.IsNotNull(instance);
			Assert.IsNotNull(instance as PersonViewModel);
		}
		
		[TestMethod]
		public void CreateInstance_ComplexViewModel_ShouldInitializeTest()
		{
			// Arrange
			var type = typeof(SchoolViewModel);
			var property = type.GetProperty("AverageGrade");
			
			// Act
			var instance = type.CreateInstance();
			
			// Assert
			Assert.IsNotNull(instance);
			Assert.IsNotNull(instance as SchoolViewModel);
		}
		
		[TestMethod]
		public void CreateInstance_GenericType_ShouldInitializeTest()
		{
			// Arrange
			var type = typeof(GenericStandalone<string>);
			
			// Act
			var instance = type.CreateInstance();
			
			// Assert
			Assert.IsNotNull(instance);
			Assert.IsNotNull(instance as GenericStandalone<string>);
		}
		
		[TestMethod]
		public void CreateInstance_GenericTypeDefinition_ShouldReturnNullTest()
		{
			// Arrange
			var type = typeof(GenericStandalone<>);
			
			// Act
			var instance = type.CreateInstance();
			
			// Assert
			Assert.IsNull(instance);
		}
		
		[TestMethod]
		public void CreateInstance_Interface_ShouldReturnNullTest()
		{
			// Arrange
			var type = typeof(ISchoolViewModel);
			
			// Act
			var result = type.CreateInstance();
			
			// Assert
			Assert.IsNull(result);
		}
		
		[TestMethod]
		public void CreateInstance_AbstractType_ShouldReturnNullTest()
		{
			// Arrange
			var type = typeof(ViewModel);
			
			// Act
			var result = type.CreateInstance();
			
			// Assert
			Assert.IsNull(result);
		}
	}
}