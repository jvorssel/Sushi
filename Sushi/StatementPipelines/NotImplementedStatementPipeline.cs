using System.Collections.Generic;
using Sushi.Descriptors;

namespace Sushi.StatementPipelines
{
    /// <inheritdoc />
    public class NotImplementedStatementPipeline : StatementPipeline
    {
        #region Overrides of StatementPipeline

        /// <inheritdoc />
        public override ScriptConditionDescriptor ArgumentDefinedStatement(ConversionKernel kernel)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override ScriptConditionDescriptor ArgumentUndefinedStatement(ConversionKernel kernel)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override ScriptConditionDescriptor CreateKeyCheckStatement(ConversionKernel kernel, PropertyDescriptor property)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override ScriptConditionDescriptor CreateUndefinedStatement(ConversionKernel kernel, PropertyDescriptor property)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override ScriptConditionDescriptor CreateDefinedStatement(ConversionKernel kernel, PropertyDescriptor property)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override ScriptConditionDescriptor CreateInstanceCheckStatement(ConversionKernel kernel, PropertyDescriptor property)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override ScriptConditionDescriptor CreateTypeCheckStatement(ConversionKernel kernel, PropertyDescriptor property)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}