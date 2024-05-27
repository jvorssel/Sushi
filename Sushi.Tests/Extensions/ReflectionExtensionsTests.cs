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
using System.Collections;
using System.Collections.Generic;
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

    [TestClass]
    public class InheritsInterface : ReflectionExtensionsTests
    {
        [TestMethod]
        public void IsOrInheritsInterface_Equal_ReturnTrueTest()
        {
            // Arrange
            var type = typeof(IEnumerable<int>);

            // Act
            var result = type.IsOrInheritsInterface<IEnumerable<int>>();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsOrInheritsInterface_InheritedArgument_ReturnTrueTest()
        {
            // Arrange
            var type = typeof(IEnumerable<int>);

            // Act
            var result = type.IsOrInheritsInterface<IEnumerable>();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsOrInheritsInterface_NotAnInterface_ShouldThrow()
        {
            // Arrange
            var type = typeof(IEnumerable<int>);
            var exception = new ArgumentException($"Expected {nameof(StudentViewModel)} to be an interface.");

            // Act & Assert
            var result =
                Assert.ThrowsException<ArgumentException>(() => type.IsOrInheritsInterface<StudentViewModel>());
            Assert.AreEqual(exception.Message, result.Message);
        }
    }

    [TestClass]
    public class IsArrayType : ReflectionExtensionsTests
    {
        [TestMethod]
        public void IsArrayType_IEnumerable_ReturnTrueTest()
        {
            // Arrange
            var type = typeof(IEnumerable<int>);

            // Act
            var result = type.IsArrayType();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsArrayType_Array_ReturnTrueTest()
        {
            // Arrange
            var type = typeof(int[]);

            // Act
            var result = type.IsArrayType();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsArrayType_String_ReturnFalseTest()
        {
            // Arrange
            var type = typeof(string);

            // Act
            var result = type.IsArrayType();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsArrayType_Dictionary_ReturnFalseTest()
        {
            // Act
            var valueType = typeof(Dictionary<string, int>).IsArrayType();
            var interfaceType = typeof(IDictionary<string, int>).IsArrayType();
            
            // Act & Assert
            Assert.IsFalse(valueType);
            Assert.IsFalse(interfaceType);
        }
    }

    [TestClass]
    public class IsPropertyHidingBaseClassPropertyMethod : ReflectionExtensionsTests
    {
        [TestMethod]
        public void IsPropertyHidingBaseClassProperty_NotFound_ShouldThrow()
        {
            // Arrange
            var classType = typeof(NullablePropertiesViewModel);
            
            // Assert
            Assert.ThrowsException<ArgumentException>(() => classType.IsPropertyHidingBaseClassProperty("nope"));
        }
        
        [TestMethod]
        public void IsPropertyHidingBaseClassProperty_Inherited_ShouldReturnTrueTest()
        {
            // Arrange
            var classType = typeof(NullablePropertiesViewModel);
            var propertyName = nameof(NullablePropertiesViewModel.Guid);
            
            // Act
            var result = classType.IsPropertyHidingBaseClassProperty(propertyName);
            
            // Assert
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void IsPropertyHidingBaseClassProperty_NotInherited_ShouldReturnTrueTest()
        {
            // Arrange
            var classType = typeof(NullablePropertiesViewModel);
            var propertyName = nameof(NullablePropertiesViewModel.Value2);
            
            // Act
            var result = classType.IsPropertyHidingBaseClassProperty(propertyName);
            
            // Assert
            Assert.IsFalse(result);
        }
    }
}