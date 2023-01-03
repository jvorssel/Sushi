using System.Text;

namespace Sushi.Extensions
{
    public static class StringExtensions
    {
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
        public static string JoinString(this List<string> @this, char separator, int amount = 0)
        {
            var sb = new StringBuilder();
            if (amount == 0)
                amount = @this.Count;

            for (int i = 0; i < amount; i++)
            {


                sb.Append(@this[i] + separator);
            }

            return sb.ToString().TrimEnd('.');
        }
    }
}
