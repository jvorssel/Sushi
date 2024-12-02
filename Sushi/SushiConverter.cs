using System.Reflection;
using Sushi.Descriptors;
using Sushi.Documentation;
using Sushi.Extensions;
using Sushi.Helpers;
using Sushi.Interfaces;

namespace Sushi;

/// <summary>
///     Converts a set of types to the desired class script equivalent.
/// </summary>
/// <inheritdoc />
public sealed class SushiConverter : IConvertModels
{
    public IReadOnlyCollection<ClassDescriptor> Models { get; }
    public IReadOnlyCollection<EnumDescriptor> EnumModels { get; }

    public XmlDocumentationReader? Documentation { get; private set; }

    /// <summary>
    ///     Initialize a new <see cref="SushiConverter" /> with given <paramref name="types" /> to convert.
    /// </summary>
    public SushiConverter(ICollection<Type> types)
    {
        Models = types
            .Select(x => new ClassDescriptor(x))
            .Where(x => x.IsApplicable)
            .BuildTree()
            .Flatten()
            .ToHashSet();

        EnumModels = types
            .Where(x => x.IsEnum)
            .Select(x => new EnumDescriptor(x))
            .ToHashSet();
    }

    /// <summary>
    ///     Initialize a new <see cref="SushiConverter" /> for the given <paramref name="types" />.
    /// </summary>
    /// <inheritdoc />
    public SushiConverter(params Type[] types) : this(types.ToList())
    {
    }

    /// <summary>
    ///     Initialize a new <see cref="SushiConverter" /> and find the classes that
    ///     inherit <see cref="IScriptModel" /> in the given <paramref name="assembly" />.
    /// </summary>
    /// <inheritdoc />
    public SushiConverter(Assembly assembly) : this(assembly.ExportedTypes.ToList())
    {
    }

    /// <summary>
    ///		Use the msbuild xml file to provide documentation.
    /// </summary>
    public SushiConverter UseDocumentation(string msBuildXmlFilePath)
    {
        if (string.IsNullOrWhiteSpace(msBuildXmlFilePath))
            throw new ArgumentNullException(nameof(msBuildXmlFilePath));

        var extension = Path.GetExtension(msBuildXmlFilePath);
        if (extension != ".xml")
            throw new ArgumentException($"Expected the path '{msBuildXmlFilePath}' to lead to a XML file.");

        if (!File.Exists(msBuildXmlFilePath))
            throw new ArgumentException("XML documentation file not found.", nameof(msBuildXmlFilePath));

        Documentation = new XmlDocumentationReader(msBuildXmlFilePath);
        return this;
    }
}