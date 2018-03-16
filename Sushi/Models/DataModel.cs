using System;
using System.Collections.Generic;
using System.Linq;
using Sushi.Attributes;
using Sushi.Utility;

namespace Sushi.Models
{
    public sealed class DataModel : IEquatable<DataModel>
    {
        public readonly Type Type;

        /// <summary>
        ///     The actual <see cref="Name"/> of the model that the given <see cref="System.Type"/> refers to.
        /// </summary>
        public string Name => Type.Name;

        /// <summary>
        ///     The <see cref="FullName"/> of the model that the given <see cref="System.Type"/> refers to.
        /// </summary>
        public string FullName => Type.FullName;

        /// <summary>
        ///     The generated <see cref="Script"/> for this <see cref="DataModel"/>.
        /// </summary>
        public string Script { get; set; }

        /// <summary>
        ///     The base <see cref="System.Type"/> of the given <see cref="System.Type"/>.
        /// </summary>
        public Type BaseType => Type.BaseType;

        /// <summary>
        ///     If the <see cref="BaseType"/> is not a default <see cref="System.Type"/> instance.
        /// </summary>
        public bool HasBaseType => BaseType != typeof(Type);

        public DataModel(Type type)
        {
            Type = type;

            // Get the available properties in the given type
            Properties = type.GetPropertiesWithStaticValue()
                .Where(x => !x.Key.GetCustomAttributes(typeof(IgnoreForScript), true).Any())
                .Select(x => new Property(x.Key, x.Value))
                .ToList();
        }

        public IReadOnlyList<Property> Properties { get; }

        public static bool operator ==(DataModel m1, DataModel m2)
            => m1?.Type == m2?.Type;

        public static bool operator !=(DataModel m1, DataModel m2)
            => !(m1 == m2);

        public static bool operator ==(DataModel m1, Type m2)
            => m1?.Type == m2;

        public static bool operator !=(DataModel m1, Type m2)
            => !(m1 == m2);

        #region Equality members

        /// <inheritdoc />
        public bool Equals(DataModel other)
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
            return obj is DataModel model && Equals(model);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return (Type != null ? Type.GetHashCode() : 0);
        }

        #endregion
    }

}
