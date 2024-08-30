namespace Sushi.TestModels;

/// <summary>
///     Should NOT be included.
/// </summary>
public sealed class NotAScriptModel
{
    public ExcludedModel? excluded = null;
    public bool Included { get; set; } = false;

    public NotAScriptModel()
    {
        Included = excluded?.Included ?? false;
        throw new Exception("Should not be initialized.");
    }
    
}