using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelConverter.JavaScript;
using ModelConverter.JavaScript.Enum;
using ModelConverter.Models;

namespace ModelConverter.Tests
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
