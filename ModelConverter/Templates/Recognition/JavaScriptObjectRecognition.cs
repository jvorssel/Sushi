using System;
using System.Collections.Generic;
using System.Linq;
using Common.Utility;
using Common.Utility.Enum;
using Common.Utility.Enum.ECMAScript;
using ModelConverter.Models;
using ModelConverter.Templates.Languages;

namespace ModelConverter.Templates.Recognition
{
    public class JavaScriptObjectRecognition : RecognitionPipeline
    {
        #region Overrides of RecognitionPipeline

        /// <inheritdoc />
        public override IEnumerable<string> CreateStatements(LanguageSpecification language,
            ConversionKernel kernel,
            Property property,
            IEnumerable<DataModel> referenceDataModels)
        {
            var isDefinedStatement = $@"{kernel.ArgumentName}['{property.Name}'] !== void 0 && {kernel.ArgumentName}['{property.Name}'] !== null";

            yield return $"if (!{kernel.ArgumentName}.hasOwnProperty('{property.Name}'))" +
                $" throw new TypeError(\"{string.Format(kernel.ObjectPropertyMissing, property.Name)}\"); ";

            var typeCheck = $@"if ({isDefinedStatement} && typeof ({kernel.ArgumentName}['{{0}}']) !== '{{1}}')" +
                $" throw new TypeError(\"{kernel.PropertyTypeMismatch}\");";

            var instanceCheck = $@"if ({isDefinedStatement} && !({kernel.ArgumentName}['{{0}}'] instanceof {{1}}))" +
                $" throw new TypeError(\"{kernel.PropertyInstanceMismatch}\");";

            var models = referenceDataModels.ToList();
            var scriptType = property.NativeType.ToJavaScriptType();
            switch (scriptType)
            {
                case JavaScriptType.Undefined:
                case JavaScriptType.Null:
                    break;
                case JavaScriptType.Boolean:
                    yield return string.Format(typeCheck, property.Name, "boolean");
                    break;
                case JavaScriptType.Number:
                    yield return string.Format(typeCheck, property.Name, "number");
                    break;
                case JavaScriptType.String:
                    yield return string.Format(typeCheck, property.Name, "string");
                    break;
                case JavaScriptType.Date:
                    yield return string.Format(instanceCheck, property.Name, "Date");
                    break;
                case JavaScriptType.RegExp:
                    yield return string.Format(instanceCheck, property.Name, "Regexp");
                    break;
                case JavaScriptType.Array:
                    yield return string.Format(instanceCheck, property.Name, "Array");
                    break;
                case JavaScriptType.Object:
                    yield return string.Format(typeCheck, property.Name, "object");

                    var propertyWithName = models.FirstOrDefault(x => x.FullName == property.Type.FullName);
                    if (propertyWithName != null)
                        yield return string.Format(instanceCheck, property.Name, propertyWithName.Name);

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion
    }
}