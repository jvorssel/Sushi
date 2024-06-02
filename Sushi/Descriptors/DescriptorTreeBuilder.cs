// /***************************************************************************\
// Module Name:       DescriptorTreeBuilder.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 03-01-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

#endregion

using Sushi.Extensions;

namespace Sushi.Descriptors;

public class DescriptorTreeBuilder
{
    private readonly IEnumerable<ClassDescriptor> _types;

    public DescriptorTreeBuilder(IEnumerable<ClassDescriptor> types)
    {
        _types = types;
    }

    public IEnumerable<ClassDescriptor> BuildTree()
    {
        var flat = _types.ToList();
        var dict = flat.ToDictionary(x => x.Type, x => x);

        var tree = new HashSet<ClassDescriptor>();
        foreach (var cd in flat)
        {
            if (tree.FindDescriptor(cd.Type) != null)
                continue;

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
}