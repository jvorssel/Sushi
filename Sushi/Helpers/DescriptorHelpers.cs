// /***************************************************************************\
// Module Name:       DescriptorHelpers.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 15-05-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System.Reflection;
using Sushi.Attributes;
using Sushi.Descriptors;
using Sushi.Extensions;
using Sushi.Interfaces;

#endregion

namespace Sushi.Helpers;

/// <summary>
///     Logic for describing C# model.
/// </summary>
public static class DescriptorHelpers
{
    /// <summary>
    ///     Iterate over every property of the given <see cref="Type" />
    ///     and map them to <see cref="PropertyDescriptor" />s.
    /// </summary>
    public static ICollection<PropertyDescriptor> GetPropertyDescriptors(this Type @this)
    {
        var descriptors = @this.GetPropertiesWithStaticValue()
            .Where(x => !x.Key.GetCustomAttributes(typeof(IgnoreForScriptAttribute), true).Any())
            .Select(x => new PropertyDescriptor(x.Key, x.Value))
            .ToList();

        return descriptors;
    }

    /// <summary>
    ///     Iterate over every field of the given <see cref="Type" />
    ///     and map them to <see cref="PropertyDescriptor" />s.
    /// </summary>
    public static ICollection<FieldDescriptor> GetFieldDescriptors(this Type @this)
    {
        var descriptors = @this.GetFields()
            .Select(x => new FieldDescriptor(x))
            .ToList();

        return descriptors;
    }

    public static bool IsPropertyInherited(this ClassDescriptor model, IPropertyDescriptor property, bool sameType)
    {
        var parent = model.Parent;
        while (parent != null)
        {
            var query = parent.Properties.AsQueryable();
            if (sameType)
                query = query.Where(x => x.Type == property.Type);
            
            if (query.Any(x => x.Name == property.Name))
                return true;

            parent = parent.Parent;
        }

        return false;
    }

    public static bool IsApplicable(this ClassDescriptor descriptor)
    {
        var type = descriptor.Type;
        var hasScriptAttr = type.GetCustomAttributes(typeof(ConvertToScriptAttribute)).Any();
        var isScriptModel = type.IsOrInheritsInterface<IScriptModel>();
        var attrs = type.GetCustomAttributes(typeof(IgnoreForScriptAttribute), true);
        if (attrs.Any() || !type.IsClass)
            return false;

        return isScriptModel || hasScriptAttr;
    }
}