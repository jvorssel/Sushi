export enum Gender {
    Undefined = 0,
    Male = 1,
    Female = 2
}

export class GenericComplexStandalone<TFirst, TSecond> {
    first: Array<TFirst> = [];
    second: Array<TSecond> = [];
    totalAmount!: number;

    constructor(value?: any) {
        if (value) {
            this.first = value.first;
            this.second = value.second;
            this.totalAmount = value.totalAmount;
        }
    }
}

export class GenericStandalone<TEntry> {
    values: Array<TEntry> = [];
    totalAmount!: number;

    constructor(value?: any) {
        if (value) {
            this.values = value.values;
            this.totalAmount = value.totalAmount;
        }
    }
}

export class ViewModel {
    guid!: string;
    createdOn!: Date | string | null;

    constructor(value?: any) {
        if (value) {
            this.guid = value.guid;
            this.createdOn = value.createdOn;
        }
    }
}

export class PersonViewModel extends ViewModel {
    identifier: string = "edb5fa48-eed6-4174-9a33-30a53248e877";
    name!: string;
    surname!: string;
    gender: Gender | number = 1;

    constructor(value?: any) {
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
    grade: number = 9;
    school!: SchoolViewModel;

    constructor(value?: any) {
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
    amountOfStudents: number = 0;
    owner!: PersonViewModel;
    address: string = "";
    zipCode!: string;
    houseNumber: number = 0;
    houseNumberAddition!: string;
    averageGrade: number = 2.6666666666666;
    students: Array<StudentViewModel> = [];
    timmy: StudentViewModel = new StudentViewModel();

    constructor(value?: any) {
        super(value);

        if (value) {
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
            this.guid = value.guid;
            this.createdOn = value.createdOn;
        }
    }
}

export class TypeModel extends ViewModel {
    nullableBool!: boolean | null;
    nullableString!: string;
    date: Date | string | null = null;
    student: StudentViewModel = new StudentViewModel();
    students: Array<StudentViewModel> = [];
    studentPerClass: Array<Array<StudentViewModel>> = [];
    readonlyString!: string;

    constructor(value?: any) {
        super(value);

        if (value) {
            this.nullableBool = value.nullableBool;
            this.nullableString = value.nullableString;
            this.guid = value.guid;
            this.date = value.date;
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

    constructor(value?: any) {
        if (value) {
            this.name = value.name;
        }
    }
}

export class AbstractParentModel extends AbstractBaseModel {
    surname!: string;

    constructor(value?: any) {
        super(value);

        if (value) {
            this.surname = value.surname;
            this.name = value.name;
        }
    }
}

export class NoXmlDocumentationModel {
    name!: string;

    constructor(value?: any) {
        if (value) {
            this.name = value.name;
        }
    }
}

