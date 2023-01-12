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
    Guid: string = "7f7a2fe0-95a2-49ae-90dd-a6b1da21ec5a";
    CreatedOn: Date | string | null = null;

    public constructor(value?: any) {
        if (!(value instanceof Object))
            return;

        this.Guid = value.Guid;
        this.CreatedOn = value.CreatedOn;
    }

    static mapFrom(obj: any): ViewModel {
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
    Identifier!: string;
    /** The Name of the person. */
    Name!: string;
    /** The Surname of the person. */
    Surname!: string;
    /** The Gender of the person. */
    Gender!: Gender | number;

    public constructor(value?: any) {
        super(value);

        if (!(value instanceof Object))
            return;

        this.Identifier = value.Identifier;
        this.Name = value.Name;
        this.Surname = value.Surname;
        this.Gender = value.Gender;
    }

    static mapFrom(obj: any): PersonViewModel {
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
    Grade: number = 9;
    /** The name of the School. */
    School!: SchoolViewModel | null;

    public constructor(value?: any) {
        super(value);

        if (!(value instanceof Object))
            return;

        this.Grade = value.Grade;
        this.School = value.School;
    }

    static mapFrom(obj: any): StudentViewModel {
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
    Name!: string;
    /** The Owner of this SchoolViewModel. */
    Owner!: PersonViewModel | null;
    /** The AmountOfStudents of this SchoolViewModel. */
    AmountOfStudents: number = 0;
    /** The Address of this SchoolViewModel. */
    Address: string = "";
    /** The ZipCode of this SchoolViewModel. */
    ZipCode!: string;
    /** The HouseNumber of this SchoolViewModel. */
    HouseNumber: number = 0;
    /** The HouseNumberAddition of this SchoolViewModel. */
    HouseNumberAddition!: string;
    /** The school student aren't doing too great ... */
    AverageGrade: number = 2.6666666666666666666666666667;
    /** The Students of this SchoolViewModel. */
    Students: Array<StudentViewModel | null> = [];
    Timmy: StudentViewModel | null = null;

    public constructor(value?: any) {
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
        this.AverageGrade = value.AverageGrade;
        this.Students = value.Students;
        this.Timmy = value.Timmy;
    }

    static mapFrom(obj: any): SchoolViewModel {
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
    NullableBool: boolean | null = null;
    /** A nullable string, defaults to null. */
    NullableString!: string;
    Student: StudentViewModel | null = null;
    Students: Array<StudentViewModel | null> = [];
    StudentPerClass: Array<Array<StudentViewModel | null>> = [];
    /** A readonly string. */
    ReadonlyString!: string;

    public constructor(value?: any) {
        super(value);

        if (!(value instanceof Object))
            return;

        this.NullableBool = value.NullableBool;
        this.NullableString = value.NullableString;
        this.Student = value.Student;
        this.Students = value.Students;
        this.StudentPerClass = value.StudentPerClass;
        this.ReadonlyString = value.ReadonlyString;
    }

    static mapFrom(obj: any): TypeModel {
        return Object.assign(new TypeModel(), obj);
    }
}

/**
 * Sushi.Tests.BugFixes.AbstractBaseClass+AbstractBaseModel
 * @typedef {Object} AbstractBaseModel
 */
export class AbstractBaseModel {
    Name!: string;

    public constructor(value?: any) {
        if (!(value instanceof Object))
            return;

        this.Name = value.Name;
    }

    static mapFrom(obj: any): AbstractBaseModel {
        return Object.assign(new AbstractBaseModel(), obj);
    }
}

/**
 * Sushi.Tests.BugFixes.AbstractBaseClass+AbstractParentModel
 * @typedef {Object} AbstractParentModel
 * @extends AbstractBaseModel 
 */
export class AbstractParentModel extends AbstractBaseModel {
    Surname!: string;

    public constructor(value?: any) {
        super(value);

        if (!(value instanceof Object))
            return;

        this.Surname = value.Surname;
    }

    static mapFrom(obj: any): AbstractParentModel {
        return Object.assign(new AbstractParentModel(), obj);
    }
}

/**
 * Sushi.Tests.BugFixes.NoXmlDocumentation+NoXmlDocumentationModel
 * @typedef {Object} NoXmlDocumentationModel
 */
export class NoXmlDocumentationModel {
    Name!: string;

    public constructor(value?: any) {
        if (!(value instanceof Object))
            return;

        this.Name = value.Name;
    }

    static mapFrom(obj: any): NoXmlDocumentationModel {
        return Object.assign(new NoXmlDocumentationModel(), obj);
    }
}

