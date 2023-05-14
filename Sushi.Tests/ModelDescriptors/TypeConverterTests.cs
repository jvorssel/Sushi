// /***************************************************************************\
// Module Name:       TypeConverterTests.cs
// Project:                   Sushi.Tests
// Author:                   Jeroen Vorsselman 03-01-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.Converters;
using Sushi.Descriptors;
using Sushi.Extensions;
using Sushi.Tests.Models;

#endregion

namespace Sushi.Tests.ModelDescriptors
{
	public abstract class TypeScriptTypeConverterTests
	{
		[TestClass]
		public class ResolveScriptTypeTests : TypeScriptTypeConverterTests
		{
			[TestMethod]
			public void ComplexType_ClassProperty_ShouldFormatCorrectly()
			{
				// Arrange
				var descriptor = new ClassDescriptor(typeof(TypeModel));
				var propertyDescriptor = descriptor.Properties.Single(x => x.Name == nameof(TypeModel.Student));
				var converter = new TypeScriptTypeConverter();
				converter.Classes.Add(new ClassDescriptor(typeof(StudentViewModel)));

				// Act
				var scriptType = converter.ResolveScriptType(propertyDescriptor.Type);

				// Assert
				Assert.AreEqual("StudentViewModel", scriptType);
			}

			[TestMethod]
			public void ComplexType_ClassPropertyMissing_ShouldUseAny()
			{
				// Arrange
				var descriptor = new ClassDescriptor(typeof(TypeModel));
				var propertyDescriptor = descriptor.Properties.Single(x => x.Name == nameof(TypeModel.Student));
				var converter = new TypeScriptTypeConverter();

				// Act
				var scriptType = converter.ResolveScriptType(propertyDescriptor.Type);

				// Assert
				Assert.AreEqual("any", scriptType);
			}

			[TestMethod]
			public void ComplexType_EnumPropertyMissing_ShouldReturnNumber()
			{
				// Arrange
				var descriptor = new ClassDescriptor(typeof(StudentViewModel));
				var propertyDescriptor = descriptor.Properties.Single(x => x.Name == nameof(StudentViewModel.Gender));
				var converter = new TypeScriptTypeConverter();

				// Act
				var scriptType = converter.ResolveScriptType(propertyDescriptor.Type);

				// Assert
				Assert.AreEqual("number", scriptType);
			}

			[TestMethod]
			public void ComplexType_GenericArrayType_ShouldFormatCorrectly()
			{
				// Arrange
				var converter = new TypeScriptTypeConverter();
				converter.Classes.Add(new ClassDescriptor(typeof(StudentViewModel)));

				// Act
				var results = new[]
				{
					converter.ResolveScriptType(typeof(HashSet<StudentViewModel>)),
					converter.ResolveScriptType(typeof(Collection<StudentViewModel>)),
					converter.ResolveScriptType(typeof(IList<StudentViewModel>)),
					converter.ResolveScriptType(typeof(ICollection<StudentViewModel>)),
					converter.ResolveScriptType(typeof(ImmutableHashSet<StudentViewModel>)),
					converter.ResolveScriptType(typeof(IReadOnlyList<StudentViewModel>)),
					converter.ResolveScriptType(typeof(ReadOnlyCollection<StudentViewModel>)),
					converter.ResolveScriptType(typeof(List<StudentViewModel>))
				};

				// Assert
				foreach (var scriptTypeValue in results)
					Assert.AreEqual("Array<StudentViewModel>", scriptTypeValue);
			}

			[TestMethod]
			public void ComplexType_DeepGenerics_ShouldFormatCorrectly()
			{
				// Arrange
				var converter = new TypeScriptTypeConverter();
				converter.Classes.Add(new ClassDescriptor(typeof(StudentViewModel)));

				// Act
				var result= converter.ResolveScriptType(typeof(List<List<List<List<List<bool?>>>>>));

				// Assert
				Assert.AreEqual("Array<Array<Array<Array<Array<boolean | null>>>>>", result);
			}
			
			[TestMethod]
			public void ComplexType_DeepComplexGenerics_ShouldFormatCorrectly()
			{
				// Arrange
				var converter = new TypeScriptTypeConverter();
				converter.Classes.Add(new ClassDescriptor(typeof(StudentViewModel)));

				// Act
				var result= converter.ResolveScriptType(typeof(Dictionary<string, List<StudentViewModel>>));

				// Assert
				Assert.AreEqual("Array<string, Array<StudentViewModel>>", result);
			}
			
			[TestMethod]
			public void ComplexType_NullableProperty_ShouldFormatCorrectly()
			{
				// Arrange
				var converter = new TypeScriptTypeConverter();

				// Act
				var result = converter.ResolveScriptType(typeof(bool?));

				// Assert
				Assert.AreEqual("boolean | null", result);
			}
		}

		[TestClass]
		public class ResolveDefaultValueTests : TypeScriptTypeConverterTests
		{
			[TestMethod]
			public void ResolveDefaultValue_NullableProperty_ReturnsCorrectValueTest()
			{
				// Arrange
				var converter = new TypeScriptTypeConverter();
				var prop = new PropertyDescriptor(typeof(bool?));
				
				// Act
				var value = converter.ResolveDefaultValue(prop);
				
				// Assert
				Assert.AreEqual("", value);
			}
			
