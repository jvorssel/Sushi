export enum Gender {
    Undefined = 0,
    Male = 1,
    Female = 2
}

export class ConstrainedGeneric<T> {
    data!: T;
    name!: string;

    constructor(value: any = null) {
        if (Object.prototype.hasOwnProperty.call(value, 'data'))
            this.data = value.data;

        if (Object.prototype.hasOwnProperty.call(value, 'name'))
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
        if (Object.prototype.hasOwnProperty.call(value, 'first'))
            this.first = value.first;

        if (Object.prototype.hasOwnProperty.call(value, 'second'))
            this.second = value.second;

        if (Object.prototype.hasOwnProperty.call(value, 'totalAmount'))
            this.totalAmount = value.totalAmount;

    }
}

export class GenericStandalone<TEntry> {
    values: Array<TEntry> = [];
    totalAmount!: number;

    constructor(value: any = null) {
        if (Object.prototype.hasOwnProperty.call(value, 'values'))
            this.values = value.values;

        if (Object.prototype.hasOwnProperty.call(value, 'totalAmount'))
            this.totalAmount = value.totalAmount;

    }
}

export class ViewModel {
    guid!: string;
    createdOn!: Date | string | null;

    constructor(value: any = null) {
        if (Object.prototype.hasOwnProperty.call(value, 'guid'))
            this.guid = value.guid;

        if (Object.prototype.hasOwnProperty.call(value, 'createdOn'))
            this.createdOn = value.createdOn;

    }
}

export class BaseViewModel extends ViewModel {
    value: string = "base";
    base: boolean = true;

    constructor(value: any = null) {
        super(value);

        if (Object.prototype.hasOwnProperty.call(value, 'value'))
            this.value = value.value;

        if (Object.prototype.hasOwnProperty.call(value, 'guid'))
            this.guid = value.guid;

        if (Object.prototype.hasOwnProperty.call(value, 'base'))
            this.base = value.base;

        if (Object.prototype.hasOwnProperty.call(value, 'createdOn'))
            this.createdOn = value.createdOn;

    }
}

export class InheritedViewModel extends BaseViewModel {
    override guid: string = "new guid";
    addition: string = "added";

    constructor(value: any = null) {
        super(value);

        if (Object.prototype.hasOwnProperty.call(value, 'value'))
            this.value = value.value;

        if (Object.prototype.hasOwnProperty.call(value, 'guid'))
            this.guid = value.guid;

        if (Object.prototype.hasOwnProperty.call(value, 'addition'))
            this.addition = value.addition;

        if (Object.prototype.hasOwnProperty.call(value, 'guid'))
            this.guid = value.guid;

        if (Object.prototype.hasOwnProperty.call(value, 'base'))
            this.base = value.base;

        if (Object.prototype.hasOwnProperty.call(value, 'createdOn'))
            this.createdOn = value.createdOn;

    }
}

export class PersonViewModel extends ViewModel {
    identifier: string = "440513b5-4b48-4958-8e96-4a8cb627c783";
    name!: string;
    surname!: string;
    gender: Gender | number = 1;

    constructor(value: any = null) {
        super(value);

        if (Object.prototype.hasOwnProperty.call(value, 'identifier'))
            this.identifier = value.identifier;

        if (Object.prototype.hasOwnProperty.call(value, 'name'))
            this.name = value.name;

        if (Object.prototype.hasOwnProperty.call(value, 'surname'))
            this.surname = value.surname;

        if (Object.prototype.hasOwnProperty.call(value, 'gender'))
            this.gender = value.gender;

        if (Object.prototype.hasOwnProperty.call(value, 'guid'))
            this.guid = value.guid;

        if (Object.prototype.hasOwnProperty.call(value, 'createdOn'))
            this.createdOn = value.createdOn;

    }
}

export class StudentViewModel extends PersonViewModel {
    grade: number = 9;
    school!: SchoolViewModel;

