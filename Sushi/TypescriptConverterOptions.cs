namespace Sushi;

public class TypescriptConverterOptions : ConverterOptions
{
    public TypescriptConverterOptions()
    {
        // Suppress duplicate property type declaration warning.
        Headers.Add("// noinspection JSUnusedGlobalSymbols");
    }
}