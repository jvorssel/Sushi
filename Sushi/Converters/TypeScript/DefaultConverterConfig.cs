using Sushi.Enum;
using Sushi.Interfaces;

namespace Sushi.Converters.TypeScript;

public class DefaultConverterConfig : IConverterConfig
{
    public const string Boolean = "boolean";
    public const string String = "string";
    public const string Number = "number";
    public const string Date = "string";

    public string Indent { get; set; } = "    ";
    public PropertyNameCasing CasingStyle { get; set; } = PropertyNameCasing.CamelCase;
    public List<string> Headers { get; set; } = new();

    public Dictionary<Type, ITypeConverter> TypeConverters { get; set; } = new();
    public bool Strict { get; set; } = true;

    public DefaultConverterConfig()
    {
        // Boolean
        TypeConverters[typeof(bool)] = new TypeConverter<bool>(Boolean);

        // String
        TypeConverters[typeof(string)] = new TypeConverter<string>(String);
        TypeConverters[typeof(char)] = new TypeConverter<char>(String);
        TypeConverters[typeof(Guid)] = new TypeConverter<Guid>(String);

        // Date
        TypeConverters[typeof(DateTime)] = new TypeConverter<DateTime>(Date);

        // Number
        TypeConverters[typeof(System.Enum)] = new TypeConverter<byte>(Number);
        TypeConverters[typeof(byte)] = new TypeConverter<byte>(Number);
        TypeConverters[typeof(sbyte)] = new TypeConverter<sbyte>(Number);
        TypeConverters[typeof(decimal)] = new TypeConverter<decimal>(Number);
        TypeConverters[typeof(double)] = new TypeConverter<double>(Number);
        TypeConverters[typeof(float)] = new TypeConverter<float>(Number);
        TypeConverters[typeof(short)] = new TypeConverter<short>(Number);
        TypeConverters[typeof(int)] = new TypeConverter<int>(Number);
        TypeConverters[typeof(long)] = new TypeConverter<long>(Number);
        TypeConverters[typeof(sbyte)] = new TypeConverter<sbyte>(Number);
        TypeConverters[typeof(uint)] = new TypeConverter<uint>(Number);
        TypeConverters[typeof(ulong)] = new TypeConverter<ulong>(Number);
        TypeConverters[typeof(ushort)] = new TypeConverter<ushort>(Number);
    }
}