using System.Diagnostics;
using System.Reflection;
using Sushi.Extensions;
using Sushi.Interfaces;

namespace Sushi.Descriptors;

[DebuggerDisplay("Name = {ClassType.Name}.{Name}, Default = {DefaultValue}, Type = {Type.Name}")]
public sealed class FieldDescriptor : IPropertyDescriptor
{
    private readonly FieldInfo _field;

    /// <inheritdoc />
    public string Name => _field.Name;

    /// <inheritdoc />
    public bool Readonly => true;

    /// <inheritdoc />
    public bool IsStatic => true;

    /// <inheritdoc />
    public Type Type => IsNullable ? Nullable.GetUnderlyingType(_field.FieldType)  ?? _field.FieldType : _field.FieldType;

    /// <inheritdoc />
    public Type? ClassType => _field.DeclaringType;

    /// <inheritdoc />
    public object? DefaultValue { get; }

    public bool IsNullable => _field.FieldType.IsNullable() || (_field.FieldType == typeof(string) && DefaultValue == null);

    /// <inheritdoc />
    public bool IsOverridden => _field.DeclaringType.IsPropertyHidingBaseClassProperty(Name);

    public FieldDescriptor(FieldInfo fieldInfo)
    {
        _field = fieldInfo;
        
        try
        {
            var instance = _field.DeclaringType?.CreateInstance();
            DefaultValue = fieldInfo.GetValue(instance);
        }
        catch (Exception)
        {
            DefaultValue = null;
        }
    }
}