export enum Gender {
    Undefined = 0,
    Male = 1,
    Female = 2
}

export class ViewModel {
    guid: string = "629a3ed4-5e08-4f0c-8f29-70a67c89af1a";
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

export class PersonViewModel extends ViewModel {
    identifier!: string;
    name!: string;
    surname!: string;
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

export class StudentViewModel extends PersonViewModel {
    grade: number = 9;
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

export class SchoolViewModel extends ViewModel {
    name!: string;
    owner!: PersonViewModel | null;
    amountOfStudents: number = 0;
    address: string = "";
    zipCode!: string;
    houseNumber: number = 0;
    houseNumberAddition!: string;
    averageGrade: number = 2.6666666666666666666666666667;
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

export class TypeModel extends ViewModel {
    nullableBool: boolean | null = null;
    nullableString!: string;
    student: StudentViewModel | null = null;
    students: Array<StudentViewModel | null> = [];
    studentPerClass: Array<Array<StudentViewModel | null>> = [];
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

