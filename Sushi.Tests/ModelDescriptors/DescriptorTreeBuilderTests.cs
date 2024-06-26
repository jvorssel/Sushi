﻿// /***************************************************************************\
// Module Name:       DescriptorTreeBuilderTests.cs
// Project:                   Sushi.Tests
// Author:                   Jeroen Vorsselman 15-05-2023
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
using Sushi.Descriptors;
using Sushi.Extensions;
using Sushi.Tests.Models;

#endregion

namespace Sushi.Tests.ModelDescriptors;

public abstract class DescriptorTreeBuilderTests
{
	private readonly List<Type> Types = new List<Type>
	{
		typeof(PersonViewModel),
		typeof(SchoolViewModel),
		typeof(StudentViewModel),
		typeof(ViewModel),
		typeof(ScriptModel)
	};

	private List<ClassDescriptor> AsDescriptors(params Type[] types)
		=> types.Select(x => new ClassDescriptor(x)).ToList();

	[TestClass]
	public class BuildTreeTests : DescriptorTreeBuilderTests
	{
		[TestMethod]
		public void BuildTree_MissingBaseType_ShouldThrow()
		{
			// Arrange
			var descriptors = new ClassDescriptor(typeof(TypeModel));
			var message = $"Base type {typeof(ViewModel)} for {typeof(TypeModel)} is missing.";

			// Act & Assert
			Assert.ThrowsException<InvalidOperationException>(() => new[] { descriptors }.BuildTree(), message);
		}

		[TestMethod]
		public void BuildTree_ShouldNestCorrectlyTest()
		{
			// Arrange
			var types = AsDescriptors(Types.ToArray());

			// Act
			var result = types.BuildTree().ToList();

			// Assert
			Assert.AreEqual(1, result.Count, "Only one class defined as the root of the tree.");

			// The view-model class should be the root.
			var scriptModel = result.Single();
			Assert.AreEqual(nameof(ScriptModel), scriptModel.Name);
			Assert.IsNull(scriptModel.Parent);

			var viewModelDescriptor = scriptModel.Children.Single();

			// The view-model class is inherited twice.
			Assert.AreEqual(2, viewModelDescriptor.Children.Count);

			// Once by the person
			var personDescriptor = viewModelDescriptor.Children.SingleOrDefault(x => x.Name == nameof(PersonViewModel));
			Assert.IsNotNull(personDescriptor);
			Assert.AreEqual(1, personDescriptor.Children.Count);

			// The student class inherits the person class
			var studentDescriptor =
				personDescriptor.Children.SingleOrDefault(x => x.Name == nameof(StudentViewModel));
			Assert.IsNotNull(studentDescriptor);
			Assert.AreEqual(nameof(PersonViewModel), studentDescriptor.Parent.Name);

			// And once by the school
			var schoolDescriptor = viewModelDescriptor.Children.SingleOrDefault(x => x.Name == nameof(SchoolViewModel));
			Assert.IsNotNull(schoolDescriptor);

			Assert.IsFalse(schoolDescriptor.Children.Any());
			Assert.AreEqual(nameof(ViewModel), schoolDescriptor.Parent.Name);
		}
	}
}