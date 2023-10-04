using System;
using System.Threading;

namespace Sushi.Tests.Models;

/// <summary>
///     Should NOT be included.
/// </summary>
public class NotAScriptModel
{
    public ExcludedModel? excluded = null;
    public bool Included { get; set; } = false;

    public NotAScriptModel()
    {
        Included = excluded.Included;
        throw new Exception("Should not be initialized.");
    }
    
}