using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.Attributes;
using Sushi.Descriptors;
using Sushi.Tests.Models;

namespace Sushi.Tests.BugFixes;

/// <summary>
///     Classes without a parameterless ctor require a specific init.
/// </summary>
[TestClass]
public class NoParameterlessCtorTests : TestBase
{
    [ConvertToScript]
    public class CtorFixModel 
    {
        public string Name { get; set; }

        public CtorFixModel(string name)
        {
            Name = name;
        }
    }

    [TestMethod]
    public void NoParameterlessCtor_ShouldMapModelTest()
    {
        // Arrange
        var type = typeof(CtorFixModel);

        // Act
        var descriptor = new ClassDescriptor(type);

        // Assert
        Assert.AreEqual(1, descriptor.Properties.Count);
        Assert.AreEqual(nameof(CtorFixModel.Name), descriptor.Properties.Single().Name);
    }
}