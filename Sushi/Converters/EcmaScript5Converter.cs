using System.Text;
using Sushi.Descriptors;
using Sushi.Documentation;
using Sushi.Interfaces;

namespace Sushi.Converters;

/// <summary>
///     Add the JavaScript class declaration to the <see cref="SushiConverter.Models" />.
/// </summary>
public sealed class EcmaScript5Converter : ModelConverter
{
    private bool _includeUnderscoreExtend;

    /// <inheritdoc />
    public EcmaScript5Converter(SushiConverter converter, IConverterConfig config) : base(converter, config)
    {
    }

    /// / <inheritdoc />
    protected override IEnumerable<string> ConvertToScript(IEnumerable<ClassDescriptor> descriptors)
    {
        return descriptors.Select(Compile);
    }

    public EcmaScript5Converter IncludeUnderscoreMapper()
    {
        _includeUnderscoreExtend = true;
        return this;
    }

    private string Compile(ClassDescriptor model)
    {
        var builder = new StringBuilder();
        var i = Config.Indent;

        builder.AppendJsDoc(XmlDocument, model);

        builder.AppendLine($"function {model.Name}(obj) {{");
        builder.AppendLine(i + "let value = obj;");
        builder.AppendLine(i + "if (!(value instanceof Object)) ");
        builder.AppendLine(i + i + "value = {};");
        builder.AppendLine();

        foreach (var prop in model.Properties.Select(x => x.Value))
            builder.AppendLine($"{i}this.{ApplyCasingStyle(prop.Name)} = value.{ApplyCasingStyle(prop.Name)};");
        builder.AppendLine("}");

        if (!_includeUnderscoreExtend)
            return builder.ToString();

        builder.AppendLine();
        builder.AppendLine($"{model.Name}.prototype.mapFrom = function(obj) {{");
        builder.AppendLine($"{i}return _.extend(new {model.Name}(), obj); ");
        builder.AppendLine("};");

        return builder.ToString();
    }
}