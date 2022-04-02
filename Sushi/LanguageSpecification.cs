﻿using System;
using System.Collections.Generic;
using System.Linq;
using Sushi.Consistency;
using Sushi.Descriptors;
using Sushi.Enum;
using Sushi.Extensions;
using Sushi.Helpers;
using Sushi.Interfaces;

namespace Sushi
{
    /// <inheritdoc />
    public abstract class LanguageSpecification : ILanguageSpecification
    {
        /// <inheritdoc />
        public ConditionPipeline ConditionPipeline { get; protected set; }

        /// <inheritdoc />
        public abstract string Extension { get; }

        /// <inheritdoc />
        public string Template { get; private set; } = string.Empty;

        /// <inheritdoc />
        public string WrapTemplate { get; private set; } = string.Empty;

        /// <inheritdoc />
        public WrapTemplateUsage WrapUsage { get; private set; } = WrapTemplateUsage.None;

        /// <inheritdoc />
        public abstract IEnumerable<string> FormatProperty(Converter converter, IPropertyDescriptor descriptor);

        /// <inheritdoc />
        public abstract IEnumerable<string> FormatPropertyDefinition(Converter converter, IPropertyDescriptor descriptor);

        /// <inheritdoc />
        public abstract ScriptConditionDescriptor FormatComment(string comment, ConditionType statementType);

        /// <inheritdoc />
        public abstract string RemoveComments(ClassDescriptor model);

        /// <inheritdoc />
        public abstract IEnumerable<ScriptConditionDescriptor> FormatStatements(Converter converter, List<IPropertyDescriptor> descriptors);

        /// <inheritdoc />
        public abstract string GetDefaultForProperty(Converter converter, IPropertyDescriptor descriptor);

        /// <inheritdoc />
        public LanguageSpecification UseTemplate(string template)
        {
            if (template.IsEmpty())
                throw new ArgumentNullException(nameof(template));

            if (TemplateConsistency.TestTemplate(template).Count() == TemplateConsistency.Keys.Count())
                throw Errors.NoPlaceholdersInTemplate();

            Template = template;
            return this;
        }


        /// <inheritdoc />
        public LanguageSpecification UseWrapTemplate(string template, WrapTemplateUsage usage)
        {
            if (template.IsEmpty())
                throw new ArgumentNullException(nameof(template));

            if (!TemplateConsistency.TestWrapTemplate(template))
                throw Errors.NoPlaceholdersInTemplate();

            WrapTemplate = template;
            WrapUsage = usage;
            return this;
        }
    }
}