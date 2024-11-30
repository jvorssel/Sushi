using System.Text;
using Sushi.Descriptors;
using Sushi.Documentation;
using Sushi.Interfaces;

namespace Sushi.Converters;

/// <summary>
///     Add the JavaScript class declaration to the <see cref="SushiConverter.Models" />.
/// </summary>
public sealed class EcmaScript6Converter : ModelConverter
{
    /// <inheritdoc />
    public EcmaScript6Converter(SushiConverter converter, IConverterConfig config) : base(converter, config)
    {
    }

    /// / <inheritdoc />
    protected override IEnumerable<string> ConvertToScript(IEnumerable<ClassDescriptor> descriptors)
    {
        return descriptors.Select(Compile);
    }

    private string CreatePropertyDeclaration(IEnumerable<IPropertyDescriptor> properties)
    {
        var builder = new StringBuilder();
        foreach (var prop in properties)
        {
            builder.AppendJsDoc(XmlDocument, prop, Config.Indent);
            builder.AppendLine($"{Config.Indent}{prop.Name};");
        }

        return builder.ToString();
    }

    private string CreateConstructorDeclaration(IEnumerable<IPropertyDescriptor> properties, bool hasParent)
    {
        var builder = new StringBuilder();
        var i = Config.Indent;
        builder.AppendLine(i + "constructor(value) {");
        if (hasParent)
        {
            builder.AppendLine(i + i + "super(value);");
            builder.AppendLine("");
        }

        builder.AppendLine(i + i + "if (!(value instanceof Object))");
        builder.AppendLine(i + i + i + "return;");
        builder.AppendLine();

        foreach (var prop in properties)
            builder.AppendLine(i + i +
                               $"this.{ApplyCasingStyle(prop.Name)} = value.{ApplyCasingStyle(prop.Name)};");

        builder.Append(i + "}");
        return builder.ToString();
    }

    private string Compile(ClassDescriptor model)
    {
        var properties = model.GetProperties().ToList();
        var builder = new StringBuilder();
        builder.AppendJsDoc(XmlDocument, model);

        var parentClass = model.Parent == null ? string.Empty : $" extends {model.Parent.Name}";
        var propertyDeclaration = CreatePropertyDeclaration(properties);
        var constructorDeclaration = CreateConstructorDeclaration(properties, model.Parent != null);

        var i = Config.Indent;
        builder.AppendLine($"export class {model.Name}{parentClass} {{");
        builder.AppendLine(propertyDeclaration);
        builder.AppendLine(constructorDeclaration);
        builder.AppendLine(i + "static mapFrom(obj) {");
        builder.AppendLine(i + i + "return Object.assign(new {model.Name}(), obj);");
        builder.AppendLine(i + "}");
        builder.AppendLine("}");

        return builder.ToString();
    }
}