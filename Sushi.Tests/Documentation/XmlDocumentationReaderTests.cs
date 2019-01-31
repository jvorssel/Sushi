using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.Documentation;
using Sushi.TestModels;

namespace Sushi.Tests.Documentation
{
    [TestClass]
    public class XmlDocumentationReaderTests
    {
        public string BaseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;

        public string FilePath { get; set; }

        public Assembly Assembly { get; set; }

        public XmlDocumentationReader Reader { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            Assembly = typeof(SchoolViewModel).Assembly;
            FilePath = Path.Combine(BaseDirectoryPath, $"{Assembly.FullName.Split(',')[0]}.xml");
            Reader = new XmlDocumentationReader(FilePath);
        }

        [TestMethod]
        public void InitializeTest()
        {
            // ACT
            Reader.Initialize();

            // ASSERT
            Assert.IsTrue(Reader.Members.Count > 0);
            Assert.IsTrue(Reader.Members.Any(x => x.IsInherited));
            Assert.IsTrue(Reader.Members.Where(x => x.FieldType == ReferenceType.Property).All(x => x.DeclaringTypeName.Length > 0), "Expected each field to have a declaring type name.");
            Assert.IsTrue(Reader.Initialized);
        }

        [TestMethod]
        public void ClearTest()
        {
            // ARRANGE
            Reader.Initialize();

            // ACT
            Reader.Clear();

            // ASSERT
            Assert.IsFalse(Reader.Initialized);
            Assert.AreEqual(0, Reader.Members.Count);
        }

        [TestMethod]
        public void GetDocumentationForTypeTest()
        {
            // ARRANGE
            var type = typeof(SchoolViewModel);

            // ACT
            var doc = Reader.GetDocumentationForType(type);

            // ASSERT
            Assert.IsNotNull(doc);
            Assert.AreEqual(ReferenceType.Type, doc.FieldType);
            Assert.AreEqual(nameof(SchoolViewModel), doc.Name);
            Assert.IsTrue(doc.Summary.Length > 0);
        }

        [TestMethod]
        public void GetDocumentationForProperty()
        {
            // ARRANGE
            var instance = new SchoolViewModel();

            // ACT
            var doc = Reader.GetDocumentationForProperty(instance, x => x.Name);

            // ASSERT
            Assert.IsNotNull(doc);
            Assert.AreEqual("Name", doc.Name);
            Assert.IsTrue(doc.Summary.Length > 0);
        }
    }
}
