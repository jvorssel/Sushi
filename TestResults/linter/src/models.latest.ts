// noinspection JSUnusedGlobalSymbols

export enum Gender {
    Undefined = 0,
    Male = 1,
    Female = 2
}

/**
 * Sushi.Tests.Models.ConstrainedGeneric`1
 * @template {any} T
 */
export class ConstrainedGeneric<T> {
    data!: T;
    name: string | null = null;

    constructor(value: Partial<ConstrainedGeneric<T>> = {}) {
        if (value.data !== undefined) this.data = value.data;
        if (value.name !== undefined) this.name = value.name;
    }
}

/**
 * A class with const values.
 * Sushi.Tests.Models.ConstValues
 */
export class ConstValues {

    /**
     * A Static value.
     * @type (string)
     */
    static readonly static: string = "Static";

    /**
     * The First value.
     * @type (string)
     */
    static readonly first: string = "First";

    /**
     * The Last value.
     * @type (string)
     */
    static readonly last: string = "Last";


}

/**
 * Sushi.Tests.Models.GenericComplexStandalone`2
 * @template {any} TFirst
 * @template {any} TSecond
 */
export class GenericComplexStandalone<TFirst, TSecond> {
    first: Array<TFirst> = [];
    second: Array<TSecond> = [];
    totalAmount!: number;

    constructor(value: Partial<GenericComplexStandalone<TFirst, TSecond>> = {}) {
        if (value.first !== undefined) this.first = value.first;
        if (value.second !== undefined) this.second = value.second;
        if (value.totalAmount !== undefined) this.totalAmount = value.totalAmount;
    }
}

/**
 * Sushi.Tests.Models.GenericStandalone`1
 * @template {any} TEntry
 */
export class GenericStandalone<TEntry> {
    values: Array<TEntry> = [];
    totalAmount!: number;

    constructor(value: Partial<GenericStandalone<TEntry>> = {}) {
        if (value.values !== undefined) this.values = value.values;
        if (value.totalAmount !== undefined) this.totalAmount = value.totalAmount;
    }
}

/**
 * .
 * Sushi.Tests.Models.ScriptModel
 */
export class ScriptModel {


}

/**
 * The view model base class.
 * Sushi.Tests.Models.ViewModel
 * @extends ScriptModel
 */
export class ViewModel extends ScriptModel {

    /**
     * The view model identifier.
     * @type (string)
     */
    guid: string = "";

    /**
     * When this view model was created.
     * @type (Date | string | null)
     */
    createdOn!: Date | string | null;

    constructor(value: Partial<ViewModel> = {}) {
        super();

        if (value.guid !== undefined) this.guid = value.guid;
        if (value.createdOn !== undefined) this.createdOn = value.createdOn;
    }
}

/**
 * Sushi.Tests.Models.BaseViewModel
 * @extends ViewModel
 */
export class BaseViewModel extends ViewModel {
    value: string = "base";
    override guid: string = "00000000-0000-0000-0000-000000000000";
    base: boolean = true;

    constructor(value: Partial<BaseViewModel> = {}) {
        super(value);

        if (value.value !== undefined) this.value = value.value;
        if (value.guid !== undefined) this.guid = value.guid;
        if (value.base !== undefined) this.base = value.base;
    }
}

/**
 * Sushi.Tests.Models.InheritedViewModel
 * @extends BaseViewModel
 */
export class InheritedViewModel extends BaseViewModel {

    /**
     * .
     * @type (string)
     */
    override value: string = "override";
    addition: string = "added";

    constructor(value: Partial<InheritedViewModel> = {}) {
        super(value);

        if (value.value !== undefined) this.value = value.value;
        if (value.addition !== undefined) this.addition = value.addition;
    }
}

/**
 * For testing nullable properties.
 * Sushi.Tests.Models.NullablePropertiesViewModel
 * @extends ViewModel
 */
export class NullablePropertiesViewModel extends ViewModel {

    /**
     * An overridden, nullable Guid identifier.
     * @type (string)
     */
    override guid: string = "00000000-0000-0000-0000-000000000000";

    /**
     * Nullable string w get/set.
     * @type (string | null)
     */
    value2: string | null = null;

    /**
     * Nullable string.
     * @type (string | null)
     */
    static value: string | null = null;

    constructor(value: Partial<NullablePropertiesViewModel> = {}) {
        super(value);

        if (value.guid !== undefined) this.guid = value.guid;
        if (value.value2 !== undefined) this.value2 = value.value2;
    }
}

/**
 * The PersonViewModel that represents a Person.
 * Sushi.Tests.Models.PersonViewModel
 * @extends ViewModel
 */
export class PersonViewModel extends ViewModel {

    /**
     * The Identifier that this Model refers to.
     * @type (string)
     */
    identifier: string = "34837ead-3540-4553-bf24-677c4543a803";

    /**
     * The Name of the person.
     * @type (string | null)
     */
    name: string | null = null;

