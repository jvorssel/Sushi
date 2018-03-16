using System.Text.RegularExpressions;
using Sushi.Consistency;
using Sushi.Enum;
using Sushi.Models;

namespace Sushi {
    public static class SpecificationDefaults
    {
        /// <summary>
        ///     Remove single- & multi-line comments from 
        ///     the given <see cref="DataModel.Script"/>.
        /// </summary>
        public static string RemoveCommentsFromModel(DataModel model)
        {
            var script = model.Script;

            // Remove single-line comments
            script = new Regex(@"([/]{2})(.*)$", RegexOptions.Multiline | RegexOptions.Compiled).Replace(script, "");

            // Remove multi-line comments
            script = new Regex(@"(\/\*)(.|[\r\n])*?(\*\/)", RegexOptions.Compiled | RegexOptions.Multiline).Replace(script, "");

            model.Script = script;
            return script;
        }

        /// <summary>
        ///     Make sure the given <paramref name="comment"/> is formatted as a single-line comment.
        /// </summary>
        public static Statement FormatInlineComment(string comment, StatementType relatedType)
        {
            if (comment.Contains("\n"))
                throw Errors.OnlyInlineCommentsSupported(comment);

            if (comment.EndsWith("."))
                comment = comment.Substring(0, comment.Length - 1);

            return new Statement($@"// {comment}.", relatedType, true);
        }
    }
}