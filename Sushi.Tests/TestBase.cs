using System;
using System.IO;
using Sushi.Extensions;
using Sushi.JavaScript;
using Sushi.JavaScript.Enum;
using Sushi.Models;
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
        protected static void CompileJavaScript(ConversionKernel kernel,
            JavaScriptVersion version,
            bool isolated,
            string fileName,
            Func<DataModel, bool> predicate)
        {
            var isolatedText = isolated ? "isolated" : string.Empty;
            var converter = kernel.CreateConverterForJavaScript(version, isolated);
            var converted = converter.Convert(predicate);

            var writer = new FileWriter(converter, FilePath, ".js");
            writer.FlushToFile(converted, $@"{fileName}.{version}.{isolatedText}");
        }

        /// <summary>
        ///     Compile a model for TypeScript.
        /// </summary>
        protected static void CompileTypeScript(ConversionKernel kernel, string fileName = "typescript", Func<DataModel, bool> predicate = null)
        {
            var converter = kernel.CreateConverterForTypeScript(TypeScriptSpecification.TypeScript);
            var converted = converter.Convert(predicate);

            var writer = new FileWriter(converter, FilePath, ".ts");
            writer.FlushToFile(converted, fileName);
        }

        /// <summary>
        ///     Compile a model for DefinitelyTyped.
        /// </summary>
        protected static void CompileDefinitelyTyped(ConversionKernel kernel, string fileName = "reference")
        {
            // Make sure the XML documentation is loaded
            var assemblyName = typeof(TestBase).Assembly.GetProjectName();
            var xmlDocPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{assemblyName}.xml");
            kernel.LoadXmlDocumentation(xmlDocPath);

            var converter = kernel.CreateConverterForTypeScript(TypeScriptSpecification.Declaration);
            var converted = converter.Convert();

            var writer = new FileWriter(converter, FilePath, ".d.ts");
            writer.FlushToFile(converted, fileName);
        }
    }
}
