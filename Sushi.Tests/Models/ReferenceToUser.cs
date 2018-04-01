using System;
using Sushi.Interfaces;

namespace Sushi.Tests.Models
{
    public class PersonReferenceToUser : IScriptModel
    {
        public string Name { get; set; }
        public string Insertion { get; set; }
        public string Surname { get; set; }

        public UserReferenceToPerson User { get; set; }
    }

    public class UserReferenceToPerson : IScriptModel
    {
        public DateTime RegisteredOn { get; set; } = DateTime.Now;
        public Guid Guid { get; set; } = Guid.Empty;

        public string Username { get; set; } = "MrAwesome";
        public string Password { get; set; } = "Secret";

        public PersonReferenceToUser Person { get; set; }
    }
}
