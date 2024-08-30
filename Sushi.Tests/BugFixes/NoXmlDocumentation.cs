using Sushi.Attributes;
using Sushi.Tests.Extensions;
using Xunit;


namespace Sushi.Tests.BugFixes;


public sealed class NoXmlDocumentation : TestBase
{
    [ConvertToScript]
    public sealed class NoXmlDocumentationModel
    {
        public string Name { get; }

        public NoXmlDocumentationModel(string name)
        {
            Name = name;
        }
    }
    
    [Fact]
    public void NoXmlDocumentationModel_ShouldConvertToTypeScriptTest()
    {
        // Arrange
        var type = typeof(NoXmlDocumentationModel);
        var sushi = new SushiConverter(type);
        
        // Act
        var script = sushi.TypeScript().ToString();

        // Assert
        Assert.False(script.IsEmpty());
    }
}