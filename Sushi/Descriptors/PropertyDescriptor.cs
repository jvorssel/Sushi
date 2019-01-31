using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Sushi.Enum;
using Sushi.Extensions;
using Sushi.Helpers;

namespace Sushi.Descriptors
{
	/// <summary>
	///     Describes a property in a class.
	/// </summary>
	public sealed class PropertyDescriptor
	{
		public readonly PropertyInfo Property;

		public string Name { get; }
		public object Value { get; }
		public bool IsReadonly { get; }

		public Type Type { get; }
		public Type Container { get; }
		public bool IsNullable {get; }
		public NativeType NativeType { get; }

		public string Namespace => $"{Container.Namespace}.{Container.Name}.{Property.Name}";

		public PropertyDescriptor(PropertyInfo property, object value)
		{
			var type = property.PropertyType;

			Property = property;
			Name = property.Name;
			Container = property.DeclaringType;
			NativeType = Type.ToNativeTypeEnum();
			IsNullable = type.IsNullable();
			Type = IsNullable ? Nullable.GetUnderlyingType(type) : type;
			Value = value;

			// Check if the property is marked as read-only.
			var canWrite = property.CanWrite;
			var readOnlyAttr = Attribute.GetCustomAttribute(Property, typeof(ReadOnlyAttribute));
			var isReadOnlyFromAttr = readOnlyAttr is ReadOnlyAttribute attribute && attribute.IsReadOnly;

			IsReadonly = !canWrite || isReadOnlyFromAttr;
		}
	}
}