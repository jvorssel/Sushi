/* eslint-disable @typescript-eslint/no-inferrable-types,@typescript-eslint/no-explicit-any */
export enum Gender {
    Undefined = 0,
    Male = 1,
    Female = 2
}

/**
 * Sushi.Tests.Models.ConstrainedGeneric`1
 */
export class ConstrainedGeneric<T> {
    data!: T;
    name!: string;

    constructor(value: any = null) {
        if (Object.prototype.hasOwnProperty.call(value, 'data'))
            this.data = value.data;

        if (Object.prototype.hasOwnProperty.call(value, 'name'))
            this.name = value.name;

    }
}

/**
 * A class with const values.
 */
export class ConstValues {
    /** A Static value. */
    static readonly static: string = "Static";
    /** The First value. */
    static readonly first: string = "First";
    /** The Last value. */
    static readonly last: string = "Last";


}

/**
 * Sushi.Tests.Models.GenericComplexStandalone`2
 */
export class GenericComplexStandalone<TFirst, TSecond> {
    first: Array<TFirst> = [];
    second: Array<TSecond> = [];
    totalAmount!: number;

    constructor(value: any = null) {
        if (Object.prototype.hasOwnProperty.call(value, 'first'))
            this.first = value.first;

        if (Object.prototype.hasOwnProperty.call(value, 'second'))
            this.second = value.second;

        if (Object.prototype.hasOwnProperty.call(value, 'totalAmount'))
            this.totalAmount = value.totalAmount;

    }
}

/**
 * Sushi.Tests.Models.GenericStandalone`1
 */
export class GenericStandalone<TEntry> {
    values: Array<TEntry> = [];
    totalAmount!: number;

    constructor(value: any = null) {
        if (Object.prototype.hasOwnProperty.call(value, 'values'))
            this.values = value.values;

        if (Object.prototype.hasOwnProperty.call(value, 'totalAmount'))
            this.totalAmount = value.totalAmount;

    }
}

/**
 * The view model base class.
 */
export class ViewModel {
    /** The view model identifier. */
    guid!: string;
    /** When this view model was created. */
    createdOn!: Date | string | null;

    constructor(value: any = null) {
        if (Object.prototype.hasOwnProperty.call(value, 'guid'))
            this.guid = value.guid;

        if (Object.prototype.hasOwnProperty.call(value, 'createdOn'))
            this.createdOn = value.createdOn;

    }
}

/**
 * Sushi.Tests.Models.BaseViewModel
 * @extends ViewModel 
 */
export class BaseViewModel extends ViewModel {
    value: string = "base";
    base: boolean = true;

    constructor(value: any = null) {
        super(value);

        if (Object.prototype.hasOwnProperty.call(value, 'value'))
            this.value = value.value;

        if (Object.prototype.hasOwnProperty.call(value, 'guid'))
            this.guid = value.guid;

        if (Object.prototype.hasOwnProperty.call(value, 'base'))
            this.base = value.base;

        if (Object.prototype.hasOwnProperty.call(value, 'createdOn'))
            this.createdOn = value.createdOn;

    }
}

/**
 * Sushi.Tests.Models.InheritedViewModel
 * @extends BaseViewModel 
 */
export class InheritedViewModel extends BaseViewModel {
    guid: string = "new guid";
    addition: string = "added";

    constructor(value: any = null) {
        super(value);

        if (Object.prototype.hasOwnProperty.call(value, 'value'))
            this.value = value.value;

        if (Object.prototype.hasOwnProperty.call(value, 'guid'))
            this.guid = value.guid;

        if (Object.prototype.hasOwnProperty.call(value, 'addition'))
            this.addition = value.addition;

        if (Object.prototype.hasOwnProperty.call(value, 'guid'))
            this.guid = value.guid;

        if (Object.prototype.hasOwnProperty.call(value, 'base'))
            this.base = value.base;

        if (Object.prototype.hasOwnProperty.call(value, 'createdOn'))
            this.createdOn = value.createdOn;

    }
}

/**
 * The PersonViewModel that represents a Person.
 * @extends ViewModel 
 */
export class PersonViewModel extends ViewModel {
    /** The Identifier that this Model refers to. */
    identifier: string = "02bc4440-272b-4fd1-970c-a6a9c2f02284";
    /** The Name of the person. */
    name!: string;
    /** The Surname of the person. */
    surname!: string;
    /** The Gender of the person. */
    gender: Gender | number = 1;

    constructor(value: any = null) {
        super(value);

        if (Object.prototype.hasOwnProperty.call(value, 'identifier'))
            this.identifier = value.identifier;

        if (Object.prototype.hasOwnProperty.call(value, 'name'))
            this.name = value.name;

        if (Object.prototype.hasOwnProperty.call(value, 'surname'))
            this.surname = value.surname;

        if (Object.prototype.hasOwnProperty.call(value, 'gender'))
            this.gender = value.gender;

        if (Object.prototype.hasOwnProperty.call(value, 'guid'))
            this.guid = value.guid;

        if (Object.prototype.hasOwnProperty.call(value, 'createdOn'))
            this.createdOn = value.createdOn;

    }
}

/**
 * Represents a Student in a school.
 * @extends PersonViewModel 
 */
export class StudentViewModel extends PersonViewModel {
    /** What Grade the Student is in. */
    grade: number = 9;
    /** The name of the School. */
    school!: SchoolViewModel;

