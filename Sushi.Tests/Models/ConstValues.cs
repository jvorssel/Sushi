using Sushi.Attributes;

namespace Sushi.Tests.Models;

/// <summary>
///     A class with const values.
/// </summary>
[ConvertToScript]
public sealed class ConstValues
{
    /// <summary>
    ///     The First value.
    /// </summary>
    public const string First = @"First";
    
    /// <summary>
    ///     The Last value.
    /// </summary>
    public const string Last = @"Last";

    /// <summary>
    ///     A Static value.
    /// </summary>
    public static string Static = @"Static";
}