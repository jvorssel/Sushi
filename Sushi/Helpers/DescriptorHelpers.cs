using System.Reflection;
using Sushi.Attributes;
using Sushi.Descriptors;
using Sushi.Extensions;
using Sushi.Interfaces;

namespace Sushi.Helpers;

/// <summary>
///     Logic for describing C# model.
/// </summary>
internal static class DescriptorHelpers
{
    /// <summary>
    ///     Iterate over every property of the given <see cref="Type" />
    ///     and map them to <see cref="PropertyDescriptor" />s.
    /// </summary>
    public static ICollection<PropertyDescriptor> GetPropertyDescriptors(this Type @this)
    {
        var descriptors = @this.GetPropertiesWithStaticValue()
            .Where(x => !x.Key.GetCustomAttributes(typeof(IgnoreForScriptAttribute), true).Any())
            .Select(x => new PropertyDescriptor(x.Key, x.Value))
            .ToList();

        return descriptors;
    }

    /// <summary>
    ///     Iterate over every field of the given <see cref="Type" />
    ///     and map them to <see cref="PropertyDescriptor" />s.
    /// </summary>
    public static ICollection<FieldDescriptor> GetFieldDescriptors(this Type @this)
    {
        var descriptors = @this.GetFields()
            .Select(x => new FieldDescriptor(x))
            .ToList();

        return descriptors;
    }

    public static bool IsPropertyInherited(this ClassDescriptor model, string propertyName)
    {
        var parent = model.Parent;
        while (parent != null)
        {
            var sameName = parent.Properties.ContainsKey(propertyName);
            if (sameName)
                return true;

            parent = parent.Parent;
        }

        return false;
    }

    public static bool IsApplicable(this ClassDescriptor descriptor)
    {
        var type = descriptor.Type;
        var hasScriptAttr = type.GetCustomAttributes(typeof(ConvertToScriptAttribute)).Any();
        var isScriptModel = type.IsOrInheritsInterface<IScriptModel>();
        var attrs = type.GetCustomAttributes(typeof(IgnoreForScriptAttribute), true);
        if (attrs.Any() || !type.IsClass)
            return false;

        return isScriptModel || hasScriptAttr;
    }
}