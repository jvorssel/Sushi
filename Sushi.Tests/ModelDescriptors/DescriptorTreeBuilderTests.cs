using System;
using System.Collections.Generic;
using System.Linq;
using Sushi.Descriptors;
using Sushi.Extensions;
using Sushi.TestModels;
using Xunit;

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

	
	public sealed class BuildTreeTests : DescriptorTreeBuilderTests
	{
		[Fact]
		public void BuildTree_MissingBaseType_ShouldThrow()
		{
			// Arrange
			var descriptors = new ClassDescriptor(typeof(TypeModel));
			_ = $"Base type {typeof(ViewModel)} for {typeof(TypeModel)} is missing.";

			// Act & Assert
			Assert.Throws<InvalidOperationException>(() => new[] { descriptors }.BuildTree());
		}

		[Fact]
		public void BuildTree_ShouldNestCorrectlyTest()
		{
			// Arrange
			var types = AsDescriptors(Types.ToArray());

			// Act
			var result = types.BuildTree().ToList();

			// Assert
			Assert.Single(result);

			// The view-model class should be the root.
			var scriptModel = result.Single();
			Assert.Equal(nameof(ScriptModel), scriptModel.Name);
			Assert.Null(scriptModel.Parent);

			var viewModelDescriptor = scriptModel.Children.Single();

			// The view-model class is inherited twice.
			Assert.Equal(2, viewModelDescriptor.Children.Count);

			// Once by the person
			var personDescriptor = viewModelDescriptor.Children.SingleOrDefault(x => x.Name == nameof(PersonViewModel));
			Assert.NotNull(personDescriptor);
			Assert.Single(personDescriptor.Children);

			// The student class inherits the person class
			var studentDescriptor =
				personDescriptor.Children.SingleOrDefault(x => x.Name == nameof(StudentViewModel));
			Assert.NotNull(studentDescriptor);
			Assert.Equal(nameof(PersonViewModel), studentDescriptor.Parent?.Name);

			// And once by the school
			var schoolDescriptor = viewModelDescriptor.Children.SingleOrDefault(x => x.Name == nameof(SchoolViewModel));
			Assert.NotNull(schoolDescriptor);

			Assert.False(schoolDescriptor.Children.Any());
			Assert.Equal(nameof(ViewModel), schoolDescriptor.Parent?.Name);
		}
	}
}