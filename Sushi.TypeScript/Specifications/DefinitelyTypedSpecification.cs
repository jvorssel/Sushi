using System;
using System.Collections.Generic;
using Sushi.Descriptors;

namespace Sushi.TypeScript.Specifications
{
    public class DefinitelyTypedSpecification : TypeScriptSpecificationBase
    {
        #region Overrides of LanguageSpecification

        /// <inheritdoc />
        public override string Extension { get; } = @".d.ts";

        /// <inheritdoc />
        public override IEnumerable<string> FormatProperty(ConversionKernel kernel, PropertyDescriptor property)
        {
            yield break;
        }

        /// <inheritdoc />
        public override IEnumerable<ScriptConditionDescriptor> FormatStatements(ConversionKernel kernel, List<PropertyDescriptor> properties)
        {
            yield break;
        }

        /// <inheritdoc />
        public override string GetDefaultForProperty(ConversionKernel kernel, PropertyDescriptor property)
            => string.Empty;

        /// <inheritdoc />
        public override string FormatValueForProperty(ConversionKernel kernel,PropertyDescriptor property, object value)
            => string.Empty;

        /// <inheritdoc />
        public override string RemoveComments(ClassDescriptor model)
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
