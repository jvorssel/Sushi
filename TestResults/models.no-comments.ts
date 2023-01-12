export enum Gender {
    Undefined = 0,
    Male = 1,
    Female = 2
}

export class ViewModel {
    Guid: string = "d7493bbb-f4b9-45f6-9a68-029e1645ac61";
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

export class PersonViewModel extends ViewModel {
    Identifier!: string;
    Name!: string;
    Surname!: string;
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

export class StudentViewModel extends PersonViewModel {
    Grade: number = 9;
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

export class SchoolViewModel extends ViewModel {
    Name!: string;
    Owner!: PersonViewModel | null;
    AmountOfStudents: number = 0;
    Address: string = "";
    ZipCode!: string;
    HouseNumber: number = 0;
    HouseNumberAddition!: string;
    AverageGrade: number = 2.6666666666666666666666666667;
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

export class TypeModel extends ViewModel {
    NullableBool: boolean | null = null;
    NullableString!: string;
    Student: StudentViewModel | null = null;
    Students: Array<StudentViewModel | null> = [];
    StudentPerClass: Array<Array<StudentViewModel | null>> = [];
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

