using System;
using System.IO;
using System.Threading.Tasks;
using Common.Utility.Enum;
using ModelConverter.Interfaces;

namespace ModelConverter.Languages
{
    /// <inheritdoc />
    public class LanguageSpecification : ILanguageSpecification
    {
        private string _targetObject = @"window";
        private string _template = string.Empty;

        public const string PROPERTY_KEY = @"$$PROPERTY$$";

        /// <inheritdoc />
        public string FilePath { get; set; } = string.Empty;

        /// <inheritdoc />
        public string Language { get; set; } = string.Empty;

        ///<inheritdoc />
        public Version Version { get; set; } = new Version();

        /// <inheritdoc />
        public bool IsIsolated { get; set; } = false;

        /// <inheritdoc />
        public string TargetObject
        {
            get => _targetObject;
            set => _targetObject = FormatObjectPath(value);
        }

        #region Initializers

        public LanguageSpecification()
        {

        }

        public LanguageSpecification(string scriptLanguage, Version version, bool isIsolated = false)
        {
            if (scriptLanguage == string.Empty)
                throw new ArgumentNullException(nameof(scriptLanguage));

            Language = scriptLanguage;
            Version = version ?? throw new ArgumentNullException(nameof(version));
            IsIsolated = isIsolated;
        }

        public LanguageSpecification(string scriptLanguage, string version, bool isIsolated = false)
            : this(scriptLanguage, Version.Parse(version), isIsolated)
        {

        }

        public LanguageSpecification(string path, string scriptLanguage, string version, bool isIsolated = false)
            : this(path, scriptLanguage, Version.Parse(version), isIsolated)
        {

        }

        public LanguageSpecification(string path, string scriptLanguage, Version version, bool isIsolated = false)
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
        public virtual string FormatProperty(CSharpNativeType type, string name)
        {
            return string.Empty;
        }

        /// <inheritdoc />
        public virtual string FormatRecognition(CSharpNativeType type, string name, string body)
        {
            return string.Empty;
        }

        /// <inheritdoc />
        public bool IsLoaded => _template != string.Empty;

        /// <inheritdoc />
        public LanguageSpecification LoadFile()
        {
            _template = string.Empty;
            using (var reader = new StreamReader(FilePath))
            {
                _template = reader.ReadToEnd();
            }

            return this;
        }

        /// <inheritdoc />
        public async Task<LanguageSpecification> LoadFileAsync()
        {
            _template = string.Empty;
            using (var reader = new StreamReader(FilePath))
            {
                _template = await reader.ReadToEndAsync();
            }

            return this;
        }

        /// <inheritdoc />
        public LanguageSpecification UseTemplate(string template)
        {
            _template = template ?? throw new ArgumentNullException(nameof(template));
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