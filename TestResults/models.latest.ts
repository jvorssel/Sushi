/* eslint-disable @typescript-eslint/no-inferrable-types */
export enum Gender {
    Undefined = 0,
    Male = 1,
    Female = 2
}

/**
 * Sushi.Tests.Models.GenericComplexStandalone`2
 */
export class GenericComplexStandalone<TFirst, TSecond> {
    first: Array<TFirst> = [];
    second: Array<TSecond> = [];
    totalAmount!: number;

    constructor(value: object | null = null) {
        if (value?.hasOwnProperty('first'))
            this.first = value['first'];

        if (value?.hasOwnProperty('second'))
            this.second = value['second'];

        if (value?.hasOwnProperty('totalAmount'))
            this.totalAmount = value['totalAmount'];

    }
}

/**
 * Sushi.Tests.Models.GenericStandalone`1
 */
export class GenericStandalone<TEntry> {
    values: Array<TEntry> = [];
    totalAmount!: number;

    constructor(value: object | null = null) {
        if (value?.hasOwnProperty('values'))
            this.values = value['values'];

        if (value?.hasOwnProperty('totalAmount'))
            this.totalAmount = value['totalAmount'];

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

    constructor(value: object | null = null) {
        if (value?.hasOwnProperty('guid'))
            this.guid = value['guid'];

        if (value?.hasOwnProperty('createdOn'))
            this.createdOn = value['createdOn'];

    }
}

/**
 * Sushi.Tests.Models.BaseViewModel
 * @extends ViewModel 
 */
export class BaseViewModel extends ViewModel {
    value: string = "base";
    base: boolean = true;

    constructor(value: object | null = null) {
        super(value);

        if (value?.hasOwnProperty('value'))
            this.value = value['value'];

        if (value?.hasOwnProperty('guid'))
            this.guid = value['guid'];

        if (value?.hasOwnProperty('base'))
            this.base = value['base'];

        if (value?.hasOwnProperty('createdOn'))
            this.createdOn = value['createdOn'];

    }
}

/**
 * Sushi.Tests.Models.InheritedViewModel
 * @extends BaseViewModel 
 */
export class InheritedViewModel extends BaseViewModel {
    guid: string = "new guid";
    addition: string = "added";

    constructor(value: object | null = null) {
        super(value);

        if (value?.hasOwnProperty('value'))
            this.value = value['value'];

        if (value?.hasOwnProperty('guid'))
            this.guid = value['guid'];

        if (value?.hasOwnProperty('addition'))
            this.addition = value['addition'];

        if (value?.hasOwnProperty('guid'))
            this.guid = value['guid'];

        if (value?.hasOwnProperty('base'))
            this.base = value['base'];

        if (value?.hasOwnProperty('createdOn'))
            this.createdOn = value['createdOn'];

    }
}

/**
 * The PersonViewModel that represents a Person.
 * @extends ViewModel 
 */
export class PersonViewModel extends ViewModel {
    /** The Identifier that this Model refers to. */
    identifier: string = "a19f249f-69eb-4c9a-8d8a-125e53ac3a1c";
    /** The Name of the person. */
    name!: string;
    /** The Surname of the person. */
    surname!: string;
    /** The Gender of the person. */
    gender: Gender | number = 1;

