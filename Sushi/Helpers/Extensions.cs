namespace Sushi.Helpers;

public static class Extensions
{
    internal static HashSet<T> ToHashSet<T>(this IEnumerable<T> source, IEqualityComparer<T>? comparer = null)
    {
        return new HashSet<T>(source, comparer);
    }
}