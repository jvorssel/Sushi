﻿using System;
using Sushi.Descriptors;

namespace Sushi.Consistency
{
    /// <summary>
    ///     Container class to keep the error messages in one place.
    /// </summary>
    public static class Errors
    {
        private const string XML_DOC_INSTRUCTIONS = "\n\rMake sure you're using the XML file generated by Visual Studio.\n\rYou can generate the in the project properties > build > XML Documentation File (checked).";

        public static ArgumentException XmlDocumentExpected(string path)
            => new($"Expected the path '{path}' to lead to a XML file.{XML_DOC_INSTRUCTIONS}");

        public static InvalidOperationException NonExistentFile(string path)
            => new($"Could not read the file for the given path '{path}'.\n\rIs the file in use or is the path incorrect?");

        public static InvalidOperationException IncompatibleXmlDocument(object missingNode)
            => new($"Expected the node '{missingNode}' to exist in the loaded XML file.{XML_DOC_INSTRUCTIONS}");

        public static ArgumentNullException NoScriptAvailableInModels(string paramName)
            => new(paramName, $@"No members found with its '{nameof(ClassDescriptor.Script)}' set, call Convert first.");
    }
}