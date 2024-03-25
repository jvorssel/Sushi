/* eslint-disable @typescript-eslint/no-inferrable-types,@typescript-eslint/no-explicit-any */
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
    name: string = "";

    constructor(value: Partial<ConstrainedGeneric<T>> = {}) {
        if (value.data) this.data = value.data;
        if (value.name) this.name = value.name;
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
        if (value.first) this.first = value.first;
        if (value.second) this.second = value.second;
        if (value.totalAmount) this.totalAmount = value.totalAmount;
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
        if (value.values) this.values = value.values;
        if (value.totalAmount) this.totalAmount = value.totalAmount;
    }
}

/**
 * The view model base class.
 * Sushi.Tests.Models.ViewModel
 */
export class ViewModel {

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
        if (value.guid) this.guid = value.guid;
        if (value.createdOn) this.createdOn = value.createdOn;
    }
}

/**
 * Sushi.Tests.Models.BaseViewModel
 * @extends ViewModel
 */
export class BaseViewModel extends ViewModel {
    value: string = "base";
    base: boolean = true;

    constructor(value: Partial<BaseViewModel> = {}) {
        super(value);

        if (value.value) this.value = value.value;
        if (value.guid) this.guid = value.guid;
        if (value.base) this.base = value.base;
        if (value.createdOn) this.createdOn = value.createdOn;
    }
}

/**
 * Sushi.Tests.Models.InheritedViewModel
 * @extends BaseViewModel
 */
export class InheritedViewModel extends BaseViewModel {
    override guid: string = "new guid";
    addition: string = "added";

    constructor(value: Partial<InheritedViewModel> = {}) {
        super(value);

        if (value.value) this.value = value.value;
        if (value.guid) this.guid = value.guid;
        if (value.addition) this.addition = value.addition;
        if (value.guid) this.guid = value.guid;
        if (value.base) this.base = value.base;
        if (value.createdOn) this.createdOn = value.createdOn;
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
    identifier: string = "031a6c59-5709-46fe-a650-64efc93e184f";

    /**
     * The Name of the person.
     * @type (string)
     */
    name: string = "";

    /**
     * The Surname of the person.
     * @type (string)
     */
    surname: string = "";

    /**
     * The Gender of the person.
     * @type (Gender | number)
     */
    gender: Gender | number = 1;

    constructor(value: Partial<PersonViewModel> = {}) {
        super(value);

        if (value.identifier) this.identifier = value.identifier;
        if (value.name) this.name = value.name;
        if (value.surname) this.surname = value.surname;
        if (value.gender) this.gender = value.gender;
        if (value.guid) this.guid = value.guid;
        if (value.createdOn) this.createdOn = value.createdOn;
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

        if (value.grade) this.grade = value.grade;
        if (value.school) this.school = value.school;
        if (value.identifier) this.identifier = value.identifier;
        if (value.name) this.name = value.name;
        if (value.surname) this.surname = value.surname;
        if (value.gender) this.gender = value.gender;
        if (value.guid) this.guid = value.guid;
        if (value.createdOn) this.createdOn = value.createdOn;
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
     * @type (string)
     */
    name: string = "";

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
     * @type (string)
     */
    zipCode: string = "";

    /**
     * The HouseNumber of this SchoolViewModel.
     * @type (number)
     */
    houseNumber: number = 0;

    /**
     * The HouseNumberAddition of this SchoolViewModel.
     * @type (string)
     */
    houseNumberAddition: string = "";

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

        if (value.name) this.name = value.name;
        if (value.amountOfStudents) this.amountOfStudents = value.amountOfStudents;
        if (value.owner) this.owner = value.owner;
        if (value.address) this.address = value.address;
        if (value.zipCode) this.zipCode = value.zipCode;
        if (value.houseNumber) this.houseNumber = value.houseNumber;
        if (value.houseNumberAddition) this.houseNumberAddition = value.houseNumberAddition;
        if (value.averageGrade) this.averageGrade = value.averageGrade;
        if (value.students) this.students = value.students;
        if (value.timmy) this.timmy = value.timmy;
        if (value.guid) this.guid = value.guid;
        if (value.createdOn) this.createdOn = value.createdOn;
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
     * @type (string)
     */
    nullableString: string = "";

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

        if (value.nullableBool) this.nullableBool = value.nullableBool;
        if (value.nullableString) this.nullableString = value.nullableString;
        if (value.guid) this.guid = value.guid;
        if (value.date) this.date = value.date;
        if (value.student) this.student = value.student;
        if (value.students) this.students = value.students;
        if (value.studentPerClass) this.studentPerClass = value.studentPerClass;
        if (value.createdOn) this.createdOn = value.createdOn;
    }
}

/**
 * Sushi.Tests.BugFixes.AbstractBaseClass+AbstractBaseModel
 */
export class AbstractBaseModel {
    name: string = "";

    constructor(value: Partial<AbstractBaseModel> = {}) {
        if (value.name) this.name = value.name;
    }
}

/**
 * Sushi.Tests.BugFixes.AbstractBaseClass+AbstractParentModel
 * @extends AbstractBaseModel
 */
export class AbstractParentModel extends AbstractBaseModel {
    surname: string = "";

    constructor(value: Partial<AbstractParentModel> = {}) {
        super(value);

        if (value.surname) this.surname = value.surname;
        if (value.name) this.name = value.name;
    }
}

/**
 * Sushi.Tests.BugFixes.NoParameterlessCtorTests+CtorFixModel
 */
export class CtorFixModel {
    name: string = "";

    constructor(value: Partial<CtorFixModel> = {}) {
        if (value.name) this.name = value.name;
    }
}

/**
 * Sushi.Tests.BugFixes.NoXmlDocumentation+NoXmlDocumentationModel
 */
export class NoXmlDocumentationModel {
    name: string = "";


}

