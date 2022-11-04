// /***************************************************************************\
// Module Name:       TypeConverterTests.cs
// Project:                   Sushi.Tests
// Author:                   Jeroen Vorsselman 04-11-2022
// Copyright:              Royaldesk @ 2022
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.Converters;
using Sushi.Descriptors;
using Sushi.Tests.Models;

#endregion

namespace Sushi.Tests.ModelDescriptors
{
	public abstract class TypeConverterTests
	{
		private readonly List<Type> _dependencies = new()
		{
			typeof(TypeModel),
			typeof(Gender),
			typeof(StudentViewModel),
			typeof(PersonViewModel),
			typeof(ViewModel)
		};

		[TestClass]
		public class AssignScriptTypesTests : TypeConverterTests
		{
			[TestMethod]
			public void ComplexType_ClassProperty_ShouldFormatCorrectly()
			{
				// Arrange
				var typeClass = _dependencies[0];
				var converter = new SushiConverter(_dependencies);

				// Act
				converter.AssignScriptTypes();

				// Assert
				var typeModelDescriptor = converter.Models.FindDescriptor(typeClass);
				var studentPropertyDescriptor = typeModelDescriptor.Properties.Single(x => x.Name == "Student");

				Assert.IsNotNull(studentPropertyDescriptor);
				Assert.AreEqual("StudentViewModel | null", studentPropertyDescriptor.ScriptTypeValue);
			}

			[TestMethod]
			public void ComplexType_ArrayProperty_ShouldFormatCorrectly()
			{
				// Arrange
				var typeClass = _dependencies[0];
				var converter = new SushiConverter(_dependencies);

				// Act
				converter.AssignScriptTypes();

				// Assert
				var typeModelDescriptor = converter.Models.FindDescriptor(typeClass);
				var studentsPropertyDescriptor = typeModelDescriptor.Properties.Single(x => x.Name == "Students");

				Assert.IsNotNull(studentsPropertyDescriptor);
				Assert.AreEqual("Array<StudentViewModel | null>", studentsPropertyDescriptor.ScriptTypeValue);
			}

			[TestMethod]
			public void ComplexType_MultilayerArrayProperty_ShouldFormatCorrectly()
			{
				// Arrange
				var typeClass = _dependencies[0];
				var converter = new SushiConverter(_dependencies);

				// Act
				converter.AssignScriptTypes();

				// Assert
				var typeModelDescriptor = converter.Models.FindDescriptor(typeClass);
				var studentsPropertyDescriptor =
					typeModelDescriptor.Properties.Single(x => x.Name == "StudentPerClass");

				Assert.IsNotNull(studentsPropertyDescriptor);
				Assert.AreEqual("Array<Array<StudentViewModel | null>>", studentsPropertyDescriptor.ScriptTypeValue);
			}
		}
	}
}