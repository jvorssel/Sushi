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
using Sushi.Converters;
using Sushi.Enum;
using Sushi.Helpers;
using Sushi.TestModels;
using Xunit;

namespace Sushi.Tests.Converters;

public abstract class ModelConverterTests : TestBase
{
	
	public sealed class ApplyCasingStyleMethod : ModelConverterTests
	{
		[Fact]
		public void ApplyCasingStyle_Default_KeepValueTests()
		{
			// Arrange
			var options = new ConverterOptions(casing: PropertyNameCasing.Default);
			var converter = new SushiConverter().TypeScript(options);
			var value = "CasingTest";
			
			// Act
			var result = converter.ApplyCasingStyle(value);
			
			// Assert
			Assert.Equal(value, result);
		}
		
		[Fact]
		public void ApplyCasingStyle_CamelCasing_ShouldTransformValueTests()
		{
			// Arrange
			var options = new ConverterOptions(casing: PropertyNameCasing.CamelCase);
			var converter = new SushiConverter().TypeScript(options);
			var value = "CasingTest";
			
			// Act
			var result = converter.ApplyCasingStyle(value);
			
			// Assert
			Assert.Equal("casingTest", result);
		}
		
		[Fact]
		public void ApplyCasingStyle_UnsupportedValue_ShouldThrow()
		{
			// Arrange
			var options = new ConverterOptions(casing: (PropertyNameCasing)500);
			var converter = new SushiConverter().TypeScript(options);

			// Act & Assert
			Assert.Throws<ArgumentOutOfRangeException>(() =>
			{
				converter.ApplyCasingStyle("");
			});
		}
	}

	
	public sealed class IsSushiTypeMethod : ModelConverterTests
	{
		public Type Type { get; }
		public Type EnumType { get; }
		public TypeScriptConverter Converter { get; }
		
		public IsSushiTypeMethod()
		{
			Type = typeof(TypeModel);
			EnumType = typeof(Gender);
			Converter = new SushiConverter(Type, typeof(ViewModel), typeof(ScriptModel), EnumType).TypeScript();
		}
		
		[Fact]
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
			Assert.True(typeFound);
			Assert.True(isListFound);
			Assert.True(isArrayFound);
			
			Assert.Equal(Type, resolvedType);
			Assert.Equal(Type, resolvedListType);
			Assert.Equal(Type, resolvedArrayType);
		}
		
		[Fact]
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
			Assert.True(typeFound);
			Assert.True(isListFound);
			Assert.True(isArrayFound);
			
			Assert.Equal(EnumType, resolvedType);
			Assert.Equal(EnumType, resolvedListType);
			Assert.Equal(EnumType, resolvedArrayType);
		}

		[Fact]
		public void ReadonlyType_Property_ShouldResolveDefaultValueTest()
		{
			// Assert
			var result = Converter.Models.Single(x => x.Type == Type);
			var properties = result.Type.GetFieldDescriptors().ToList();
			var property = properties.Single(x => x.Name == "ReadonlyString");
			
			// Act
			var defaultValue = Converter.ResolveDefaultValue(property);
			
			// Assert
			Assert.NotNull(defaultValue);
			Assert.Equal("\"readonly\"", defaultValue);
		}

		[Fact]
		public void ReadonlyType_ShouldResolveDefaultValueTest()
		{
			// Act
			var result = Converter.Models.Single(x => x.Type == Type);
			var property = result.Properties["ReadonlyString"];
			
			// Assert
			Assert.NotNull(property);
			Assert.True(property.Readonly);
			Assert.Equal("readonly", property.DefaultValue);
		}
	}
}