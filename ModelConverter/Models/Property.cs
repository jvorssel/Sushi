using System;
using System.Reflection;
using Common.Utility;
using Common.Utility.Enum;
using Common.Utility.Enum.ECMAScript;

namespace ModelConverter.Models {
    public sealed class Property
    {
        private readonly PropertyInfo _property;

        public string Name => _property.Name;

        public CSharpNativeType NativeType => _property.PropertyType.ToCSharpNativeType();

        public JavaScriptType EcmaType => NativeType.ToJavaScriptType();

        public object Default { get; }

        public Property(PropertyInfo property, object defaultValue)
        {
            _property = property;
            Default = defaultValue;
        }
    }
}