// /***************************************************************************\
// Module Name:       IConditionSpecification.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 02-04-2022
// Copyright:              Royaldesk @ 2022
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

using Sushi.Descriptors;

namespace Sushi.Interfaces
{
	public interface IConditionSpecification
	{
		/// <summary>
		///     Create a statement to check if the given <see cref="Converter.ArgumentName"/> has a value.
		/// </summary>
		ScriptConditionDescriptor ArgumentDefinedCheck(Converter converter);

		/// <summary>
		///     Create a statement to check if the given <see cref="Converter.ArgumentName"/> has no value.
		/// </summary>
		ScriptConditionDescriptor ArgumentUndefinedCheck(Converter converter);

		/// <summary>
		///     Create a statement to check if the <see cref="PropertyDescriptor.Name"/> exists in the given argument.
		/// </summary>
		ScriptConditionDescriptor CreateKeyExistsCheck(Converter converter, IPropertyDescriptor descriptor);

		/// <summary>
		///     Create a statement to check if the <see cref="PropertyDescriptor.Name"/> is a instance of the expected class.
		/// </summary>
		ScriptConditionDescriptor CreateInstanceCheck(Converter converter, IPropertyDescriptor descriptor);

		/// <summary>
		///     Create a statement to check if the <see cref="PropertyDescriptor.Name"/> is a instance of the expected type.
		/// </summary>
		ScriptConditionDescriptor CreateTypeCheck(Converter converter, IPropertyDescriptor descriptor);

		/// <inheritdoc cref=""/>
		ScriptConditionDescriptor CreateDefinedCheck(Converter converter, IPropertyDescriptor descriptor);
	}
}