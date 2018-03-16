using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelConverter.DefinitelyTyped;

namespace ModelConverter.Tests
{
    [TestClass]
    public class DefinitelyTypedTests
    {
        public TestContext Context { get; set; }

        [TestMethod]
        public void CompileFileTest()
        {
            using (var kernel = new ConversionKernel(typeof(DefinitelyTypedTests).Assembly))
            {
                var converter = kernel.CreateConverterForDefinitelyTyped();
                var converted = converter.Convert();
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Result\Compiled\");

                var writer = new FileWriter(converter, path,".d.ts");
                writer.FlushToFile(converted, @"reference");
            }
        }
    }
}