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
		private readonly IEnumerable<Type> _types;

		public DescriptorTreeBuilder(IEnumerable<Type> types)
			=> _types = types;

		public IEnumerable<ClassDescriptor> FilterTypes()
		{
			foreach (var type in _types)
			{
				var hasScriptAttr = type.GetCustomAttributes(typeof(ConvertToScriptAttribute)).Any();
				var isScriptModel = type.IsTypeOrInheritsOf(typeof(IScriptModel));
				var attrs = type.GetCustomAttributes(typeof(IgnoreForScript), true);
				if (attrs.Any() ||!type.IsClass)
					continue;

				if (isScriptModel || hasScriptAttr)
					yield return new ClassDescriptor(type);
			}
		}

		public IEnumerable<ClassDescriptor> BuildTree()
		{
			var flat = FilterTypes().ToList();

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