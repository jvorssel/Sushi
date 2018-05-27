using System.Collections.Generic;
using Sushi.Models;

namespace Sushi.StatementPipelines
{
    /// <inheritdoc />
    public class EmptyStatementPipeline : StatementPipeline
    {
        /// <inheritdoc />
        public override Statement ArgumentDefinedStatement(ConversionKernel kernel)
            => null;

        /// <inheritdoc />
        public override Statement ArgumentUndefinedStatement(ConversionKernel kernel)
            => null;

        /// <inheritdoc />
        public override Statement CreateKeyCheckStatement(ConversionKernel kernel, Property property)
            => null;

        /// <inheritdoc />
        public override Statement CreateUndefinedStatement(ConversionKernel kernel, Property property)
            => null;

        /// <inheritdoc />
        public override Statement CreateDefinedStatement(ConversionKernel kernel, Property property)
            => null;

        /// <inheritdoc />
        public override Statement CreateInstanceCheckStatement(ConversionKernel kernel, Property property)
            => null;

        /// <inheritdoc />
        public override Statement CreateTypeCheckStatement(ConversionKernel kernel, Property property)
            => null;
    }
}