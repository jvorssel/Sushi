using System.Collections.Generic;
using Sushi.Models;
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
        public abstract Statement ArgumentDefinedStatement(ConversionKernel kernel);

        /// <summary>
        ///     Create a statement to check if the given <see cref="ConversionKernel.ArgumentName"/> has no value.
        /// </summary>
        public abstract Statement ArgumentUndefinedStatement(ConversionKernel kernel);

        /// <summary>
        ///     Create a statement to check if the <see cref="Property.Name"/> exists in the given argument.
        /// </summary>
        public abstract Statement CreateKeyCheckStatement(ConversionKernel kernel, Property property);

        /// <summary>
        ///     Create a statement to check if the <see cref="Property.Name"/> is undefined or null in the <see cref="ConversionKernel.ArgumentName"/>.
        /// </summary>
        public abstract Statement CreateUndefinedStatement(ConversionKernel kernel, Property property);

        /// <summary>
        ///     Create a statement to check if the <see cref="Property.Name"/> in the <see cref="ConversionKernel.ArgumentName"/> is defined.
        /// </summary>
        public abstract Statement CreateDefinedStatement(ConversionKernel kernel, Property property);

        /// <summary>
        ///     Create a statement to check if the <see cref="Property.Name"/> is a instance of the expected class.
        /// </summary>
        public abstract Statement CreateInstanceCheckStatement(ConversionKernel kernel, Property property);

        /// <summary>
        ///     Create a statement to check if the <see cref="Property.Name"/> is a instance of the expected type.
        /// </summary>
        public abstract Statement CreateTypeCheckStatement(ConversionKernel kernel, Property property);

        /// <summary>
        ///     An <see cref="Empty"/> <see cref="StatementPipeline"/> without any <see cref="Statement"/>s defined.
        /// </summary>
        public static EmptyStatementPipeline Empty => new EmptyStatementPipeline();
    }
}