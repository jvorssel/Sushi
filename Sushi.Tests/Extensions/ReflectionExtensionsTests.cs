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
        [Theory]
        [InlineData(typeof(PersonViewModel))]
        [InlineData(typeof(SchoolViewModel))]
        [InlineData(typeof(GenericStandalone<string>))]
        [InlineData(typeof(string))]
        public void CreateInstance_ShouldInitializeTest(Type type)
        {
            // Act
            var instance = type.CreateInstance();

            // Assert
            Assert.NotNull(instance);
            Assert.IsType(type, instance);
        }
        
        [Theory]
        [InlineData(typeof(GenericStandalone<>))]
        [InlineData(typeof(ISchoolViewModel))]
        [InlineData(typeof(ViewModel))]
        public void CreateInstance_ShouldReturnNullTest(Type type)
        {
            // Act
            var instance = type.CreateInstance();

            // Assert
            Assert.Null(instance);
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

    public sealed class GetBaseTypeMethod : ReflectionExtensionsTests
    {
        [Theory]
        [InlineData(typeof(Gender))]
        [InlineData(typeof(Gender[]))]
        [InlineData(typeof(List<Gender>))]
        [InlineData(typeof(IEnumerable<Gender[]>))]
        public void GetBaseType_GenderEnum_ShouldResolveBaseTypeTest(Type source)
        {
            // Arrange
            var expectedType = typeof(Gender);
            
            // Act
            var result = source.GetBaseType();
            
            // Assert
            Assert.Equal(result, expectedType);
        }
    }
    
    
    public sealed class IsArrayTypeMethod : ReflectionExtensionsTests
    {
        [Theory]
        [InlineData(typeof(IEnumerable<int>), true)]
        [InlineData(typeof(int[]), true)]
        [InlineData(typeof(string), false)]
        [InlineData(typeof(Dictionary<string,string>), false)]
        [InlineData(typeof(IDictionary<string,string>), false)]
        public void IsArrayTypeTest(Type type, bool expected)
        {
            // Act
            var result = type.IsArrayType();

            // Assert
            Assert.Equal(expected, result);
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