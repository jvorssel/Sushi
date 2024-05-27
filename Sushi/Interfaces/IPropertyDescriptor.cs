// /***************************************************************************\
// Module Name:       IPropertyDescriptor.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 16-05-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

namespace Sushi.Interfaces;

public interface IPropertyDescriptor
{
    /// <summary>
    ///     The <see cref="Name" /> of the described property or field.
    /// </summary>
    string Name { get; }

    /// <summary>
    ///     The actual type.
    /// </summary>
    Type? Type { get; }

    /// <summary>
    ///     The type of the class that the property or field belongs to.
    /// </summary>
    Type? ClassType { get; }

    /// <summary>
    ///		The default value assigned to the property.
    /// </summary>
    object? DefaultValue { get; }

    /// <summary>
    ///     If the property can is readonly.
    /// </summary>
    bool Readonly { get; }
    
    /// <summary>
    ///     If the property is static.
    /// </summary>
    bool IsStatic { get; }
    
    /// <summary>
    ///     If the property is nullable.
    /// </summary>
    bool IsNullable { get; }

    /// <summary>
    ///     If the property is inherited and overridden.
    /// </summary>
    bool IsOverridden { get; }
}