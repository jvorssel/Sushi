using System;
using Sushi.Descriptors;
using Sushi.TestModels;
using Xunit;

namespace Sushi.Tests.ModelDescriptors;

public abstract class PropertyDescriptorTests
{
    
    public sealed class DefaultTypeMapTests : PropertyDescriptorTests
    {
        [Fact]
        public void GuidProperty_ShouldMapCorrectly()
        {
            // Arrange
            var classDescriptor = new ClassDescriptor(typeof(ViewModel));

            // Act
            var descriptor = classDescriptor.GetProperty(nameof(ViewModel.Guid));

            // Assert
            Assert.Equal(nameof(ViewModel.Guid), descriptor.Name);
            Assert.Equal(typeof(Guid), descriptor.Type);
        }

        [Fact]
        public void NullableProperty_ShouldMapCorrectly()
        {
            // Arrange
            var classDescriptor = new ClassDescriptor(typeof(TypeModel));

            // Act
            var descriptor = classDescriptor.GetProperty(nameof(TypeModel.NullableBool));

            // Assert
            Assert.Equal(nameof(TypeModel.NullableBool), descriptor.Name);
            Assert.Equal(typeof(bool?), descriptor.Type);
        }
            
            

        [Fact]
        public void NullableStringValue2_ShouldMapCorrectly()
        {
            // Arrange
            var converter = new SushiConverter().TypeScript();
            var property = typeof(NullablePropertiesViewModel).GetProperty("Value2") ?? throw new InvalidOperationException("Unable to resolve property.");

            var prop = new PropertyDescriptor(property, null);

            // Act
            var value = converter.ResolveDefaultValue(prop);

            // Assert
            Assert.Equal("null", value);
            Assert.True(prop.IsNullable);
        }
    }
}