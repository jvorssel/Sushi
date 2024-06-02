using System.Reflection;
using System.Text;
using Sushi.Descriptors;
using Sushi.Documentation;
using Sushi.Enum;
using Sushi.Extensions;
using Sushi.Interfaces;

namespace Sushi.Converters;

public abstract class ModelConverter : IConvertModels
{
    protected List<string> HeaderLines { get; }
    protected string Indent { get; }
    private PropertyNameCasing CasingStyle { get; }

    protected readonly XmlDocumentationReader? XmlDocument;
    public IReadOnlyCollection<ClassDescriptor> Models { get; }
    public IReadOnlyCollection<EnumDescriptor> EnumModels { get; }

    /// <summary>
    ///     The amount of <see cref="Models" /> found in the given <see cref="Assembly" />.
    /// </summary>
    protected ModelConverter(SushiConverter converter, IConverterOptions options)
    {
        Indent = options.Indent;
        CasingStyle = options.CasingStyle;
        HeaderLines = options.Headers;
        XmlDocument = converter.Documentation;
        Models = converter.Models;
        EnumModels = converter.EnumModels;
    }

    /// <summary>
    ///     Write the resulting script values from the enum and class models to a string.
    /// </summary>
    public override string ToString()
    {
        var builder = new StringBuilder();
        var descriptors = Models
            .BuildTree()
            .Flatten();

        foreach (var script in ConvertToScript(descriptors))
            builder.AppendLine(script);

        var result = builder.ToString();
        return result;
    }

    /// <summary>
    ///     Compile the models in the converter.
    /// </summary>
    protected abstract IEnumerable<string> ConvertToScript(IEnumerable<ClassDescriptor> descriptors);

    /// <summary>
    ///     Apply the chosen <see cref="CasingStyle" /> to the given <paramref name="value" />.
    /// </summary>
    public string ApplyCasingStyle(string value)
    {
        switch (CasingStyle)
        {
            case PropertyNameCasing.Default:
                return value;
            case PropertyNameCasing.CamelCase:
                return char.ToLowerInvariant(value[0]) + value.Substring(1);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}