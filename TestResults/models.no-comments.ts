export enum Gender {
    Undefined = 0,
    Male = 1,
    Female = 2
}

export class ConstValues {
    static readonly static: string = "Static";
    static readonly first: string = "First";
    static readonly last: string = "Last";


}

export class GenericComplexStandalone<TFirst, TSecond> {
    first: Array<TFirst> = [];
    second: Array<TSecond> = [];
    totalAmount!: number;

    constructor(value: any = null) {
        if (value?.hasOwnProperty('first'))
            this.first = value.first;

        if (value?.hasOwnProperty('second'))
            this.second = value.second;

        if (value?.hasOwnProperty('totalAmount'))
            this.totalAmount = value.totalAmount;

    }
}

export class GenericStandalone<TEntry> {
    values: Array<TEntry> = [];
    totalAmount!: number;

    constructor(value: any = null) {
        if (value?.hasOwnProperty('values'))
            this.values = value.values;

        if (value?.hasOwnProperty('totalAmount'))
            this.totalAmount = value.totalAmount;

    }
}

export class ViewModel {
    guid!: string;
    createdOn!: Date | string | null;

    constructor(value: any = null) {
        if (value?.hasOwnProperty('guid'))
            this.guid = value.guid;

        if (value?.hasOwnProperty('createdOn'))
            this.createdOn = value.createdOn;

    }
}

export class BaseViewModel extends ViewModel {
    value: string = "base";
    base: boolean = true;

    constructor(value: any = null) {
        super(value);

        if (value?.hasOwnProperty('value'))
            this.value = value.value;

        if (value?.hasOwnProperty('guid'))
            this.guid = value.guid;

        if (value?.hasOwnProperty('base'))
            this.base = value.base;

        if (value?.hasOwnProperty('createdOn'))
            this.createdOn = value.createdOn;

    }
}

export class InheritedViewModel extends BaseViewModel {
    guid: string = "new guid";
    addition: string = "added";

    constructor(value: any = null) {
        super(value);

        if (value?.hasOwnProperty('value'))
            this.value = value.value;

        if (value?.hasOwnProperty('guid'))
            this.guid = value.guid;

        if (value?.hasOwnProperty('addition'))
            this.addition = value.addition;

        if (value?.hasOwnProperty('guid'))
            this.guid = value.guid;

        if (value?.hasOwnProperty('base'))
            this.base = value.base;

        if (value?.hasOwnProperty('createdOn'))
            this.createdOn = value.createdOn;

    }
}

export class PersonViewModel extends ViewModel {
    identifier: string = "361641f4-2a86-4120-8601-99ba3c270a02";
    name!: string;
    surname!: string;
    gender: Gender | number = 1;

    constructor(value: any = null) {
        super(value);

        if (value?.hasOwnProperty('identifier'))
            this.identifier = value.identifier;

        if (value?.hasOwnProperty('name'))
            this.name = value.name;

        if (value?.hasOwnProperty('surname'))
            this.surname = value.surname;

        if (value?.hasOwnProperty('gender'))
            this.gender = value.gender;

        if (value?.hasOwnProperty('guid'))
            this.guid = value.guid;

        if (value?.hasOwnProperty('createdOn'))
            this.createdOn = value.createdOn;

    }
}

export class StudentViewModel extends PersonViewModel {
    grade: number = 9;
    school!: SchoolViewModel;

    constructor(value: any = null) {
        super(value);

        if (value?.hasOwnProperty('grade'))
            this.grade = value.grade;

        if (value?.hasOwnProperty('school'))
            this.school = value.school;

        if (value?.hasOwnProperty('identifier'))
            this.identifier = value.identifier;

        if (value?.hasOwnProperty('name'))
            this.name = value.name;

        if (value?.hasOwnProperty('surname'))
            this.surname = value.surname;

        if (value?.hasOwnProperty('gender'))
            this.gender = value.gender;

        if (value?.hasOwnProperty('guid'))
            this.guid = value.guid;

        if (value?.hasOwnProperty('createdOn'))
            this.createdOn = value.createdOn;

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

    constructor(value: any = null) {
        super(value);

        if (value?.hasOwnProperty('name'))
            this.name = value.name;

        if (value?.hasOwnProperty('amountOfStudents'))
            this.amountOfStudents = value.amountOfStudents;

        if (value?.hasOwnProperty('owner'))
            this.owner = value.owner;

        if (value?.hasOwnProperty('address'))
            this.address = value.address;

        if (value?.hasOwnProperty('zipCode'))
            this.zipCode = value.zipCode;

        if (value?.hasOwnProperty('houseNumber'))
            this.houseNumber = value.houseNumber;

        if (value?.hasOwnProperty('houseNumberAddition'))
            this.houseNumberAddition = value.houseNumberAddition;

        if (value?.hasOwnProperty('averageGrade'))
            this.averageGrade = value.averageGrade;

        if (value?.hasOwnProperty('students'))
            this.students = value.students;

        if (value?.hasOwnProperty('timmy'))
            this.timmy = value.timmy;

        if (value?.hasOwnProperty('guid'))
            this.guid = value.guid;

        if (value?.hasOwnProperty('createdOn'))
            this.createdOn = value.createdOn;

    }
}

export class TypeModel extends ViewModel {
    nullableBool: boolean | null = null;
    nullableString!: string;
    date: Date | string | null = null;
    student: StudentViewModel = new StudentViewModel();
    students: Array<StudentViewModel> = [];
    studentPerClass: { [key: string]: Array<StudentViewModel> } = {};
    static readonly readonlyString!: string;

    constructor(value: any = null) {
        super(value);

        if (value?.hasOwnProperty('nullableBool'))
            this.nullableBool = value.nullableBool;

        if (value?.hasOwnProperty('nullableString'))
            this.nullableString = value.nullableString;

        if (value?.hasOwnProperty('guid'))
            this.guid = value.guid;

        if (value?.hasOwnProperty('date'))
            this.date = value.date;

        if (value?.hasOwnProperty('student'))
            this.student = value.student;

        if (value?.hasOwnProperty('students'))
            this.students = value.students;

        if (value?.hasOwnProperty('studentPerClass'))
            this.studentPerClass = value.studentPerClass;

        if (value?.hasOwnProperty('createdOn'))
            this.createdOn = value.createdOn;

    }
}

export class AbstractBaseModel {
    name!: string;

    constructor(value: any = null) {
        if (value?.hasOwnProperty('name'))
            this.name = value.name;

    }
}

export class AbstractParentModel extends AbstractBaseModel {
    surname!: string;

    constructor(value: any = null) {
        super(value);

        if (value?.hasOwnProperty('surname'))
            this.surname = value.surname;

        if (value?.hasOwnProperty('name'))
            this.name = value.name;

    }
}

export class CtorFixModel {
    name!: string;

    constructor(value: any = null) {
        if (value?.hasOwnProperty('name'))
            this.name = value.name;

    }
}

export class NoXmlDocumentationModel {
    readonly name!: string;


}

