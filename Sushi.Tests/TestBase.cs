using System;
using System.IO;
using Sushi.JavaScript;
using Sushi.JavaScript.Enum;
using Sushi.Models;

namespace Sushi.Tests
{
    public class TestBase
    {
        protected static readonly string FilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"Compiled\");

        protected static void Compile(ConversionKernel kernel,
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
    }
}
