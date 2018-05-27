using System.Collections.Generic;
using Sushi.Models;

namespace Sushi.StatementPipelines
{
    /// <inheritdoc />
    public class NotImplementedStatementPipeline : StatementPipeline
    {
        #region Overrides of StatementPipeline

        /// <inheritdoc />
        public override Statement ArgumentDefinedStatement(ConversionKernel kernel)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override Statement ArgumentUndefinedStatement(ConversionKernel kernel)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override Statement CreateKeyCheckStatement(ConversionKernel kernel, Property property)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override Statement CreateUndefinedStatement(ConversionKernel kernel, Property property)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override Statement CreateDefinedStatement(ConversionKernel kernel, Property property)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override Statement CreateInstanceCheckStatement(ConversionKernel kernel, Property property)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override Statement CreateTypeCheckStatement(ConversionKernel kernel, Property property)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}