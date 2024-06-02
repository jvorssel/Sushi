// /***************************************************************************\
// Module Name:       DescriptorExtensions.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 03-01-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

using Sushi.Descriptors;

namespace Sushi.Extensions;

public static class DescriptorExtensions
{
    /// <summary>
    ///		Find the  <see cref="ClassDescriptor"/> of <paramref name="type"/> in the descriptor tree.
    /// </summary>
    public static ClassDescriptor? FindDescriptor(this ICollection<ClassDescriptor> tree, Type type)
    {
        foreach (var d in tree)
        {
            if (d.Type == type)
                return d;

            var child = FindDescriptor(d.Children, type);
            if (child != null)
                return child;
        }

        return null;
    }

    /// <summary>
    ///		Flatten the <see cref="ClassDescriptor"/> tree to a flat list.
    /// </summary>
    public static IEnumerable<ClassDescriptor> Flatten(this IEnumerable<ClassDescriptor> tree)
    {
        foreach (var cd in tree)
        {
            yield return cd;
            foreach (var cdc in cd.Children.Flatten())
                yield return cdc;
        }
    }

    public static bool HasParameterizedSuperConstructor(this ClassDescriptor tree)
    {
        var descriptor = tree;
        while (descriptor != null)
        {
            if (descriptor.GenerateConstructor)
                return true;

            descriptor = descriptor.Parent;
        }

        return false;
    }
}