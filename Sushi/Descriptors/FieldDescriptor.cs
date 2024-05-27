// /***************************************************************************\
// Module Name:       FieldDescriptor.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 02-04-2022
// Copyright:              Royaldesk @ 2022
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

using System.Diagnostics;
using System.Reflection;
using Sushi.Enum;
using Sushi.Extensions;
using Sushi.Helpers;
using Sushi.Interfaces;

namespace Sushi.Descriptors;

[DebuggerDisplay("Name = {ClassType.Name}.{Name}, Default = {DefaultValue}, Type = {Type.Name}")]
public sealed class FieldDescriptor : IPropertyDescriptor
{
    private readonly FieldInfo _field;

    #region Implementation of IPropertyDescriptor

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

    /// <summary>
    ///     The <see cref="NativeType"/> that matches this field.
    /// </summary>
    public NativeType NativeType => Type.ToNativeScriptType();

    #endregion

    public FieldDescriptor(FieldInfo fieldInfo)
    {
        _field = fieldInfo;
        
        try
        {
            var instance = _field.DeclaringType?.CreateInstance();
            DefaultValue = fieldInfo.GetValue(instance);
        }
        catch (Exception e)
        {
            DefaultValue = null;
        }
    }
}