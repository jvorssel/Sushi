-# SushiScript Library for converting .NET classes to script language classes.

**Currently supports**

- **[TypeScript](https://github.com/jvorssel/Sushi/tree/master/TestResults)**
- **[ECMAScript 5](https://github.com/jvorssel/Sushi/tree/master/TestResults)** 
- **[ECMAScript 6](https://github.com/jvorssel/Sushi/tree/master/TestResults)**


**Author**

Jeroen Vorsselman @ 2024

**[GitHub](https://github.com/jvorssel)**

**[NuGet](https://www.nuget.org/packages/SushiScriptCore/1.0.0)**

---

## Features
- Converts .NET classes to script languages (typescript / ECMAScript)
- Compiled using **[.NET Standard 2.0](https://learn.microsoft.com/en-us/dotnet/standard/net-standard?tabs=net-standard-2-0)**
- Supports native types, type inheritance, generics and enum types
- Adds documentation using the generated MS build XML file
- 95% Code coverage
---
## About
``` 
string xmlDocPath =  Path.Combine(Environment.CurrentDirectory, "Sushi.tests.xml");

// Specify the types to convert using a Type[] or Assembly.ExportedTypes.
Assembly assembly = typeof(PersonViewModel).Assembly;
SushiConverter converter = new SushiConverter(assembly).UseDocumentation(xmlDocPath);

// Specify the script language and convert by invoking ToString().
ConverterOptions options = new ConverterOptions(excludeComments: true);
string result = converter.TypeScript(options).ToString();
```

Create a new `SushiConverter` instance with the given `Assembly` or `Type[]` that contain the types you want to convert.  
These classes must be decorated with the `ConvertToScriptAttribute` or inherit the `IScriptModel` interface. Classes can be excluded using the `IgnoreForScriptAttribute`.
The converter contains a collection of type- and enum-descriptors. These are used to generate script models.  


## Helpers
You can check if a type exists using: 
`IsSushiType(IConvertModels converter, Type type, out Type resolvedType) : boolean`

You can convert types using:
`TypeScriptConverter.ResolveScriptType(Type type, string prefix = "") : string`

You can get the script default value using:
`TypeScriptConverter.ResolveDefaultValue(IPropertyDescriptor prop) : string`

## Conversion result
### C# class
```
/// <summary>
///     Simple model to verify complex types.
/// </summary>
public sealed class TypeModel : ViewModel
{
  /// <summary>
  ///     A nullable boolean.
  /// </summary>
  public bool? NullableBool { get; set; } = null;
  
  /// <summary>
  ///     A nullable string, defaults to null.
  /// </summary>
  public string? NullableString { get; set; } = null;
  
  /// <summary>
  ///     A readonly string.
  /// </summary>
  public readonly string ReadonlyString = "readonly";
  
  /// <inheritdoc cref="Guid" />
  public new Guid Guid { get; set; } = Guid.NewGuid();
  
  /// <summary>
  ///     A DateTime instance.
  /// </summary>
  public DateTime Date{get;set;} = DateTime.Now;
  
  public StudentViewModel Student { get; set; } = new StudentViewModel();
  
  public List<StudentViewModel> Students { get; set; }
  
  public Dictionary<string, StudentViewModel[]> StudentPerClass { get; set; } = new ();
}
```
### Typescript class

```
/**
 * Simple model to verify complex types.
 * Sushi.Tests.Models.TypeModel
 * @extends ViewModel
 */
export class TypeModel extends ViewModel {

    /**
     * A nullable boolean.
     * @type (boolean | null)
     */
    nullableBool: boolean | null = null;

    /**
     * A nullable string, defaults to null.
     * @type (string | null)
     */
    nullableString: string | null = null;

    /**
     * A DateTime instance.
     * @type (Date | string | null)
     */
    date!: Date | string | null;
    student: StudentViewModel = new StudentViewModel();
    students: Array<StudentViewModel | null> = [];
    studentPerClass: { [key: string]: Array<StudentViewModel> } = {};

    /**
     * A readonly string.
     * @type (string)
     */
    static readonly readonlyString: string = "readonly";

    constructor(value: Partial<TypeModel> = {}) {
        super(value);

        if (value.nullableBool !== undefined) this.nullableBool = value.nullableBool;
        if (value.nullableString !== undefined) this.nullableString = value.nullableString;
        if (value.guid !== undefined) this.guid = value.guid;
        if (value.date !== undefined) this.date = value.date;
        if (value.student !== undefined) this.student = value.student;
        if (value.students !== undefined) this.students = value.students;
        if (value.studentPerClass !== undefined) this.studentPerClass = value.studentPerClass;
        if (value.createdOn !== undefined) this.createdOn = value.createdOn;
    }
}
```