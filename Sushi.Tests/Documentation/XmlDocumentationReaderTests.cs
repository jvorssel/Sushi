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
using Sushi.Documentation;
using Sushi.TestModels;
using Xunit;

#endregion

namespace Sushi.Tests.Documentation;

public abstract class XmlDocumentationReaderTests : TestBase
{
	private string FilePath { get; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, XmlFileName);

	private XmlDocumentationReader Reader { get; set; }

	
	public sealed class Initialize : XmlDocumentationReaderTests
	{
		[Fact]
		public void InitializeTest()
		{
				// Act
				Reader = new XmlDocumentationReader(FilePath);

				// Assert
				Assert.True(Reader.Members.Count > 0);
				Assert.Contains(Reader.Members, x => x.IsInherited);
				Assert.True(
					Reader.Members.Where(x => x.FieldType    == ReferenceType.Property)
						.All(x => x.DeclaringTypeName.Length > 0),
					"Expected each field to have a declaring type name.");
			}
	}

	
	public sealed class GetDocumentationForType : XmlDocumentationReaderTests
	{
		[Fact]
		public void GetDocumentationForType_ViewModel_ShouldResolveTest()
		{
				// Arrange
				Reader = new XmlDocumentationReader(FilePath);
				var type = typeof(SchoolViewModel);

				// Act
				var doc = Reader.GetDocumentationForType(type);

				// Assert
				Assert.NotNull(doc);
				Assert.Equal(ReferenceType.Type, doc.FieldType);
				Assert.Equal(nameof(SchoolViewModel), doc.Name);
				Assert.True(doc.Summary.Length > 0);
			}

		[Fact]
		public void GetDocumentationForType_Inherited_ShouldResolveFromInterfaceTest()
		{
				// Arrange
				Reader = new XmlDocumentationReader(FilePath);
				var type = typeof(SchoolViewModel);

				// Act
				var doc = Reader.GetDocumentationForType(type);

				// Assert
				Assert.NotNull(doc);
				Assert.Equal(nameof(SchoolViewModel), doc.Name);
				Assert.True(doc.IsInherited);
				Assert.True(doc.Summary.Length > 0);
			}
	}

	
	public sealed class GetDocumentationForProperty : XmlDocumentationReaderTests
	{
		[Fact]
		public void GetDocumentationForProperty_NoDescriptor_ShouldThrowTest()
		{
				// Arrange
				Reader = new XmlDocumentationReader(FilePath);

				// Act & Assert
				Assert.Throws<ArgumentNullException>(() => Reader.GetDocumentationForProperty(null));
			}

		[Fact]
		public void GetDocumentationForProperty_Property_ShouldGetSummaryTest()
		{
				// Arrange
				Reader = new XmlDocumentationReader(FilePath);
				var instance = new SchoolViewModel();

				// Act
				var doc = Reader.GetDocumentationForProperty(instance, x => x.AverageGrade);

				// Assert
				Assert.NotNull(doc);
				Assert.Equal("AverageGrade", doc.Name);
				Assert.True(doc.Summary.Length > 0);
				Assert.False(doc.IsInherited);
			}
			
		[Fact]
		public void GetDocumentationForProperty_InheritedProperty_ShouldGetFromInterfaceTest()
		{
				// Arrange
				Reader = new XmlDocumentationReader(FilePath);
				var instance = new SchoolViewModel();

				// Act
				var doc = Reader.GetDocumentationForProperty(instance, x => x.Name);

				// Assert
				Assert.NotNull(doc);
				Assert.Equal("Name", doc.Name);
				Assert.True(doc.Summary.Length > 0);
				Assert.True(doc.IsInherited);
				Assert.Equal(typeof(ISchoolViewModel), doc.InheritedFrom);
			}
	}
}