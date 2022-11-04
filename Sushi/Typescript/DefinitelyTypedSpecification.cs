using System.Collections.Generic;
using Sushi.Interfaces;
using Sushi.Javascript;

namespace Sushi.Typescript
{
    public sealed class DefinitelyTypedSpecification : JavaScriptSpecification
    {
        #region Overrides of LanguageSpecification

        /// <inheritdoc />
        public override string Extension => @".d.ts";

        /// <inheritdoc />
        public override IEnumerable<string> FormatProperty(SushiConverter converter, IPropertyDescriptor descriptor)
        {
            yield break;
        }


        /// <inheritdoc />
        public override string GetDefaultForProperty(SushiConverter converter, IPropertyDescriptor descriptor)
            => string.Empty;


        #endregion
    }
}
