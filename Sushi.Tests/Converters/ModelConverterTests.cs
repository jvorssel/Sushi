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
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Sushi.Converters;
using Sushi.Enum;
using Sushi.Helpers;
using Sushi.Tests.Models;

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

	[TestClass]
	public class IsSushiTypeMethod : ModelConverterTests
	{
		public Type Type { get; }
		public Type EnumType { get; }
		public TypeScriptConverter Converter { get; }
		
		public IsSushiTypeMethod()
		{
			Type = typeof(TypeModel);
			EnumType = typeof(Gender);
			Converter = new SushiConverter(Type, EnumType).TypeScript();
		}
		
		[TestMethod]
		public void IsSushiType_Arrays_ShouldResolveType()
		{
			// Arrange
			var type = typeof(TypeModel);
			var listType = typeof(List<TypeModel>);
			var arrayType = typeof(TypeModel[]);
			
			// Act
			var typeFound = Converter.IsSushiType(type, out var resolvedType);
			var isListFound = Converter.IsSushiType(listType, out var resolvedListType);
			var isArrayFound = Converter.IsSushiType(arrayType, out var resolvedArrayType);
			
			// Assert
			Assert.IsTrue(typeFound);
			Assert.IsTrue(isListFound);
			Assert.IsTrue(isArrayFound);
			
			Assert.AreEqual(Type, resolvedType);
			Assert.AreEqual(Type, resolvedListType);
			Assert.AreEqual(Type, resolvedArrayType);
		}
		
		[TestMethod]
		public void IsSushiType_Enums_ShouldResolveType()
		{
			// Arrange
			var type = typeof(Gender);
			var listType = typeof(List<Gender>);
			var arrayType = typeof(Gender[]);
			
			// Act
			var typeFound = Converter.IsSushiType(type, out var resolvedType);
			var isListFound = Converter.IsSushiType(listType, out var resolvedListType);
			var isArrayFound = Converter.IsSushiType(arrayType, out var resolvedArrayType);
			
			// Assert
			Assert.IsTrue(typeFound);
			Assert.IsTrue(isListFound);
			Assert.IsTrue(isArrayFound);
			
			Assert.AreEqual(EnumType, resolvedType);
			Assert.AreEqual(EnumType, resolvedListType);
			Assert.AreEqual(EnumType, resolvedArrayType);
		}

		[TestMethod]
		public void ReadonlyType_Property_ShouldResolveDefaultValueTest()
		{
			// Assert
			var result = Converter.Models.Single(x => x.Type == Type);
			var properties = result.Type.GetFieldDescriptors().ToList();
			var property = properties.Single(x => x.Name == "ReadonlyString");
			
			// Act
			var defaultValue = Converter.ResolveDefaultValue(property);
			
			// Assert
			Assert.IsNotNull(defaultValue);
			Assert.AreEqual("\"readonly\"", defaultValue);
		}

		[TestMethod]
		public void ReadonlyType_ShouldResolveDefaultValueTest()
		{
			// Act
			var result = Converter.Models.Single(x => x.Type == Type);
			var property = result.Properties["ReadonlyString"];
			
			// Assert
			Assert.IsNotNull(property);
			Assert.IsTrue(property.Readonly);
			Assert.AreEqual("readonly", property.DefaultValue);
		}
	}
}