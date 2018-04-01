using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sushi.Interfaces;

namespace Sushi.Tests.Models
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