			[TestMethod]
			public void ResolveDefaultValue_ArrayProperty_ReturnsCorrectValueTest()
			{
				// Arrange
				var converter = new TypeScriptTypeConverter();
				var prop = new PropertyDescriptor(typeof(List<int>));
				
				// Act
				var value = converter.ResolveDefaultValue(prop);
				
				// Assert
				Assert.AreEqual("[]", value);
			}
			
			[TestMethod]
			public void ResolveDefaultValue_NullValue_ReturnsCorrectValueTest()
			{
				// Arrange
				var converter = new TypeScriptTypeConverter();
				var prop = new PropertyDescriptor(typeof(int));
				
				// Act
				var value = converter.ResolveDefaultValue(prop);
				
				// Assert
				Assert.AreEqual(string.Empty, value);
			}
			
			[TestMethod]
			public void ResolveDefaultValue_BooleanValue_ReturnsCorrectValueTest()
			{
				// Arrange
				var converter = new TypeScriptTypeConverter();
				var prop = new PropertyDescriptor(typeof(bool), true);
				
				// Act
				var value = converter.ResolveDefaultValue(prop);
				
				// Assert
				Assert.AreEqual("true", value);
			}
			
			[TestMethod]
			public void ResolveDefaultValue_BooleanValueFalse_ReturnsCorrectValueTest()
			{
				// Arrange
				var converter = new TypeScriptTypeConverter();
				var prop = new PropertyDescriptor(typeof(bool), false);
				
				// Act
				var value = converter.ResolveDefaultValue(prop);
				
				// Assert
				Assert.AreEqual("false", value);
			}
			
			[TestMethod]
			public void ResolveDefaultValue_EnumValue_ReturnsCorrectValueTest()
			{
				// Arrange
				var converter = new TypeScriptTypeConverter();
				var prop = new PropertyDescriptor(typeof(Gender), Gender.Male);
				
				// Act
				var value = converter.ResolveDefaultValue(prop);
				
				// Assert
				Assert.AreEqual("1", value);
			}
			
			[TestMethod]
			public void ResolveDefaultValue_DecimalValue_ReturnsCorrectValueTest()
			{
				// Arrange
				var converter = new TypeScriptTypeConverter();
				var prop = new PropertyDescriptor(typeof(decimal), 2.666666666666666666666666666666666m);
				
				// Act
				var value = converter.ResolveDefaultValue(prop);
				
				// Assert
				Assert.AreEqual("2.6666666666666666666666666667".Substring(0, 15), value);
			}
			
			[TestMethod]
			public void ResolveDefaultValue_StringValue_ReturnsCorrectValueTest()
			{
				// Arrange
				var converter = new TypeScriptTypeConverter();
				var prop = new PropertyDescriptor(typeof(string), "Hi!");
				
				// Act
				var value = converter.ResolveDefaultValue(prop);
				
				// Assert
				Assert.AreEqual("\"Hi!\"", value);
			}
			
			[TestMethod]
			public void ResolveDefaultValue_ClassValue_ReturnsEmptyStringTest()
			{
				// Arrange
				var converter = new TypeScriptTypeConverter();
				converter.Classes.Add(new ClassDescriptor(typeof(StudentViewModel)));
				var prop = new PropertyDescriptor(typeof(StudentViewModel), new StudentViewModel());
				
				// Act
				var value = converter.ResolveDefaultValue(prop);
				
				// Assert
				Assert.AreEqual($"{{}} as {nameof(StudentViewModel)}", value, "No support for deep initialization."); 
			}
			
			[TestMethod]
			public void ResolveDefaultValue_NoScriptTypeClassValue_ReturnsEmptyStringTest()
			{
				// Arrange
				var converter = new TypeScriptTypeConverter();
				var prop = new PropertyDescriptor(typeof(StudentViewModel), new StudentViewModel());
				
				// Act
				var value = converter.ResolveDefaultValue(prop);
				
				// Assert
				Assert.AreEqual("", value, "No support for deep initialization."); 
			}
		}

		[TestClass]
		public class GetGenericTypeArgumentMethod : TypeScriptTypeConverterTests
		{
			[TestMethod]
			public void GGetGenericTypeArgument_SimpleType_ShouldReturnGivenTypeTest()
			{
				// Arrange
				var type = typeof(ViewModel);
				
				// Act
				var result = TypeScriptTypeConverter.GetGenericType(type);
				
				// Assert
				Assert.AreEqual(type, result);
			}
			
			[TestMethod]
			public void GetGenericTypeArgument_GenericType_ShouldGetGenericTypeTest()
			{
				// Arrange
				var type = typeof(List<ViewModel>);
				
				// Act
				var result = TypeScriptTypeConverter.GetGenericType(type);
				
				// Assert
				Assert.AreEqual(typeof(ViewModel), result);
			}	
			
			[TestMethod]
			public void GetGenericTypeArgument_NestedGenericType_ShouldGetGenericTypeTest()
			{
				// Arrange
				var type = typeof(List<List<ViewModel>>);
				
				// Act
				var result = TypeScriptTypeConverter.GetGenericType(type);
				
				// Assert
				Assert.AreEqual(typeof(ViewModel), result);
			}	
			
			[TestMethod]
			public void GetGenericTypeArgument_NullableType_ShouldGetGenericTypeTest()
			{
				// Arrange
				var type = typeof(bool?);
				
				// Act
				var result = TypeScriptTypeConverter.GetGenericType(type);
				
				// Assert
				Assert.AreEqual(typeof(bool), result);
			}	
		}
		
	}
}