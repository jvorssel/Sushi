using System.Linq;
using Sushi.Attributes;
using Sushi.Descriptors;
using Xunit;


namespace Sushi.Tests.BugFixes;

/// <summary>
///     Classes without a parameterless ctor require a specific init.
/// </summary>

public sealed class NoParameterlessCtorTests : TestBase
{
    [ConvertToScript]
    public sealed class CtorFixModel
    {
        public string Name { get; set; }

        public CtorFixModel(string name)
        {
            Name = name;
        }
    }

    [Fact]
    public void NoParameterlessCtor_ShouldMapModelTest()
    {
        // Arrange
        var type = typeof(CtorFixModel);

        // Act
        var descriptor = new ClassDescriptor(type);

        // Assert
        Assert.Single(descriptor.Properties);
        Assert.Equal(nameof(CtorFixModel.Name), descriptor.Properties.Values.Single().Name);
    }
}