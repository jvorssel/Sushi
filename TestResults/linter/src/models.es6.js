/**
 * Sushi.Tests.Models.ConstrainedGeneric`1
 * @template {any} T
 */
export class ConstrainedGeneric {
    Data;
    Name;

    constructor(value) {
        if (!(value instanceof Object))
            return;

        this.data = value.data;
        this.name = value.name;
    }
    static mapFrom(obj) {
        return Object.assign(new {model.Name}(), obj);
    }
}

/**
 * A class with const values.
 * Sushi.Tests.Models.ConstValues
 */
export class ConstValues {

    /**
     * A Static value.
     */
    Static;

    /**
     * The First value.
     */
    First;

    /**
     * The Last value.
     */
    Last;

    constructor(value) {
        if (!(value instanceof Object))
            return;

        this.static = value.static;
        this.first = value.first;
        this.last = value.last;
    }
    static mapFrom(obj) {
        return Object.assign(new {model.Name}(), obj);
    }
}

/**
 * Sushi.Tests.Models.GenericComplexStandalone`2
 * @template {any} TFirst
 * @template {any} TSecond
 */
export class GenericComplexStandalone {
    First;
    Second;
    TotalAmount;

    constructor(value) {
        if (!(value instanceof Object))
            return;

        this.first = value.first;
        this.second = value.second;
        this.totalAmount = value.totalAmount;
    }
    static mapFrom(obj) {
        return Object.assign(new {model.Name}(), obj);
    }
}

/**
 * Sushi.Tests.Models.GenericStandalone`1
 * @template {any} TEntry
 */
export class GenericStandalone {
    Values;
    TotalAmount;

    constructor(value) {
        if (!(value instanceof Object))
            return;

        this.values = value.values;
        this.totalAmount = value.totalAmount;
    }
    static mapFrom(obj) {
        return Object.assign(new {model.Name}(), obj);
    }
}

/**
 * The view model base class.
 * Sushi.Tests.Models.ViewModel
 */
export class ViewModel {

    /**
     * The view model identifier.
     */
    Guid;

    /**
     * When this view model was created.
     */
    CreatedOn;

    constructor(value) {
        if (!(value instanceof Object))
            return;

        this.guid = value.guid;
        this.createdOn = value.createdOn;
    }
    static mapFrom(obj) {
        return Object.assign(new {model.Name}(), obj);
    }
}

/**
 * Sushi.Tests.Models.BaseViewModel
 * @extends ViewModel
 */
export class BaseViewModel extends ViewModel {
    Value;
    Base;

    constructor(value) {
        super(value);

        if (!(value instanceof Object))
            return;

        this.value = value.value;
        this.base = value.base;
    }
    static mapFrom(obj) {
        return Object.assign(new {model.Name}(), obj);
    }
}

/**
 * Sushi.Tests.Models.InheritedViewModel
 * @extends BaseViewModel
 */
export class InheritedViewModel extends BaseViewModel {
    Guid;
    Addition;

    constructor(value) {
        super(value);

        if (!(value instanceof Object))
            return;

        this.guid = value.guid;
        this.addition = value.addition;
    }
    static mapFrom(obj) {
        return Object.assign(new {model.Name}(), obj);
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
     */
    Identifier;

    /**
     * The Name of the person.
     */
    Name;

    /**
     * The Surname of the person.
     */
    Surname;

    /**
     * The Gender of the person.
     */
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
        return Object.assign(new {model.Name}(), obj);
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
     */
    Grade;

    /**
     * The name of the School.
     */
    School;

    constructor(value) {
        super(value);

        if (!(value instanceof Object))
            return;

        this.grade = value.grade;
        this.school = value.school;
    }
    static mapFrom(obj) {
        return Object.assign(new {model.Name}(), obj);
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
     */
    Name;

    /**
     * The AmountOfStudents of this SchoolViewModel.
     */
    AmountOfStudents;

    /**
     * The Owner of this SchoolViewModel.
     */
    Owner;

    /**
     * The Address of this SchoolViewModel.
     */
    Address;

    /**
     * The ZipCode of this SchoolViewModel.
     */
    ZipCode;

    /**
     * The HouseNumber of this SchoolViewModel.
     */
    HouseNumber;

    /**
     * The HouseNumberAddition of this SchoolViewModel.
     */
    HouseNumberAddition;

    /**
     * The school student aren't doing too great ...
     */
    AverageGrade;

    /**
     * The Students of this SchoolViewModel.
     */
    Students;
    Timmy;

    constructor(value) {
        super(value);

        if (!(value instanceof Object))
            return;

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
    }
    static mapFrom(obj) {
        return Object.assign(new {model.Name}(), obj);
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
     */
    NullableBool;

    /**
     * A nullable string, defaults to null.
     */
    NullableString;

    /**
     * A DateTime instance.
     */
    Date;
    Student;
    Students;
    StudentPerClass;

    /**
     * A readonly string.
     */
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
        return Object.assign(new {model.Name}(), obj);
    }
}

/**
 * Sushi.Tests.BugFixes.AbstractBaseClass+AbstractBaseModel
 */
export class AbstractBaseModel {
    Name;

    constructor(value) {
        if (!(value instanceof Object))
            return;

        this.name = value.name;
    }
    static mapFrom(obj) {
        return Object.assign(new {model.Name}(), obj);
    }
}

/**
 * Sushi.Tests.BugFixes.AbstractBaseClass+AbstractParentModel
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
        return Object.assign(new {model.Name}(), obj);
    }
}

/**
 * Sushi.Tests.BugFixes.NoParameterlessCtorTests+CtorFixModel
 */
export class CtorFixModel {
    Name;

    constructor(value) {
        if (!(value instanceof Object))
            return;

        this.name = value.name;
    }
    static mapFrom(obj) {
        return Object.assign(new {model.Name}(), obj);
    }
}

/**
 * Sushi.Tests.BugFixes.NoXmlDocumentation+NoXmlDocumentationModel
 */
export class NoXmlDocumentationModel {
    Name;

    constructor(value) {
        if (!(value instanceof Object))
            return;

        this.name = value.name;
    }
    static mapFrom(obj) {
        return Object.assign(new {model.Name}(), obj);
    }
}

