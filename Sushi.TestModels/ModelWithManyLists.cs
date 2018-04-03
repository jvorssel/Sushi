using System.Collections.Generic;
using Sushi.Interfaces;

namespace Sushi.TestModels
{
    /// <summary>
    ///     A model with a LOT of lists.
    /// </summary>
    public class ModelWithManyLists : IScriptModel
    {
        /// <summary>
        ///     A beautiful list!
        /// </summary>
        public List<string> List { get; set; } = new List<string>();

        /// <summary>
        ///     Another one!
        /// </summary>
        public HashSet<string> HashSet { get; set; } = new HashSet<string>();

        /// <summary>
        ///     Wow another one!
        /// </summary>
        public IEnumerable<string> Enumerable { get; set; } = new List<string>();

        /// <summary>
        ///     Dude another one! WOW!
        /// </summary>
        public ICollection<string> Collection { get; set; } = new List<string>();

        /// <summary>
        ///     This one is readonly? WOAH!
        /// </summary>
        public IReadOnlyList<int> ReadOnlyList { get; set; } = new List<int>();

        /// <summary>
        ///     DUDE THIS IS NOT A LIST BUT AN OBJECT!
        /// </summary>
        public Dictionary<string, string> Dictionary { get; set; } = new Dictionary<string, string>();
    }
}