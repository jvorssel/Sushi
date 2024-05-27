using System;

namespace Sushi.Tests.Models;

/// <summary>
///     For testing nullable properties.
/// </summary>
public sealed class NullablePropertiesViewModel : ViewModel
{
    /// <summary>
    ///     An overridden, nullable Guid identifier.
    /// </summary>
    public new Guid? Guid { get; set; } = null;
    
    /// <summary>
    ///     Nullable string.
    /// </summary>
    public string? Value = null;

    /// <summary>
    ///     Nullable string w get/set.
    /// </summary>
    public string? Value2 { get; set; } = null;
}