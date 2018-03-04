using System;
using System.Collections.Generic;
using System.Reflection;
using Common.Utility;
using Common.Utility.Enum;

namespace ModelConverter.Models
{
    public sealed class Property
    {
        public IEnumerable<string> Script { get; set; } = new List<string>();
        private readonly PropertyInfo _property;

        public string Name => _property.Name;

        public Type Type => _property.PropertyType;
        public CSharpNativeType NativeType => _property.PropertyType.ToCSharpNativeType();

        public object Value { get; }

        public Property(PropertyInfo property, object value)
        {
            _property = property;
            Value = value;
        }
    }
}