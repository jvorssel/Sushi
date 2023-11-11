using Sushi.Attributes;

namespace Sushi.Tests.Models;

/// <summary>
///     Another Generic class with a constraint.
/// </summary>
[ConvertToScript]
public sealed class ConstrainedGeneric<T> where T : class
{
    /// <summary>
    ///     The generic value.
    /// </summary>
    public T Data { get; set; }

    /// <summary>
    ///     Another field.
    /// </summary>
    public string Name { get; set; }
}