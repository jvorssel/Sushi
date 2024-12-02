using Sushi.Descriptors;

namespace Sushi.Interfaces;

/// <summary>
///     Resolve the default property value for a specific types.
/// </summary>
public interface IDefaultValueMap
{
    public string GetArrayValue(IPropertyDescriptor descriptor);
    public string GetClassValue(IPropertyDescriptor descriptor, ClassDescriptor? classDescriptor);
    public string GetNumericValue(IPropertyDescriptor descriptor);
    public string GetStringValue(IPropertyDescriptor descriptor);
    public string GetBooleanValue(IPropertyDescriptor descriptor);
    public string GetDateValue(IPropertyDescriptor descriptor);
    public string GetNullOrEmptyValue(IPropertyDescriptor descriptor);
    public string GetNull();
}