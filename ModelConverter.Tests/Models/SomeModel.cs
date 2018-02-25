using ModelConverter.Interfaces.Models;

namespace ModelConverter.Tests.Models
{
    public class SomeModel : IModelToConvert
    {
        // Lets start with some person data-model.
        public string Name { get; set; } = @"Jeroen";
        public string Insertion { get; set; }
        public string Surname { get; set; } = @"Vorsselman";
    }
}
