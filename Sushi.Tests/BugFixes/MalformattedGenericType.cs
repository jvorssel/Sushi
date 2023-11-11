using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.Descriptors;
using Sushi.Tests.Models;

namespace Sushi.Tests.BugFixes;

[TestClass]
public class MalformattedGenericType : TestBase
{
    [TestMethod]
    public void Detection_ShouldDetectAsGenericTest()
    {
        // Arrange
        var type = typeof(ConstrainedGeneric<>);

        // Act
        var converter = new SushiConverter(type);
        var descriptor = converter.Models.Single(x => x.Type == type);

        var newDescriptor = new ClassDescriptor(type);

        // Assert
        Assert.IsNotNull(descriptor);
        Assert.AreEqual(descriptor.GenericParameterNames.Count, newDescriptor.GenericParameterNames.Count);
        Assert.AreEqual("T", descriptor.GenericParameterNames.Single());

        var genericProperty = descriptor.Properties.Single(x => x.Name == nameof(ConstrainedGeneric<object>.Data));
        Assert.IsTrue(genericProperty.Type.IsGenericParameter);

        var typescript = converter.TypeScript(new ConverterOptions{Indent = string.Empty});
        var propertyScript = typescript.ConvertProperty(descriptor, genericProperty);
        var expectedScript = "data!: T;";
        
        Assert.AreEqual(expectedScript, propertyScript);
    }
}