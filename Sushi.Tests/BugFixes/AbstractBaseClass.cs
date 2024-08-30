using Sushi.Attributes;
using Sushi.Descriptors;
using Sushi.Tests.Extensions;
using Xunit;


namespace Sushi.Tests.BugFixes;

/// <summary>
///     Abstract classes can not be initiated to discover their public exported properties.
/// </summary>

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

    public sealed class ChildModel : AbstractBaseModel
    {
        public string Surname { get; set; }

        public ChildModel(string name, string surname) : base(name)
        {
            Surname = surname;
        }
    }

    [Fact]
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
        Assert.Single(descriptor.Properties);
        Assert.True(descriptor.Properties.ContainsKey(nameof(ChildModel.Surname)));
        Assert.Single(descriptor.Parent.Properties);
        Assert.True(descriptor.Parent.Properties.ContainsKey(nameof(ChildModel.Name)));
    }
    
    [Fact]
    public void NoParameterlessCtor_ShouldConvertToTypeScriptTest()
    {
        // Arrange
        var sushi = new SushiConverter(typeof(ChildModel), typeof(AbstractBaseModel));
        
        // Act
        var script = sushi.TypeScript().ToString();

        // Assert
        Assert.False(script.IsEmpty());
    }
}