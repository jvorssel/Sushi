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
				var propertyType = typeof(ViewModel).GetProperty(nameof(ViewModel.Guid));

				// Act
				var descriptor = new PropertyDescriptor(propertyType);

				// Assert
				Assert.AreEqual(nameof(ViewModel.Guid), descriptor.Name);
				Assert.AreEqual(typeof(Guid), descriptor.Type);
			}

			[TestMethod]
			public void NullableProperty_ShouldMapCorrectly()
			{
				// Arrange
				var propertyType = typeof(TypeModel).GetProperty(nameof(TypeModel.NullableBool));

				// Act
				var descriptor = new PropertyDescriptor(propertyType);

				// Assert
				Assert.AreEqual(nameof(TypeModel.NullableBool), descriptor.Name);
				Assert.AreEqual(typeof(bool?), descriptor.Type);
				Assert.IsNull(descriptor.DefaultValue);
			}
		}
	}
}