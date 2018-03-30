using System;
using Sushi.Extensions;

namespace Sushi.Documentation.Models
{
    /// <summary>
    ///     A class representation for a member in the XML document.
    /// </summary>
    public class MemberSummary : IEquatable<MemberSummary>
    {
        public string Namespace { get; }
        public string Summary { get; }
        public FieldType Field { get; }
        public bool HasValue => !Summary.IsEmpty();

        /// <inheritdoc />
        public MemberSummary(string @namespace, string summary, FieldType field)
        {
            Namespace = @namespace ?? throw new ArgumentNullException(nameof(@namespace));
            Summary = summary?.Trim().TrimStart('\n').TrimEnd('\n') ?? throw new ArgumentNullException(nameof(summary));
            Field = field;
        }

        public static bool operator ==(MemberSummary ms, Type type)
            => (type is null && ms is null) || ms?.Namespace == type?.Namespace + type?.Name;

        public static bool operator !=(MemberSummary ms, Type type)
            => !(ms == type);

        #region Overrides of Object

        /// <inheritdoc />
        public override string ToString()
            => Summary;

        #endregion

        #region Equality members

        /// <inheritdoc />
        public bool Equals(MemberSummary other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return string.Equals(Namespace, other.Namespace) && string.Equals(Summary, other.Summary) && Field == other.Field;
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
            return Equals((MemberSummary)obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Namespace != null ? Namespace.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Summary != null ? Summary.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)Field;
                return hashCode;
            }
        }

        #endregion
    }
}