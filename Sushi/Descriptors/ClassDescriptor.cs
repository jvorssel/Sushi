// /***************************************************************************\
// Module Name:       ClassDescriptor.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 15-05-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System.Diagnostics;
using Sushi.Helpers;
using Sushi.Interfaces;

#endregion

namespace Sushi.Descriptors;

/// <summary>
///     Describes a <see cref="System.Type" />.
/// </summary>
[DebuggerDisplay("Name = {Name}")]
public sealed class ClassDescriptor
{
    public readonly Type Type;

    /// <summary>
    ///     The actual <see cref="Name" /> of the model that the given <see cref="System.Type" /> refers to.
    /// </summary>
    public string Name { get; }

    /// <summary>
    ///     The <see cref="FullName" /> of the model that the given <see cref="System.Type" /> refers to.
    /// </summary>
    public string FullName => Type.FullName;

    public bool HasParameterlessCtor => Type.GetConstructor(Type.EmptyTypes) != null;

    public bool IsApplicable { get; } = false;

    public IReadOnlyList<IPropertyDescriptor> Properties { get; }

    public IReadOnlyList<string> GenericParameterNames { get; } = new List<string>();

    public ClassDescriptor? Parent { get; set; }

    public HashSet<ClassDescriptor> Children { get; } = new();

    public bool GenerateConstructor => Properties.Any(x => !x.Readonly);

    public ClassDescriptor(Type type)
    {
        Type = type;
        Name = Type.Name.Split('`')[0];
        IsApplicable = this.IsApplicable();
        if (!IsApplicable)
            return;

        // Get the available properties in the given type
        var properties = Type.GetPropertyDescriptors();
        var fields = Type.GetFieldDescriptors();
        Properties = properties.Cast<IPropertyDescriptor>().Concat(fields).ToList();

        if (!Type.IsGenericTypeDefinition)
            return;

        GenericParameterNames = type.GetGenericArguments().Select(x => x.Name).ToList();
    }

    /// <summary>
    ///     Get the <see cref="Properties" /> <see cref="List{T}" /> but allows filtering inherited properties.
    /// </summary>
    public IEnumerable<IPropertyDescriptor> GetProperties(bool excludeInherited)
    {
        foreach (var prop in Properties)
        {
            var isInherited = this.IsPropertyInherited(prop, true);
            if (excludeInherited && isInherited)
                continue;

            yield return prop;
        }
    }

    public IPropertyDescriptor? GetProperty(string name)
    {
        return Properties.SingleOrDefault(x => x.Name == name);
    }

    #region Equality members

    public static bool operator ==(ClassDescriptor? m1, ClassDescriptor? m2)
    {
        if (m1 is null || m2 is null)
            return m1 is null == m2 is null;

        return m1.Type == m2.Type;
    }

    public static bool operator !=(ClassDescriptor? m1, ClassDescriptor? m2)
    {
        return !(m1 == m2);
    }

    #endregion
}