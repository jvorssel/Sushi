# Sushi
Library for converting .NET classes to script classes.

Author: Jeroen Vorsselman @ 2023

**[GitHub](https://github.com/jvorssel)**

**[NuGet](https://www.nuget.org/packages/SushiScriptCore/1.0.0)**

---
##  Main features
- Generates **[ECMAScript 5](https://github.com/jvorssel/Sushi/blob/master/TestResults/models.es5.js)**, **[ECMAScript 6](https://github.com/jvorssel/Sushi/blob/master/TestResults/models.es6.js)** and **[TypeScript](https://github.com/jvorssel/Sushi/blob/master/TestResults/models.latest.ts)** classes using .NET types.
- Support for nested generic types.
- Support for .NET Core. 
- Vastly improved compared to its predecessor.
- Creates extended classes and their constructors.
- Simple object mapping.
- Allows custom datatype conversion.
- Improved type dependency tree ordering.
- Adds documentation from the XML file generated on project build.
- 85% Code coverage.
- Assigns explicitly specified default values for "simple" types.
---
## How to use
1. Specify what types to use in an `assembly` by adding:
   1. An `ConvertToScriptAttribute` to the class, or;
   2. Inheriting from the `IScriptModel` interface. 
   3. You can also exclude models using the `IgnoreForScriptAttribute`.
2. Create an instance of the `SushiConverter`:
   1. `SushiConverter(ICollection<Type> types)` Create an instance using the given collection of types.
   2. `SushiConverter(ICollection<Type> types, string assemblyDocPath)` Delegates to #1 and adds a path to the XML documentation file. 
   3. `SushiConverter(params Type[] types)` Delegates to #1. 
   4. `SushiConverter(Assembly assembly, string assemblyDocPath)` Delegates to #1 using the `assembly.ExportedTypes` and adds a path to the XML documentation file.
   5. **REMARK:** All given types MUST inherit from the Interface or Attribute or they will be ignored.
3. Create a `ModelConverter` for a specific language.

### Example
``` 
var converter = new SushiConverter(assembly, xmlFilePath);

var script = converter.TypeScript(indent: "    ", casing: PropertyNameCasing.Default)
    .Convert()
    .ConvertEnums()
    .ToString();
``` 
The following .NET class is used:

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

	public StudentViewModel Student { get; set; } = new StudentViewModel();
	public List<StudentViewModel> Students { get; set; }
	public List<List<StudentViewModel>> StudentPerClass { get; set; }
}
```
To generate this TypeScript model:

```
/**
 * Simple model to verify complex types.
 * @typedef {Object} TypeModel
 * @extends ViewModel 
 */
export class TypeModel extends ViewModel {
    /** A nullable boolean. */
    nullableBool: boolean | null;
    /** A nullable string, defaults to null. */
    nullableString: string;
    student = {} as StudentViewModel;
    students = [];
    studentPerClass = [];
    /** A readonly string. */
    readonlyString: string;

    constructor(value?: Partial<TypeModel>) {
        super(value);

        if (value) {
            this.nullableBool = value.nullableBool;
            this.nullableString = value.nullableString;
            this.guid = value.guid;
            this.student = value.student;
            this.students = value.students;
            this.studentPerClass = value.studentPerClass;
            this.createdOn = value.createdOn;
            this.readonlyString = value.readonlyString;
        }
    }
}
```