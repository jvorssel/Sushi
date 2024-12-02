using System.Globalization;
using Sushi.Descriptors;
using Sushi.Extensions;
using Sushi.Interfaces;

namespace Sushi.DefaultTypeResolver;

public class DefaultValueResolver : IDefaultValueResolver
{
    public virtual string GetArrayValue(IPropertyDescriptor descriptor)
    {
        return "[]";
    }

    public virtual string GetClassValue(IPropertyDescriptor property, ClassDescriptor? classDescriptor)
    {
        var defaultValueType = property.DefaultValue!.GetType();
        if (classDescriptor != null)
            return $"new {classDescriptor.Name}()";

        return defaultValueType.IsDictionary() ? "{}" : string.Empty;
    }

    public virtual string GetNumericValue(IPropertyDescriptor descriptor)
    {
        if (descriptor.DefaultValue == null)
            return string.Empty;

        var asDecimal = Convert.ToDecimal(descriptor.DefaultValue)
            .ToString(CultureInfo.InvariantCulture);

        return asDecimal.Length > 15 ? asDecimal.Substring(0, 15) : asDecimal;
    }

    public virtual string GetStringValue(IPropertyDescriptor descriptor)
    {
        return $"\"{descriptor.DefaultValue}\"";
    }

    public virtual string GetBooleanValue(IPropertyDescriptor descriptor)
    {
        if (descriptor.IsNullable)
            return GetNull();

        return descriptor.DefaultValue as bool? == true ? "true" : "false";
    }

    public virtual string GetDateValue(IPropertyDescriptor descriptor)
    {
        return "(new Date()).toISOString()";
    }

    public virtual string GetNull()
    {
        return "null";
    }

    public virtual string GetNullOrEmptyValue(IPropertyDescriptor descriptor)
    {
        return descriptor.IsNullable ? GetNull() : string.Empty;
    }
}