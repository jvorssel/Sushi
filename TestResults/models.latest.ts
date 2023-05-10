export enum Gender {
    Undefined = 0,
    Male = 1,
    Female = 2
}

/**
 * Sushi.Tests.Models.ViewModel
 * @typedef {Object} ViewModel
 */
export class ViewModel {
    guid = "47dc7d0b-7f8e-4422-90bf-964f7ce8cb01";
    createdOn = null;

    constructor(value?: Partial<ViewModel>) {
        if (value) {
            this.guid = value.guid;
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
    identifier!: string;
    /** The Name of the person. */
    name!: string;
    /** The Surname of the person. */
    surname!: string;
    /** The Gender of the person. */
    gender!: Gender | number;

    constructor(value?: Partial<PersonViewModel>) {
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
    grade = 9;
    /** The name of the School. */
    school!: SchoolViewModel;

    constructor(value?: Partial<StudentViewModel>) {
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
    /** The Owner of this SchoolViewModel. */
    owner!: PersonViewModel;
    /** The AmountOfStudents of this SchoolViewModel. */
    amountOfStudents = 0;
    /** The Address of this SchoolViewModel. */
    address = "";
    /** The ZipCode of this SchoolViewModel. */
    zipCode!: string;
    /** The HouseNumber of this SchoolViewModel. */
    houseNumber = 0;
    /** The HouseNumberAddition of this SchoolViewModel. */
    houseNumberAddition!: string;
    /** The school student aren't doing too great ... */
    averageGrade = 2.6666666666666;
    /** The Students of this SchoolViewModel. */
    students = [];
    timmy = {} as StudentViewModel;

    constructor(value?: Partial<SchoolViewModel>) {
        super(value);

        if (value) {
            this.name = value.name;
            this.owner = value.owner;
            this.amountOfStudents = value.amountOfStudents;
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
    nullableBool!: boolean | null;
    /** A nullable string, defaults to null. */
    nullableString!: string;
    student = {} as StudentViewModel;
    students = [];
    studentPerClass = [];
    /** A readonly string. */
    readonlyString!: string;

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

/**
 * Sushi.Tests.BugFixes.AbstractBaseClass+AbstractBaseModel
 * @typedef {Object} AbstractBaseModel
 */
export class AbstractBaseModel {
    name!: string;

    constructor(value?: Partial<AbstractBaseModel>) {
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

    constructor(value?: Partial<AbstractParentModel>) {
        super(value);

        if (value) {
            this.surname = value.surname;
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

    constructor(value?: Partial<NoXmlDocumentationModel>) {
        if (value) {
            this.name = value.name;
        }
    }
}

