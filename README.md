-# Sushi
Library for converting .NET classes to script language classes.

**Currently supports**

- **[TypeScript](https://github.com/jvorssel/Sushi/tree/master/TestResults)**
- **[ECMAScript 5](https://github.com/jvorssel/Sushi/tree/master/TestResults)** 
- **[ECMAScript 6](https://github.com/jvorssel/Sushi/tree/master/TestResults)**


**Author**

Jeroen Vorsselman @ 2023

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

Create a new `SushiConverter` instance with the given `Assembly` or `Type[]` that contain the types you want to convert.  <br />
These classes must be decorated with the `ConvertToScriptAttribute` or inherit the `IScriptModel` interface. Classes can be excluded using the `IgnoreForScriptAttribute`.
The converter contains a collection of type- and enum-descriptors. These are used to generate script models.  <br />


## Helpers
You can check if a type exists using: `IsSushiType(IConvertModels converter, Type type, out Type resolvedType) : boolean`  <br />
You can convert types using: `TypeScriptConverter.ResolveScriptType(Type type, string prefix = "") : string`  <br />
You can get the script default value using: `TypeScriptConverter.ResolveDefaultValue(IPropertyDescriptor prop) : string`  <br />
## Typescript result

```
/**
 * Simple model to verify complex types.
 * @typedef {Object} TypeModel
 * @extends ViewModel 
 */
export class TypeModel extends ViewModel {
    /** A nullable boolean. */
    nullableBool!: boolean | null;
    /** A nullable string, defaults to null. */
    nullableString!: string;
    /** A DateTime instance. */
    date: Date | string | null = null;
    student: StudentViewModel = new StudentViewModel();
    students: Array<StudentViewModel> = [];
    studentPerClass: Array<Array<StudentViewModel>> = [];
    /** A readonly string. */
    readonlyString!: string;

    constructor(value?: any) {
        super(value);

        if (value) {
            this.nullableBool = value.nullableBool;
            this.nullableString = value.nullableString;
            this.guid = value.guid;
            this.date = value.date;
            this.student = value.student;
            this.students = value.students;
            this.studentPerClass = value.studentPerClass;
            this.createdOn = value.createdOn;
            this.readonlyString = value.readonlyString;
        }
    }
}
```