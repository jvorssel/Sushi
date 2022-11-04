/**
 * Sushi.Tests.Models.ViewModel.
 * @typedef {Object} ViewModel
 */
class ViewModel {
    Guid;
    CreatedOn;

    constructor(value) {
        if (!(value instanceof Object)) value = {};
        this.Guid = value.Guid;
        this.CreatedOn = value.CreatedOn;
    }
}

/**
 * The PersonViewModel that represents a Person.
 * @typedef {Object} PersonViewModel
 * @extends ViewModel
 */
class PersonViewModel extends ViewModel {
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

        if (!(value instanceof Object)) value = {};
        this.Identifier = value.Identifier;
        this.Name = value.Name;
        this.Surname = value.Surname;
        this.Gender = value.Gender;
        this.Guid = value.Guid;
        this.CreatedOn = value.CreatedOn;
    }
}

/**
 * Represents a Student in a school.
 * @typedef {Object} StudentViewModel
 * @extends PersonViewModel
 */
class StudentViewModel extends PersonViewModel {
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

        if (!(value instanceof Object)) value = {};
        this.Grade = value.Grade;
        this.School = value.School;
        this.Identifier = value.Identifier;
        this.Name = value.Name;
        this.Surname = value.Surname;
        this.Gender = value.Gender;
        this.Guid = value.Guid;
        this.CreatedOn = value.CreatedOn;
    }
}

/**
 * Basic information about a School.
 * @typedef {Object} SchoolViewModel
 * @extends ViewModel
 */
class SchoolViewModel extends ViewModel {
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

        if (!(value instanceof Object)) value = {};
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
}

/**
 * Simple model to verify complex types.
 * @typedef {Object} TypeModel
 * @extends ViewModel
 */
class TypeModel extends ViewModel {
    /** A nullable boolean. */
    NullableBool;
    Guid;
    CreatedOn;
    /** A readonly string. */
    ReadonlyString;

    constructor(value) {
        super(value);

        if (!(value instanceof Object)) value = {};
        this.NullableBool = value.NullableBool;
        this.Guid = value.Guid;
        this.CreatedOn = value.CreatedOn;
        this.ReadonlyString = value.ReadonlyString;
    }
}

