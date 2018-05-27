using System;
using System.Reflection;
using Sushi.Interfaces;
using Sushi.Models;

namespace Sushi.Consistency
{
    /// <summary>
    ///     Template key constants.
    /// </summary>
    public static class TemplateKeys
    {
        /// <summary>
        ///     The summary doc for the specific <see cref="PropertyInfo"/>.
        /// </summary>
        public const string SUMMARY_KEY = @"$$SUMMARY$$";

        /// <summary>
        ///     The name for the specific <see cref="Type"/> to compile.
        /// </summary>
        public const string TYPE_NAME_KEY = @"$$TYPENAME$$";

        /// <summary>
        ///     The namespace for the specific <see cref="Type"/> to compile.
        /// </summary>
        public const string TYPE_NAMESPACE_KEY = @"$$TYPE_NAMESPACE$$";

        /// <summary>
        ///     Placeholder for the <see cref="Type"/> properties validation.
        /// </summary>
        public const string VALIDATION_KEY = @"$$VALIDATE_OBJECT$$";

        /// <summary>
        ///     Placeholder for the properties that should be defined.
        /// </summary>
        public const string CLASS_PROPERTIES_KEY = @"$$DEFINE_PROPERTIES$$";

        /// <summary>
        ///     Placeholder for the values that should be set.
        /// </summary>
        public const string CTOR_PROPERTIES_KEY = @"$$SET_PROPERTY_VALUES$$";

        /// <summary>
        ///     Statement if the <see cref="Property"/> is defined / has a value.
        /// </summary>
        public const string IS_DEFINED_CHECK = @"$$DEFINED_CHECK$$";

        /// <summary>
        ///     Statement if the <see cref="Property"/> is not defined / has no value.
        /// </summary>
        public const string IS_UNDEFINED_CHECK = @"$$UNDEFINED_CHECK$$";

        /// <summary>
        ///     Placeholder for the argument of the object that should be used.
        /// </summary>
        public const string ARGUMENT_NAME = @"$$ARGUMENT_NAME$$";

        /// <summary>
        ///     Placeholder for the generated <see cref="SCRIPT_MODELS"/>.
        ///     Mainly used in the <see cref="ILanguageSpecification.WrapTemplate"/>.
        /// </summary>
        public const string SCRIPT_MODELS = @"$$SCRIPT_MODELS$$";
    }
}