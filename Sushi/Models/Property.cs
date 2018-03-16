using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Sushi.Utility;
using Sushi.Utility.Enum;

namespace Sushi.Models
{
    public sealed class Property
    {
        public IEnumerable<string> Script { get; set; } = new List<string>();
        private readonly PropertyInfo _property;

        public string Name => _property.Name;

        public Type Type => _property.PropertyType;
        public CSharpNativeType NativeType => _property.PropertyType.ToCSharpNativeType();
        public string Namespace => $"{_property.DeclaringType.Namespace}.{_property.DeclaringType.Name}.{_property.Name}";

        public object Value { get; }

        public bool IsReadonly =>
            !_property.CanWrite ||
            Attribute.GetCustomAttribute(_property, typeof(ReadOnlyAttribute))
                is ReadOnlyAttribute attribute && attribute.IsReadOnly;
        
        public Property(PropertyInfo property, object value)
        {
            _property = property;
            Value = value;
        }
    }
}