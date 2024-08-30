using System;
using System.Linq;
using Sushi.Attributes;
using Sushi.Extensions;
using Xunit;


namespace Sushi.Tests.BugFixes;

/// <summary>
///     Classes without a parameterless ctor require a specific init.
/// </summary>
public sealed class NoDeepCtorInheritanceTests : TestBase
{
    [ConvertToScript]
    private class BaseModel
    {
        public Guid Guid { get; set; }
    }

    private abstract class MiddleClass : BaseModel
    {
    }

    private sealed class GenerateCtorClass : MiddleClass
    {
    }

    [Fact]
    public void NoDeepCtorInheritance_ShouldGenerateCtorTest()
    {
        // Arrange
        var types = new[] { typeof(BaseModel), typeof(MiddleClass), typeof(GenerateCtorClass) };
        var sushi = new SushiConverter(types).TypeScript();

        var descriptor = sushi.Models.Single(x => x.Name == nameof(GenerateCtorClass));

        // Act
        var result = descriptor.HasParameterizedSuperConstructor();

        // Assert
        Assert.True(result);
    }
}