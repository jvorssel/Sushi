using System.Collections.Generic;
using Sushi.Descriptors;
using Sushi.StatementPipelines;

namespace Sushi
{
    /// <summary>
    ///     Manage the validation method used when an object is parsed to the generated constructor.
    /// </summary>
    /// <remarks>
    ///     These templates are not type-specific (yet). 
    ///     Will be used for every generated file with matching property type(s).
    /// </remarks>
    public abstract class StatementPipeline
    {
        /// <summary>
        ///     Create a statement to check if the given <see cref="ConversionKernel.ArgumentName"/> has a value.
        /// </summary>
        public abstract ScriptConditionDescriptor ArgumentDefinedStatement(ConversionKernel kernel);

        /// <summary>
        ///     Create a statement to check if the given <see cref="ConversionKernel.ArgumentName"/> has no value.
        /// </summary>
        public abstract ScriptConditionDescriptor ArgumentUndefinedStatement(ConversionKernel kernel);

        /// <summary>
        ///     Create a statement to check if the <see cref="PropertyDescriptor.Name"/> exists in the given argument.
        /// </summary>
        public abstract ScriptConditionDescriptor CreateKeyCheckStatement(ConversionKernel kernel, PropertyDescriptor property);

        /// <summary>
        ///     Create a statement to check if the <see cref="PropertyDescriptor.Name"/> is undefined or null in the <see cref="ConversionKernel.ArgumentName"/>.
        /// </summary>
        public abstract ScriptConditionDescriptor CreateUndefinedStatement(ConversionKernel kernel, PropertyDescriptor property);

        /// <summary>
        ///     Create a statement to check if the <see cref="PropertyDescriptor.Name"/> in the <see cref="ConversionKernel.ArgumentName"/> is defined.
        /// </summary>
        public abstract ScriptConditionDescriptor CreateDefinedStatement(ConversionKernel kernel, PropertyDescriptor property);

        /// <summary>
        ///     Create a statement to check if the <see cref="PropertyDescriptor.Name"/> is a instance of the expected class.
        /// </summary>
        public abstract ScriptConditionDescriptor CreateInstanceCheckStatement(ConversionKernel kernel, PropertyDescriptor property);

        /// <summary>
        ///     Create a statement to check if the <see cref="PropertyDescriptor.Name"/> is a instance of the expected type.
        /// </summary>
        public abstract ScriptConditionDescriptor CreateTypeCheckStatement(ConversionKernel kernel, PropertyDescriptor property);

        /// <summary>
        ///     An <see cref="Empty"/> <see cref="StatementPipeline"/> without any <see cref="ScriptConditionDescriptor"/>s defined.
        /// </summary>
        public static EmptyStatementPipeline Empty => new EmptyStatementPipeline();
    }
}