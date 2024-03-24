export enum Gender {
    Undefined = 0,
    Male = 1,
    Female = 2
}

/**
 * Sushi.Tests.Models.ConstrainedGeneric`1
 */
export class ConstrainedGeneric<T> {

    data!: T;

    name: string = "";

    constructor(value: Partial<ConstrainedGeneric<T>> = {}) {
        if (value.data) this.data = value.data;
        if (value.name) this.name = value.name;
    }
}

/**
 * Sushi.Tests.Models.ConstValues
 */
export class ConstValues {

    static readonly static: string = "Static";

    static readonly first: string = "First";

    static readonly last: string = "Last";


}

/**
 * Sushi.Tests.Models.GenericComplexStandalone`2
 */
export class GenericComplexStandalone<TFirst, TSecond> {

    first: Array<TFirst> = [];

    second: Array<TSecond> = [];

    totalAmount!: number;

    constructor(value: Partial<GenericComplexStandalone<TFirst, TSecond>> = {}) {
        if (value.first) this.first = value.first;
        if (value.second) this.second = value.second;
        if (value.totalAmount) this.totalAmount = value.totalAmount;
    }
}

/**
 * Sushi.Tests.Models.GenericStandalone`1
 */
export class GenericStandalone<TEntry> {

    values: Array<TEntry> = [];

    totalAmount!: number;

    constructor(value: Partial<GenericStandalone<TEntry>> = {}) {
        if (value.values) this.values = value.values;
        if (value.totalAmount) this.totalAmount = value.totalAmount;
    }
}

/**
 * Sushi.Tests.Models.ViewModel
 */
export class ViewModel {

    guid: string = "";

    createdOn!: Date | string | null;

    constructor(value: Partial<ViewModel> = {}) {
        if (value.guid) this.guid = value.guid;
        if (value.createdOn) this.createdOn = value.createdOn;
    }
}

/**
 * Sushi.Tests.Models.BaseViewModel
 * @extends ViewModel
 */
export class BaseViewModel extends ViewModel {

    value: string = "base";

    base: boolean = true;

    constructor(value: Partial<BaseViewModel> = {}) {
        super(value);

        if (value.value) this.value = value.value;
        if (value.guid) this.guid = value.guid;
        if (value.base) this.base = value.base;
        if (value.createdOn) this.createdOn = value.createdOn;
    }
}

/**
 * Sushi.Tests.Models.InheritedViewModel
 * @extends BaseViewModel
 */
export class InheritedViewModel extends BaseViewModel {

    override guid: string = "new guid";

    addition: string = "added";

    constructor(value: Partial<InheritedViewModel> = {}) {
        super(value);

        if (value.value) this.value = value.value;
        if (value.guid) this.guid = value.guid;
        if (value.addition) this.addition = value.addition;
        if (value.guid) this.guid = value.guid;
        if (value.base) this.base = value.base;
        if (value.createdOn) this.createdOn = value.createdOn;
    }
}

/**
 * Sushi.Tests.Models.PersonViewModel
 * @extends ViewModel
 */
export class PersonViewModel extends ViewModel {

    identifier: string = "e4a2e0ff-c185-4479-a758-06ca377dfc26";

    name: string = "";

    surname: string = "";

    gender: Gender | number = 1;

    constructor(value: Partial<PersonViewModel> = {}) {
        super(value);

        if (value.identifier) this.identifier = value.identifier;
        if (value.name) this.name = value.name;
        if (value.surname) this.surname = value.surname;
        if (value.gender) this.gender = value.gender;
        if (value.guid) this.guid = value.guid;
        if (value.createdOn) this.createdOn = value.createdOn;
    }
}

/**
 * Sushi.Tests.Models.StudentViewModel
 * @extends PersonViewModel
 */
export class StudentViewModel extends PersonViewModel {

    grade: number = 9;

    school!: SchoolViewModel;

