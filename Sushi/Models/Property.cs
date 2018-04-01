using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Sushi.Enum;
using Sushi.Helpers;

namespace Sushi.Models
{
    public sealed class Property
    {
        public IEnumerable<string> Script { get; set; } = new List<string>();
        public readonly PropertyInfo PropertyType;

        public string Name => PropertyType.Name;

        public Type Type => PropertyType.PropertyType;
        public Type Container => PropertyType.DeclaringType;
        public CSharpNativeType NativeType => PropertyType.PropertyType.ToCSharpNativeType();
        public string Namespace => $"{PropertyType.DeclaringType.Namespace}.{PropertyType.DeclaringType.Name}.{PropertyType.Name}";

        public object Value { get; }

        public bool IsReadonly =>
            !PropertyType.CanWrite ||
            Attribute.GetCustomAttribute(PropertyType, typeof(ReadOnlyAttribute))
                is ReadOnlyAttribute attribute && attribute.IsReadOnly;

        public Property(PropertyInfo property, object value)
        {
            PropertyType = property;
            Value = value;
        }
    }
}