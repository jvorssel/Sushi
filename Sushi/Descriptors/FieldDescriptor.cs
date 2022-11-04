// /***************************************************************************\
// Module Name:       FieldDescriptor.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 02-04-2022
// Copyright:              Royaldesk @ 2022
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

using System;
using System.Reflection;
using Sushi.Enum;
using Sushi.Extensions;
using Sushi.Helpers;
using Sushi.Interfaces;

namespace Sushi.Descriptors
{
	public sealed class FieldDescriptor : IPropertyDescriptor
	{
		private readonly FieldInfo _field;

		#region Implementation of IPropertyDescriptor

		/// <inheritdoc />
		public string Name => _field.Name;

		/// <inheritdoc />
		public bool IsReadonly => true;

		/// <inheritdoc />
		public Type Type { get; }

		/// <inheritdoc />
		public Type ClassType => _field.DeclaringType;

		/// <inheritdoc />
		public bool IsNullable { get; }

		/// <inheritdoc />
		public NativeType NativeType => Type.ToNativeTypeEnum();

		/// <inheritdoc />
		public object DefaultValue { get; }

		/// <inheritdoc />
		public string ScriptTypeValue { get; set; }

		#endregion

		public FieldDescriptor(FieldInfo fieldInfo)
		{
			_field = fieldInfo;
			Type = _field.FieldType;
			IsNullable = Type.IsNullable();

			if (IsNullable)
				Type = Nullable.GetUnderlyingType(Type);
			
			DefaultValue = ClassType.GetDefaultValue(_field);	
		}
	}
}