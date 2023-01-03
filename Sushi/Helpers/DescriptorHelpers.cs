// /***************************************************************************\
// Module Name:       DescriptorHelpers.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 01-01-2023
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

namespace Sushi.Helpers
{
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
				.Where(x => !x.Key.GetCustomAttributes(typeof(IgnoreForScript), true).Any())
				.Select(x => new PropertyDescriptor(x.Key))
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

		public static object GetDefaultValue(this Type @this, PropertyInfo property)
		{
			var instance = Activator.CreateInstance(@this);
			return instance == null ? null : property.GetValue(instance, null);
		}

		public static object GetDefaultValue(this Type @this, FieldInfo property)
		{
			var instance = Activator.CreateInstance(@this);
			return instance == null ? null : property.GetValue(instance);
		}

		public static bool IsPropertyInherited(this ClassDescriptor model, IPropertyDescriptor property)
		{
			var parent = model.Parent;
			while (parent != null)
			{
				if (parent.Properties.Any(x => x.Name == property.Name && x.Type == property.Type))
					return true;

				parent = parent.Parent;
			}

			return false;
		}
	}
}