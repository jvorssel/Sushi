using System;
using System.Collections.Generic;
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
            var chars = new char[@this.Length / sizeof(char)];
            Buffer.BlockCopy(@this, 0, chars, 0, @this.Length);

            return new string(chars);
        }
    }
}
