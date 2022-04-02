// /***************************************************************************\
// Module Name:       DescriptorHelpers.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 02-04-2022
// Copyright:              Royaldesk @ 2022
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sushi.Attributes;
using Sushi.Descriptors;
using Sushi.Extensions;

namespace Sushi.Helpers
{
	/// <summary>
	///     Logic for describing C# model.
	/// </summary>
	public static class DescriptorHelpers
	{
		/// <summary>
		///     Iterate over every property of the given <see cref="Type"/>
		///     and map them to <see cref="PropertyDescriptor"/>s. 
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
		///     Iterate over every field of the given <see cref="Type"/>
		///     and map them to <see cref="PropertyDescriptor"/>s. 
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
	}
}