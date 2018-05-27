using System;
using System.Collections.Generic;
using Sushi.Models;

namespace Sushi.TypeScript.Specifications
{
    public class DefinitelyTypedSpecification : TypeScriptSpecificationBase
    {
        #region Overrides of LanguageSpecification

        /// <inheritdoc />
        public override string Extension { get; } = @".d.ts";

        /// <inheritdoc />
        public override IEnumerable<string> FormatProperty(ConversionKernel kernel, Property property)
        {
            yield break;
        }

        /// <inheritdoc />
        public override IEnumerable<Statement> FormatStatements(ConversionKernel kernel, List<Property> properties)
        {
            yield break;
        }

        /// <inheritdoc />
        public override string GetDefaultForProperty(ConversionKernel kernel, Property property)
            => string.Empty;

        /// <inheritdoc />
        public override string FormatValueForProperty(ConversionKernel kernel,Property property, object value)
            => string.Empty;

        /// <inheritdoc />
        public override string RemoveComments(DataModel model)
            => model.Script;

        #endregion

        #region Initializers

        public DefinitelyTypedSpecification()
        : base("DefinitelyTyped", new Version(1, 0, 0))
        {
            StatementPipeline = StatementPipeline.Empty;
        }

        #endregion Initializers
    }
}
