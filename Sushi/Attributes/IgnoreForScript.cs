using System;

namespace Sushi.Attributes {
	/// <summary>
	///     Used to tell what properties and classes should NOT be converted to specified script language.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class |
		AttributeTargets.Struct)]
	public class IgnoreForScript : Attribute
	{

	}
}