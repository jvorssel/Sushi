export enum Gender {
    Undefined = 0,
    Male = 1,
    Female = 2,
}

/**
 * Sushi.Tests.Models.ViewModel.
 * @typedef {Object} ViewModel
 */
export class ViewModel {
    Guid: string;
    CreatedOn: Date;

    constructor();
    constructor(value?: any) {
        if (!(value instanceof Object))
            return;

        this.Guid = value.Guid;
        this.CreatedOn = value.CreatedOn;
    }

    static from(obj: any): ViewModel {
        return Object.assign(new ViewModel(), obj);
    }
}

/**
 * The PersonViewModel that represents a Person.
 * @typedef {Object} PersonViewModel
 * @extends ViewModel
 */
export class PersonViewModel extends ViewModel {
    /** The Identifier that this Model refers to. */
    Identifier: string;
    /** The Name of the person. */
    Name: string;
    /** The Surname of the person. */
    Surname: string;
    /** The Gender of the person. */
    Gender: Gender | number;
    Guid: string;
    CreatedOn: Date;

    constructor();
    constructor(value?: any) {
        super();

        if (!(value instanceof Object))
            return;

        this.Identifier = value.Identifier;
        this.Name = value.Name;
        this.Surname = value.Surname;
        this.Gender = value.Gender;
        this.Guid = value.Guid;
        this.CreatedOn = value.CreatedOn;
    }

    static from(obj: any): PersonViewModel {
        return Object.assign(new PersonViewModel(), obj);
    }
}

/**
 * Represents a Student in a school.
 * @typedef {Object} StudentViewModel
 * @extends PersonViewModel
 */
export class StudentViewModel extends PersonViewModel {
    /** What Grade the Student is in. */
    Grade: number;
    /** The name of the School. */
    School: SchoolViewModel | null;
    /** The Identifier that this Model refers to. */
    Identifier: string;
    /** The Name of the person. */
    Name: string;
    /** The Surname of the person. */
    Surname: string;
    /** The Gender of the person. */
    Gender: Gender | number;
    Guid: string;
    CreatedOn: Date;

    constructor();
    constructor(value?: any) {
        super();

        if (!(value instanceof Object))
            return;

        this.Grade = value.Grade;
        this.School = value.School;
        this.Identifier = value.Identifier;
        this.Name = value.Name;
        this.Surname = value.Surname;
        this.Gender = value.Gender;
        this.Guid = value.Guid;
        this.CreatedOn = value.CreatedOn;
    }

    static from(obj: any): StudentViewModel {
        return Object.assign(new StudentViewModel(), obj);
    }
}

/**
 * Basic information about a School.
 * @typedef {Object} SchoolViewModel
 * @extends ViewModel
 */
export class SchoolViewModel extends ViewModel {
    /** The Name of this SchoolViewModel. */
    Name: string;
    /** The Owner of this SchoolViewModel. */
    Owner: PersonViewModel | null;
    /** The AmountOfStudents of this SchoolViewModel. */
    AmountOfStudents: number;
    /** The Address of this SchoolViewModel. */
    Address: string;
    /** The ZipCode of this SchoolViewModel. */
    ZipCode: string;
    /** The HouseNumber of this SchoolViewModel. */
    HouseNumber: number;
    /** The HouseNumberAddition of this SchoolViewModel. */
    HouseNumberAddition: string;
    /** The Students of this SchoolViewModel. */
    Students: Array<StudentViewModel | null>;
    Guid: string;
    CreatedOn: Date;

    constructor();
    constructor(value?: any) {
        super();

        if (!(value instanceof Object))
            return;

        this.Name = value.Name;
        this.Owner = value.Owner;
        this.AmountOfStudents = value.AmountOfStudents;
        this.Address = value.Address;
        this.ZipCode = value.ZipCode;
        this.HouseNumber = value.HouseNumber;
        this.HouseNumberAddition = value.HouseNumberAddition;
        this.Students = value.Students;
        this.Guid = value.Guid;
        this.CreatedOn = value.CreatedOn;
    }

    static from(obj: any): SchoolViewModel {
        return Object.assign(new SchoolViewModel(), obj);
    }
}

/**
 * Simple model to verify complex types.
 * @typedef {Object} TypeModel
 * @extends ViewModel
 */
export class TypeModel extends ViewModel {
    /** A nullable boolean. */
    NullableBool: boolean;
    Guid: string;
    Student: StudentViewModel | null;
    Students: Array<StudentViewModel | null>;
    StudentPerClass: Array<Array<StudentViewModel | null>>;
    CreatedOn: Date;
    /** A readonly string. */
    ReadonlyString: string;

    constructor();
    constructor(value?: any) {
        super();

        if (!(value instanceof Object))
            return;

        this.NullableBool = value.NullableBool;
        this.Guid = value.Guid;
        this.Student = value.Student;
        this.Students = value.Students;
        this.StudentPerClass = value.StudentPerClass;
        this.CreatedOn = value.CreatedOn;
        this.ReadonlyString = value.ReadonlyString;
    }

    static from(obj: any): TypeModel {
        return Object.assign(new TypeModel(), obj);
    }
}

