﻿namespace Sushi.Extensions;

internal static class StringExtensions
{
    /// <summary>
    ///     Remove the escaped characters from the given <see cref="string"/> <paramref name="this"/>.
    /// </summary>
    internal static string RemoveEscapedCharacters(this string @this)
    {
        return @this.Replace("\r", string.Empty)
            .Replace("\n", string.Empty)
            .Replace("\t", string.Empty)
            .Replace("\0", string.Empty);
    }
}