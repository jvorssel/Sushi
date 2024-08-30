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

internal static class DescriptorExtensions
{
    /// <summary>
    ///		Flatten the <see cref="ClassDescriptor"/> tree to a flat list.
    /// </summary>
    internal static IEnumerable<ClassDescriptor> Flatten(this IEnumerable<ClassDescriptor> tree)
    {
        foreach (var cd in tree)
        {
            yield return cd;
            foreach (var cdc in cd.Children.Flatten())
                yield return cdc;
        }
    }
    
    internal static IEnumerable<ClassDescriptor> BuildTree(this IEnumerable<ClassDescriptor> values)
    {
        var flat = values.ToList();
        var dict = flat.ToDictionary(x => x.Type, x => x);

        var tree = new HashSet<ClassDescriptor>();
        foreach (var cd in flat)
        {
            var current = cd;
            if (current.Type.BaseType == typeof(object))
            {
                tree.Add(current);
                continue;
            }

            if (!dict.TryGetValue(current.Type.BaseType, out var fromList))
                throw new InvalidOperationException(
                    $"Base type {current.Type.BaseType} for {current.Type} is missing.");

            while (fromList != null)
            {
                current.Parent = fromList;
                fromList.Children.Add(current);

                current = fromList;
                if (current.Type.BaseType == typeof(object))
                    break;

                fromList = dict[current.Type.BaseType];
            }
        }

        return tree;
    }

    internal static bool HasParameterizedSuperConstructor(this ClassDescriptor tree)
    {
        var descriptor = tree;
        while (descriptor != null)
        {
            if (descriptor.Parent?.GenerateConstructor ?? false)
                return true;

            descriptor = descriptor.Parent;
        }

        return false;
    }
}