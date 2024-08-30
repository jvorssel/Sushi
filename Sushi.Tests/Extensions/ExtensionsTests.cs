namespace Sushi.Tests.Extensions;

public static class ExtensionsTests
{
    internal static bool IsEmpty(this string value)
    {
        return string.IsNullOrWhiteSpace(value);
    }
}