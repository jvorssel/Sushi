// /***************************************************************************\
// Module Name:       SushiConverter.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 04-11-2022
// Copyright:              Royaldesk @ 2022
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Sushi.Consistency;
using Sushi.Descriptors;
using Sushi.Documentation;
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

		public XmlDocumentationReader Documentation { get; set; }

		/// <summary>
		///     Initialize a new <see cref="SushiConverter" /> with given <paramref name="types" /> for <see cref="Models" />.
		/// </summary>
		public SushiConverter(ICollection<Type> types)
		{
			var treeBuilder = new DescriptorTreeBuilder(types);
			Models = treeBuilder.BuildTree().ToHashSet();
			
			EnumModels = types
				.Where(x => x.IsEnum)
				.Select(x => new EnumDescriptor(x))
				.ToHashSet();
		}

		/// <summary>
		///     Initialize a new <see cref="SushiConverter" /> with models that
		///     inherit <see cref="IScriptModel" /> in the given <paramref name="assembly" />.
		/// </summary>
		public SushiConverter(Assembly assembly) : this(assembly.ExportedTypes.ToList()) { }

		/// <summary>
		///     Use the xml documentation generated on build.
		/// </summary>
		public SushiConverter LoadXmlDocumentation(string path)
		{
			var extension = Path.GetExtension(path);
			if (extension != ".xml")
				throw Errors.XmlDocumentExpected(path);

			Documentation = new XmlDocumentationReader(path).Initialize();

			return this;
		}
	}
}