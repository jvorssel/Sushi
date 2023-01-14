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
    guid: string = "f32cc365-a633-470f-80f0-2f53657df1d0";
    createdOn: Date | string | null = null;

    public constructor(value?: any) {
        if (!(value instanceof Object))
            return;

        this.guid = value.guid;
        this.createdOn = value.createdOn;
    }

    public static mapFrom(obj: any): ViewModel {
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
    identifier!: string;
    /** The Name of the person. */
    name!: string;
    /** The Surname of the person. */
    surname!: string;
    /** The Gender of the person. */
    gender!: Gender | number;

    public constructor(value?: any) {
        super(value);

        if (!(value instanceof Object))
            return;

        this.identifier = value.identifier;
        this.name = value.name;
        this.surname = value.surname;
        this.gender = value.gender;
    }

    public static override mapFrom(obj: any): PersonViewModel {
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
    grade: number = 9;
    /** The name of the School. */
    school!: SchoolViewModel | null;

    public constructor(value?: any) {
        super(value);

        if (!(value instanceof Object))
            return;

        this.grade = value.grade;
        this.school = value.school;
    }

    public static override mapFrom(obj: any): StudentViewModel {
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
    name!: string;
    /** The Owner of this SchoolViewModel. */
    owner!: PersonViewModel | null;
    /** The AmountOfStudents of this SchoolViewModel. */
    amountOfStudents: number = 0;
    /** The Address of this SchoolViewModel. */
    address: string = "";
    /** The ZipCode of this SchoolViewModel. */
    zipCode!: string;
    /** The HouseNumber of this SchoolViewModel. */
    houseNumber: number = 0;
    /** The HouseNumberAddition of this SchoolViewModel. */
    houseNumberAddition!: string;
    /** The school student aren't doing too great ... */
    averageGrade: number = 2.6666666666666666666666666667;
    /** The Students of this SchoolViewModel. */
    students: Array<StudentViewModel | null> = [];
    timmy: StudentViewModel | null = null;

    public constructor(value?: any) {
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

    public static override mapFrom(obj: any): SchoolViewModel {
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
    nullableBool: boolean | null = null;
    /** A nullable string, defaults to null. */
    nullableString!: string;
    student: StudentViewModel | null = null;
    students: Array<StudentViewModel | null> = [];
    studentPerClass: Array<Array<StudentViewModel | null>> = [];
    /** A readonly string. */
    readonlyString!: string;

    public constructor(value?: any) {
        super(value);

        if (!(value instanceof Object))
            return;

        this.nullableBool = value.nullableBool;
        this.nullableString = value.nullableString;
        this.student = value.student;
        this.students = value.students;
        this.studentPerClass = value.studentPerClass;
        this.readonlyString = value.readonlyString;
    }

    public static override mapFrom(obj: any): TypeModel {
        return Object.assign(new TypeModel(), obj);
    }
}

/**
 * Sushi.Tests.BugFixes.AbstractBaseClass+AbstractBaseModel
 * @typedef {Object} AbstractBaseModel
 */
export class AbstractBaseModel {
    name!: string;

    public constructor(value?: any) {
        if (!(value instanceof Object))
            return;

        this.name = value.name;
    }

    public static mapFrom(obj: any): AbstractBaseModel {
        return Object.assign(new AbstractBaseModel(), obj);
    }
}

/**
 * Sushi.Tests.BugFixes.AbstractBaseClass+AbstractParentModel
 * @typedef {Object} AbstractParentModel
 * @extends AbstractBaseModel 
 */
export class AbstractParentModel extends AbstractBaseModel {
    surname!: string;

    public constructor(value?: any) {
        super(value);

        if (!(value instanceof Object))
            return;

        this.surname = value.surname;
    }

    public static override mapFrom(obj: any): AbstractParentModel {
        return Object.assign(new AbstractParentModel(), obj);
    }
}

/**
 * Sushi.Tests.BugFixes.NoXmlDocumentation+NoXmlDocumentationModel
 * @typedef {Object} NoXmlDocumentationModel
 */
export class NoXmlDocumentationModel {
    name!: string;

    public constructor(value?: any) {
        if (!(value instanceof Object))
            return;

        this.name = value.name;
    }

    public static mapFrom(obj: any): NoXmlDocumentationModel {
        return Object.assign(new NoXmlDocumentationModel(), obj);
    }
}

