export enum Gender {
    Undefined = 0,
    Male = 1,
    Female = 2
}

export class ConstrainedGeneric<T> {
    data!: T;
    name!: string;

    constructor(value: any = null) {
        if (Object.hasOwnProperty(value, 'data'))
            this.data = value.data;

        if (Object.hasOwnProperty(value, 'name'))
            this.name = value.name;

    }
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
        if (Object.hasOwnProperty(value, 'first'))
            this.first = value.first;

        if (Object.hasOwnProperty(value, 'second'))
            this.second = value.second;

        if (Object.hasOwnProperty(value, 'totalAmount'))
            this.totalAmount = value.totalAmount;

    }
}

export class GenericStandalone<TEntry> {
    values: Array<TEntry> = [];
    totalAmount!: number;

    constructor(value: any = null) {
        if (Object.hasOwnProperty(value, 'values'))
            this.values = value.values;

        if (Object.hasOwnProperty(value, 'totalAmount'))
            this.totalAmount = value.totalAmount;

    }
}

export class ViewModel {
    guid!: string;
    createdOn!: Date | string | null;

    constructor(value: any = null) {
        if (Object.hasOwnProperty(value, 'guid'))
            this.guid = value.guid;

        if (Object.hasOwnProperty(value, 'createdOn'))
            this.createdOn = value.createdOn;

    }
}

export class BaseViewModel extends ViewModel {
    value: string = "base";
    base: boolean = true;

    constructor(value: any = null) {
        super(value);

        if (Object.hasOwnProperty(value, 'value'))
            this.value = value.value;

        if (Object.hasOwnProperty(value, 'guid'))
            this.guid = value.guid;

        if (Object.hasOwnProperty(value, 'base'))
            this.base = value.base;

        if (Object.hasOwnProperty(value, 'createdOn'))
            this.createdOn = value.createdOn;

    }
}

export class InheritedViewModel extends BaseViewModel {
    guid: string = "new guid";
    addition: string = "added";

    constructor(value: any = null) {
        super(value);

        if (Object.hasOwnProperty(value, 'value'))
            this.value = value.value;

        if (Object.hasOwnProperty(value, 'guid'))
            this.guid = value.guid;

        if (Object.hasOwnProperty(value, 'addition'))
            this.addition = value.addition;

        if (Object.hasOwnProperty(value, 'guid'))
            this.guid = value.guid;

        if (Object.hasOwnProperty(value, 'base'))
            this.base = value.base;

        if (Object.hasOwnProperty(value, 'createdOn'))
            this.createdOn = value.createdOn;

    }
}

export class PersonViewModel extends ViewModel {
    identifier: string = "1fd3a8c1-6841-4675-a466-bf2535756af4";
    name!: string;
    surname!: string;
    gender: Gender | number = 1;

    constructor(value: any = null) {
        super(value);

        if (Object.hasOwnProperty(value, 'identifier'))
            this.identifier = value.identifier;

        if (Object.hasOwnProperty(value, 'name'))
            this.name = value.name;

        if (Object.hasOwnProperty(value, 'surname'))
            this.surname = value.surname;

        if (Object.hasOwnProperty(value, 'gender'))
            this.gender = value.gender;

        if (Object.hasOwnProperty(value, 'guid'))
            this.guid = value.guid;

        if (Object.hasOwnProperty(value, 'createdOn'))
            this.createdOn = value.createdOn;

    }
}

export class StudentViewModel extends PersonViewModel {
    grade: number = 9;
    school!: SchoolViewModel;

    constructor(value: any = null) {
        super(value);

        if (Object.hasOwnProperty(value, 'grade'))
            this.grade = value.grade;

        if (Object.hasOwnProperty(value, 'school'))
            this.school = value.school;

        if (Object.hasOwnProperty(value, 'identifier'))
            this.identifier = value.identifier;

        if (Object.hasOwnProperty(value, 'name'))
            this.name = value.name;

        if (Object.hasOwnProperty(value, 'surname'))
            this.surname = value.surname;

        if (Object.hasOwnProperty(value, 'gender'))
            this.gender = value.gender;

        if (Object.hasOwnProperty(value, 'guid'))
            this.guid = value.guid;

        if (Object.hasOwnProperty(value, 'createdOn'))
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

        if (Object.hasOwnProperty(value, 'name'))
            this.name = value.name;

        if (Object.hasOwnProperty(value, 'amountOfStudents'))
            this.amountOfStudents = value.amountOfStudents;

        if (Object.hasOwnProperty(value, 'owner'))
            this.owner = value.owner;

        if (Object.hasOwnProperty(value, 'address'))
            this.address = value.address;

        if (Object.hasOwnProperty(value, 'zipCode'))
            this.zipCode = value.zipCode;

        if (Object.hasOwnProperty(value, 'houseNumber'))
            this.houseNumber = value.houseNumber;

        if (Object.hasOwnProperty(value, 'houseNumberAddition'))
            this.houseNumberAddition = value.houseNumberAddition;

        if (Object.hasOwnProperty(value, 'averageGrade'))
            this.averageGrade = value.averageGrade;

        if (Object.hasOwnProperty(value, 'students'))
            this.students = value.students;

        if (Object.hasOwnProperty(value, 'timmy'))
            this.timmy = value.timmy;

        if (Object.hasOwnProperty(value, 'guid'))
            this.guid = value.guid;

        if (Object.hasOwnProperty(value, 'createdOn'))
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

        if (Object.hasOwnProperty(value, 'nullableBool'))
            this.nullableBool = value.nullableBool;

        if (Object.hasOwnProperty(value, 'nullableString'))
            this.nullableString = value.nullableString;

        if (Object.hasOwnProperty(value, 'guid'))
            this.guid = value.guid;

        if (Object.hasOwnProperty(value, 'date'))
            this.date = value.date;

        if (Object.hasOwnProperty(value, 'student'))
            this.student = value.student;

        if (Object.hasOwnProperty(value, 'students'))
            this.students = value.students;

        if (Object.hasOwnProperty(value, 'studentPerClass'))
            this.studentPerClass = value.studentPerClass;

        if (Object.hasOwnProperty(value, 'createdOn'))
            this.createdOn = value.createdOn;

    }
}

export class AbstractBaseModel {
    name!: string;

    constructor(value: any = null) {
        if (Object.hasOwnProperty(value, 'name'))
            this.name = value.name;

    }
}

export class AbstractParentModel extends AbstractBaseModel {
    surname!: string;

    constructor(value: any = null) {
        super(value);

        if (Object.hasOwnProperty(value, 'surname'))
            this.surname = value.surname;

        if (Object.hasOwnProperty(value, 'name'))
            this.name = value.name;

    }
}

export class CtorFixModel {
    name!: string;

    constructor(value: any = null) {
        if (Object.hasOwnProperty(value, 'name'))
            this.name = value.name;

    }
}

export class NoXmlDocumentationModel {
    readonly name!: string;


}

