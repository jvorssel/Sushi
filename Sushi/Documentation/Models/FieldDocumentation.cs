using System;
using System.Collections.Generic;
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
        public string Namespace { get; internal set; }
        public string Name { get; }
        public string DeclaringTypeName { get; internal set; }
        public FieldType FieldType { get; }

        // FIELDS
        public bool IsInherited { get; }
        public string Summary { get; }
        public string Remarks { get; }


        /// <inheritdoc />
        public FieldDocumentation(string @namespace, string name, FieldType field, Dictionary<string, string> values)
        {
            Namespace = @namespace ?? throw new ArgumentNullException(nameof(@namespace));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Values = values ?? throw new ArgumentNullException(nameof(values));
            FieldType = field;

            // FIELDS
            Summary = values.ContainsKey("summary") ? Trim(Values["summary"]) : string.Empty;
            Remarks = values.ContainsKey("remarks") ? Trim(Values["remarks"]) : string.Empty;
            IsInherited = values.ContainsKey("inheritdoc");
        }

        private string Trim(string value)
            => value.Trim().TrimStart('\n').TrimEnd('\n');

        public static bool operator ==(FieldDocumentation ms, Type type)
            => type is null && ms is null || ms?.Namespace == type?.Namespace && ms?.Name == type?.Name;

        public static bool operator !=(FieldDocumentation ms, Type type)
            => !(ms == type);

        public static bool operator ==(FieldDocumentation fd, PropertyInfo prop)
            => fd is null && prop is null || fd?.Namespace == prop?.DeclaringType?.Namespace && fd?.Name == prop?.Name;

        public static bool operator !=(FieldDocumentation fd, PropertyInfo prop)
            => !(fd == prop);

        #region Overrides of Object

        /// <inheritdoc />
        public override string ToString()
            => Summary;

        #endregion

        #region Equality members

        /// <inheritdoc />
        public bool Equals(FieldDocumentation other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return string.Equals(Namespace, other.Namespace) && string.Equals(Summary, other.Summary) && FieldType == other.FieldType;
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
                var hashCode = (Namespace != null ? Namespace.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Summary != null ? Summary.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)FieldType;
                return hashCode;
            }
        }

        #endregion
    }
}