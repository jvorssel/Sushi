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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.Documentation;
using Sushi.Extensions;
using Sushi.Tests.Models;

#endregion

namespace Sushi.Tests.Documentation;

public abstract class XmlSummaryDescriptorTests
{
	[TestClass]
	public class Constructor : XmlSummaryDescriptorTests
	{
		[TestMethod]
		public void Constructor_EmptyName_ShouldThrowTest()
		{
			// Arrange
			var name = string.Empty;

			// Act & Assert
			Assert.ThrowsException<ArgumentNullException>(() => new XmlSummaryDescriptor(
				name,
				ReferenceType.Property,
				new Dictionary<string, string>()));
		}

		[TestMethod]
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
			Assert.IsNotNull(descriptor);
			Assert.AreEqual(name, descriptor.RawName);
			Assert.AreEqual(xmlDocValues, descriptor.Values);
			Assert.AreEqual(summary, descriptor.Summary);
			Assert.AreEqual(ReferenceType.Property, descriptor.FieldType);
			Assert.IsFalse(descriptor.IsInherited);
			Assert.AreEqual(property.Name.Split(".").Last(), descriptor.Name);
			Assert.AreEqual(nameof(PersonViewModel), descriptor.DeclaringTypeName);
			Assert.AreEqual(type.Namespace, descriptor.Namespace);
		}

		[TestMethod]
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
			Assert.IsNotNull(descriptor);
			Assert.AreEqual(name, descriptor.RawName);
			Assert.AreEqual(xmlDocValues, descriptor.Values);
			Assert.AreEqual(summary, descriptor.Summary);
			Assert.AreEqual(ReferenceType.Type, descriptor.FieldType);
			Assert.IsFalse(descriptor.IsInherited);
			Assert.AreEqual(nameof(PersonViewModel), descriptor.Name);
			Assert.AreEqual(nameof(PersonViewModel), descriptor.DeclaringTypeName);
			Assert.AreEqual(type.Namespace, descriptor.Namespace);
		}

		[TestMethod]
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
			Assert.IsTrue(new[] { @namespace, error, undefined }.All(x => x != null));
			Assert.IsTrue(new[] { @namespace.Name, error.Name, undefined.Name }.All(x => x.IsEmpty()));
			Assert.IsTrue(new[] { @namespace.DeclaringTypeName, error.DeclaringTypeName, undefined.DeclaringTypeName }
				.All(x => x.IsEmpty()));
			Assert.IsTrue(new[] { @namespace.Namespace, error.Namespace, undefined.Namespace }.All(x => x.IsEmpty()));
		}
	}

	[TestClass]
	public class Equality : XmlSummaryDescriptorTests
	{
		[TestMethod]
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
			Assert.IsTrue(areEqual);
			Assert.IsFalse(areNotEqual);
			Assert.IsFalse(isNull);
		}

		[TestMethod]
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
			Assert.IsTrue(areEqual);
			Assert.IsTrue(areNotEqual);
			Assert.IsFalse(isNotNull);
		}

		[TestMethod]
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
			Assert.IsTrue(areEqual);
			Assert.IsTrue(areNotEqual);
		}
	}
}