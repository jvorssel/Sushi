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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.Descriptors;
using Sushi.Enum;
using Sushi.Tests.Models;

namespace Sushi.Tests.ModelDescriptors
{
	public abstract class FieldDescriptorTests
	{
		[TestClass]
		public class TypeMapTests : FieldDescriptorTests
		{
			[TestMethod]
			public void ReadonlyString_ShouldMapCorrectly()
			{
				// Arrange
				var fieldType = typeof(TypeModel).GetField(nameof(TypeModel.ReadonlyString));
				
				// Act
				var descriptor = new FieldDescriptor(fieldType);
				
				// Assert
				Assert.AreEqual(nameof(TypeModel.ReadonlyString), descriptor.Name);
				Assert.IsTrue(descriptor.IsReadonly);
				Assert.AreEqual(typeof(string), descriptor.Type);
				Assert.IsFalse(descriptor.IsNullable);
				Assert.AreEqual(NativeType.String, descriptor.NativeType);
				Assert.AreEqual("readonly", descriptor.DefaultValue);
			}
		}	
	}
}