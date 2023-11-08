using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.Helpers;

namespace Sushi.Tests.Extensions;

public abstract class ExtensionsTests
{
    [TestClass]
    public class GlueMethod : ExtensionsTests
    {
        [TestMethod]
        public void Glue_Empty_ShouldGlueCorrectly()
        {
            // Arrange
            var values = Array.Empty<string>();

            // Act
            var result = values.Glue(".");

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void Glue_Sentence_ShouldGlueCorrectly()
        {
            // Arrange
            var values = new[] { "this", "is", "awesome" };

            // Act
            var result = values.Glue(" ");

            // Assert
            Assert.AreEqual("this is awesome", result);
        }

        [TestMethod]
        public void Glue_Mirrorable_ShouldGlueCorrectly()
        {
            // Arrange
            var values = new[] { "1", "0", "1" };

            // Act
            var result = values.Glue(".");

            // Assert
            Assert.AreEqual("1.0.1", result);
        }
    }
}