using Sushi.Enum;

namespace Sushi.Interfaces;

public interface IConverterOptions
{
    /// <summary>
    ///		Indentation style, default is 4 spaces.
    /// </summary>
    string Indent { get; }

    /// <summary>
    ///		Casing style for properties, default is camel case.
    /// </summary>
    PropertyNameCasing CasingStyle { get; }

    /// <summary>
    ///		A list of headers written at the start of the file.
    ///		Can be used to suppress es-lint warnings or add licence(s).
    /// </summary>
    List<string> Headers { get; }
}