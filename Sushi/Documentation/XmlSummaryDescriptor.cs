// /***************************************************************************\
// Module Name:       XmlSummaryDescriptor.cs
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
using System.Reflection;
using System.Text;
using Sushi.Descriptors;
using Sushi.Extensions;
using Sushi.Interfaces;

#endregion

namespace Sushi.Documentation
{
    /// <summary>
    ///     Describes xml-summary about a field, property or method.
    /// </summary>
    public sealed class XmlSummaryDescriptor : IEquatable<XmlSummaryDescriptor>
	{
        /// <summary>
        ///     <see cref="Dictionary{TKey,TValue}" /> that describes direct child-elements of the member.
        /// </summary>
        public Dictionary<string, string> Values { get; }

        /// <summary>
        ///     The <see cref="RawName" /> value of the member.
        /// </summary>
        public string RawName { get; }

        /// <summary>
        ///     The last-part of the <see cref="RawName" /> that describes the actual <see cref="Name" />.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     The full-<see cref="Namespace" /> that the <see cref="Name" /> belongs in.
        /// </summary>
        public string Namespace { get; }

        /// <summary>
        ///     The type-name of the class this <see cref="Name" /> belongs to.
        /// </summary>
        public string DeclaringTypeName { get; }

        /// <summary>
        ///     The complete, formatted <see cref="FullName" />.
        /// </summary>
        public string FullName
		{
			get
			{
				switch (FieldType)
				{
					case ReferenceType.Namespace:
						return $"{Namespace}";
					case ReferenceType.Error:
					case ReferenceType.Type:
						return $"{Namespace}.{Name}";
					case ReferenceType.Method:
					case ReferenceType.Property:
					case ReferenceType.Field:
					case ReferenceType.Event:
						return $"{Namespace}.{DeclaringTypeName}.{Name}";
					case ReferenceType.Undefined:
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}

        /// <summary>
        ///     What <see cref="ReferenceType" /> does the xml-doc reflect.
        /// </summary>
        public ReferenceType FieldType { get; }

		// FIELDS
		public bool IsInherited { get; }
		public string Summary { get; }
		public string Remarks { get; }

		/// <inheritdoc />
		public XmlSummaryDescriptor(string name, ReferenceType field, Dictionary<string, string> values)
		{
			if (name.IsEmpty())
				throw new ArgumentNullException(nameof(name));

			RawName = XmlDocumentationReader.RemoveMethodArgs.Match(name).Value;
			Values = values ?? throw new ArgumentNullException(nameof(values));
			FieldType = field;

			var split = RawName.Split('.').ToList();
			switch (field)
			{
				case ReferenceType.Type:
					Name = split.Last();
					DeclaringTypeName = split.Last();
					Namespace = split.JoinString('.', split.Count - 1);
					break;
				case ReferenceType.Property:
					Name = split.Last();
					DeclaringTypeName = split[split.Count         - 2];
					Namespace = split.JoinString('.', split.Count - 2);
					break;
				case ReferenceType.Method:
					Name = split.Last();
					DeclaringTypeName = split[split.Count         - 2];
					Namespace = split.JoinString('.', split.Count - 2);
					break;
				case ReferenceType.Namespace:
					Name = split.JoinString('.');
					Namespace = Name;
					break;
				case ReferenceType.Field:
					Name = split.Last();
					DeclaringTypeName = split[split.Count         - 2];
					Namespace = split.JoinString('.', split.Count - 2);
					break;
				case ReferenceType.Event:
					Name = split.Last();
					DeclaringTypeName = split[split.Count         - 2];
					Namespace = split.JoinString('.', split.Count - 2);
					break;
				case ReferenceType.Error:
					Name = split.JoinString('.');
					break;
				case ReferenceType.Undefined:
				default:
					throw new ArgumentOutOfRangeException(nameof(field), field, null);
			}

			// FIELDS
			Summary = values.ContainsKey("summary") ? Trim(Values["summary"]) : string.Empty;
			Remarks = values.ContainsKey("remarks") ? Trim(Values["remarks"]) : string.Empty;
			IsInherited = values.ContainsKey("inheritdoc");
		}

        /// <summary>
        ///     Custom method to <see cref="Trim" /> the inner-body of the xml-doc.
        /// </summary>
        private string Trim(string value)
			=> value.Trim().TrimStart('\n').TrimEnd('\n');

		public static bool operator ==(XmlSummaryDescriptor fd, Type type)
		{
			if (type is null && fd is null)
				return true;

			if (type is null && !(fd is null))
				return false;

			if (!(type is null) && fd is null)
				return false;

			switch (fd.FieldType)
			{
				case ReferenceType.Type:
					return fd.Name == type.Name && fd.Namespace == type.Namespace;
				case ReferenceType.Method:
				case ReferenceType.Field:
				case ReferenceType.Property:
					return fd.Namespace == type.Namespace;
				case ReferenceType.Namespace:
				case ReferenceType.Event:
				case ReferenceType.Error:
				case ReferenceType.Undefined:
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public static bool operator !=(XmlSummaryDescriptor ms, Type type)
			=> !(ms == type);

		public static bool operator ==(XmlSummaryDescriptor fd, PropertyInfo prop)
		{
			if (prop is null && fd is null)
				return true;

			if (prop is null && !(fd is null))
				return false;

			if (!(prop is null) && fd is null)
				return false;

			switch (fd.FieldType)
			{
				case ReferenceType.Type:
					return prop.DeclaringType?.Name      == fd.DeclaringTypeName &&
					       prop.PropertyType?.Name       == fd.Name              &&
					       prop.DeclaringType?.Namespace == fd.Namespace;
				case ReferenceType.Method:
				case ReferenceType.Field:
				case ReferenceType.Property:
					return prop.DeclaringType?.Name      == fd.DeclaringTypeName &&
					       prop.DeclaringType?.Namespace == fd.Namespace         &&
					       prop.Name                     == fd.Name;
				case ReferenceType.Namespace:
				case ReferenceType.Event:
				case ReferenceType.Error:
				case ReferenceType.Undefined:
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public static bool operator !=(XmlSummaryDescriptor fd, PropertyInfo prop)
			=> !(fd == prop);

		#region Overrides of Object

		/// <inheritdoc />
		public override string ToString()
			=> FullName;

		#endregion

		#region Equality members

		/// <inheritdoc />
		public bool Equals(XmlSummaryDescriptor other)
		{
			if (ReferenceEquals(null, other))
				return false;
			if (ReferenceEquals(this, other))
				return true;
			return string.Equals(Name, other.Name) && string.Equals(Namespace, other.Namespace) &&
			       string.Equals(DeclaringTypeName, other.DeclaringTypeName) && FieldType == other.FieldType;
		}

		/// <inheritdoc />
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != GetType())
				return false;
			return Equals((XmlSummaryDescriptor)obj);
		}

		/// <inheritdoc />
		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Name                              != null ? Name.GetHashCode() : 0;
				hashCode = (hashCode * 397) ^ (Namespace         != null ? Namespace.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (DeclaringTypeName != null ? DeclaringTypeName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (int)FieldType;
				return hashCode;
			}
		}

		#endregion
	}

	public static class JsDocComment
	{
		public static string JsDocPropertySummary(this XmlDocumentationReader doc, IPropertyDescriptor descriptor)
		{
			// Return the rows for the js-doc
			var summary = doc.GetDocumentationForProperty(descriptor);
			if (summary?.Summary.Length > 0)
				return $"/** {summary.Summary} */";

			return null;
		}

		public static string JsDocClassSummary(this SushiConverter converter, ClassDescriptor descriptor)
		{
			var builder = new StringBuilder();
			var doc = converter.Documentation;
			// Return the rows for the js-doc
			var typeDoc = doc?.GetDocumentationForType(descriptor.Type);
			builder.AppendLine("/**");
			var summary = typeDoc?.Summary.IsEmpty() ?? true ? $"{descriptor.FullName}." : typeDoc.Summary;
			builder.AppendLine($" * {summary} ");
			builder.AppendLine($" * @typedef {{Object}} {descriptor.Name}");

			if (descriptor.Parent != (ClassDescriptor)null)
			{
				builder.AppendLine($" * @extends {descriptor.Parent.Name} ");
			}
			
			builder.AppendLine(" */");

			// foreach (var property in descriptor.Properties)
			// {
			// 	// Apply formatting for TypeScript its Array type.
			// 	var type = property.ScriptTypeValue;
			// 	var name = descriptor.Name;
			//
			// 	if (descriptor.Type.IsNullable())
			// 		name += "?";
			//
			// 	var statement = $@" * {name}: {type};";
			// 	builder.AppendLine(statement);
			// }

			return builder.ToString();
		}

	}
}