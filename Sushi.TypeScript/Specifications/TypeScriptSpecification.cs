using System.Collections.Generic;
using Sushi.Descriptors;
using Sushi.Enum;
using Sushi.Interfaces;
using Sushi.JavaScript;

namespace Sushi.TypeScript.Specifications
{
    public class TypeScriptSpecification : TypeScriptSpecificationBase
    {
        #region Overrides of LanguageSpecification

        /// <inheritdoc />
        public override string Extension => @".ts";

        /// <inheritdoc />
        public override IEnumerable<ScriptConditionDescriptor> FormatStatements(Converter converter, List<IPropertyDescriptor> properties)
        {
            // Key check
            yield return FormatComment(@"Check property keys", ConditionType.Key);
            foreach (var prop in properties)
                yield return ConditionSpecification.CreateKeyExistsCheck(converter, prop);

            // Type check
            yield return new ScriptConditionDescriptor(string.Empty, ConditionType.Type, false, true);
            yield return FormatComment(@"Check property type match", ConditionType.Type);
            foreach (var prop in properties)
                yield return ConditionSpecification.CreateTypeCheck(converter, prop);

            // Instance check
            yield return new ScriptConditionDescriptor(string.Empty, ConditionType.Instance, false, true);
            yield return FormatComment(@"Check property class instance match", ConditionType.Instance);
            foreach (var prop in properties)
                yield return ConditionSpecification.CreateInstanceCheck(converter, prop);
        }

        #endregion

        /// <inheritdoc />
        public TypeScriptSpecification()
        {
            ConditionSpecification = new JavaScriptConditions();
        }
    }
}