    constructor(value: any = null) {
        super(value);

        if (Object.prototype.hasOwnProperty.call(value, 'grade'))
            this.grade = value.grade;

        if (Object.prototype.hasOwnProperty.call(value, 'school'))
            this.school = value.school;

        if (Object.prototype.hasOwnProperty.call(value, 'identifier'))
            this.identifier = value.identifier;

        if (Object.prototype.hasOwnProperty.call(value, 'name'))
            this.name = value.name;

        if (Object.prototype.hasOwnProperty.call(value, 'surname'))
            this.surname = value.surname;

        if (Object.prototype.hasOwnProperty.call(value, 'gender'))
            this.gender = value.gender;

        if (Object.prototype.hasOwnProperty.call(value, 'guid'))
            this.guid = value.guid;

        if (Object.prototype.hasOwnProperty.call(value, 'createdOn'))
            this.createdOn = value.createdOn;

    }
}

/**
 * Basic information about a School.
 * @extends ViewModel 
 */
export class SchoolViewModel extends ViewModel {
    /** The Name of this SchoolViewModel. */
    name!: string;
    /** The AmountOfStudents of this SchoolViewModel. */
    amountOfStudents: number = 0;
    /** The Owner of this SchoolViewModel. */
    owner!: PersonViewModel;
    /** The Address of this SchoolViewModel. */
    address: string = "";
    /** The ZipCode of this SchoolViewModel. */
    zipCode!: string;
    /** The HouseNumber of this SchoolViewModel. */
    houseNumber: number = 0;
    /** The HouseNumberAddition of this SchoolViewModel. */
    houseNumberAddition!: string;
    /** The school student aren't doing too great ... */
    averageGrade: number = 2.6666666666666;
    /** The Students of this SchoolViewModel. */
    students: Array<StudentViewModel> = [];
    timmy: StudentViewModel = new StudentViewModel();

    constructor(value: any = null) {
        super(value);

        if (Object.prototype.hasOwnProperty.call(value, 'name'))
            this.name = value.name;

        if (Object.prototype.hasOwnProperty.call(value, 'amountOfStudents'))
            this.amountOfStudents = value.amountOfStudents;

        if (Object.prototype.hasOwnProperty.call(value, 'owner'))
            this.owner = value.owner;

        if (Object.prototype.hasOwnProperty.call(value, 'address'))
            this.address = value.address;

        if (Object.prototype.hasOwnProperty.call(value, 'zipCode'))
            this.zipCode = value.zipCode;

        if (Object.prototype.hasOwnProperty.call(value, 'houseNumber'))
            this.houseNumber = value.houseNumber;

        if (Object.prototype.hasOwnProperty.call(value, 'houseNumberAddition'))
            this.houseNumberAddition = value.houseNumberAddition;

        if (Object.prototype.hasOwnProperty.call(value, 'averageGrade'))
            this.averageGrade = value.averageGrade;

        if (Object.prototype.hasOwnProperty.call(value, 'students'))
            this.students = value.students;

        if (Object.prototype.hasOwnProperty.call(value, 'timmy'))
            this.timmy = value.timmy;

        if (Object.prototype.hasOwnProperty.call(value, 'guid'))
            this.guid = value.guid;

        if (Object.prototype.hasOwnProperty.call(value, 'createdOn'))
            this.createdOn = value.createdOn;

    }
}

/**
 * Simple model to verify complex types.
 * @extends ViewModel 
 */
export class TypeModel extends ViewModel {
    /** A nullable boolean. */
    nullableBool: boolean | null = null;
    /** A nullable string, defaults to null. */
    nullableString!: string;
    /** A DateTime instance. */
    date: Date | string | null = null;
    student: StudentViewModel = new StudentViewModel();
    students: Array<StudentViewModel> = [];
    studentPerClass: { [key: string]: Array<StudentViewModel> } = {};
    /** A readonly string. */
    static readonly readonlyString!: string;

    constructor(value: any = null) {
        super(value);

        if (Object.prototype.hasOwnProperty.call(value, 'nullableBool'))
            this.nullableBool = value.nullableBool;

        if (Object.prototype.hasOwnProperty.call(value, 'nullableString'))
            this.nullableString = value.nullableString;

        if (Object.prototype.hasOwnProperty.call(value, 'guid'))
            this.guid = value.guid;

        if (Object.prototype.hasOwnProperty.call(value, 'date'))
            this.date = value.date;

        if (Object.prototype.hasOwnProperty.call(value, 'student'))
            this.student = value.student;

        if (Object.prototype.hasOwnProperty.call(value, 'students'))
            this.students = value.students;

        if (Object.prototype.hasOwnProperty.call(value, 'studentPerClass'))
            this.studentPerClass = value.studentPerClass;

        if (Object.prototype.hasOwnProperty.call(value, 'createdOn'))
            this.createdOn = value.createdOn;

    }
}

/**
 * Sushi.Tests.BugFixes.AbstractBaseClass+AbstractBaseModel
 */
export class AbstractBaseModel {
    name!: string;

    constructor(value: any = null) {
        if (Object.prototype.hasOwnProperty.call(value, 'name'))
            this.name = value.name;

    }
}

/**
 * Sushi.Tests.BugFixes.AbstractBaseClass+AbstractParentModel
 * @extends AbstractBaseModel 
 */
export class AbstractParentModel extends AbstractBaseModel {
    surname!: string;

    constructor(value: any = null) {
        super(value);

        if (Object.prototype.hasOwnProperty.call(value, 'surname'))
            this.surname = value.surname;

        if (Object.prototype.hasOwnProperty.call(value, 'name'))
            this.name = value.name;

    }
}

/**
 * Sushi.Tests.BugFixes.NoParameterlessCtorTests+CtorFixModel
 */
export class CtorFixModel {
    name!: string;

    constructor(value: any = null) {
        if (Object.prototype.hasOwnProperty.call(value, 'name'))
            this.name = value.name;

    }
}

/**
 * Sushi.Tests.BugFixes.NoXmlDocumentation+NoXmlDocumentationModel
 */
export class NoXmlDocumentationModel {
    readonly name!: string;


}

