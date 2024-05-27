// /***************************************************************************\
// Module Name:       PropertyDescriptorTests.cs
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
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.Descriptors;
using Sushi.Tests.Models;

#endregion

namespace Sushi.Tests.ModelDescriptors
{
    public abstract class PropertyDescriptorTests
    {
        [TestClass]
        public class TypeMapTests : PropertyDescriptorTests
        {
            [TestMethod]
            public void GuidProperty_ShouldMapCorrectly()
            {
                // Arrange
                var classDescriptor = new ClassDescriptor(typeof(ViewModel));

                // Act
                var descriptor = classDescriptor.GetProperty(nameof(ViewModel.Guid));

                // Assert
                Assert.AreEqual(nameof(ViewModel.Guid), descriptor.Name);
                Assert.AreEqual(typeof(Guid), descriptor.Type);
            }

            [TestMethod]
            public void NullableProperty_ShouldMapCorrectly()
            {
                // Arrange
                var classDescriptor = new ClassDescriptor(typeof(TypeModel));

                // Act
                var descriptor = classDescriptor.GetProperty(nameof(TypeModel.NullableBool));

                // Assert
                Assert.AreEqual(nameof(TypeModel.NullableBool), descriptor.Name);
                Assert.AreEqual(typeof(bool?), descriptor.Type);
            }
            
            

            [TestMethod]
            public void NullableStringValue2_ShouldMapCorrectly()
            {
                // Arrange
                var converter = new SushiConverter().TypeScript();
                var property = typeof(NullablePropertiesViewModel).GetProperty("Value2");

                var prop = new PropertyDescriptor(property, null);

                // Act
                var value = converter.ResolveDefaultValue(prop);

                // Assert
                Assert.AreEqual("null", value);
                Assert.IsTrue(prop.IsNullable);
            }
        }
    }
}