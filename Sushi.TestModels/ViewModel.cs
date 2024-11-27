namespace Sushi.TestModels;

/// <summary>
///     The view model base class.
/// </summary>
public abstract class ViewModel : ScriptModel
{
	/// <summary>
	///     The view model identifier.
	/// </summary>
	public Guid Guid { get; set; } = Guid.NewGuid();

	/// <summary>
	///     When this view model was created.
	/// </summary>
	public DateTime CreatedOn { get; set; } = DateTime.Now;
}