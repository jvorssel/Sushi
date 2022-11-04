// /***************************************************************************\
// Module Name:       ClassDescriptor.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 04-11-2022
// Copyright:              Royaldesk @ 2022
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System;
using System.Collections.Generic;
using System.Linq;
using Sushi.Helpers;
using Sushi.Interfaces;

#endregion

namespace Sushi.Descriptors
{
	/// <summary>
	///     Describes a <see cref="System.Type" />.
	/// </summary>
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

		public ClassDescriptor Parent { get; set; }
		public HashSet<ClassDescriptor> Children { get; } = new();

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