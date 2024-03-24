// /***************************************************************************\
// Module Name:       XmlSummaryDescriptor.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 14-05-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using Sushi.Extensions;
using Sushi.Helpers;

#endregion

namespace Sushi.Documentation;

/// <summary>
///     Describes xml-summary about a field, property or method.
/// </summary>
public sealed class XmlSummaryDescriptor
{
    /// <summary>
    ///     <see cref="Dictionary{TKey,TValue}" /> that describes direct child-elements of the member.
    /// </summary>
    public Dictionary<string, string> Values { get; }

    /// <summary>
    ///     The <see cref="RawName" /> value of the member.
    /// </summary>
    public string RawName { get; }

    /// <summary>
    ///     The last-part of the <see cref="RawName" /> that describes the actual <see cref="Name" />.
    /// </summary>
    public string Name { get; } = string.Empty;

    /// <summary>
    ///     The full-<see cref="Namespace" /> that the <see cref="Name" /> belongs in.
    /// </summary>
    public string Namespace { get; } = string.Empty;

    /// <summary>
    ///     The type-name of the class this <see cref="Name" /> belongs to.
    /// </summary>
    public string DeclaringTypeName { get; } = string.Empty;

    /// <summary>
    ///     What <see cref="ReferenceType" /> does the xml-doc reflect.
    /// </summary>
    public ReferenceType FieldType { get; }

    // FIELDS
    public bool IsInherited { get; }
    public Type InheritedFrom { get; private set; }
    public string Summary { get; private set; }

    public XmlSummaryDescriptor(string name, ReferenceType field, Dictionary<string, string> values)
    {
        if (name.IsEmpty())
            throw new ArgumentNullException(nameof(name));

        RawName = XmlDocumentationReader.RemoveMethodArgs.Match(name).Value;
        Values = values ?? throw new ArgumentNullException(nameof(values));
        FieldType = field;

        // FIELDS
        Summary = values.ContainsKey("summary") ? Trim(Values["summary"]) : string.Empty;
        Summary = !Summary.EndsWith(".") ? Summary + "." : Summary;
        
        IsInherited = values.ContainsKey("inheritdoc");

        var split = RawName.Split('.').ToList();
        switch (field)
        {
            case ReferenceType.Type:
                Name = split.Last();
                DeclaringTypeName = split.Last();
                Namespace = split.Take(split.Count - 1).Glue(".");
                break;
            case ReferenceType.Method:
            case ReferenceType.Event:
            case ReferenceType.Property:
            case ReferenceType.Field:
                Name = split.Last();
                DeclaringTypeName = split[split.Count - 2];
                Namespace = split.Take(split.Count - 2).Glue(".");
                break;
            case ReferenceType.Namespace:
            case ReferenceType.Error:
            case ReferenceType.Undefined:
            default:
                return;
        }
    }

    /// <summary>
    ///     Custom method to <see cref="Trim" /> the inner-body of the xml-doc.
    /// </summary>
    private static string Trim(string value)
    {
        return value.Trim().TrimStart('\n').TrimEnd('\n');
    }

    public XmlSummaryDescriptor UseInheritedSummary(string summary, Type type)
    {
        Summary = summary;
        InheritedFrom = type;
        return this;
    }

    #region Equality members

    public static bool operator ==(XmlSummaryDescriptor? fd, Type? type)
    {
        if (type is null || fd is null)
            return type is null == fd is null;

        return fd.IsSameType(type);
    }

    public static bool operator !=(XmlSummaryDescriptor ms, Type type)
    {
        return !(ms == type);
    }

    public bool IsEqualTo(XmlSummaryDescriptor other)
    {
        if (ReferenceEquals(null, other))
            return false;
        if (ReferenceEquals(this, other))
            return true;
        return string.Equals(Name, other.Name) && string.Equals(Namespace, other.Namespace) &&
               string.Equals(DeclaringTypeName, other.DeclaringTypeName) && FieldType == other.FieldType;
    }

    public bool IsSameType(Type type)
    {
        if (ReferenceEquals(null, type))
            return false;

        return string.Equals(Name, type.Name) && string.Equals(Namespace, type.Namespace) &&
               string.Equals(RawName, type.FullName) && FieldType == ReferenceType.Type;
    }

    #endregion
}