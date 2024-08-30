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
using Sushi.Extensions;
using Sushi.TestModels;
using Xunit;


namespace Sushi.Tests.Extensions;

public abstract class ReflectionExtensionsTests
{
    
    public sealed class CreateInstance : ReflectionExtensionsTests
    {
        [Fact]
        public void CreateInstance_SimpleViewModel_ShouldInitializeTest()
        {
            // Arrange
            var type = typeof(PersonViewModel);

            // Act
            var instance = type.CreateInstance();

            // Assert
            Assert.NotNull(instance);
            Assert.NotNull(instance as PersonViewModel);
        }

        [Fact]
        public void CreateInstance_ComplexViewModel_ShouldInitializeTest()
        {
            // Arrange
            var type = typeof(SchoolViewModel);

            // Act
            var instance = type.CreateInstance();

            // Assert
            Assert.NotNull(instance);
            Assert.NotNull(instance as SchoolViewModel);
        }

        [Fact]
        public void CreateInstance_GenericType_ShouldInitializeTest()
        {
            // Arrange
            var type = typeof(GenericStandalone<string>);

            // Act
            var instance = type.CreateInstance();

            // Assert
            Assert.NotNull(instance);
            Assert.NotNull(instance as GenericStandalone<string>);
        }

        [Fact]
        public void CreateInstance_GenericTypeDefinition_ShouldReturnNullTest()
        {
            // Arrange
            var type = typeof(GenericStandalone<>);

            // Act
            var instance = type.CreateInstance();

            // Assert
            Assert.Null(instance);
        }

        [Fact]
        public void CreateInstance_Interface_ShouldReturnNullTest()
        {
            // Arrange
            var type = typeof(ISchoolViewModel);

            // Act
            var result = type.CreateInstance();

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void CreateInstance_AbstractType_ShouldReturnNullTest()
        {
            // Arrange
            var type = typeof(ViewModel);

            // Act
            var result = type.CreateInstance();

            // Assert
            Assert.Null(result);
        }
    }

    
    public sealed class InheritsInterface : ReflectionExtensionsTests
    {
        [Fact]
        public void IsOrInheritsInterface_Equal_ReturnTrueTest()
        {
            // Arrange
            var type = typeof(IEnumerable<int>);

            // Act
            var result = type.IsOrInheritsInterface<IEnumerable<int>>();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsOrInheritsInterface_InheritedArgument_ReturnTrueTest()
        {
            // Arrange
            var type = typeof(IEnumerable<int>);

            // Act
            var result = type.IsOrInheritsInterface<IEnumerable>();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsOrInheritsInterface_NotAnInterface_ShouldThrow()
        {
            // Arrange
            var type = typeof(IEnumerable<int>);
            var exception = new ArgumentException($"Expected {nameof(StudentViewModel)} to be an interface.");

            // Act & Assert
            var result =
                Assert.Throws<ArgumentException>(() => type.IsOrInheritsInterface<StudentViewModel>());
            Assert.Equal(exception.Message, result.Message);
        }
    }

    
    public sealed class IsArrayType : ReflectionExtensionsTests
    {
        [Fact]
        public void IsArrayType_IEnumerable_ReturnTrueTest()
        {
            // Arrange
            var type = typeof(IEnumerable<int>);

            // Act
            var result = type.IsArrayType();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsArrayType_Array_ReturnTrueTest()
        {
            // Arrange
            var type = typeof(int[]);

            // Act
            var result = type.IsArrayType();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsArrayType_String_ReturnFalseTest()
        {
            // Arrange
            var type = typeof(string);

            // Act
            var result = type.IsArrayType();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsArrayType_Dictionary_ReturnFalseTest()
        {
            // Act
            var valueType = typeof(Dictionary<string, int>).IsArrayType();
            var interfaceType = typeof(IDictionary<string, int>).IsArrayType();
            
            // Act & Assert
            Assert.False(valueType);
            Assert.False(interfaceType);
        }
    }

    
    public sealed class IsPropertyHidingBaseClassPropertyMethod : ReflectionExtensionsTests
    {
        [Fact]
        public void IsPropertyHidingBaseClassProperty_NotFound_ShouldThrow()
        {
            // Arrange
            var classType = typeof(NullablePropertiesViewModel);
            
            // Assert
            Assert.Throws<ArgumentException>(() => classType.IsPropertyHidingBaseClassProperty("nope"));
        }
        
        [Fact]
        public void IsPropertyHidingBaseClassProperty_Inherited_ShouldReturnTrueTest()
        {
            // Arrange
            var classType = typeof(NullablePropertiesViewModel);
            var propertyName = nameof(NullablePropertiesViewModel.Guid);
            
            // Act
            var result = classType.IsPropertyHidingBaseClassProperty(propertyName);
            
            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void IsPropertyHidingBaseClassProperty_NotInherited_ShouldReturnTrueTest()
        {
            // Arrange
            var classType = typeof(NullablePropertiesViewModel);
            var propertyName = nameof(NullablePropertiesViewModel.Value2);
            
            // Act
            var result = classType.IsPropertyHidingBaseClassProperty(propertyName);
            
            // Assert
            Assert.False(result);
        }
    }
}