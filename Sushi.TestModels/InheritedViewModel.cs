namespace Sushi.TestModels;

public class InheritedViewModel : BaseViewModel
{
	/// <inheritdoc />
	public override string Value { get; set; } = "override";

	public string Addition { get; set; } = "added";
}