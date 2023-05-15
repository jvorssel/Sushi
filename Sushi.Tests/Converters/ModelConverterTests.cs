// /***************************************************************************\
// Module Name:       ModelConverterTests.cs
// Project:                   Sushi.Tests
// Author:                   Jeroen Vorsselman 14-01-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Sushi.Enum;

namespace Sushi.Tests.Converters;

public abstract class ModelConverterTests : TestBase
{
	[TestClass]
	public class ApplyCasingStyleMethod : ModelConverterTests
	{
		[TestMethod]
		public void ApplyCasingStyle_Default_KeepValueTests()
		{
			// Arrange
			var options = new ConverterOptions(casing: PropertyNameCasing.Default);
			var converter = new SushiConverter().TypeScript(options);
			var value = "CasingTest";
			
			// Act
			var result = converter.ApplyCasingStyle(value);
			
			// Assert
			Assert.AreEqual(value, result);
		}
		
		[TestMethod]
		public void ApplyCasingStyle_CamelCasing_ShouldTransformValueTests()
		{
			// Arrange
			var options = new ConverterOptions(casing: PropertyNameCasing.CamelCase);
			var converter = new SushiConverter().TypeScript(options);
			var value = "CasingTest";
			
			// Act
			var result = converter.ApplyCasingStyle(value);
			
			// Assert
			Assert.AreEqual("casingTest", result);
		}
		
		[TestMethod]
		public void ApplyCasingStyle_UnsupportedValue_ShouldThrow()
		{
			// Arrange
			var options = new ConverterOptions(casing: (PropertyNameCasing)500);
			var converter = new SushiConverter().TypeScript(options);
			var value = "CasingTest";
			
			// Act & Assert
			Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
			{
				converter.ApplyCasingStyle("");
			});
		}
	}
}