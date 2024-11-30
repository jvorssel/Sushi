namespace Sushi.TestModels;

/// <summary>
///     Simple model to verify complex types.
/// </summary>
public sealed class TypeModel : ViewModel
{
    /// <summary>
    ///     A nullable boolean.
    /// </summary>
    public bool? NullableBool { get; set; } = null;

    /// <summary>
    ///     A nullable string, defaults to null.
    /// </summary>
    public string? NullableString { get; set; } = null;

    /// <summary>
    ///     A readonly string.
    /// </summary>
    public readonly string ReadonlyString = "readonly";

    /// <inheritdoc cref="Guid" />
    public new Guid Guid { get; set; } = Guid.NewGuid();

    /// <summary>
    ///     A DateTime instance.
    /// </summary>
    public DateTime Date { get; set; } = DateTime.Now;

    public StudentViewModel Student { get; set; } = new();

    public List<StudentViewModel> Students { get; set; }

    public Dictionary<string, StudentViewModel[]> StudentPerClass { get; set; } = new();
}