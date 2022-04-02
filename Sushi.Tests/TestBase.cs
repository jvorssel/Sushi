using System;
using System.IO;
using Sushi.Descriptors;
using Sushi.Extensions;
using Sushi.JavaScript;
using Sushi.JavaScript.Enum;
using Sushi.TypeScript;
using Sushi.TypeScript.Enum;

namespace Sushi.Tests
{
    public class TestBase
    {
        protected static readonly string FilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"Compiled\");

        /// <summary>
        ///     Compile a model for JavaScript.
        /// </summary>
        protected static void CompileJavaScript(Converter converter,
            JavaScriptVersion version,
            Func<ClassDescriptor, bool> predicate = null,
            string fileName = "ecmascript",
            bool minify = false,
            Wrap wrap = Wrap.None)
        {
            var javaScriptConverter = converter.CreateConverterForJavaScript(version, wrap);
            var converted = javaScriptConverter.Convert(predicate);

            fileName += $".{version.ToString().ToLowerInvariant()}";

            if (wrap != Wrap.None)
                fileName += "." + wrap;

            if (minify)
                fileName += ".min";

            javaScriptConverter.WriteToFile(converted, FilePath, fileName, minify);
        }

        /// <summary>
        ///     Compile a model for TypeScript.
        /// </summary>
        protected static void CompileTypeScript(Converter converter, string fileName = "typescript", Func<ClassDescriptor, bool> predicate = null, bool minify = false)
        {
            var javaScriptConverter = converter.CreateConverterForTypeScript(TypeScriptSpecification.TypeScript);
            var converted = javaScriptConverter.Convert(predicate);

            if (minify)
                fileName += ".min";

            javaScriptConverter.WriteToFile(converted, FilePath, fileName, minify);
        }

        /// <summary>
        ///     Compile a model for DefinitelyTyped.
        /// </summary>
        protected static void CompileDefinitelyTyped(Converter converter, string fileName = "reference", bool minify = false)
        {
            // Make sure the XML documentation is loaded
            var assemblyName = typeof(TestBase).Assembly.GetProjectName();
            converter.LoadXmlDocumentation();

            var javaScriptConverter = converter.CreateConverterForTypeScript(TypeScriptSpecification.Declaration);
            var converted = javaScriptConverter.Convert();

            if (minify)
                fileName += ".min";

            javaScriptConverter.WriteToFile(converted, FilePath, fileName, minify);
        }
    }
}
