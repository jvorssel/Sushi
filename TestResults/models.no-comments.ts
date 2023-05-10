export enum Gender {
    Undefined = 0,
    Male = 1,
    Female = 2
}

export class ViewModel {
    guid = "a872c2e8-a016-44ee-9b71-acb4cadff9e0";
    createdOn = null;

    constructor(value?: Partial<ViewModel>) {
        if (value) {
            this.guid = value.guid;
            this.createdOn = value.createdOn;
        }
    }
}

export class PersonViewModel extends ViewModel {
    identifier!: string;
    name!: string;
    surname!: string;
    gender!: Gender | number;

    constructor(value?: Partial<PersonViewModel>) {
        super(value);

        if (value) {
            this.identifier = value.identifier;
            this.name = value.name;
            this.surname = value.surname;
            this.gender = value.gender;
            this.guid = value.guid;
            this.createdOn = value.createdOn;
        }
    }
}

export class StudentViewModel extends PersonViewModel {
    grade = 9;
    school!: SchoolViewModel;

    constructor(value?: Partial<StudentViewModel>) {
        super(value);

        if (value) {
            this.grade = value.grade;
            this.school = value.school;
            this.identifier = value.identifier;
            this.name = value.name;
            this.surname = value.surname;
            this.gender = value.gender;
            this.guid = value.guid;
            this.createdOn = value.createdOn;
        }
    }
}

export class SchoolViewModel extends ViewModel {
    name!: string;
    owner!: PersonViewModel;
    amountOfStudents = 0;
    address = "";
    zipCode!: string;
    houseNumber = 0;
    houseNumberAddition!: string;
    averageGrade = 2.6666666666666;
    students = [];
    timmy = {} as StudentViewModel;

    constructor(value?: Partial<SchoolViewModel>) {
        super(value);

        if (value) {
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
            this.guid = value.guid;
            this.createdOn = value.createdOn;
        }
    }
}

export class TypeModel extends ViewModel {
    nullableBool!: boolean | null;
    nullableString!: string;
    student = {} as StudentViewModel;
    students = [];
    studentPerClass = [];
    readonlyString!: string;

    constructor(value?: Partial<TypeModel>) {
        super(value);

        if (value) {
            this.nullableBool = value.nullableBool;
            this.nullableString = value.nullableString;
            this.guid = value.guid;
            this.student = value.student;
            this.students = value.students;
            this.studentPerClass = value.studentPerClass;
            this.createdOn = value.createdOn;
            this.readonlyString = value.readonlyString;
        }
    }
}

export class AbstractBaseModel {
    name!: string;

    constructor(value?: Partial<AbstractBaseModel>) {
        if (value) {
            this.name = value.name;
        }
    }
}

export class AbstractParentModel extends AbstractBaseModel {
    surname!: string;

    constructor(value?: Partial<AbstractParentModel>) {
        super(value);

        if (value) {
            this.surname = value.surname;
            this.name = value.name;
        }
    }
}

export class NoXmlDocumentationModel {
    name!: string;

    constructor(value?: Partial<NoXmlDocumentationModel>) {
        if (value) {
            this.name = value.name;
        }
    }
}

