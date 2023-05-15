// /***************************************************************************\
// Module Name:       ClassDescriptorTests.cs
// Project:                   Sushi.Tests
// Author:                   Jeroen Vorsselman 01-01-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.Descriptors;
using Sushi.Helpers;
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

				Assert.AreEqual(2, descriptor.Properties.Count);
				Assert.IsFalse(descriptor.HasParameterlessCtor);
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
				Assert.IsFalse(descriptor.HasParameterlessCtor);
			}
			
			[TestMethod]
			public void Initialize_WithGenericClass_ShouldMapCorrectly()
			{
				// Arrange
				var withGenericType = typeof(GenericStandalone<string>);
				var withoutGenericType = typeof(GenericStandalone<>);

				// Act
				var with = new ClassDescriptor(withGenericType);
				var without = new ClassDescriptor(withoutGenericType);

				// Assert
				Assert.AreEqual(2, with.Properties.Count);
				Assert.AreEqual(2, without.Properties.Count);
				
				Assert.AreEqual("T1", with.GenericParameterNames.Single());
				Assert.AreEqual("T1", without.GenericParameterNames.Single());
				
				Assert.IsTrue(with.HasParameterlessCtor);
				Assert.IsTrue(without.HasParameterlessCtor);
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
			
			[TestMethod]
			public void Equal_WithNullValues_ShouldNotBeEqual()
			{
				// Arrange
				var m1 = new ClassDescriptor(typeof(ViewModel));
				var m2 = (ClassDescriptor)null;

				// Act & Assert
				Assert.IsFalse(m1 == m2);
				Assert.IsTrue(m2 != m1);
				Assert.IsFalse(m1.Equals(m2));
				Assert.IsFalse(m1.Equals((object)null));
				Assert.IsTrue(m1.Equals((object)m1));
				Assert.IsTrue(m1.GetHashCode() == m1.GetHashCode());
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
				Assert.AreEqual(9, descriptor.Properties.Count);
				Assert.AreEqual(8, descriptor.Properties.Count(x => x is PropertyDescriptor));
				Assert.AreEqual(1, descriptor.Properties.Count(x => x is FieldDescriptor));
			}
		}

		[TestClass]
		public class GetPropertiesTests : ClassDescriptorTests
		{
			[TestMethod]
			public void GetProperties_IncludeInheritedTest()
			{
				// Arrange
				var descriptor = new ClassDescriptor(typeof(InheritedViewModel))
				{
					Parent = new ClassDescriptor(typeof(BaseViewModel))
				};

				// Act
				var properties = descriptor.GetProperties(false).ToList();

				// Assert
				Assert.IsTrue(properties.Any(x => x.Name == "Guid"));
				Assert.IsTrue(properties.Any(x => x.Name == "Addition"));
				Assert.IsTrue(properties.Any(x => x.Name == "Value"));
				Assert.IsTrue(properties.Any(x => x.Name == "Base"));
			}

			[TestMethod]
			public void GetProperties_ExcludeInheritedTest()
			{
				// Arrange
				var descriptor = new ClassDescriptor(typeof(InheritedViewModel))
				{
					Parent = new ClassDescriptor(typeof(BaseViewModel))
				};

				// Act
				var properties = descriptor.GetProperties(true).ToList();

				// Assert
				Assert.IsTrue(properties.Any(x => x.Name  == "Guid"));
				Assert.IsTrue(properties.Any(x => x.Name  == "Addition"));
				Assert.IsFalse(properties.Any(x => x.Name == "Value"));
				Assert.IsFalse(properties.Any(x => x.Name == "Base"));
			}
		}
		
		[TestClass]
		public class FilterTypesTest : ClassDescriptorTests
		{
			[TestMethod]
			public void FilterTypes_WithoutAttribute_ShouldFilterTest()
			{
				// Arrange
				var descriptors = new[] { typeof(ViewModel), typeof(string) }.Select(x=> new ClassDescriptor(x));

				// Act
				var result = descriptors.FilterClassDescriptors().ToList();

				// Assert
				Assert.AreEqual(1, result.Count);
				Assert.AreEqual(typeof(ViewModel), result.Single().Type);
			}

			[TestMethod]
			public void FilterTypes_WithNonClassTypes_ShouldFilterTest()
			{
				// Arrange
				var descriptors = new[] { typeof(ViewModel), typeof(bool), typeof(Gender) }.Select(x=> new ClassDescriptor(x));

				// Act
				var result = descriptors.FilterClassDescriptors().ToList();

				// Assert
				Assert.AreEqual(1, result.Count);
				Assert.AreEqual(typeof(ViewModel), result.Single().Type);
			}
		}
	}
}