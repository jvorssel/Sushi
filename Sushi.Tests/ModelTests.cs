using System.Linq;
using System.Reflection;
using Sushi.TestModels;
using Sushi.Tests.Extensions;
using Xunit;

namespace Sushi.Tests;


public sealed class ModelTests
{
	private readonly Assembly _assembly = typeof(PersonViewModel).Assembly;

	[Fact]
	public void ModelsInAssemblyTest()
	{
		var converter = new SushiConverter(_assembly);
		Assert.True(converter.Models.Count > 0, "Expected at least one model to be available.");
		Assert.True(converter.Models.Any(x => x.Name == nameof(ViewModel)), "Expected at least one ");
	}

	[Fact]
	public void ModelPropertyRecognitionTest()
	{
		var converter = new SushiConverter(_assembly);

		var personModel = converter.Models.SingleOrDefault(x => x.Name == nameof(PersonViewModel));
		Assert.NotNull(personModel);

		// PersonModel has 2 properties
		Assert.Equal(4, personModel.Properties.Count);

		// The name property
		var name = personModel.Properties[nameof(PersonViewModel.Name)];
		Assert.NotNull(name);

		// The surname property
		var surname = personModel.Properties[nameof(PersonViewModel.Surname)];
		Assert.NotNull(surname);
	}

	[Fact]
	public void GenericModelTest()
	{
		// Arrange
		var sushi = new SushiConverter(typeof(GenericStandalone<>));

		// Act
		var typescript = sushi.TypeScript();

		// Assert
		var descriptor = sushi.Models.Single();
		Assert.Equal("GenericStandalone", descriptor.Name);
		Assert.Single(descriptor.GenericParameterNames);
		Assert.Equal("TEntry", descriptor.GenericParameterNames.Single());

		Assert.False(typescript.ToString().IsEmpty());
	}
}