using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelConverter.Interfaces.Models;

namespace ModelConverter.Tests.Models
{
    public class PersonReferenceToUser : IModelToConvert
    {
        public string Name { get; set; }
        public string Insertion { get; set; }
        public string Surname { get; set; }

        public UserReferenceToPerson User { get; set; }
    }

    public class UserReferenceToPerson : IModelToConvert
    {
        public DateTime RegisteredOn { get; set; } = DateTime.Now;
        public Guid Guid { get; set; } = Guid.Empty;

        public string Username { get; set; } = "MrAwesome";
        public string Password { get; set; } = "Secret";

        public PersonReferenceToUser Person { get; set; }
    }
}
