using System.IO;
using Sushi.Enum;

namespace Sushi.Tests
{
    public class TestBase
    {
        protected static readonly string FilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"Compiled\");

        /// <summary>
        ///     Compile a model for JavaScript.
        /// </summary>
        protected static void CompileJavaScript(SushiConverter converter, JavaScriptVersion version)
        {
            var jsConverter = converter.JavaScript(version);
            jsConverter.Convert();

            var fileName = $"models.{version}.js".ToLowerInvariant();
            jsConverter.WriteToFile(FilePath + fileName);
        }

        /// <summary>
        ///     Compile a model for TypeScript.
        /// </summary>
        protected static void CompileTypeScript(SushiConverter converter, TypeScriptVersion version)
        {
            var tsConverter = converter.TypeScript(version);
            tsConverter.Convert();
            
            const string fileName = "models.latest.ts";
            tsConverter.WriteToFile(FilePath + fileName);
        }

    }
}
