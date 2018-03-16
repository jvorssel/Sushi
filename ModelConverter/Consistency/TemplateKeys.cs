using System;
using System.Reflection;

namespace ModelConverter.Consistency
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
        ///     Placeholder for the values that should be set.
        /// </summary>
        public const string VALUES_KEY = @"$$SET_VALUES$$";
        
        /// <summary>
        ///     Placeholder for the name of the inherited <see cref="Type"/>.
        /// </summary>
        public const string INHERIT_TYPE = @"$$INHERIT_TYPE$$";

        public const string IS_DEFINED_CHECK = @"$$DEFINED_CHECK$$";
        public const string IS_UNDEFINED_CHECK = @"$$UNDEFINED_CHECK$$";
        public const string ARGUMENT_NAME = @"$$ARGUMENT_NAME$$";
    }
}