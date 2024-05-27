using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.Attributes;
using Sushi.Descriptors;
using Sushi.Tests.Models;

namespace Sushi.Tests;

[TestClass]
public class IgnoreAttributeTest
{
    private readonly List<Type> _types = new() { typeof(IgnoreMe), typeof(IgnoreTestRoot), typeof(DoNotIgnoreMe) };

    [IgnoreForScript]
    private class IgnoreMe : IgnoreTestRoot
    {
    }

    [ConvertToScript]
    private class IgnoreTestRoot
    {
    }

    private class DoNotIgnoreMe : IgnoreTestRoot
    {
        public string ShouldExist { get; set; }

        [IgnoreForScript] public string ShouldNotExist { get; set; }
    }

    [TestMethod]
    public void FindModelWithAttributeTest()
    {
        var converter = new SushiConverter(_types);

        // Have the ConvertToScript attribute, should exist in queue.
        Assert.IsTrue(converter.Models.Any(x => x.Name == nameof(DoNotIgnoreMe) || x.Name == nameof(IgnoreTestRoot)),
            $"Expected the {nameof(DoNotIgnoreMe)} and {nameof(IgnoreTestRoot)} classes to be available.");

        // IgnoreMe has the ignore attribute, should not exist in queue.
        Assert.IsTrue(converter.Models.All(x => x.Name != nameof(IgnoreMe)),
            $"Expected the {nameof(IgnoreMe)} class not to be available.");
    }

    [TestMethod]
    public void ExcludePropertyWithAttributeTest()
    {
        var converter = new SushiConverter(_types);

        // Get the model with the properties that should use the Ignore attribute.
        var model = converter.Models.Flatten().SingleOrDefault(x => x.Name == nameof(DoNotIgnoreMe));
        Assert.IsNotNull(model);

        Assert.IsTrue(model.Properties.ContainsKey(nameof(DoNotIgnoreMe.ShouldExist)),
            $"Expected the {nameof(DoNotIgnoreMe.ShouldExist)} to be available");
        
        Assert.IsFalse(model.Properties.ContainsKey(nameof(DoNotIgnoreMe.ShouldNotExist)),
            $"Expected the {nameof(DoNotIgnoreMe.ShouldNotExist)} to not be available");
    }

    [TestMethod]
    public void ExcludeClassWithoutAttributeTest()
    {
        // Arrange
        var type = typeof(NotAScriptModel);
        var assembly = type.Assembly;

        // Act
        var converter = new SushiConverter(assembly);

        // Assert
        Assert.IsFalse(converter.Models.Any(x => x.Type == type));
    }
    
    [TestMethod]
    public void ExcludeClassWithExcludeAttributeTest()
    {
        // Arrange
        var type = typeof(ExcludedModel);
        var assembly = type.Assembly;

        // Act
        var converter = new SushiConverter(assembly);

        // Assert
        Assert.IsFalse(converter.Models.Any(x => x.Type == type));
    }
}