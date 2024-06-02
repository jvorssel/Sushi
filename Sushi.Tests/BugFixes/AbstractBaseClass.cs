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

    public class ChildModel : AbstractBaseModel
    {
        public string Surname { get; set; }

        public ChildModel(string name, string surname) : base(name)
        {
            Surname = surname;
        }
    }

    [TestMethod]
    public void NoParameterlessCtor_ShouldMapModelTest()
    {
        // Arrange
        var parentDescriptor = new ClassDescriptor(typeof(AbstractBaseModel));
        var descriptor = new ClassDescriptor(typeof(ChildModel))
        {
            Parent = parentDescriptor
        };

        // Act

        // Assert
        Assert.AreEqual(1, descriptor.Properties.Count);
        Assert.IsTrue(descriptor.Properties.ContainsKey(nameof(ChildModel.Surname)));
        Assert.AreEqual(1, descriptor.Parent.Properties.Count);
        Assert.IsTrue(descriptor.Parent.Properties.ContainsKey(nameof(ChildModel.Name)));
    }
    
    [TestMethod]
    public void NoParameterlessCtor_ShouldConvertToTypeScriptTest()
    {
        // Arrange
        var sushi = new SushiConverter(typeof(ChildModel), typeof(AbstractBaseModel));
        
        // Act
        var script = sushi.TypeScript().ToString();

        // Assert
        Assert.IsFalse(script.IsEmpty());
    }
}