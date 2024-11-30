using Sushi.Converters;
using Sushi.Converters.TypeScript;
using Sushi.Interfaces;

// ReSharper disable InconsistentNaming

namespace Sushi;

public static class ConverterExtensions
{
    /// <summary>
    ///     Create the converter for ECMAScript 5.
    /// </summary>
    public static EcmaScript5Converter ECMAScript5(this SushiConverter converter, IConverterConfig? options = null)
    {
        return new EcmaScript5Converter(converter, options ?? new ConverterConfig());
    }

    /// <summary>
    ///     Create the converter for ECMAScript 6.
    /// </summary>
    public static EcmaScript6Converter ECMAScript6(this SushiConverter converter, IConverterConfig? options = null)
    {
        return new EcmaScript6Converter(converter, options ?? new ConverterConfig());
    }

    /// <summary>
    ///     Create the converter for TypeScript.
    /// </summary>
    public static TypeScriptConverter TypeScript(this SushiConverter converter, IConverterConfig? options = null)
    {
        return new TypeScriptConverter(converter, options ?? new DefaultTypeScriptConverterConfig());
    }
}