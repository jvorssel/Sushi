using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utility
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
        ///     Enumerate over each available line in the given <see cref="string"/> <paramref name="@this"/>.
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
    }
}
