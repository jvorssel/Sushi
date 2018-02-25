using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Common.Utility;

namespace ModelConverter.Models
{
    public sealed class DataModel
    {
        private readonly Type _type;

        /// <summary>
        ///     The actual <see cref="Name"/> of the model that the given <see cref="Type"/> refers to.
        /// </summary>
        public string Name => _type.Name;

        /// <summary>
        ///     The <see cref="FullName"/> of the model that the given <see cref="Type"/> refers to.
        /// </summary>
        public string FullName => _type.FullName;

        public DataModel(Type type)
        {
            _type = type;

            // Get the available properties in the given type
            Properties = type.GetPropertiesWithStaticValue()
                .Select(x => new Property(x.Key, x.Value))
                .ToList();
        }

        public IReadOnlyList<Property> Properties { get; }
    }
}
