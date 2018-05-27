using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Sushi.Enum;
using Sushi.Models;
using Sushi.Extensions;
using Sushi.JavaScript;

namespace Sushi.TypeScript.Specifications
{
    public class TypeScriptSpecification : TypeScriptSpecificationBase
    {
        #region Overrides of LanguageSpecification

        /// <inheritdoc />
        public override string Extension { get; } = @".ts";

        /// <inheritdoc />
        public override IEnumerable<Statement> FormatStatements(ConversionKernel kernel, List<Property> properties)
        {
            // Key check
            yield return FormatComment(@"Check property keys", StatementType.Key);
            foreach (var prop in properties)
                yield return StatementPipeline.CreateKeyCheckStatement(kernel, prop);

            // Type check
            yield return new Statement(string.Empty, StatementType.Type, false, true);
            yield return FormatComment(@"Check property type match", StatementType.Type);
            foreach (var prop in properties)
                yield return StatementPipeline.CreateTypeCheckStatement(kernel, prop);

            // Instance check
            yield return new Statement(string.Empty, StatementType.Instance, false, true);
            yield return FormatComment(@"Check property class instance match", StatementType.Instance);
            foreach (var prop in properties)
                yield return StatementPipeline.CreateInstanceCheckStatement(kernel, prop);
        }

        #endregion

        #region Initializers

        public TypeScriptSpecification(Version version)
            : base("TypeScript", version)
        {
            StatementPipeline = new JavaScriptStatements();
        }

        #endregion Initializers
    }
}