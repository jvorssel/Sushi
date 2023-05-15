using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.Attributes;
using Sushi.Descriptors;
using Sushi.Extensions;

namespace Sushi.Tests.BugFixes;

/// <summary>
///     Abstract classes can not be initiated to discover their public exported properties.
/// </summary>
[TestClass]
public class AbstractBaseClass : TestBase
{
    [ConvertToScript]
    public abstract class AbstractBaseModel
    {
        public string Name { get; set; }

        public AbstractBaseModel(string name)
        {
            Name = name;
        }
    }

    public class AbstractParentModel : AbstractBaseModel
    {
        public string Surname { get; set; }

        public AbstractParentModel(string name, string surname) : base(name)
        {
            Surname = surname;
        }
    }

    [TestMethod]
    public void NoParameterlessCtor_ShouldMapModelTest()
    {
        // Arrange
        var type = typeof(AbstractParentModel);

        // Act
        var descriptor = new ClassDescriptor(type);

        // Assert
        Assert.AreEqual(2, descriptor.Properties.Count);
        Assert.IsTrue(descriptor.Properties.Any(x => x.Name == nameof(AbstractParentModel.Name)));
        Assert.IsTrue(descriptor.Properties.Any(x => x.Name == nameof(AbstractParentModel.Surname)));
    }
    
    [TestMethod]
    public void NoParameterlessCtor_ShouldConvertToTypeScriptTest()
    {
        // Arrange
        var sushi = new SushiConverter(typeof(AbstractParentModel), typeof(AbstractBaseModel));
        
        // Act
        var script = sushi.TypeScript().ToString();

        // Assert
        Assert.IsFalse(script.IsEmpty());
    }
}