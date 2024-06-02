using Sushi.Descriptors;

namespace Sushi.Interfaces;

public interface IConvertModels
{
    IReadOnlyCollection<ClassDescriptor> Models { get; }
    IReadOnlyCollection<EnumDescriptor> EnumModels { get; }
}