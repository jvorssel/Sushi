using Sushi.Interfaces;

namespace Sushi.TestModels
{
    /// <inheritdoc />
    public class MySummaryIsInherited : IHaveTheSummary, IScriptModel
    {
        /// <inheritdoc />
        public string Name { get; set; }
    }

    /// <summary>
    ///     An awesome summary!
    /// </summary>
    public interface IHaveTheSummary : IScriptModel
    {
        /// <summary>
        ///     An awesome name!
        /// </summary>
        string Name { get; set; }
    }
}
