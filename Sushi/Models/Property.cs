using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Sushi.Enum;
using Sushi.Extensions;
using Sushi.Helpers;

namespace Sushi.Models
{
    public sealed class Property
    {
        public IEnumerable<string> Script { get; set; } = new List<string>();
        public readonly PropertyInfo PropertyType;

        public string Name => PropertyType.Name;

        public Type Type { get; }
        public Type Container => PropertyType.DeclaringType;
        public CSharpNativeType NativeType => Type.ToCSharpNativeType();
        public string Namespace => $"{Container.Namespace}.{Container.Name}.{PropertyType.Name}";

        public object Value { get; }

        public bool IsReadonly =>
            !PropertyType.CanWrite ||
            Attribute.GetCustomAttribute(PropertyType, typeof(ReadOnlyAttribute))
                is ReadOnlyAttribute attribute && attribute.IsReadOnly;

        public bool IsNullable => Type.IsNullable();

        public Property(PropertyInfo property, object value)
        {
            var type = property.PropertyType;

            PropertyType = property;
            Type = type.IsNullable() ? Nullable.GetUnderlyingType(type) : type;
            Value = value;
        }
    }
}