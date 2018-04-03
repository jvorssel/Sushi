using Sushi.Interfaces;

namespace Sushi.TestModels
{
    /// <summary>
    ///     Class for a Name.
    /// </summary>
    public class NameModel : IScriptModel
    {
        /// <summary>
        ///     The <see cref="Name"/> definition.
        /// </summary>
        public string Name { get; set; } = @"Jeroen";

        /// <summary>
        ///     The <see cref="Insertion"/> definition.
        /// </summary>
        public string Insertion { get; set; }

        /// <summary>
        ///     The <see cref="Surname"/> definition.
        /// </summary>
        public string Surname { get; set; } = @"Vorsselman";
    }
}
