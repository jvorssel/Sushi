using Sushi.Attributes;

namespace Sushi.TestModels;

/// <summary>
///     A Generic class for a collection and a total amount of available entries.
/// </summary>
[ConvertToScript]
public sealed class GenericStandalone<TEntry>
{
	/// <summary>
	///     The list of values.
	/// </summary>
	public List<TEntry> Values { get; set; } = new();

	/// <summary>
	///     The total amount of available entries.
	/// </summary>
	public long TotalAmount { get; set; }
}