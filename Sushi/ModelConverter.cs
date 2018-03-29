﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Sushi.Consistency;
using Sushi.Extensions;
using Sushi.Helpers;
using Sushi.Interfaces;
using Sushi.Models;
using static Sushi.Consistency.TemplateKeys;

namespace Sushi
{
    public class ModelConverter
    {
        private readonly ConversionKernel _kernel;
        public ILanguageSpecification Language { get; }

        /// <summary>
        ///     The amount of <see cref="Models"/> found in the given <see cref="Assembly"/>.
        /// </summary>
        public ModelConverter(ConversionKernel kernel, ILanguageSpecification language)
        {
            Language = language;
            _kernel = kernel;
        }

        /// <summary>
        ///     Convert the available models in the <see cref="ConversionKernel"/> that match the given <paramref name="predicate"/>.
        /// </summary>
        public IEnumerable<DataModel> Convert(Func<DataModel, bool> predicate = null)
        {
            var enumerable = (predicate == null ? _kernel.Models : _kernel.Models.Where(predicate)).ToList();

            foreach (var model in enumerable)
            {
                var scriptModel = Compile(model, enumerable);

                yield return scriptModel;
            }
        }

        /// <summary>
        ///     Join one or more given <paramref name="models"/> and maybe <paramref name="minify"/>
        ///     them to create one <see cref="string"/>.
        /// </summary>
        public string MergeModelsToString(IEnumerable<DataModel> models, bool minify = false)
        {
            var builder = new StringBuilder();
            foreach (var model in models)
            {
                builder.AppendLine(minify ? Minify(model) : model.Script);
            }

            return builder.ToString();
        }

        /// <summary>
        ///     Remove leading whitespaces, newlines and tabs and comments.
        /// </summary>
        public string Minify(DataModel model)
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
        /// <param name="model">The <see cref="DataModel"/> to convert to the given <see cref="Language"/>.</param>
        /// <param name="referenceDataModels">Check type reference for found <see cref="DataModel"/>(s).</param>
        public DataModel Compile(DataModel model, List<DataModel> referenceDataModels)
        {
            var modelBuilder = new StringBuilder();
            var doc = _kernel.Documentation?.Members.SingleOrDefault(x => x.Namespace == model.Type.FullName);

            var template = Language.Template
                .Replace(TYPE_NAME_KEY, model.Name)
                .Replace(TYPE_NAMESPACE_KEY, model.Type.Namespace)
                .Replace(ARGUMENT_NAME, _kernel.ArgumentName)
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
                        foreach (var line in Language.FormatProperty(_kernel, property))
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
                        foreach (var line in Language.FormatPropertyDefinition(_kernel, property, referenceDataModels))
                            propertyDefinitionBuilder.AppendLine(indent + line);
                    }

                    modelBuilder.Append(propertyDefinitionBuilder);
                }
                // Check
                else if (row.Contains(VALIDATION_KEY))
                {
                    var indent = row.Before(VALIDATION_KEY);
                    var statementBuilder = new StringBuilder();
                    var statements = Language.FormatStatements(_kernel, model.Properties.ToList(), referenceDataModels).GroupBy(x => x.Type);

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
                    var statement = Language.StatementPipeline.ArgumentDefinedStatement(_kernel);
                    var rowWithStatement = row.Replace(IS_DEFINED_CHECK, statement.ToString());
                    modelBuilder.Append(rowWithStatement);
                }
                // Undefined check
                else if (row.Contains(IS_UNDEFINED_CHECK))
                {
                    var statement = Language.StatementPipeline.ArgumentUndefinedStatement(_kernel);
                    var rowWithStatement = row.Replace(IS_UNDEFINED_CHECK, statement.ToString());
                    modelBuilder.Append(rowWithStatement);
                }
                // Base type check
                else if (row.Contains(INHERIT_TYPE))
                {
                    var inherits = referenceDataModels.SingleOrDefault(x => x == model.BaseType);
                    if (ReferenceEquals(inherits, null))
                    {
                        modelBuilder.Append(row.Replace(INHERIT_TYPE, string.Empty)); // No inheritance member available, add row.
                        continue;
                    }

                    var statement = Language.FormatInheritanceStatement(model, inherits);
                    modelBuilder.Append(row.Replace(INHERIT_TYPE, statement.ToString()));
                }
                // JsDoc
                else if (row.Contains(SUMMARY_KEY))
                {
                    var summary = doc?.Summary ?? string.Empty;
                    if (!summary.IsEmpty())
                        modelBuilder.Append(enumerator.Current.Replace(SUMMARY_KEY, summary));
                }
                // Comments & Empty lines
                else if (row.StartsWith("// ReSharper")) // Remove resharper comments.
                    continue;
                else
                    modelBuilder.Append(enumerator.Current);
            }

            // Set the model name in the template.
            var result = modelBuilder.ToString();
            model.Script = result;

            return model;
        }

        /// <summary>
        ///     Write the given <see cref="DataModel"/> <paramref name="models"/> to the 
        ///     <paramref name="fileName"/> in the given folder <paramref name="path"/>.
        /// </summary>
        /// <param name="models">The <see cref="DataModel"/> <see cref="IEnumerable{T}"/> with the models to write.</param>
        /// <param name="path">The <paramref name="path"/> to the folder to store the file in.</param>
        /// <param name="fileName">The <paramref name="fileName"/> for the generated file.</param>
        /// <param name="minify">If the comments, newline, tabs, etc should be removed from the file contents.</param>
        /// <param name="encoding">What <see cref="Encoding"/> method should be used to create the file.</param>
        public void FlushToFile(IEnumerable<DataModel> models, string path, string fileName, bool minify = false, Encoding encoding = null)
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

        /// <summary>
        ///     Write the given <see cref="DataModel"/> <paramref name="models"/> to the 
        ///     <paramref name="fileName"/> in the given folder <paramref name="path"/> asynchronously.
        /// </summary>
        /// <param name="models">The <see cref="DataModel"/> <see cref="IEnumerable{T}"/> with the models to write.</param>
        /// <param name="path">The <paramref name="path"/> to the folder to store the file in.</param>
        /// <param name="fileName">The <paramref name="fileName"/> for the generated file.</param>
        /// <param name="minify">If the comments, newline, tabs, etc should be removed from the file contents.</param>
        /// <param name="encoding">What <see cref="Encoding"/> method should be used to create the file.</param>
        public async Task FlushToFileAsync(IEnumerable<DataModel> models, string path, string fileName, bool minify = false, Encoding encoding = null)
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
            await writer.FlushToFileAsync(models, fileName);
        }

    }
}