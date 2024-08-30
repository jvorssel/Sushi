using System;
using System.Collections.Generic;
using System.Linq;
using Sushi.Attributes;
using Sushi.TestModels;
using Xunit;


namespace Sushi.Tests;


public sealed class IgnoreAttributeTest
{
    private readonly List<Type> _types = new() { typeof(IgnoreMe), typeof(IgnoreTestRoot), typeof(DoNotIgnoreMe) };

    [IgnoreForScript]
    private sealed class IgnoreMe : IgnoreTestRoot
    {
    }

    [ConvertToScript]
    private class IgnoreTestRoot
    {
    }

    private sealed class DoNotIgnoreMe : IgnoreTestRoot
    {
        public string ShouldExist { get; set; } = string.Empty;

        [IgnoreForScript] public string ShouldNotExist { get; set; } = string.Empty;
    }

    [Fact]
    public void FindModelWithAttributeTest()
    {
        var converter = new SushiConverter(_types);

        // Have the ConvertToScript attribute, should exist in queue.
        Assert.True(converter.Models.Any(x => x.Name == nameof(DoNotIgnoreMe) || x.Name == nameof(IgnoreTestRoot)),
            $"Expected the {nameof(DoNotIgnoreMe)} and {nameof(IgnoreTestRoot)} classes to be available.");

        // IgnoreMe has the ignore attribute, should not exist in queue.
        Assert.True(converter.Models.All(x => x.Name != nameof(IgnoreMe)),
            $"Expected the {nameof(IgnoreMe)} class not to be available.");
    }

    [Fact]
    public void ExcludePropertyWithAttributeTest()
    {
        var converter = new SushiConverter(_types);

        // Get the model with the properties that should use the Ignore attribute.
        var model = converter.Models.SingleOrDefault(x => x.Name == nameof(DoNotIgnoreMe));
        Assert.NotNull(model);

        Assert.True(model.Properties.ContainsKey(nameof(DoNotIgnoreMe.ShouldExist)),
            $"Expected the {nameof(DoNotIgnoreMe.ShouldExist)} to be available");
        
        Assert.False(model.Properties.ContainsKey(nameof(DoNotIgnoreMe.ShouldNotExist)),
            $"Expected the {nameof(DoNotIgnoreMe.ShouldNotExist)} to not be available");
    }

    [Fact]
    public void ExcludeClassWithoutAttributeTest()
    {
        // Arrange
        var type = typeof(NotAScriptModel);
        var assembly = type.Assembly;

        // Act
        var converter = new SushiConverter(assembly);

        // Assert
        Assert.DoesNotContain(converter.Models, x => x.Type == type);
    }
    
    [Fact]
    public void ExcludeClassWithExcludeAttributeTest()
    {
        // Arrange
        var type = typeof(ExcludedModel);
        var assembly = type.Assembly;

        // Act
        var converter = new SushiConverter(assembly);

        // Assert
        Assert.DoesNotContain(converter.Models, x => x.Type == type);
    }
}