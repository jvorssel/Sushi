﻿using System;
using Sushi.Descriptors;
using Sushi.TestModels;
using Xunit;

namespace Sushi.Tests.ModelDescriptors;

public abstract class FieldDescriptorTests
{
    
    public sealed class DefaultTypeMapTests : FieldDescriptorTests
    {
        [Fact]
        public void ReadonlyString_ShouldMapCorrectly()
        {
            // Arrange
            var fieldType = typeof(TypeModel).GetField(nameof(TypeModel.ReadonlyString)) ??
                            throw new InvalidOperationException("Unable to resolve field.");
            ;

            // Act
            var descriptor = new FieldDescriptor(fieldType);

            // Assert
            Assert.Equal(nameof(TypeModel.ReadonlyString), descriptor.Name);
            Assert.True(descriptor.Readonly);
            Assert.Equal(typeof(string), descriptor.Type);
            Assert.False(descriptor.IsNullable);
        }


        [Fact]
        public void NullableStringValue_ShouldMapCorrectly()
        {
            // Arrange
            var converter = new SushiConverter().TypeScript();
            var field = typeof(NullablePropertiesViewModel).GetField("Value") ??
                        throw new InvalidOperationException("Unable to resolve field.");
            ;
            ;

            var descriptor = new FieldDescriptor(field);

            // Act
            var value = converter.ResolveDefaultValue(descriptor);

            // Assert
            Assert.Equal("null", value);
            Assert.True(descriptor.IsNullable);
        }
    }
}