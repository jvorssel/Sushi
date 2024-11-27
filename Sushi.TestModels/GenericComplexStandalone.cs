using Sushi.Attributes;

namespace Sushi.TestModels;

/// <summary>
///     Another Generic class for a collection and a total amount of available entries.
/// </summary>
[ConvertToScript]
public sealed class GenericComplexStandalone<TFirst, TSecond>
{
	/// <summary>
	///     The first list of values.
	/// </summary>
	public List<TFirst> First { get; set; } = new();
	
	/// <summary>
	///     The second list of values.
	/// </summary>
	public List<TSecond> Second { get; set; } = new();

	/// <summary>
	///     The total amount of available entries.
	/// </summary>
	public long TotalAmount { get; set; }
}    