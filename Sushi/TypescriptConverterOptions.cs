namespace Sushi;

public class TypescriptConverterOptions : ConverterOptions
{
    public TypescriptConverterOptions()
    {
        // Suppress duplicate property type declaration warning.
        this.Headers.Add("/* eslint-disable @typescript-eslint/no-inferrable-types,@typescript-eslint/no-explicit-any */");
    }
}