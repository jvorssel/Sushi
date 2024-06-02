// noinspection JSUnusedGlobalSymbols

export enum Gender {
    Undefined = 0,
    Male = 1,
    Female = 2
}

export class ConstrainedGeneric<T> {
    data!: T;
    name: string | null = null;

    constructor(value: Partial<ConstrainedGeneric<T>> = {}) {
        if (value.data !== undefined) this.data = value.data;
        if (value.name !== undefined) this.name = value.name;
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

    constructor(value: Partial<GenericComplexStandalone<TFirst, TSecond>> = {}) {
        if (value.first !== undefined) this.first = value.first;
        if (value.second !== undefined) this.second = value.second;
        if (value.totalAmount !== undefined) this.totalAmount = value.totalAmount;
    }
}

export class GenericStandalone<TEntry> {
    values: Array<TEntry> = [];
    totalAmount!: number;

    constructor(value: Partial<GenericStandalone<TEntry>> = {}) {
        if (value.values !== undefined) this.values = value.values;
        if (value.totalAmount !== undefined) this.totalAmount = value.totalAmount;
    }
}

export class ScriptModel {


}

export class ViewModel extends ScriptModel {
    guid: string = "";
    createdOn!: Date | string | null;

    constructor(value: Partial<ViewModel> = {}) {
        super();

        if (value.guid !== undefined) this.guid = value.guid;
        if (value.createdOn !== undefined) this.createdOn = value.createdOn;
    }
}

export class BaseViewModel extends ViewModel {
    value: string = "base";
    override guid: string = "00000000-0000-0000-0000-000000000000";
    base: boolean = true;

    constructor(value: Partial<BaseViewModel> = {}) {
        super(value);

        if (value.value !== undefined) this.value = value.value;
        if (value.guid !== undefined) this.guid = value.guid;
        if (value.base !== undefined) this.base = value.base;
    }
}

export class InheritedViewModel extends BaseViewModel {
    override value: string = "override";
    addition: string = "added";

    constructor(value: Partial<InheritedViewModel> = {}) {
        super(value);

        if (value.value !== undefined) this.value = value.value;
        if (value.addition !== undefined) this.addition = value.addition;
    }
}

export class NullablePropertiesViewModel extends ViewModel {
    override guid: string = "00000000-0000-0000-0000-000000000000";
    value2: string | null = null;
    static value: string | null = null;

    constructor(value: Partial<NullablePropertiesViewModel> = {}) {
        super(value);

        if (value.guid !== undefined) this.guid = value.guid;
        if (value.value2 !== undefined) this.value2 = value.value2;
    }
}

export class PersonViewModel extends ViewModel {
    identifier: string = "a96efb15-204f-4968-9817-3f21244e1ed0";
    name: string | null = null;
    surname: string | null = null;
    gender: Gender | number = 1;

    constructor(value: Partial<PersonViewModel> = {}) {
        super(value);

        if (value.identifier !== undefined) this.identifier = value.identifier;
        if (value.name !== undefined) this.name = value.name;
        if (value.surname !== undefined) this.surname = value.surname;
        if (value.gender !== undefined) this.gender = value.gender;
    }
}

export class StudentViewModel extends PersonViewModel {
    grade: number = 9;
    school!: SchoolViewModel;

    constructor(value: Partial<StudentViewModel> = {}) {
        super(value);

        if (value.grade !== undefined) this.grade = value.grade;
        if (value.school !== undefined) this.school = value.school;
    }
}

export class SchoolViewModel extends ViewModel {
    name: string | null = null;
    amountOfStudents: number = 0;
    owner!: PersonViewModel;
    address: string = "";
    zipCode: string | null = null;
    houseNumber: number = 0;
    houseNumberAddition: string | null = null;
    averageGrade: number = 2.6666666666666;
    students: Array<StudentViewModel> = [];
    timmy: StudentViewModel = new StudentViewModel();

    constructor(value: Partial<SchoolViewModel> = {}) {
        super(value);

        if (value.name !== undefined) this.name = value.name;
        if (value.amountOfStudents !== undefined) this.amountOfStudents = value.amountOfStudents;
        if (value.owner !== undefined) this.owner = value.owner;
        if (value.address !== undefined) this.address = value.address;
        if (value.zipCode !== undefined) this.zipCode = value.zipCode;
        if (value.houseNumber !== undefined) this.houseNumber = value.houseNumber;
        if (value.houseNumberAddition !== undefined) this.houseNumberAddition = value.houseNumberAddition;
        if (value.averageGrade !== undefined) this.averageGrade = value.averageGrade;
        if (value.students !== undefined) this.students = value.students;
        if (value.timmy !== undefined) this.timmy = value.timmy;
    }
}

export class TypeModel extends ViewModel {
    nullableBool: boolean | null = null;
    nullableString: string | null = null;
    override guid: string = "99b5ebc5-2801-4aba-9926-a6b4d0e87cb0";
    date!: Date | string | null;
    student: StudentViewModel = new StudentViewModel();
    students: Array<StudentViewModel> = [];
    studentPerClass: { [key: string]: Array<StudentViewModel> } = {};
    static readonly readonlyString: string = "readonly";

    constructor(value: Partial<TypeModel> = {}) {
        super(value);

        if (value.nullableBool !== undefined) this.nullableBool = value.nullableBool;
        if (value.nullableString !== undefined) this.nullableString = value.nullableString;
        if (value.guid !== undefined) this.guid = value.guid;
        if (value.date !== undefined) this.date = value.date;
        if (value.student !== undefined) this.student = value.student;
        if (value.students !== undefined) this.students = value.students;
        if (value.studentPerClass !== undefined) this.studentPerClass = value.studentPerClass;
    }
}

export class AbstractBaseModel {
    name: string | null = null;

    constructor(value: Partial<AbstractBaseModel> = {}) {
        if (value.name !== undefined) this.name = value.name;
    }
}

export class ChildModel extends AbstractBaseModel {
    surname: string | null = null;

    constructor(value: Partial<ChildModel> = {}) {
        super(value);

        if (value.surname !== undefined) this.surname = value.surname;
    }
}

export class CtorFixModel {
    name: string | null = null;

    constructor(value: Partial<CtorFixModel> = {}) {
        if (value.name !== undefined) this.name = value.name;
    }
}

export class NoXmlDocumentationModel {
    name: string | null = null;


}

