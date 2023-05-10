// /***************************************************************************\
// Module Name:       PropertyDescriptor.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 04-11-2022
// Copyright:              Royaldesk @ 2022
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System.Diagnostics;
using System.Reflection;
using Sushi.Helpers;
using Sushi.Interfaces;

#endregion

namespace Sushi.Descriptors
{
	/// <summary>
	///     Describes a property in a class.
	/// </summary>
	public sealed class PropertyDescriptor : IPropertyDescriptor
	{
		private readonly PropertyInfo _property;
		
		/// <inheritdoc />
		public object? DefaultValue { get; }

		/// <inheritdoc />
		public string Name { get; }

		/// <inheritdoc />
		public Type Type { get; }

		/// <inheritdoc />
		public Type ClassType => _property.DeclaringType;

		public PropertyDescriptor(PropertyInfo property, object? defaultValue = null)
		{
			var type = property.PropertyType;

			_property = property;
			Name = property.Name;
			Type = type;
			DefaultValue = defaultValue;
		}

		public PropertyDescriptor(Type type, object? defaultValue = null)
		{
			Type = type;
			DefaultValue = defaultValue;
		}

		/// <inheritdoc />
		public override string ToString()
			=> $"{ClassType.Namespace}.{ClassType.Name}.{_property.Name}";
	}
}