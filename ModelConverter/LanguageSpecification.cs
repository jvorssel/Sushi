using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Common.Utility.Enum;
using ModelConverter.Consistency;
using ModelConverter.Interfaces;
using ModelConverter.Models;

namespace ModelConverter
{
    /// <inheritdoc />
    public abstract class LanguageSpecification : ILanguageSpecification
    {
        private string _targetObject = @"window";

        /// <inheritdoc />
        public StatementPipeline StatementPipeline { get; protected set; }

        /// <inheritdoc />
        public string FilePath { get; } = string.Empty;

        /// <inheritdoc />
        public string Language { get; } = string.Empty;

        ///<inheritdoc />
        public Version Version { get; } = new Version();

        /// <inheritdoc />
        public bool IsIsolated { get; }

        /// <inheritdoc />
        public string TargetObject
        {
            get => _targetObject;
            set => _targetObject = FormatObjectPath(value);
        }

        /// <inheritdoc />
        public bool IsLoaded => Template != string.Empty;

        /// <inheritdoc />
        public string Template { get; private set; } = string.Empty;

        /// <inheritdoc />
        public abstract string FormatProperty(ConversionKernel kernel, Property property);

        /// <inheritdoc />
        public abstract Statement FormatComment(string comment, StatementType statementType);

        /// <inheritdoc />
        public abstract string RemoveComments(DataModel model);

        /// <inheritdoc />
        public abstract IEnumerable<Statement> FormatStatements(ConversionKernel kernel, List<Property> properties, List<DataModel> dataModels);

        /// <inheritdoc />
        public abstract Statement FormatInheritanceStatement(DataModel model, DataModel inherits);

        /// <inheritdoc />
        public abstract string GetDefaultForProperty(Property property);

        /// <inheritdoc />
        public abstract string FormatValueForProperty(Property property, object value);

        #region Initializers

        protected LanguageSpecification()
        {
        }

        protected LanguageSpecification(string scriptLanguage, Version version, bool isIsolated = false)
        {
            if (scriptLanguage == string.Empty)
                throw new ArgumentNullException(nameof(scriptLanguage));

            Language = scriptLanguage;
            Version = version ?? throw new ArgumentNullException(nameof(version));
            IsIsolated = isIsolated;
        }

        protected LanguageSpecification(string scriptLanguage, string version, bool isIsolated = false)
            : this(scriptLanguage, Version.Parse(version), isIsolated)
        {

        }

        protected LanguageSpecification(string path, string scriptLanguage, string version, bool isIsolated = false)
            : this(path, scriptLanguage, Version.Parse(version), isIsolated)
        {

        }

        protected LanguageSpecification(string path, string scriptLanguage, Version version, bool isIsolated = false)
            : this(scriptLanguage, version, isIsolated)
        {
            if (path == string.Empty)
                throw new ArgumentNullException(nameof(path));

            if (!Directory.Exists(path))
                throw Errors.NonExistentLanguageFile(path);

            FilePath = path.Replace('/', '\\');
        }

        #endregion Initializers

        /// <summary>
        ///     Makes sure the given <paramref name="input"/> does not end with a '.'.
        /// </summary>
        private static string FormatObjectPath(string input)
            => input.EndsWith(".") ? input.Substring(0, input.Length - 1) : input;

        /// <inheritdoc />
        public LanguageSpecification LoadFile()
        {
            Template = string.Empty;
            using (var reader = new StreamReader(FilePath))
            {
                Template = reader.ReadToEnd();
            }

            return this;
        }

        /// <inheritdoc />
        public async Task<LanguageSpecification> LoadFileAsync()
        {
            Template = string.Empty;
            using (var reader = new StreamReader(FilePath))
            {
                Template = await reader.ReadToEndAsync();
            }

            return this;
        }

        /// <inheritdoc />
        public LanguageSpecification UseTemplate(string template)
        {
            Template = template ?? throw new ArgumentNullException(nameof(template));
            return this;
        }

        #region Equality members

        /// <inheritdoc />
        public bool Equals(LanguageSpecification other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return string.Equals(FilePath, other.FilePath, StringComparison.InvariantCultureIgnoreCase) && string.Equals(Language, other.Language, StringComparison.InvariantCultureIgnoreCase) && Equals(Version, other.Version) && IsIsolated == other.IsIsolated;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((LanguageSpecification)obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (FilePath != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(FilePath) : 0);
                hashCode = (hashCode * 397) ^ (Language != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(Language) : 0);
                hashCode = (hashCode * 397) ^ (Version != null ? Version.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ IsIsolated.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(LanguageSpecification left, LanguageSpecification right)
            => Equals(left, right);

        public static bool operator !=(LanguageSpecification left, LanguageSpecification right)
            => !Equals(left, right);

        public static bool operator ==(ILanguageSpecification left, LanguageSpecification right)
            => Equals(left, right);

        public static bool operator !=(ILanguageSpecification left, LanguageSpecification right)
            => !Equals(left, right);

        public static bool operator ==(LanguageSpecification left, ILanguageSpecification right)
            => Equals(left, right);

        public static bool operator !=(LanguageSpecification left, ILanguageSpecification right)
            => !Equals(left, right);

        #endregion
    }
}