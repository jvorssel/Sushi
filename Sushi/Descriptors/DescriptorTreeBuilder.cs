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

using System.Reflection;
using Sushi.Attributes;
using Sushi.Extensions;
using Sushi.Interfaces;

#endregion

namespace Sushi.Descriptors
{
	public class DescriptorTreeBuilder
	{
		private readonly IEnumerable<ClassDescriptor> _types;

		public DescriptorTreeBuilder(IEnumerable<ClassDescriptor> types)
			=> _types = types;

		public IEnumerable<ClassDescriptor> BuildTree()
		{
			var flat = _types.ToList();

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

				var fromList = flat.SingleOrDefault(x => x.Type == current.Type.BaseType);
				if (fromList == null)
				{
					throw new InvalidOperationException(
						$"Base type {current.Type.BaseType} for {current.Type} is missing.");
				}

				while (fromList != null)
				{
					current.Parent = fromList;
					fromList.Children.Add(current);

					current = fromList;
					fromList = flat.SingleOrDefault(x => x.Type == current.Type.BaseType);
				}
			}

			return tree;
		}
	}
}