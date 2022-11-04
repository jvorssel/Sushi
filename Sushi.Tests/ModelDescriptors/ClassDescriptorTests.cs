// /***************************************************************************\
// Module Name:       ClassDescriptorTests.cs
// Project:                   Sushi.Tests
// Author:                   Jeroen Vorsselman 04-11-2022
// Copyright:              Royaldesk @ 2022
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.Descriptors;
using Sushi.Tests.Models;

#endregion

namespace Sushi.Tests.ModelDescriptors
{
	public abstract class ClassDescriptorTests
	{
		[TestClass]
		public class InitializerTests : ClassDescriptorTests
		{
			[TestMethod]
			public void Initialize_WithSimpleClass_ShouldMapCorrectly()
			{
				// Arrange
				var type = typeof(ViewModel);

				// Act
				var descriptor = new ClassDescriptor(type);

				// Assert
				Assert.AreEqual(nameof(ViewModel), descriptor.Name);
				Assert.AreEqual(type.FullName, descriptor.FullName);
				Assert.AreEqual(string.Empty, descriptor.Script);

				Assert.AreEqual(2, descriptor.Properties.Count);
			}

			[TestMethod]
			public void Initialize_WithNestedClass_ShouldMapCorrectly()
			{
				// Arrange
				var type = typeof(PersonViewModel);

				// Act
				var descriptor = new ClassDescriptor(type);

				// Assert
				Assert.AreEqual(6, descriptor.Properties.Count);
				Assert.AreEqual(descriptor.Properties.Distinct().Count(), descriptor.Properties.Count);
			}
		}

		[TestClass]
		public class EqualityOperatorTests
		{
			[TestMethod]
			public void Equal_WithClass_ShouldBeEqual()
			{
				// Arrange
				var m1 = new ClassDescriptor(typeof(ViewModel));
				var m2 = new ClassDescriptor(typeof(ViewModel));

				// Act
				var result = m1 == m2;

				// Assert
				Assert.IsTrue(result);
			}

			[TestMethod]
			public void Equal_WithInheritedClass_ShouldNotBeEqual()
			{
				// Arrange
				var m1 = new ClassDescriptor(typeof(ViewModel));
				var m2 = new ClassDescriptor(typeof(PersonViewModel));

				// Act
				var result = m1 == m2;

				// Assert
				Assert.IsFalse(result);
			}
		}

		[TestClass]
		public class PropertyDescriptorsTests
		{
			[TestMethod]
			public void NestedTypeModel_ShouldFindAllFieldsAndPropertiesTest()
			{
				// Arrange
				var type = typeof(TypeModel);

				// Act
				var descriptor = new ClassDescriptor(type);

				// Assert
				Assert.AreEqual(4, descriptor.Properties.Count);
				Assert.AreEqual(3, descriptor.Properties.Count(x => x is PropertyDescriptor));
				Assert.AreEqual(1, descriptor.Properties.Count(x => x is FieldDescriptor));
			}
		}
	}
}