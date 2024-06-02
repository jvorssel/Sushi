using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.Attributes;
using Sushi.Descriptors;
using Sushi.Extensions;

namespace Sushi.Tests.BugFixes;

/// <summary>
///     Classes without a parameterless ctor require a specific init.
/// </summary>
[TestClass]
public class NoDeepCtorInheritanceTests : TestBase
{
    [ConvertToScript]
    private class BaseModel
    {
        public Guid Guid { get; set; }
    }

    private abstract class MiddleClass : BaseModel
    {
    }

    private class GenerateCtorClass : MiddleClass
    {
    }

    [TestMethod]
    public void NoDeepCtorInheritance_ShouldGenerateCtorTest()
    {
        // Arrange
        var types = new[] { typeof(BaseModel), typeof(MiddleClass), typeof(GenerateCtorClass) };
        var sushi = new SushiConverter(types).TypeScript();
        
        var descriptor = sushi.Models.Single(x => x.Name == nameof(GenerateCtorClass));

        // Act
        var result = descriptor.HasParameterizedSuperConstructor();

        // Assert
        Assert.IsTrue(result);
    }
}