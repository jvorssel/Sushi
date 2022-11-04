// /***************************************************************************\
// Module Name:       DescriptorTreeBuilderTests.cs
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
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.Descriptors;
using Sushi.Tests.Models;

#endregion

namespace Sushi.Tests.ModelDescriptors
{
	public abstract class DescriptorTreeBuilderTests
	{
		private readonly List<Type> _types = new List<Type>
		{
			typeof(PersonViewModel),
			typeof(SchoolViewModel),
			typeof(StudentViewModel),
			typeof(ViewModel)
		};

		private List<ClassDescriptor> Descriptors => _types.Select(x => new ClassDescriptor(x)).ToList();

		[TestClass]
		public class FindDescriptorTest : DescriptorTreeBuilderTests
		{
			[TestMethod]
			public void EqualType_ShouldFind()
			{
				// Arrange
				var type = typeof(ViewModel);

				// Act
				var descriptor = Descriptors.FindDescriptor(type);

				// Assert
				Assert.IsNotNull(descriptor);
				Assert.AreEqual(nameof(ViewModel), descriptor.Name);
			}

			[TestMethod]
			public void EqualTypeInChildren_ShouldFind()
			{
				// Arrange
				var descriptors = new List<ClassDescriptor> { new(typeof(PersonViewModel)) };
				descriptors[0].Children.Add(new ClassDescriptor(typeof(ViewModel)));

				// Act
				var descriptor = descriptors.FindDescriptor(typeof(ViewModel));

				// Assert
				Assert.IsNotNull(descriptor);
				Assert.AreEqual(nameof(ViewModel), descriptor.Name);
			}
			
			[TestMethod]
			public void EqualTypeInChildren_ShouldFindDeep()
			{
				// Arrange
				var descriptors = new List<ClassDescriptor> { new(typeof(StudentViewModel)) };
				descriptors[0].Children.Add(new ClassDescriptor(typeof(PersonViewModel)));
				descriptors[0].Children.Single().Children.Add(new ClassDescriptor(typeof(ViewModel)));

				// Act
				var descriptor = descriptors.FindDescriptor(typeof(ViewModel));

				// Assert
				Assert.IsNotNull(descriptor);
				Assert.AreEqual(nameof(ViewModel), descriptor.Name);
			}
		}

		[TestClass]
		public class BuildTreeTests : DescriptorTreeBuilderTests
		{
			[TestMethod]
			public void DescriptorTreeBuilder_ShouldNestCorrectlyTest()
			{
				// Arrange
				var builder = new DescriptorTreeBuilder(_types);

				// Act
				var result = builder.BuildTree().ToList();

				// Assert
				Assert.AreEqual(1, result.Count, "Only one class defined as the root of the tree.");

				// The view-model class should be the root.
				var descriptor = result.Single();
				Assert.AreEqual(nameof(ViewModel), descriptor.Name);
				Assert.IsNull(descriptor.Parent);

				// The view-model class is inherited twice.
				Assert.AreEqual(2, descriptor.Children.Count);

				// Once by the person
				var personDescriptor = descriptor.Children.SingleOrDefault(x => x.Name == nameof(PersonViewModel));
				Assert.IsNotNull(personDescriptor);
				Assert.AreEqual(1, personDescriptor.Children.Count);

				// The student class inherits the person class
				var studentDescriptor = personDescriptor.Children.SingleOrDefault(x => x.Name == nameof(StudentViewModel));
				Assert.IsNotNull(studentDescriptor);
				Assert.AreEqual(nameof(PersonViewModel), studentDescriptor.Parent.Name);

				// And once by the school
				var schoolDescriptor = descriptor.Children.SingleOrDefault(x => x.Name == nameof(SchoolViewModel));
				Assert.IsNotNull(schoolDescriptor);

				Assert.IsFalse(schoolDescriptor.Children.Any());
				Assert.AreEqual(nameof(ViewModel), schoolDescriptor.Parent.Name);
			}
		}
	}
}