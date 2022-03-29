using System.Collections.Generic;
using Sushi.Descriptors;

namespace Sushi.StatementPipelines
{
    /// <inheritdoc />
    public class NotImplementedStatementPipeline : ConditionPipeline
    {
        #region Overrides of StatementPipeline

        /// <inheritdoc />
        public override ScriptConditionDescriptor ArgumentDefinedCheck(ConversionKernel kernel)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override ScriptConditionDescriptor ArgumentUndefinedCheck(ConversionKernel kernel)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override ScriptConditionDescriptor CreateKeyExistsCheck(ConversionKernel kernel, PropertyDescriptor property)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override ScriptConditionDescriptor CreateUndefinedCheck(ConversionKernel kernel, PropertyDescriptor property)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override ScriptConditionDescriptor CreateDefinedCheck(ConversionKernel kernel, PropertyDescriptor property)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override ScriptConditionDescriptor CreateInstanceCheck(ConversionKernel kernel, PropertyDescriptor property)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override ScriptConditionDescriptor CreateTypeCheck(ConversionKernel kernel, PropertyDescriptor property)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}