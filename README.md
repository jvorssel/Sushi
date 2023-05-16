# Sushi
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

Main features
- 
- Support for nested generic types.
- Compliled using **[.NET Standard 2.0](https://learn.microsoft.com/en-us/dotnet/standard/net-standard?tabs=net-standard-2-0)**. 
- Support for .NET Core, .NET Framework etc.
- Vastly improved compared to its predecessor.
- Creates extended classes and their constructors.
- Simple object mapping.
- Improved type dependency tree ordering.
- Adds documentation from the XML file generated using MS build.
- 95% Code coverage.
---
## How to use
Script models are discovered in the `Assembly.ExportedTypes`. These classes must be decorated with the `ConvertToScriptAttribute` or by inherit from the `IScriptModel` interface and can be ignored using the `IgnoreForScriptAttribute`. 
<br>
Create an instance of the `SushiConverter` using the given types or assembly and invoke the target script language method to create a converter.

### Example
``` 
// 1) Get the assembly with the exported types.
var assembly = typeof(PersonViewModel).Assembly;
var converter = new SushiConverter(assembly).UseDocumentation(XmlDocPath);

// 2) Specify conversion options.
var options = new ConverterOptions(excludeComments: true);

// 3) Specify the target language and invoke ToString().
var script = converter.TypeScript(options).ToString();

// 4) The resulting script can be written to a file(stream).
WriteToFile(script, GetFilePath("models.no-comments.ts"));
``` 

### Typescript result

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