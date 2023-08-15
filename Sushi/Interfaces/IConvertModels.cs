using Sushi.Descriptors;

namespace Sushi.Interfaces;

public interface IConvertModels
{
    HashSet<ClassDescriptor> Models { get; }
    HashSet<EnumDescriptor> EnumModels { get; }
}