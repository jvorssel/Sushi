using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Sushi.Enum;
using Sushi.Helpers;

namespace Sushi.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        ///     Convert a <see cref="byte"/> array to a <see cref="string"/>.
        /// </summary>
        /// <remarks>
        ///     Source: http://stackoverflow.com/questions/472906/converting-a-string-to-byte-array-without-using-an-encoding-byte-by-byte/
        /// </remarks>
        /// <param name="this">The array of <see cref="byte"/>s.</param>
        /// <returns>The resulting <see cref="string"/>.</returns>
        public static string GetString(this byte[] @this)
        {
            using (var reader = new MemoryStream(@this))
            using (var streamReader = new StreamReader(reader))
            {
                return streamReader.ReadToEnd();
            }
        }

        /// <summary>
        ///     Enumerate over each available line in the given <see cref="string"/> <paramref name="this"/>.
        /// </summary>
        public static IEnumerable<string> GetLines(this string @this)
        {
            using (var reader = new StringReader(@this))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                    yield return line;
            }
        }

        /// <summary>
        ///     Get the characters in the <see cref="string"/> <paramref name="this"/>
        ///     <paramref name="before"/> a the first occurrence of given string.
        /// </summary>
        public static string Before(this string @this, string before)
        {
            var indent = string.Empty;
            if (@this.Contains(before))
                indent = @this.Substring(0, @this.IndexOf(before, StringComparison.InvariantCultureIgnoreCase));

            return indent;
        }

        /// <summary>
        ///     Replace multiple whitespaces "  " with a single one " " in the <see cref="string"/> <paramref name="this"/>.
        /// </summary>
        public static string RemoveLeadingWhitespaces(this string @this)
        {
            var str = @this;
            while (str.IndexOf("  ", StringComparison.InvariantCultureIgnoreCase) > 0)
                str = str.Replace("  ", " ");

            return str;
        }

        /// <summary>
        ///     Get the UTC timestamp.s
        /// </summary>
        public static string GetTimeStamp(this string @this)
        {
            var date = DateTime.Now;
            return date.ToFileTimeUtc().ToString();
        }

        /// <summary>
        ///     If given <see cref="string"/> <paramref name="this"/> is null or empty.
        /// </summary>
        public static bool IsEmpty(this string @this)
            => string.IsNullOrEmpty(@this) || string.IsNullOrWhiteSpace(@this) || @this.Length < 1;

        /// <summary>
        ///     Remove the escaped characters from the given <see cref="string"/> <paramref name="this"/>.
        /// </summary>
        public static string RemoveEscapedCharacters(this string @this)
            => @this.Replace("\r", string.Empty)
                    .Replace("\n", string.Empty)
                    .Replace("\t", string.Empty)
                    .Replace("\0", string.Empty);

        /// <summary>
        ///     Join the given <see cref="string"/> <see cref="IEnumerable{T}"/> to one string.
        /// </summary>
        public static string JoinString(this IEnumerable<string> @this, char separator, Except except = Except.None)
        {
            var sb = new StringBuilder();
            switch (except)
            {
                case Except.First:
                    {
                        foreach (var str in @this.Where(x => x != @this.First()))
                            sb.Append(str + separator);

                        break;
                    }
                case Except.Last:
                    {
                        foreach (var str in @this.Where(x => x != @this.Last()))
                            sb.Append(str + separator);

                        break;
                    }
                case Except.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(except), except, null);
            }

            return sb.ToString().TrimEnd('.');
        }

        /// <summary>
        ///     Get the indent for the <see cref="string"/> to <paramref name="find"/> 
        ///     in the given <see cref="string"/> <paramref name="@this"/>.
        /// </summary>
        public static string GetIndentInRowWith(this string @this, string find)
        {
            foreach (var row in new StringEnumerator(@this))
            {
                if (!row.Contains(find))
                    continue;

                return row.Before(find);
            }

            return string.Empty;
        }

        /// <summary>
        ///     <paramref name="indent"/> each row in the given <see cref="string"/> <paramref name="@this"/>.
        /// </summary>
        public static string IndentEachRow(this string @this, string indent)
        {
            var sb = new StringBuilder();
            foreach (var row in new StringEnumerator(@this))
            {
                sb.Append(indent + row);
            }

            return sb.ToString();
        }
    }
}
