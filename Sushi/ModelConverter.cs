using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Sushi.Consistency;
using Sushi.Descriptors;
using Sushi.Enum;
using Sushi.Extensions;
using Sushi.Helpers;
using Sushi.Interfaces;
using static Sushi.Consistency.TemplateKeys;

namespace Sushi
{
    public class ModelConverter
    {
        private readonly Converter _converter;
        public ILanguageSpecification Language { get; }

        /// <summary>
        ///     The amount of <see cref="Models"/> found in the given <see cref="Assembly"/>.
        /// </summary>
        public ModelConverter(Converter converter, ILanguageSpecification language)
        {
            Language = language;
            _converter = converter;
        }

        /// <summary>
        ///     Convert the available models in the <see cref="Converter"/> that match the given <paramref name="predicate"/>.
        /// </summary>
        public IEnumerable<ClassDescriptor> Convert(Func<ClassDescriptor, bool> predicate = null)
        {
            var enumerable = (predicate == null ? _converter.Models : _converter.Models.Where(predicate)).ToList();

            foreach (var scriptModel in enumerable.Select(Compile))
            {
                yield return scriptModel;
            }
        }

        /// <summary>
        ///     Join one or more given <paramref name="models"/> and maybe <paramref name="minify"/>
        ///     them to create one <see cref="string"/>.
        /// </summary>
        public string MergeModelsToString(IEnumerable<ClassDescriptor> models, bool minify = false)
        {
            var builder = new StringBuilder();
            foreach (var model in models)
            {
                var script = minify ? Minify(model) : model.Script;
                switch (Language.WrapUsage)
                {
                    case WrapTemplateUsage.Global:
                    case WrapTemplateUsage.None:
                        builder.AppendLine(script);
                        break;
                    case WrapTemplateUsage.Each:
                        if (Language.WrapTemplate.IsEmpty())
                            throw Errors.NoWrapTemplateAvailable();

                        script = Language.WrapTemplate
                            .Replace(SCRIPT_MODELS, script)
                            .Replace(TYPE_NAME_KEY, model.Name)
                            .Replace(TYPE_NAMESPACE_KEY, model.FullName);

                        builder.AppendLine(script);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            }

            var result = builder.ToString();

            if (Language.WrapUsage == WrapTemplateUsage.Global)
            {
                var indent = Language.WrapTemplate.GetIndentInRowWith(SCRIPT_MODELS);
                result = result.IndentEachRow(indent);
                result = Language.WrapTemplate.Replace(SCRIPT_MODELS, result);
            }

            return result;
        }

        /// <summary>
        ///     Remove leading whitespaces, newlines and tabs and comments.
        /// </summary>
        public string Minify(ClassDescriptor model)
        {
            // Run regex to replace comments if defined.
            var result = Language.RemoveComments(model);

            // Replace tabs and return-newline characters with whitespaces.
            result = result
                .Replace("\t", string.Empty)
                .Replace("\r", string.Empty)
                .Replace("\n", string.Empty)
                .RemoveLeadingWhitespaces();

            return result;
        }

        /// <summary>
        ///     Compile the given <paramref name="model"/> with the current <see cref="LanguageSpecification"/>.
        /// </summary>
        /// <param name="model">The <see cref="ClassDescriptor"/> to convert to the given <see cref="Language"/>.</param>
        /// <param name="referenceDataModels">Check type reference for found <see cref="ClassDescriptor"/>(s).</param>
        public ClassDescriptor Compile(ClassDescriptor model)
        {
            var modelBuilder = new StringBuilder();
            var doc = _converter.Documentation?.GetDocumentationForType(model.Type);

            var template = Language.Template
                .Replace(TYPE_NAME_KEY, model.Name)
                .Replace(TYPE_NAMESPACE_KEY, model.Type.Namespace)
                .Replace(ARGUMENT_NAME, _converter.ArgumentName)
                ;

            var enumerator = new StringEnumerator(template);
            while (enumerator.MoveNext())
            {
                var row = enumerator.Current;
                if (row == null)
                    continue;

                // Recognition
                if (row.Contains(CTOR_PROPERTIES_KEY))
                {
                    // Set the values for each property in the ctor
                    var indent = row.Before(CTOR_PROPERTIES_KEY);
                    var propertyValueBuilder = new StringBuilder();
                    foreach (var property in model.Properties)
                    {
                        foreach (var line in Language.FormatProperty(_converter, property))
                            propertyValueBuilder.AppendLine(indent + line);
                    }

                    modelBuilder.Append(propertyValueBuilder);
                }
                // Define
                else if (row.Contains(CLASS_PROPERTIES_KEY))
                {
                    var indent = row.Before(CLASS_PROPERTIES_KEY);
                    var propertyDefinitionBuilder = new StringBuilder();
                    foreach (var property in model.Properties)
                    {
                        foreach (var line in Language.FormatPropertyDefinition(_converter, property))
                            propertyDefinitionBuilder.AppendLine(indent + line);
                    }

                    modelBuilder.Append(propertyDefinitionBuilder);
                }
                // Check
                else if (row.Contains(VALIDATION_KEY))
                {
                    var indent = row.Before(VALIDATION_KEY);
                    var statementBuilder = new StringBuilder();
                    var statements = Language.FormatStatements(_converter, model.Properties.ToList()).GroupBy(x => x.Type);

                    foreach (var group in statements)
                    {
                        if (group.All(x => x.IsEmpty || x.IsComment || x.IsEmptyLine))
                            continue; // No actual statement, continue.

                        foreach (var statement in group.Where(x => !x.IsEmpty))
                            foreach (var line in statement.Lines)
                                statementBuilder.AppendLine(indent + line);
                    }

                    modelBuilder.Append(statementBuilder);
                }
                // Defined check
                else if (row.Contains(IS_DEFINED_CHECK))
                {
                    var statement = Language.ConditionPipeline.ArgumentDefinedCheck(_converter);
                    var rowWithStatement = row.Replace(IS_DEFINED_CHECK, statement.ToString());
                    modelBuilder.Append(rowWithStatement);
                }
                // Undefined check
                else if (row.Contains(IS_UNDEFINED_CHECK))
                {
                    var statement = Language.ConditionPipeline.ArgumentUndefinedCheck(_converter);
                    var rowWithStatement = row.Replace(IS_UNDEFINED_CHECK, statement.ToString());
                    modelBuilder.Append(rowWithStatement);
                }
                // JsDoc
                else if (row.Contains(SUMMARY_KEY))
                {
                    var summary = doc?.Summary ?? string.Empty;
                    if (!summary.IsEmpty())
                        modelBuilder.Append(enumerator.Current.Replace(SUMMARY_KEY, summary));
                }
                // Comments & Empty lines
                else if (!row.StartsWith("// ReSharper")) // Remove resharper comments.
                    modelBuilder.Append(enumerator.Current);
            }

            // Set the model name in the template.
            var result = modelBuilder.ToString();
            model.Script = result;

            return model;
        }

        /// <summary>
        ///     Write the given <see cref="ClassDescriptor"/> <paramref name="models"/> to the 
        ///     <paramref name="fileName"/> in the given folder <paramref name="path"/>.
        /// </summary>
        /// <param name="models">The <see cref="ClassDescriptor"/> <see cref="IEnumerable{T}"/> with the models to write.</param>
        /// <param name="path">The <paramref name="path"/> to the folder to store the file in.</param>
        /// <param name="fileName">The <paramref name="fileName"/> for the generated file.</param>
        /// <param name="minify">If the comments, newline, tabs, etc should be removed from the file contents.</param>
        /// <param name="encoding">What <see cref="Encoding"/> method should be used to create the file.</param>
        public void WriteToFile(IEnumerable<ClassDescriptor> models, string path, string fileName, bool minify = false, Encoding encoding = null)
        {
            if (path.IsEmpty())
                throw new ArgumentNullException(nameof(path));

            if (fileName.IsEmpty())
                throw new ArgumentNullException(nameof(fileName));

            if (models.EmptyIfNull().All(x => x.Script?.IsEmpty() ?? true))
                throw Errors.NoScriptAvailableInModels(nameof(models));

            if (encoding == null)
                encoding = Encoding.Default;

            var writer = new FileWriter(this, path, Language.Extension, minify, encoding);
            writer.FlushToFile(models, fileName);
        }
    }
}