﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sushi.Extensions;

namespace Sushi.Documentation.Models
{
    /// <summary>
    ///     A class representation for a member in the XML document.
    /// </summary>
    public class FieldDocumentation : IEquatable<FieldDocumentation>
    {
        public Dictionary<string, string> Values { get; }
        public string RawName { get; }
        public string Name { get; }
        public string Namespace { get; }
        public string DeclaringTypeName { get; }
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


        public ReferenceType FieldType { get; }

        // FIELDS
        public bool IsInherited { get; }
        public string Summary { get; }
        public string Remarks { get; }


        /// <inheritdoc />
        public FieldDocumentation(string name, ReferenceType field, Dictionary<string, string> values)
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
                    DeclaringTypeName = split[split.Count - 2];
                    Namespace = split.JoinString('.', split.Count - 2);
                    break;
                case ReferenceType.Method:
                    Name = split.Last();
                    DeclaringTypeName = split[split.Count - 2];
                    Namespace = split.JoinString('.', split.Count - 2);
                    break;
                case ReferenceType.Namespace:
                    Name = split.JoinString('.');
                    Namespace = Name;
                    break;
                case ReferenceType.Field:
                    Name = split.Last();
                    DeclaringTypeName = split[split.Count - 2];
                    Namespace = split.JoinString('.', split.Count - 2);
                    break;
                case ReferenceType.Event:
                    Name = split.Last();
                    DeclaringTypeName = split[split.Count - 2];
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

        private string Trim(string value)
            => value.Trim().TrimStart('\n').TrimEnd('\n');

        public static bool operator ==(FieldDocumentation fd, Type type)
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

        public static bool operator !=(FieldDocumentation ms, Type type)
            => !(ms == type);

        public static bool operator ==(FieldDocumentation fd, PropertyInfo prop)
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
                    return prop.DeclaringType?.Name == fd.DeclaringTypeName &&
                        prop.PropertyType?.Name == fd.Name &&
                        prop.DeclaringType?.Namespace == fd.Namespace;
                case ReferenceType.Method:
                case ReferenceType.Field:
                case ReferenceType.Property:
                    return prop.DeclaringType?.Name == fd.DeclaringTypeName &&
                        prop.DeclaringType?.Namespace == fd.Namespace &&
                        prop.Name == fd.Name;
                case ReferenceType.Namespace:
                case ReferenceType.Event:
                case ReferenceType.Error:
                case ReferenceType.Undefined:
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }

        public static bool operator !=(FieldDocumentation fd, PropertyInfo prop)
            => !(fd == prop);

        #region Overrides of Object

        /// <inheritdoc />
        public override string ToString()
            => FullName;

        #endregion

        #region Equality members

        /// <inheritdoc />
        public bool Equals(FieldDocumentation other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return string.Equals(Name, other.Name) && string.Equals(Namespace, other.Namespace) && string.Equals(DeclaringTypeName, other.DeclaringTypeName) && FieldType == other.FieldType;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((FieldDocumentation)obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Namespace != null ? Namespace.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (DeclaringTypeName != null ? DeclaringTypeName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)FieldType;
                return hashCode;
            }
        }

        #endregion
    }
}