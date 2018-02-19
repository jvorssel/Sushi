using System;
using Common.Utility.Enum.ECMAScript;

namespace ModelConverter
{
    /// <summary>
    ///     Manages the expected file code-templates.
    /// </summary>
    internal class TemplateManager
    {
        private const string TYPENAME_KEY = @"$$TYPENAME$$";
        private const string VALIDATION_KEY = @"$$VALIDATE_OBJECT$$";
        private const string VALUES_KEY = @"$$SET_VALUES$$";

        private string _template = string.Empty;

        internal bool InIsolateScope { get; set; }
        internal EcmaVersion EcmaVersion { get; set; }

        internal static TemplateManager ForEcmaScript(EcmaVersion version, bool useIsolateScope)
        {
            var manager = new TemplateManager
            {
                InIsolateScope = useIsolateScope,
                EcmaVersion = version
            };

            // TODO Load file into memory.

            return manager;
        }

        internal static TemplateManager ForTypeScript(string version)
        {
            throw new NotImplementedException();
        }
    }
}