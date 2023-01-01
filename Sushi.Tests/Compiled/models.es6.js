/**
 * Sushi.Tests.Models.ViewModel.
 * @typedef {Object} ViewModel
 */
export class ViewModel {
    Guid;
    CreatedOn;

    constructor(value) {
        if (!(value instanceof Object))
            return;

        this.Guid = value.Guid;
        this.CreatedOn = value.CreatedOn;
    }

    static from(obj) {
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
    Identifier;
    /** The Name of the person. */
    Name;
    /** The Surname of the person. */
    Surname;
    /** The Gender of the person. */
    Gender;
    Guid;
    CreatedOn;

    constructor(value) {
        super(value);

        if (!(value instanceof Object))
            return;

        this.Identifier = value.Identifier;
        this.Name = value.Name;
        this.Surname = value.Surname;
        this.Gender = value.Gender;
        this.Guid = value.Guid;
        this.CreatedOn = value.CreatedOn;
    }

    static from(obj) {
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
    Grade;
    /** The name of the School. */
    School;
    /** The Identifier that this Model refers to. */
    Identifier;
    /** The Name of the person. */
    Name;
    /** The Surname of the person. */
    Surname;
    /** The Gender of the person. */
    Gender;
    Guid;
    CreatedOn;

    constructor(value) {
        super(value);

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

    static from(obj) {
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
    Name;
    /** The Owner of this SchoolViewModel. */
    Owner;
    /** The AmountOfStudents of this SchoolViewModel. */
    AmountOfStudents;
    /** The Address of this SchoolViewModel. */
    Address;
    /** The ZipCode of this SchoolViewModel. */
    ZipCode;
    /** The HouseNumber of this SchoolViewModel. */
    HouseNumber;
    /** The HouseNumberAddition of this SchoolViewModel. */
    HouseNumberAddition;
    /** The Students of this SchoolViewModel. */
    Students;
    Guid;
    CreatedOn;

    constructor(value) {
        super(value);

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

    static from(obj) {
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
    NullableBool;
    Guid;
    Student;
    Students;
    StudentPerClass;
    CreatedOn;
    /** A readonly string. */
    ReadonlyString;

    constructor(value) {
        super(value);

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

    static from(obj) {
        return Object.assign(new TypeModel(), obj);
    }
}

