// /***************************************************************************\
// Module Name:       HappyFlowTests.cs
// Project:                   Sushi.Tests
// Author:                   Jeroen Vorsselman 10-05-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Sushi.TestModels;
using Xunit;


#endregion

namespace Sushi.Tests;


public sealed class HappyFlowTests : TestBase
{
    private const string SourcePath = @"linter/src/";

    private static string GetFilePath(string fileName)
    {
        var assemblyCodeBase = Assembly.GetExecutingAssembly().Location;
        var testResultsPath = Path.GetDirectoryName(assemblyCodeBase);
        return testResultsPath + $"/{fileName}";
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

        WriteToFile(script, GetFilePath(SourcePath + "models.es5.js"));
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

        WriteToFile(script, GetFilePath(SourcePath + "models.es5.map.js"));
    }

    [Fact]
    public void ECMAScript6_CompileTest()
    {
        // Arrange
        var assembly = typeof(PersonViewModel).Assembly;
        var converter = new SushiConverter(assembly).UseDocumentation(XmlDocPath);

        // Act
        var script = converter.ECMAScript6().ToString();
        WriteToFile(script, GetFilePath(SourcePath + "models.es6.js"));
    }

    [Fact]
    public void Typescript_CompileTest()
    {
        // Arrange
        var assembly = typeof(PersonViewModel).Assembly;
        var converter = new SushiConverter(assembly).UseDocumentation(XmlDocPath);

        // Act
        var script = converter.TypeScript().ToString();

        WriteToFile(script, GetFilePath(SourcePath + "models.latest.ts"));
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
        WriteToFile(script, GetFilePath(SourcePath + "models.no-comments.ts"));
    }
}