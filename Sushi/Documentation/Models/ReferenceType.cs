namespace Sushi.Documentation.Models
{
	public enum ReferenceType
	{
		/// <summary>
		///     <see cref="Undefined"/> field type
		/// </summary>
		Undefined = 0,

		/// <summary>
		///     Member redirects to a specific <see cref="Type"/> (T).
		/// </summary>
		Type = 1,

		/// <summary>
		///     Member redirects to a specific <see cref="Property"/> (P).
		/// </summary>
		Property = 2,

		/// <summary>
		///     Member redirects to a specific <see cref="Method"/> (M).
		/// </summary>
		Method = 3,

		/// <summary>
		///		References namespace.
		/// </summary>
		Namespace= 4,

		/// <summary>
		///		References field.
		/// </summary>
		Field = 5,

		/// <summary>
		///		Event property.
		/// </summary>
		Event = 6,

		/// <summary>
		///		References an Error.
		/// </summary>
		Error = 7
	}

	public static class SummaryFieldTypeExtensions
	{
		public static ReferenceType GetFieldType(this string specifier)
		{
			switch (specifier)
			{
				case "N":
					return ReferenceType.Namespace;
				case "T":
					return ReferenceType.Type;
				case "F":
					return ReferenceType.Field;
				case "P":
					return ReferenceType.Property;
				case "M":
					return ReferenceType.Method;
				case "E":
					return ReferenceType.Event;
				case "!":
					return ReferenceType.Error;
				default:
					return ReferenceType.Undefined;
			}
		}
	}
}