using Sushi.Enum;

namespace Sushi.Interfaces;

public interface IConverterConfig
{
    /// <summary>
    ///		Indentation style, default is 4 spaces.
    /// </summary>
    string Indent { get; set; }

    /// <summary>
    ///		Casing style for properties, default is camel case.
    /// </summary>
    PropertyNameCasing CasingStyle{ get; set; }

    /// <summary>
    ///		A list of headers written at the start of the file.
    ///		Can be used to suppress es-lint warnings or add licence(s).
    /// </summary>
    List<string> Headers{ get; set; }
    
    /// <summary>
    ///     Provides custom script type mapping.
    /// </summary>
    Dictionary<Type, ITypeConverter> TypeConverters { get; set; }

    /// <summary>
    ///     If type mapping should throw an error when a type is unavailable or return "any".
    /// </summary>
    bool Strict { get; }
}