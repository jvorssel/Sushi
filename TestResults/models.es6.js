
/**
 * Sushi.Tests.Models.ViewModel
 * @typedef {Object} ViewModel
 */
export class ViewModel {
    Guid;
    CreatedOn;

    constructor(value) {
        if (!(value instanceof Object))
            return;

        this.guid = value.guid;
        this.createdOn = value.createdOn;
    }

    static mapFrom(obj) {
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

    constructor(value) {
        super(value);

        if (!(value instanceof Object))
            return;

        this.identifier = value.identifier;
        this.name = value.name;
        this.surname = value.surname;
        this.gender = value.gender;
    }

    static mapFrom(obj) {
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

    constructor(value) {
        super(value);

        if (!(value instanceof Object))
            return;

        this.grade = value.grade;
        this.school = value.school;
    }

    static mapFrom(obj) {
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
    /** The school student aren't doing too great ... */
    AverageGrade;
    /** The Students of this SchoolViewModel. */
    Students;
    Timmy;

    constructor(value) {
        super(value);

        if (!(value instanceof Object))
            return;

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
    }

    static mapFrom(obj) {
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
    /** A nullable string, defaults to null. */
    NullableString;
    /** A DateTime instance. */
    Date;
    Student;
    Students;
    StudentPerClass;
    /** A readonly string. */
    ReadonlyString;

    constructor(value) {
        super(value);

        if (!(value instanceof Object))
            return;

        this.nullableBool = value.nullableBool;
        this.nullableString = value.nullableString;
        this.date = value.date;
        this.student = value.student;
        this.students = value.students;
        this.studentPerClass = value.studentPerClass;
        this.readonlyString = value.readonlyString;
    }

    static mapFrom(obj) {
        return Object.assign(new TypeModel(), obj);
    }
}

/**
 * Sushi.Tests.BugFixes.AbstractBaseClass+AbstractBaseModel
 * @typedef {Object} AbstractBaseModel
 */
export class AbstractBaseModel {
    Name;

    constructor(value) {
        if (!(value instanceof Object))
            return;

        this.name = value.name;
    }

    static mapFrom(obj) {
        return Object.assign(new AbstractBaseModel(), obj);
    }
}

/**
 * Sushi.Tests.BugFixes.AbstractBaseClass+AbstractParentModel
 * @typedef {Object} AbstractParentModel
 * @extends AbstractBaseModel 
 */
export class AbstractParentModel extends AbstractBaseModel {
    Surname;

    constructor(value) {
        super(value);

        if (!(value instanceof Object))
            return;

        this.surname = value.surname;
    }

    static mapFrom(obj) {
        return Object.assign(new AbstractParentModel(), obj);
    }
}

/**
 * Sushi.Tests.BugFixes.NoXmlDocumentation+NoXmlDocumentationModel
 * @typedef {Object} NoXmlDocumentationModel
 */
export class NoXmlDocumentationModel {
    Name;

    constructor(value) {
        if (!(value instanceof Object))
            return;

        this.name = value.name;
    }

    static mapFrom(obj) {
        return Object.assign(new NoXmlDocumentationModel(), obj);
    }
}

