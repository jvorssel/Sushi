// /***************************************************************************\
// Module Name:       XmlSummaryDescriptorTests.cs
// Project:                   Sushi.Tests
// Author:                   Jeroen Vorsselman 13-05-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System;
using System.Collections.Generic;
using System.Linq;
using Sushi.Documentation;
using Sushi.TestModels;
using Sushi.Tests.Extensions;
using Xunit;

#endregion

namespace Sushi.Tests.Documentation;

public abstract class XmlSummaryDescriptorTests
{
	
	public sealed class Constructor : XmlSummaryDescriptorTests
	{
		[Fact]
		public void Constructor_EmptyName_ShouldThrowTest()
		{
			// Arrange
			var name = string.Empty;

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new XmlSummaryDescriptor(
				name,
				ReferenceType.Property,
				new Dictionary<string, string>()));
		}

		[Fact]
		public void Constructor_Property_ShouldInitializeCorrectlyTest()
		{
			// Arrange
			var type = typeof(PersonViewModel);
			var property = type.GetProperties().Single(x => x.Name == nameof(PersonViewModel.Gender));
			var name = type.FullName + "." + property.Name;

			var summary = "A property value.";
			var xmlDocValues = new Dictionary<string, string> { { "summary", summary } };

			// Act
			var descriptor = new XmlSummaryDescriptor(name, ReferenceType.Property, xmlDocValues);

			// Assert
			Assert.NotNull(descriptor);
			Assert.Equal(name, descriptor.RawName);
			Assert.Equal(xmlDocValues, descriptor.Values);
			Assert.Equal(summary, descriptor.Summary);
			Assert.Equal(ReferenceType.Property, descriptor.FieldType);
			Assert.False(descriptor.IsInherited);
			Assert.Equal(property.Name.Split(".").Last(), descriptor.Name);
			Assert.Equal(nameof(PersonViewModel), descriptor.DeclaringTypeName);
			Assert.Equal(type.Namespace, descriptor.Namespace);
		}

		[Fact]
		public void Constructor_Type_ShouldInitializeCorrectlyTest()
		{
			// Arrange
			var type = typeof(PersonViewModel);
			var name = type.FullName ?? string.Empty;

			var summary = "A property value.";
			var xmlDocValues = new Dictionary<string, string> { { "summary", summary } };

			// Act
			var descriptor = new XmlSummaryDescriptor(name, ReferenceType.Type, xmlDocValues);

			// Assert
			Assert.NotNull(descriptor);
			Assert.Equal(name, descriptor.RawName);
			Assert.Equal(xmlDocValues, descriptor.Values);
			Assert.Equal(summary, descriptor.Summary);
			Assert.Equal(ReferenceType.Type, descriptor.FieldType);
			Assert.False(descriptor.IsInherited);
			Assert.Equal(nameof(PersonViewModel), descriptor.Name);
			Assert.Equal(nameof(PersonViewModel), descriptor.DeclaringTypeName);
			Assert.Equal(type.Namespace, descriptor.Namespace);
		}

		[Fact]
		public void Constructor_UnsupportedType_ShouldNotMapTest()
		{
			// Arrange
			var type = typeof(PersonViewModel);
			var property = type.GetProperties().Single(x => x.Name == nameof(PersonViewModel.Gender));
			var name = type.FullName + "." + property.Name;

			var summary = "A property value.";
			var xmlDocValues = new Dictionary<string, string> { { "summary", summary } };

			// Act
			var @namespace = new XmlSummaryDescriptor(name, ReferenceType.Namespace, xmlDocValues);
			var error = new XmlSummaryDescriptor(name, ReferenceType.Error, xmlDocValues);
			var undefined = new XmlSummaryDescriptor(name, ReferenceType.Undefined, xmlDocValues);

			// Assert
			Assert.True(new[] { @namespace, error, undefined }.All(x => x != null));
			Assert.True(new[] { @namespace.Name, error.Name, undefined.Name }.All(x => x.IsEmpty()));
			Assert.True(new[] { @namespace.DeclaringTypeName, error.DeclaringTypeName, undefined.DeclaringTypeName }
				.All(x => x.IsEmpty()));
			Assert.True(new[] { @namespace.Namespace, error.Namespace, undefined.Namespace }.All(x => x.IsEmpty()));
		}
	}

	
	public sealed class Equality : XmlSummaryDescriptorTests
	{
		[Fact]
		public void Equality_Type_ShouldMatchTest()
		{
			// Arrange
			var type = typeof(PersonViewModel);
			var descriptor1 =
				new XmlSummaryDescriptor(type.FullName, ReferenceType.Type, new Dictionary<string, string>());
			var descriptor2 =
				new XmlSummaryDescriptor(type.FullName, ReferenceType.Type, new Dictionary<string, string>());
			var descriptor3 = new XmlSummaryDescriptor(typeof(SchoolViewModel).FullName,
				ReferenceType.Type,
				new Dictionary<string, string>());

			// Act
			var areEqual = descriptor1.IsEqualTo(descriptor2);
			var areNotEqual = descriptor1.IsEqualTo(descriptor3);
			var isNull = descriptor1.IsEqualTo(null);

			// Assert
			Assert.True(areEqual);
			Assert.False(areNotEqual);
			Assert.False(isNull);
		}

		[Fact]
		public void EqualityOperator_Type_ShouldMatchTest()
		{
			// Arrange
			var type = typeof(PersonViewModel);
			var descriptor =
				new XmlSummaryDescriptor(type.FullName, ReferenceType.Type, new Dictionary<string, string>());

			// Act
			var areEqual = descriptor    == typeof(PersonViewModel);
			var areNotEqual = descriptor != typeof(SchoolViewModel);
			var isNotNull = descriptor.IsSameType(null);

			// Assert
			Assert.True(areEqual);
			Assert.True(areNotEqual);
			Assert.False(isNotNull);
		}

		[Fact]
		public void EqualityOperator_Descriptor_ShouldMatchTest()
		{
			// Arrange
			var type = typeof(PersonViewModel);
			var descriptor =
				new XmlSummaryDescriptor(type.FullName, ReferenceType.Type, new Dictionary<string, string>());

			// Act
			var areEqual = descriptor.IsEqualTo(descriptor);
			var areNotEqual = descriptor != typeof(SchoolViewModel);

			// Assert
			Assert.True(areEqual);
			Assert.True(areNotEqual);
		}
	}
}