// /***************************************************************************\
// Module Name:       XmlDocumentationReaderTests.cs
// Project:                   Sushi.Tests
// Author:                   Jeroen Vorsselman 14-05-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.Documentation;
using Sushi.Tests.Models;

#endregion

namespace Sushi.Tests.Documentation;

public abstract class XmlDocumentationReaderTests
{
	public string FilePath { get; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sushi.Tests.xml");

	public XmlDocumentationReader Reader { get; set; }

	[TestClass]
	public class Initialize : XmlDocumentationReaderTests
	{
		[TestMethod]
		public void InitializeTest()
		{
				// Act
				Reader = new XmlDocumentationReader(FilePath);

				// Assert
				Assert.IsTrue(Reader.Members.Count > 0);
				Assert.IsTrue(Reader.Members.Any(x => x.IsInherited));
				Assert.IsTrue(
					Reader.Members.Where(x => x.FieldType    == ReferenceType.Property)
						.All(x => x.DeclaringTypeName.Length > 0),
					"Expected each field to have a declaring type name.");
			}
	}

	[TestClass]
	public class GetDocumentationForType : XmlDocumentationReaderTests
	{
		[TestMethod]
		public void GetDocumentationForType_ViewModel_ShouldResolveTest()
		{
				// Arrange
				Reader = new XmlDocumentationReader(FilePath);
				var type = typeof(SchoolViewModel);

				// Act
				var doc = Reader.GetDocumentationForType(type);

				// Assert
				Assert.IsNotNull(doc);
				Assert.AreEqual(ReferenceType.Type, doc.FieldType);
				Assert.AreEqual(nameof(SchoolViewModel), doc.Name);
				Assert.IsTrue(doc.Summary.Length > 0);
			}

		[TestMethod]
		public void GetDocumentationForType_Inherited_ShouldResolveFromInterfaceTest()
		{
				// Arrange
				Reader = new XmlDocumentationReader(FilePath);
				var type = typeof(SchoolViewModel);

				// Act
				var doc = Reader.GetDocumentationForType(type);

				// Assert
				Assert.IsNotNull(doc);
				Assert.AreEqual(nameof(SchoolViewModel), doc.Name);
				Assert.IsTrue(doc.IsInherited);
				Assert.IsTrue(doc.Summary.Length > 0);
			}
	}

	[TestClass]
	public class GetDocumentationForProperty : XmlDocumentationReaderTests
	{
		[TestMethod]
		public void GetDocumentationForProperty_NoDescriptor_ShouldThrowTest()
		{
				// Arrange
				Reader = new XmlDocumentationReader(FilePath);
				var instance = new SchoolViewModel();
				
				// Act & Assert
				Assert.ThrowsException<ArgumentNullException>(() => Reader.GetDocumentationForProperty(null));
			}

		[TestMethod]
		public void GetDocumentationForProperty_Property_ShouldGetSummaryTest()
		{
				// Arrange
				Reader = new XmlDocumentationReader(FilePath);
				var instance = new SchoolViewModel();

				// Act
				var doc = Reader.GetDocumentationForProperty(instance, x => x.AverageGrade);

				// Assert
				Assert.IsNotNull(doc);
				Assert.AreEqual("AverageGrade", doc.Name);
				Assert.IsTrue(doc.Summary.Length > 0);
				Assert.IsFalse(doc.IsInherited);
			}
			
		[TestMethod]
		public void GetDocumentationForProperty_InheritedProperty_ShouldGetFromInterfaceTest()
		{
				// Arrange
				Reader = new XmlDocumentationReader(FilePath);
				var instance = new SchoolViewModel();

				// Act
				var doc = Reader.GetDocumentationForProperty(instance, x => x.Name);

				// Assert
				Assert.IsNotNull(doc);
				Assert.AreEqual("Name", doc.Name);
				Assert.IsTrue(doc.Summary.Length > 0);
				Assert.IsTrue(doc.IsInherited);
				Assert.AreEqual(typeof(ISchoolViewModel), doc.InheritedFrom);
			}
	}
}