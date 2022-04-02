using System;
using Sushi.Descriptors;
using Sushi.Enum;
using Sushi.Interfaces;

namespace Sushi
{
    /// <summary>
    ///     Manage the validation method used when an object is parsed to the generated constructor.
    /// </summary>
    /// <remarks>
    ///     These templates are not type-specific (yet). 
    ///     Will be used for every generated file with matching property type(s).
    /// </remarks>
    public abstract class ConditionPipeline
    {
        /// <summary>
        ///     Create a statement to check if the given <see cref="ConversionKernel.ArgumentName"/> has a value.
        /// </summary>
        public abstract ScriptConditionDescriptor ArgumentDefinedCheck(ConversionKernel kernel);

        /// <summary>
        ///     Create a statement to check if the given <see cref="ConversionKernel.ArgumentName"/> has no value.
        /// </summary>
        public abstract ScriptConditionDescriptor ArgumentUndefinedCheck(ConversionKernel kernel);

        /// <summary>
        ///     Create a statement to check if the <see cref="PropertyDescriptor.Name"/> exists in the given argument.
        /// </summary>
        public abstract ScriptConditionDescriptor CreateKeyExistsCheck(ConversionKernel kernel, IPropertyDescriptor descriptor);

        /// <summary>
        ///     Create a statement to check if the <see cref="PropertyDescriptor.Name"/> is a instance of the expected class.
        /// </summary>
        public abstract ScriptConditionDescriptor CreateInstanceCheck(ConversionKernel kernel, IPropertyDescriptor descriptor);

        /// <summary>
        ///     Create a statement to check if the <see cref="PropertyDescriptor.Name"/> is a instance of the expected type.
        /// </summary>
        public abstract ScriptConditionDescriptor CreateTypeCheck(ConversionKernel kernel, IPropertyDescriptor descriptor);

        /// <inheritdoc cref=""/>
        public abstract ScriptConditionDescriptor CreateDefinedCheck(ConversionKernel kernel, IPropertyDescriptor descriptor);
    }
}