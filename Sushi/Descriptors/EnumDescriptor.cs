// /***************************************************************************\
// Module Name:       EnumDescriptor.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 04-11-2022
// Copyright:              Royaldesk @ 2022
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

#endregion

namespace Sushi.Descriptors
{
	public sealed class EnumDescriptor
	{
		public Type Type { get; }
		public string Name => Type.Name;
		public string Script { get; set; }

		public Dictionary<string, int> Values = new();

		public EnumDescriptor(Type type)
		{
			Type = type;
			if (!type.IsEnum)
				throw new ArgumentException($"Given {nameof(type)} must be an enum Type.");

			foreach (var name in System.Enum.GetNames(Type))
				Values[name] = (int)System.Enum.Parse(type, name);
		}
	}
}