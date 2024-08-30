// /***************************************************************************\
// Module Name:       FieldDescriptorTests.cs
// Project:                   Sushi.Tests
// Author:                   Jeroen Vorsselman 02-04-2022
// Copyright:              Royaldesk @ 2022
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

using System;
using Sushi.Descriptors;
using Sushi.Enum;
using Sushi.TestModels;
using Xunit;


namespace Sushi.Tests.ModelDescriptors;

public abstract class FieldDescriptorTests
{
    
    public sealed class TypeMapTests : FieldDescriptorTests
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
            Assert.Equal(NativeType.String, descriptor.NativeType);
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