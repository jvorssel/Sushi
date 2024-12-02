using System;
using System.Security.Cryptography;
using Sushi.Configurations;
using Sushi.DefaultTypeResolver;
using Sushi.Descriptors;
using Sushi.TestModels;
using Xunit;

namespace Sushi.Tests.CustomMapping;

public sealed class CustomMappingTests
{
    [Fact]
    public void TypeScript_CustomDateFormatter()
    {
        // Arrange
        var assembly = typeof(PersonViewModel).Assembly;
        var converter = new SushiConverter(assembly);
        var config = new DefaultConverterConfig
        {
            TypeMap = new ExtendedDateTypeMap()
        };
        var typescriptConverter = converter.TypeScript(config);

        // Act
        var result = typescriptConverter.ResolveScriptType(typeof(DateTime));
        
        // Assert
        Assert.Equal("Date | string", result);
    }
    
}

class ExtendedDateTypeMap : DefaultTypeMap
{
    public override string GetDateType()
    {
        return "Date | string";
    }
}