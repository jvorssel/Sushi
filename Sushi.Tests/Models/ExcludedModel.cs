using System;
using Sushi.Attributes;

namespace Sushi.Tests.Models;

/// <summary>
///     Should NOT be included.
/// </summary>
[IgnoreForScript]
public class ExcludedModel : ViewModel
{
    public bool Included { get; set; } = false;

    public ExcludedModel()
    {
        throw new Exception("Should not be initialized.");
    }
}