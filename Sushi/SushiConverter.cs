// /***************************************************************************\
// Module Name:       SushiConverter.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 15-05-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System.Reflection;
using Sushi.Descriptors;
using Sushi.Documentation;
using Sushi.Extensions;
using Sushi.Helpers;
using Sushi.Interfaces;

#endregion

namespace Sushi
{
	/// <summary>
	///     Root <see cref="SushiConverter" /> for converting given <see cref="Models" /> to one of the specified
	///     <see cref="Languages" />.
	/// </summary>
	public sealed class SushiConverter
	{
		public HashSet<ClassDescriptor> Models { get; }
		public HashSet<EnumDescriptor> EnumModels { get; }

		public XmlDocumentationReader? Documentation { get; set; }

		/// <summary>
		///     Initialize a new <see cref="SushiConverter" /> with given <paramref name="types" /> to convert.
		/// </summary>
		public SushiConverter(ICollection<Type> types)
		{
			if (types == null)
				throw new ArgumentNullException(nameof(types));

			var descriptors = types
				.Select(x => new ClassDescriptor(x))
				.FilterClassDescriptors()
				.ToHashSet();

			Models = descriptors;

			EnumModels = types
				.Where(x => x.IsEnum)
				.Select(x => new EnumDescriptor(x))
				.ToHashSet();
		}

		/// <summary>
		///     Initialize a new <see cref="SushiConverter" /> for the given <paramref name="types" />.
		/// </summary>
		/// <param name="types"></param>
		public SushiConverter(params Type[] types) : this(types.ToList()) { }

		/// <summary>
		///     Initialize a new <see cref="SushiConverter" /> and find the classes that
		///     inherit <see cref="IScriptModel" /> in the given <paramref name="assembly" />.
		/// </summary>
		public SushiConverter(Assembly assembly) : this(assembly.ExportedTypes.ToList()) { }

		/// <summary>
		///		Use the msbuild xml file to provide documentation.
		/// </summary>
		public SushiConverter UseDocumentation(string msBuildXmlFilePath)
		{
			if (msBuildXmlFilePath.IsEmpty())
				throw new ArgumentNullException(nameof(msBuildXmlFilePath));

			var extension = Path.GetExtension(msBuildXmlFilePath);
			if (extension != ".xml")
				throw new ArgumentException($"Expected the path '{msBuildXmlFilePath}' to lead to a XML file.");

			if (!File.Exists(msBuildXmlFilePath))
				throw new ArgumentException("XML documentation file not found.", nameof(msBuildXmlFilePath));

			Documentation = new XmlDocumentationReader(msBuildXmlFilePath);
			return this;
		}
	}
}