    constructor(value: Partial<StudentViewModel> = {}) {
        super(value);

        if (value.grade) this.grade = value.grade;
        if (value.school) this.school = value.school;
        if (value.identifier) this.identifier = value.identifier;
        if (value.name) this.name = value.name;
        if (value.surname) this.surname = value.surname;
        if (value.gender) this.gender = value.gender;
        if (value.guid) this.guid = value.guid;
        if (value.createdOn) this.createdOn = value.createdOn;
    }
}

/**
 * Sushi.Tests.Models.SchoolViewModel
 * @extends ViewModel
 */
export class SchoolViewModel extends ViewModel {

    name: string = "";

    amountOfStudents: number = 0;

    owner!: PersonViewModel;

    address: string = "";

    zipCode: string = "";

    houseNumber: number = 0;

    houseNumberAddition: string = "";

    averageGrade: number = 2.6666666666666;

    students: Array<StudentViewModel> = [];

    timmy: StudentViewModel = new StudentViewModel();

    constructor(value: Partial<SchoolViewModel> = {}) {
        super(value);

        if (value.name) this.name = value.name;
        if (value.amountOfStudents) this.amountOfStudents = value.amountOfStudents;
        if (value.owner) this.owner = value.owner;
        if (value.address) this.address = value.address;
        if (value.zipCode) this.zipCode = value.zipCode;
        if (value.houseNumber) this.houseNumber = value.houseNumber;
        if (value.houseNumberAddition) this.houseNumberAddition = value.houseNumberAddition;
        if (value.averageGrade) this.averageGrade = value.averageGrade;
        if (value.students) this.students = value.students;
        if (value.timmy) this.timmy = value.timmy;
        if (value.guid) this.guid = value.guid;
        if (value.createdOn) this.createdOn = value.createdOn;
    }
}

/**
 * Sushi.Tests.Models.TypeModel
 * @extends ViewModel
 */
export class TypeModel extends ViewModel {

    nullableBool: boolean | null = null;

    nullableString: string = "";

    date!: Date | string | null;

    student: StudentViewModel = new StudentViewModel();

    students: Array<StudentViewModel> = [];

    studentPerClass: { [key: string]: Array<StudentViewModel> } = {};

    static readonly readonlyString: string = "readonly";

    constructor(value: Partial<TypeModel> = {}) {
        super(value);

        if (value.nullableBool) this.nullableBool = value.nullableBool;
        if (value.nullableString) this.nullableString = value.nullableString;
        if (value.guid) this.guid = value.guid;
        if (value.date) this.date = value.date;
        if (value.student) this.student = value.student;
        if (value.students) this.students = value.students;
        if (value.studentPerClass) this.studentPerClass = value.studentPerClass;
        if (value.createdOn) this.createdOn = value.createdOn;
    }
}

/**
 * Sushi.Tests.BugFixes.AbstractBaseClass+AbstractBaseModel
 */
export class AbstractBaseModel {

    name: string = "";

    constructor(value: Partial<AbstractBaseModel> = {}) {
        if (value.name) this.name = value.name;
    }
}

/**
 * Sushi.Tests.BugFixes.AbstractBaseClass+AbstractParentModel
 * @extends AbstractBaseModel
 */
export class AbstractParentModel extends AbstractBaseModel {

    surname: string = "";

    constructor(value: Partial<AbstractParentModel> = {}) {
        super(value);

        if (value.surname) this.surname = value.surname;
        if (value.name) this.name = value.name;
    }
}

/**
 * Sushi.Tests.BugFixes.NoParameterlessCtorTests+CtorFixModel
 */
export class CtorFixModel {

    name: string = "";

    constructor(value: Partial<CtorFixModel> = {}) {
        if (value.name) this.name = value.name;
    }
}

/**
 * Sushi.Tests.BugFixes.NoXmlDocumentation+NoXmlDocumentationModel
 */
export class NoXmlDocumentationModel {

    name: string = "";


}

