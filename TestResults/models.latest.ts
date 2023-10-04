export enum Gender {
    Undefined = 0,
    Male = 1,
    Female = 2
}

/**
 * Sushi.Tests.Models.GenericComplexStandalone`2
 * @typedef {Object} GenericComplexStandalone
 */
export class GenericComplexStandalone<TFirst, TSecond> {
    first: Array<TFirst> = [];
    second: Array<TSecond> = [];
    totalAmount!: number;

    constructor(value?: any) {
        if (value) {
            this.first = value.first;
            this.second = value.second;
            this.totalAmount = value.totalAmount;
        }
    }
}

/**
 * Sushi.Tests.Models.GenericStandalone`1
 * @typedef {Object} GenericStandalone
 */
export class GenericStandalone<TEntry> {
    values: Array<TEntry> = [];
    totalAmount!: number;

    constructor(value?: any) {
        if (value) {
            this.values = value.values;
            this.totalAmount = value.totalAmount;
        }
    }
}

/**
 * The view model base class.
 * @typedef {Object} ViewModel
 */
export class ViewModel {
    /** The view model identifier. */
    guid!: string;
    /** When this view model was created. */
    createdOn!: Date | string | null;

    constructor(value?: any) {
        if (value) {
            this.guid = value.guid;
            this.createdOn = value.createdOn;
        }
    }
}

/**
 * Sushi.Tests.Models.BaseViewModel
 * @typedef {Object} BaseViewModel
 * @extends ViewModel 
 */
export class BaseViewModel extends ViewModel {
    value: string = "base";
    base: boolean = true;

    constructor(value?: any) {
        super(value);

        if (value) {
            this.value = value.value;
            this.guid = value.guid;
            this.base = value.base;
            this.createdOn = value.createdOn;
        }
    }
}

/**
 * Sushi.Tests.Models.InheritedViewModel
 * @typedef {Object} InheritedViewModel
 * @extends BaseViewModel 
 */
export class InheritedViewModel extends BaseViewModel {
    guid: string = "new guid";
    addition: string = "added";

    constructor(value?: any) {
        super(value);

        if (value) {
            this.value = value.value;
            this.guid = value.guid;
            this.addition = value.addition;
            this.guid = value.guid;
            this.base = value.base;
            this.createdOn = value.createdOn;
        }
    }
}

/**
 * The PersonViewModel that represents a Person.
 * @typedef {Object} PersonViewModel
 * @extends ViewModel 
 */
export class PersonViewModel extends ViewModel {
    /** The Identifier that this Model refers to. */
    identifier: string = "086d8628-3490-4af8-ad58-79c7c80c2ca0";
    /** The Name of the person. */
    name!: string;
    /** The Surname of the person. */
    surname!: string;
    /** The Gender of the person. */
    gender: Gender | number = 1;

    constructor(value?: any) {
        super(value);

        if (value) {
            this.identifier = value.identifier;
            this.name = value.name;
            this.surname = value.surname;
            this.gender = value.gender;
            this.guid = value.guid;
            this.createdOn = value.createdOn;
        }
    }
}

/**
 * Represents a Student in a school.
 * @typedef {Object} StudentViewModel
 * @extends PersonViewModel 
 */
export class StudentViewModel extends PersonViewModel {
    /** What Grade the Student is in. */
    grade: number = 9;
    /** The name of the School. */
    school!: SchoolViewModel;

    constructor(value?: any) {
        super(value);

        if (value) {
            this.grade = value.grade;
            this.school = value.school;
            this.identifier = value.identifier;
            this.name = value.name;
            this.surname = value.surname;
            this.gender = value.gender;
            this.guid = value.guid;
            this.createdOn = value.createdOn;
        }
    }
}

/**
 * Basic information about a School.
 * @typedef {Object} SchoolViewModel
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

    constructor(value?: any) {
        super(value);

        if (value) {
            this.name = value.name;
            this.amountOfStudents = value.amountOfStudents;
            this.owner = value.owner;
            this.address = value.address;
            this.zipCode = value.zipCode;
            this.houseNumber = value.houseNumber;
            this.houseNumberAddition = value.houseNumberAddition;
            this.averageGrade = value.averageGrade;
            this.students = value.students;
            this.timmy = value.timmy;
            this.guid = value.guid;
            this.createdOn = value.createdOn;
        }
    }
}

/**
 * Simple model to verify complex types.
 * @typedef {Object} TypeModel
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

/**
 * Sushi.Tests.BugFixes.AbstractBaseClass+AbstractBaseModel
 * @typedef {Object} AbstractBaseModel
 */
export class AbstractBaseModel {
    name!: string;

    constructor(value?: any) {
        if (value) {
            this.name = value.name;
        }
    }
}

/**
 * Sushi.Tests.BugFixes.AbstractBaseClass+AbstractParentModel
 * @typedef {Object} AbstractParentModel
 * @extends AbstractBaseModel 
 */
export class AbstractParentModel extends AbstractBaseModel {
    surname!: string;

    constructor(value?: any) {
        super(value);

        if (value) {
            this.surname = value.surname;
            this.name = value.name;
        }
    }
}

/**
 * Sushi.Tests.BugFixes.NoParameterlessCtorTests+CtorFixModel
 * @typedef {Object} CtorFixModel
 */
export class CtorFixModel {
    name!: string;

    constructor(value?: any) {
        if (value) {
            this.name = value.name;
        }
    }
}

/**
 * Sushi.Tests.BugFixes.NoXmlDocumentation+NoXmlDocumentationModel
 * @typedef {Object} NoXmlDocumentationModel
 */
export class NoXmlDocumentationModel {
    name!: string;

    constructor(value?: any) {
        if (value) {
            this.name = value.name;
        }
    }
}

