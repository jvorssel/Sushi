namespace Sushi.TestModels;

/// <summary>
///		The <see cref="PersonViewModel"/> that represents a Person.
/// </summary>
public class PersonViewModel : ViewModel
{
    /// <summary>
    ///     The <see cref="Identifier"/> that this Model refers to.
    /// </summary>
    public Guid Identifier { get; set; } = Guid.NewGuid();

    /// <summary>
    ///		 The <see cref="Name"/> of the person.
    /// </summary>
    public string Name { get; set; } = "Jeroen";

    /// <summary>
    ///		The <see cref="Surname"/> of the person.
    /// </summary>
    public string Surname { get; set; } = "Vorsselman";

    /// <summary>
    ///		The <see cref="Gender"/> of the person.
    /// </summary>
    public Gender Gender { get; set; } = Gender.Male;

    public PersonViewModel(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }
}