    constructor(value: object | null = null) {
        super(value);

        if (value?.hasOwnProperty('identifier'))
            this.identifier = value['identifier'];

        if (value?.hasOwnProperty('name'))
            this.name = value['name'];

        if (value?.hasOwnProperty('surname'))
            this.surname = value['surname'];

        if (value?.hasOwnProperty('gender'))
            this.gender = value['gender'];

        if (value?.hasOwnProperty('guid'))
            this.guid = value['guid'];

        if (value?.hasOwnProperty('createdOn'))
            this.createdOn = value['createdOn'];

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

    constructor(value: object | null = null) {
        super(value);

        if (value?.hasOwnProperty('grade'))
            this.grade = value['grade'];

        if (value?.hasOwnProperty('school'))
            this.school = value['school'];

        if (value?.hasOwnProperty('identifier'))
            this.identifier = value['identifier'];

        if (value?.hasOwnProperty('name'))
            this.name = value['name'];

        if (value?.hasOwnProperty('surname'))
            this.surname = value['surname'];

        if (value?.hasOwnProperty('gender'))
            this.gender = value['gender'];

        if (value?.hasOwnProperty('guid'))
            this.guid = value['guid'];

        if (value?.hasOwnProperty('createdOn'))
            this.createdOn = value['createdOn'];

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

    constructor(value: object | null = null) {
        super(value);

        if (value?.hasOwnProperty('name'))
            this.name = value['name'];

        if (value?.hasOwnProperty('amountOfStudents'))
            this.amountOfStudents = value['amountOfStudents'];

        if (value?.hasOwnProperty('owner'))
            this.owner = value['owner'];

        if (value?.hasOwnProperty('address'))
            this.address = value['address'];

        if (value?.hasOwnProperty('zipCode'))
            this.zipCode = value['zipCode'];

        if (value?.hasOwnProperty('houseNumber'))
            this.houseNumber = value['houseNumber'];

        if (value?.hasOwnProperty('houseNumberAddition'))
            this.houseNumberAddition = value['houseNumberAddition'];

        if (value?.hasOwnProperty('averageGrade'))
            this.averageGrade = value['averageGrade'];

        if (value?.hasOwnProperty('students'))
            this.students = value['students'];

        if (value?.hasOwnProperty('timmy'))
            this.timmy = value['timmy'];

        if (value?.hasOwnProperty('guid'))
            this.guid = value['guid'];

        if (value?.hasOwnProperty('createdOn'))
            this.createdOn = value['createdOn'];

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
    studentPerClass: Array<Array<StudentViewModel>> = [];
    /** A readonly string. */
    readonlyString!: string;

    constructor(value: object | null = null) {
        super(value);

        if (value?.hasOwnProperty('nullableBool'))
            this.nullableBool = value['nullableBool'];

        if (value?.hasOwnProperty('nullableString'))
            this.nullableString = value['nullableString'];

        if (value?.hasOwnProperty('guid'))
            this.guid = value['guid'];

        if (value?.hasOwnProperty('date'))
            this.date = value['date'];

        if (value?.hasOwnProperty('student'))
            this.student = value['student'];

        if (value?.hasOwnProperty('students'))
            this.students = value['students'];

        if (value?.hasOwnProperty('studentPerClass'))
            this.studentPerClass = value['studentPerClass'];

        if (value?.hasOwnProperty('createdOn'))
            this.createdOn = value['createdOn'];

        if (value?.hasOwnProperty('readonlyString'))
            this.readonlyString = value['readonlyString'];

    }
}

/**
 * Sushi.Tests.BugFixes.AbstractBaseClass+AbstractBaseModel
 */
export class AbstractBaseModel {
    name!: string;

    constructor(value: object | null = null) {
        if (value?.hasOwnProperty('name'))
            this.name = value['name'];

    }
}

/**
 * Sushi.Tests.BugFixes.AbstractBaseClass+AbstractParentModel
 * @extends AbstractBaseModel 
 */
export class AbstractParentModel extends AbstractBaseModel {
    surname!: string;

    constructor(value: object | null = null) {
        super(value);

        if (value?.hasOwnProperty('surname'))
            this.surname = value['surname'];

        if (value?.hasOwnProperty('name'))
            this.name = value['name'];

    }
}

/**
 * Sushi.Tests.BugFixes.NoParameterlessCtorTests+CtorFixModel
 */
export class CtorFixModel {
    name!: string;

    constructor(value: object | null = null) {
        if (value?.hasOwnProperty('name'))
            this.name = value['name'];

    }
}

/**
 * Sushi.Tests.BugFixes.NoXmlDocumentation+NoXmlDocumentationModel
 */
export class NoXmlDocumentationModel {
    name!: string;

    constructor(value: object | null = null) {
        if (value?.hasOwnProperty('name'))
            this.name = value['name'];

    }
}

