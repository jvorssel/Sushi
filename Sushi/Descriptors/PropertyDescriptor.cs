using System.Reflection;
using Sushi.Extensions;
using Sushi.Interfaces;

namespace Sushi.Descriptors;

/// <summary>
///     Describes a property in a class.
/// </summary>
public sealed class PropertyDescriptor : IPropertyDescriptor
{
    private readonly PropertyInfo? _property;

    /// <inheritdoc />
    public object? DefaultValue { get; }

    /// <inheritdoc />
    public bool Readonly => !_property?.CanWrite ?? false;
    
    /// <inheritdoc />
    public bool IsStatic => _property?.GetGetMethod().IsStatic ?? false;

    /// <inheritdoc />
    public bool IsNullable => Type.IsNullable() || (Type == typeof(string) && DefaultValue == null);

    /// <inheritdoc />
    public bool IsOverridden => ClassType?.IsPropertyHidingBaseClassProperty(Name) ?? false;

    /// <inheritdoc />
    public string Name { get; }

    /// <inheritdoc />
    public Type Type { get; }

    /// <inheritdoc />
    public Type? ClassType => _property?.DeclaringType;

    public PropertyDescriptor(PropertyInfo property, object? defaultValue = null)
    {
        var type = property.PropertyType;

        _property = property;
        Name = property.Name;
        Type = type;
        DefaultValue = defaultValue;
    }

    public PropertyDescriptor(Type type, object? defaultValue = null)
    {
        Type = type;
        DefaultValue = defaultValue;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{ClassType?.Namespace}.{ClassType?.Name}.{_property?.Name}";
    }
}