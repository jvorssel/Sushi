using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Sushi.TestModels;
using Xunit;

namespace Sushi.Tests;

public sealed class HappyFlowTests : TestBase
{
    private const string SourcePath = @"TestResults\linter\src\";

    private static string GetFilePath(string fileName)
    {
        var assemblyCodeBase = Assembly.GetExecutingAssembly().Location;
        var solutionFolderName = "ModelConverter";

        var solutionFolder =
            assemblyCodeBase.Substring(0, assemblyCodeBase.IndexOf(solutionFolderName) + solutionFolderName.Length);

        var result = Path.Combine(solutionFolder, SourcePath, fileName);
        return result;
    }

    private string XmlDocPath => Path.Combine(Environment.CurrentDirectory, XmlFileName);

    [Fact]
    public void LoadCorrectlyTest()
    {
        // Arrange
        var assembly = typeof(PersonViewModel).Assembly;

        // Act
        var converter = new SushiConverter(assembly).UseDocumentation(XmlDocPath);

        // Assert
        Assert.NotNull(converter.Documentation);
        Assert.True(converter.Documentation.Members.Any());
    }

    [Fact]
    public void ECMAScript5_CompileTest()
    {
        // Arrange
        var assembly = typeof(PersonViewModel).Assembly;
        var converter = new SushiConverter(assembly).UseDocumentation(XmlDocPath);

        // Act
        var script = converter.ECMAScript5().ToString();

        WriteToFile(script, GetFilePath("models.es5.js"));
    }

    [Fact]
    public void ECMAScript5_WithUnderscore_CompileTest()
    {
        // Arrange
        var assembly = typeof(PersonViewModel).Assembly;
        var converter = new SushiConverter(assembly).UseDocumentation(XmlDocPath);

        // Act
        var script = converter.ECMAScript5()
            .IncludeUnderscoreMapper()
            .ToString();

        WriteToFile(script, GetFilePath("models.es5.map.js"));
    }

    [Fact]
    public void ECMAScript6_CompileTest()
    {
        // Arrange
        var assembly = typeof(PersonViewModel).Assembly;
        var converter = new SushiConverter(assembly).UseDocumentation(XmlDocPath);

        // Act
        var script = converter.ECMAScript6().ToString();
        WriteToFile(script, GetFilePath("models.es6.js"));
    }

    [Fact]
    public void Typescript_CompileTest()
    {
        // Arrange
        var assembly = typeof(PersonViewModel).Assembly;
        var converter = new SushiConverter(assembly).UseDocumentation(XmlDocPath);

        // Act
        var script = converter.TypeScript().ToString();

        WriteToFile(script, GetFilePath("models.latest.ts"));
    }

    [Fact]
    public void Typescript_WithoutComments_CompileTest()
    {
        // Arrange
        // 1) Get the assembly with the exported types.
        var assembly = typeof(PersonViewModel).Assembly;
        var converter = new SushiConverter(assembly);

        // Act
        // 2) Specify the target language and invoke ToString().
        var script = converter.TypeScript().ToString();

        // 3) The resulting script can be written to a file(stream).
        WriteToFile(script, GetFilePath("models.no-comments.ts"));
    }
}