    constructor(value: any = null) {
        super(value);

        if (Object.prototype.hasOwnProperty.call(value, 'grade'))
            this.grade = value.grade;

        if (Object.prototype.hasOwnProperty.call(value, 'school'))
            this.school = value.school;

        if (Object.prototype.hasOwnProperty.call(value, 'identifier'))
            this.identifier = value.identifier;

        if (Object.prototype.hasOwnProperty.call(value, 'name'))
            this.name = value.name;

        if (Object.prototype.hasOwnProperty.call(value, 'surname'))
            this.surname = value.surname;

        if (Object.prototype.hasOwnProperty.call(value, 'gender'))
            this.gender = value.gender;

        if (Object.prototype.hasOwnProperty.call(value, 'guid'))
            this.guid = value.guid;

        if (Object.prototype.hasOwnProperty.call(value, 'createdOn'))
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

        if (Object.prototype.hasOwnProperty.call(value, 'name'))
            this.name = value.name;

        if (Object.prototype.hasOwnProperty.call(value, 'amountOfStudents'))
            this.amountOfStudents = value.amountOfStudents;

        if (Object.prototype.hasOwnProperty.call(value, 'owner'))
            this.owner = value.owner;

        if (Object.prototype.hasOwnProperty.call(value, 'address'))
            this.address = value.address;

        if (Object.prototype.hasOwnProperty.call(value, 'zipCode'))
            this.zipCode = value.zipCode;

        if (Object.prototype.hasOwnProperty.call(value, 'houseNumber'))
            this.houseNumber = value.houseNumber;

        if (Object.prototype.hasOwnProperty.call(value, 'houseNumberAddition'))
            this.houseNumberAddition = value.houseNumberAddition;

        if (Object.prototype.hasOwnProperty.call(value, 'averageGrade'))
            this.averageGrade = value.averageGrade;

        if (Object.prototype.hasOwnProperty.call(value, 'students'))
            this.students = value.students;

        if (Object.prototype.hasOwnProperty.call(value, 'timmy'))
            this.timmy = value.timmy;

        if (Object.prototype.hasOwnProperty.call(value, 'guid'))
            this.guid = value.guid;

        if (Object.prototype.hasOwnProperty.call(value, 'createdOn'))
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
    static readonly readonlyString: string = "readonly";

    constructor(value: any = null) {
        super(value);

        if (Object.prototype.hasOwnProperty.call(value, 'nullableBool'))
            this.nullableBool = value.nullableBool;

        if (Object.prototype.hasOwnProperty.call(value, 'nullableString'))
            this.nullableString = value.nullableString;

        if (Object.prototype.hasOwnProperty.call(value, 'guid'))
            this.guid = value.guid;

        if (Object.prototype.hasOwnProperty.call(value, 'date'))
            this.date = value.date;

        if (Object.prototype.hasOwnProperty.call(value, 'student'))
            this.student = value.student;

        if (Object.prototype.hasOwnProperty.call(value, 'students'))
            this.students = value.students;

        if (Object.prototype.hasOwnProperty.call(value, 'studentPerClass'))
            this.studentPerClass = value.studentPerClass;

        if (Object.prototype.hasOwnProperty.call(value, 'createdOn'))
            this.createdOn = value.createdOn;

    }
}

export class AbstractBaseModel {
    name!: string;

    constructor(value: any = null) {
        if (Object.prototype.hasOwnProperty.call(value, 'name'))
            this.name = value.name;

    }
}

export class AbstractParentModel extends AbstractBaseModel {
    surname!: string;

    constructor(value: any = null) {
        super(value);

        if (Object.prototype.hasOwnProperty.call(value, 'surname'))
            this.surname = value.surname;

        if (Object.prototype.hasOwnProperty.call(value, 'name'))
            this.name = value.name;

    }
}

export class CtorFixModel {
    name!: string;

    constructor(value: any = null) {
        if (Object.prototype.hasOwnProperty.call(value, 'name'))
            this.name = value.name;

    }
}

export class NoXmlDocumentationModel {
    name!: string;


}

