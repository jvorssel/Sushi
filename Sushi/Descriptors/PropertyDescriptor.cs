using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Policy;
using Sushi.Enum;
using Sushi.Extensions;
using Sushi.Helpers;
using Sushi.Interfaces;

namespace Sushi.Descriptors
{
	/// <summary>
	///     Describes a property in a class.
	/// </summary>
	[DebuggerDisplay(nameof(ToString))]
	public sealed class PropertyDescriptor : IPropertyDescriptor
	{
		private readonly PropertyInfo _property;

		/// <inheritdoc />
		public string Name { get; }

		/// <inheritdoc />
		public bool IsReadonly { get; }

		/// <inheritdoc />
		public Type Type { get; }

		/// <inheritdoc />
		public Type ClassType => _property.DeclaringType;

		/// <inheritdoc />
		public bool IsNullable { get; }

		/// <inheritdoc />
		public NativeType NativeType => Type.ToNativeTypeEnum();

		public object DefaultValue { get; }

		public PropertyDescriptor(PropertyInfo property)
		{
			var type = property.PropertyType;

			_property = property;
			Name = property.Name;

			Type = type;
			IsNullable = type.IsNullable();
			if (IsNullable)
				Type = Nullable.GetUnderlyingType(type);

			// Check if the property is marked as read-only.
			var canWrite = property.CanWrite;
			var readOnlyAttr = Attribute.GetCustomAttribute(_property, typeof(ReadOnlyAttribute));
			var isReadOnlyFromAttr = readOnlyAttr is ReadOnlyAttribute attribute && attribute.IsReadOnly;

			IsReadonly = !canWrite || isReadOnlyFromAttr;
			DefaultValue = ClassType.GetDefaultValue(_property);	
		}

		/// <inheritdoc />
		public override string ToString()
			=> $"{ClassType.Namespace}.{ClassType.Name}.{_property.Name}";
	}
}