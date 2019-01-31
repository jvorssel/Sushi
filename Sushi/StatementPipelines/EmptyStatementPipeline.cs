using System.Collections.Generic;
using Sushi.Descriptors;

namespace Sushi.StatementPipelines
{
    /// <inheritdoc />
    public class EmptyStatementPipeline : StatementPipeline
    {
        /// <inheritdoc />
        public override ScriptConditionDescriptor ArgumentDefinedStatement(ConversionKernel kernel)
            => null;

        /// <inheritdoc />
        public override ScriptConditionDescriptor ArgumentUndefinedStatement(ConversionKernel kernel)
            => null;

        /// <inheritdoc />
        public override ScriptConditionDescriptor CreateKeyCheckStatement(ConversionKernel kernel, PropertyDescriptor property)
            => null;

        /// <inheritdoc />
        public override ScriptConditionDescriptor CreateUndefinedStatement(ConversionKernel kernel, PropertyDescriptor property)
            => null;

        /// <inheritdoc />
        public override ScriptConditionDescriptor CreateDefinedStatement(ConversionKernel kernel, PropertyDescriptor property)
            => null;

        /// <inheritdoc />
        public override ScriptConditionDescriptor CreateInstanceCheckStatement(ConversionKernel kernel, PropertyDescriptor property)
            => null;

        /// <inheritdoc />
        public override ScriptConditionDescriptor CreateTypeCheckStatement(ConversionKernel kernel, PropertyDescriptor property)
            => null;
    }
}