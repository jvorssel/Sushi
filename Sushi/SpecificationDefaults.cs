using System.Text.RegularExpressions;
using Sushi.Consistency;
using Sushi.Descriptors;
using Sushi.Enum;

namespace Sushi {
    public static class SpecificationDefaults
    {
        /// <summary>
        ///     Remove single- & multi-line comments from 
        ///     the given <see cref="ClassDescriptor.Script"/>.
        /// </summary>
        public static string RemoveCommentsFromModel(ClassDescriptor model)
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
        public static ScriptConditionDescriptor FormatInlineComment(string comment, ConditionType relatedType)
        {
            if (comment.Contains("\n"))
                throw Errors.OnlyInlineCommentsSupported(comment);

            if (comment.EndsWith("."))
                comment = comment.Substring(0, comment.Length - 1);

            return new ScriptConditionDescriptor($@"// {comment}.", relatedType, true);
        }
    }
}