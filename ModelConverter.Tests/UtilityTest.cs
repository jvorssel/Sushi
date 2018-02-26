using System;
using System.Text;
using Common.Utility.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ModelConverter.Tests {
    [TestClass]
    public class UtilityTest
    {
        [TestMethod]
        public void TestStringEnumerator()
        {
            var expected = @"1 2 3";

            var builder = new StringBuilder();
            var enumerator = new StringEnumerator(expected, ' ');
            while (enumerator.MoveNext())
            {
                builder.Append(enumerator.Current);
            }

            Console.WriteLine(builder.ToString());
            Assert.AreEqual(expected, builder.ToString());
        }
    }
}