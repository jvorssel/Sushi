using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.Attributes;
using Sushi.Extensions;

namespace Sushi.Tests.BugFixes;

[TestClass]
public class NoXmlDocumentation : TestBase
{
    [ConvertToScript]
    public class NoXmlDocumentationModel
    {
        public string Name { get; }

        public NoXmlDocumentationModel(string name)
        {
            Name = name;
        }
    }
    
    [TestMethod]
    public void NoXmlDocumentationModel_ShouldConvertToTypeScriptTest()
    {
        // Arrange
        var type = typeof(NoXmlDocumentationModel);
        var sushi = new SushiConverter(type);
        
        // Act
        var script = sushi.TypeScript().Convert().ToString();

        // Assert
        Assert.IsFalse(script.IsEmpty());
    }
}