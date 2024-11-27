namespace Sushi.TestModels;

public class BaseViewModel : ViewModel
{
    public virtual string Value { get; set; } = "base";

    public Guid Guid { get; set; }

    public bool Base { get; set; } = true;
}