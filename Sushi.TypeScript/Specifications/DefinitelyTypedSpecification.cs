﻿using System.Collections.Generic;
using Sushi.Descriptors;
using Sushi.Interfaces;

namespace Sushi.TypeScript.Specifications
{
    public class DefinitelyTypedSpecification : TypeScriptSpecificationBase
    {
        #region Overrides of LanguageSpecification

        /// <inheritdoc />
        public override string Extension => @".d.ts";

        /// <inheritdoc />
        public override IEnumerable<string> FormatProperty(ConversionKernel kernel, IPropertyDescriptor descriptor)
        {
            yield break;
        }

        /// <inheritdoc />
        public override IEnumerable<ScriptConditionDescriptor> FormatStatements(ConversionKernel kernel, List<IPropertyDescriptor> descriptor)
        {
            yield break;
        }

        /// <inheritdoc />
        public override string GetDefaultForProperty(ConversionKernel kernel, IPropertyDescriptor descriptor)
            => string.Empty;

        /// <inheritdoc />
        public override string RemoveComments(ClassDescriptor model)
            => model.Script;

        #endregion
    }
}
