// /***************************************************************************\
// Module Name:       ClassDescriptor.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 01-01-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Sushi.Helpers;
using Sushi.Interfaces;

#endregion

namespace Sushi.Descriptors
{
	/// <summary>
	///     Describes a <see cref="System.Type" />.
	/// </summary>
	[DebuggerDisplay("Name = {Name}")]
	public sealed class ClassDescriptor : IEquatable<ClassDescriptor>
	{
		public readonly Type Type;

		/// <summary>
		///     The actual <see cref="Name" /> of the model that the given <see cref="System.Type" /> refers to.
		/// </summary>
		public string Name => Type.Name;

		/// <summary>
		///     The <see cref="FullName" /> of the model that the given <see cref="System.Type" /> refers to.
		/// </summary>
		public string FullName => Type.FullName;

		/// <summary>
		///     The generated <see cref="Script" /> for this <see cref="ClassDescriptor" />.
		/// </summary>
		public string Script { get; set; } = string.Empty;

		public ClassDescriptor(Type type)
		{
			Type = type;

			// Get the available properties in the given type
			var properties = Type.GetPropertyDescriptors();
			var fields = Type.GetFieldDescriptors();
			Properties = properties.Cast<IPropertyDescriptor>().Concat(fields).ToList();
		}

		public IReadOnlyList<IPropertyDescriptor> Properties { get; }

		/// <summary>
		///		Get the <see cref="Properties"/> <see cref="List{T}"/> but allows filtering inherited properties.
		/// </summary>
		public IEnumerable<IPropertyDescriptor> GetProperties(bool excludeInherited)
		{
			foreach (var prop in Properties)
			{
				var isInherited = this.IsPropertyInherited(prop);
				if (excludeInherited && isInherited)
					continue;

				yield return prop;
			}
		}

		public ClassDescriptor Parent { get; set; }
		public HashSet<ClassDescriptor> Children { get; } = new();
		public bool HasParent => Parent != (ClassDescriptor)null;

		#region Equality members

		public static bool operator ==(ClassDescriptor m1, ClassDescriptor m2)
			=> m1?.Type == m2?.Type;

		public static bool operator !=(ClassDescriptor m1, ClassDescriptor m2)
			=> !(m1 == m2);

		public static bool operator ==(ClassDescriptor m1, Type m2)
			=> m1?.Type == m2;

		public static bool operator !=(ClassDescriptor m1, Type m2)
			=> !(m1 == m2);

		/// <inheritdoc />
		public bool Equals(ClassDescriptor other)
		{
			if (ReferenceEquals(null, other))
				return false;

			if (ReferenceEquals(this, other))
				return true;

			return Type == other.Type;
		}

		/// <inheritdoc />
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;

			if (ReferenceEquals(this, obj))
				return true;

			return obj is ClassDescriptor model && Equals(model);
		}

		/// <inheritdoc />
		public override int GetHashCode()
			=> Type != null ? Type.GetHashCode() : 0;

		#endregion
	}
}