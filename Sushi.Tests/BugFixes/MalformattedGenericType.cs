using System.Linq;
using System.Text;
using Sushi.Descriptors;
using Sushi.TestModels;
using Xunit;

namespace Sushi.Tests.BugFixes;


public sealed class MalformattedGenericType : TestBase
{
    [Fact]
    public void Detection_ShouldDetectAsGenericTest()
    {
        // Arrange
        var type = typeof(ConstrainedGeneric<>);

        // Act
        var converter = new SushiConverter(type);
        var descriptor = converter.Models.Single(x => x.Type == type);

        var newDescriptor = new ClassDescriptor(type);

        // Assert
        Assert.NotNull(descriptor);
        Assert.Equal(descriptor.GenericParameterNames.Count, newDescriptor.GenericParameterNames.Count);
        Assert.Equal("T", descriptor.GenericParameterNames.Single());

        var genericProperty = descriptor.Properties[nameof(ConstrainedGeneric<object>.Data)];
        Assert.NotNull(genericProperty);
        Assert.True(genericProperty.Type.IsGenericParameter);

        var typescript = converter.TypeScript(new ConverterConfig { Indent = string.Empty });
        var builder = new StringBuilder();
        typescript.ConvertProperty(builder, descriptor, genericProperty);
        var expectedScript = "data!: T;";

        Assert.Equal(expectedScript, builder.ToString());
    }
}