using Sushi.Interfaces;

namespace Sushi.Tests.Models
{
    public class NameModel : IScriptModel
    {
        // Lets start with some person data-model.
        public string Name { get; set; } = @"Jeroen";
        public string Insertion { get; set; }
        public string Surname { get; set; } = @"Vorsselman";
    }
}
