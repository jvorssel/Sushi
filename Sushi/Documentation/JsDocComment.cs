// /***************************************************************************\
// Module Name:       JsDocComment.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 16-05-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System.Text;
using Sushi.Descriptors;
using Sushi.Interfaces;

#endregion

namespace Sushi.Documentation
{
	public static class JsDocComment
	{
		public static string JsDocPropertySummary(this XmlDocumentationReader doc, IPropertyDescriptor descriptor)
		{
			if (doc == null)
				return string.Empty;
			// Return the rows for the js-doc
			var summary = doc.GetDocumentationForProperty(descriptor);
			return summary?.Summary.Length > 0 ? $"/** {summary.Summary} */" : string.Empty;
		}

		public static string JsDocClassSummary(this XmlDocumentationReader doc, ClassDescriptor descriptor)
		{
			var builder = new StringBuilder();
			// Return the rows for the js-doc

			builder.AppendLine("/**");

			if (doc != null)
			{
				var typeDoc = doc.GetDocumentationForType(descriptor.Type);
				builder.AppendLine($" * {typeDoc?.Summary ?? descriptor.FullName}");
			}
			else
				builder.AppendLine($" * {descriptor.FullName}");

			if (descriptor.Parent != null)
				builder.AppendLine($" * @extends {descriptor.Parent.Name}");

			builder.Append(" */");
			return builder.ToString();
		}
	}
}