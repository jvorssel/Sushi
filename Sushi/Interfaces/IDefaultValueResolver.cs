using Sushi.Descriptors;

namespace Sushi.Interfaces;

public interface IDefaultValueResolver
{
    string GetArrayValue(IPropertyDescriptor descriptor);
    string GetClassValue(IPropertyDescriptor descriptor, ClassDescriptor? classDescriptor);
    string GetNumericValue(IPropertyDescriptor descriptor);
    string GetStringValue(IPropertyDescriptor descriptor);
    string GetBooleanValue(IPropertyDescriptor descriptor);
    string GetDateValue(IPropertyDescriptor descriptor);
    string GetNullOrEmptyValue(IPropertyDescriptor descriptor);
    string GetNull();
}