    /**
     * The Surname of the person.
     * @type (string | null)
     */
    surname: string | null = null;

    /**
     * The Gender of the person.
     * @type (Gender | number)
     */
    gender: Gender | number = 1;

    constructor(value: Partial<PersonViewModel> = {}) {
        super(value);

        if (value.identifier !== undefined) this.identifier = value.identifier;
        if (value.name !== undefined) this.name = value.name;
        if (value.surname !== undefined) this.surname = value.surname;
        if (value.gender !== undefined) this.gender = value.gender;
    }
}

/**
 * Represents a Student in a school.
 * Sushi.Tests.Models.StudentViewModel
 * @extends PersonViewModel
 */
export class StudentViewModel extends PersonViewModel {

    /**
     * What Grade the Student is in.
     * @type (number)
     */
    grade: number = 9;

    /**
     * The name of the School.
     * @type (SchoolViewModel)
     */
    school!: SchoolViewModel;

    constructor(value: Partial<StudentViewModel> = {}) {
        super(value);

        if (value.grade !== undefined) this.grade = value.grade;
        if (value.school !== undefined) this.school = value.school;
    }
}

/**
 * Basic information about a School.
 * Sushi.Tests.Models.SchoolViewModel
 * @extends ViewModel
 */
export class SchoolViewModel extends ViewModel {

    /**
     * The Name of this SchoolViewModel.
     * @type (string | null)
     */
    name: string | null = null;

    /**
     * The AmountOfStudents of this SchoolViewModel.
     * @type (number)
     */
    amountOfStudents: number = 0;

    /**
     * The Owner of this SchoolViewModel.
     * @type (PersonViewModel)
     */
    owner!: PersonViewModel;

    /**
     * The Address of this SchoolViewModel.
     * @type (string)
     */
    address: string = "";

    /**
     * The ZipCode of this SchoolViewModel.
     * @type (string | null)
     */
    zipCode: string | null = null;

    /**
     * The HouseNumber of this SchoolViewModel.
     * @type (number)
     */
    houseNumber: number = 0;

    /**
     * The HouseNumberAddition of this SchoolViewModel.
     * @type (string | null)
     */
    houseNumberAddition: string | null = null;

    /**
     * The school student aren't doing too great ...
     * @type (number)
     */
    averageGrade: number = 2.6666666666666;

    /**
     * The Students of this SchoolViewModel.
     * @type (Array<StudentViewModel>)
     */
    students: Array<StudentViewModel> = [];
    timmy: StudentViewModel = new StudentViewModel();

    constructor(value: Partial<SchoolViewModel> = {}) {
        super(value);

        if (value.name !== undefined) this.name = value.name;
        if (value.amountOfStudents !== undefined) this.amountOfStudents = value.amountOfStudents;
        if (value.owner !== undefined) this.owner = value.owner;
        if (value.address !== undefined) this.address = value.address;
        if (value.zipCode !== undefined) this.zipCode = value.zipCode;
        if (value.houseNumber !== undefined) this.houseNumber = value.houseNumber;
        if (value.houseNumberAddition !== undefined) this.houseNumberAddition = value.houseNumberAddition;
        if (value.averageGrade !== undefined) this.averageGrade = value.averageGrade;
        if (value.students !== undefined) this.students = value.students;
        if (value.timmy !== undefined) this.timmy = value.timmy;
    }
}

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
     * .
     * @type (string)
     */
    override guid: string = "73175868-f37f-4615-9c9c-fc6bf682dca2";

    /**
     * A DateTime instance.
     * @type (Date | string | null)
     */
    date!: Date | string | null;
    student: StudentViewModel = new StudentViewModel();
    students: Array<StudentViewModel> = [];
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
    }
}

/**
 * Sushi.Tests.BugFixes.AbstractBaseClass+AbstractBaseModel
 */
export class AbstractBaseModel {
    name: string | null = null;

    constructor(value: Partial<AbstractBaseModel> = {}) {
        if (value.name !== undefined) this.name = value.name;
    }
}

/**
 * Sushi.Tests.BugFixes.AbstractBaseClass+ChildModel
 * @extends AbstractBaseModel
 */
export class ChildModel extends AbstractBaseModel {
    surname: string | null = null;

    constructor(value: Partial<ChildModel> = {}) {
        super(value);

        if (value.surname !== undefined) this.surname = value.surname;
    }
}

/**
 * Sushi.Tests.BugFixes.NoParameterlessCtorTests+CtorFixModel
 */
export class CtorFixModel {
    name: string | null = null;

    constructor(value: Partial<CtorFixModel> = {}) {
        if (value.name !== undefined) this.name = value.name;
    }
}

/**
 * Sushi.Tests.BugFixes.NoXmlDocumentation+NoXmlDocumentationModel
 */
export class NoXmlDocumentationModel {
    name: string | null = null;


}

