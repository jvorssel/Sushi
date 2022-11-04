export enum Gender {
	Undefined = 0,
	Male = 1,
	Female = 2,
}

export class ViewModel {
	Guid: string;
	CreatedOn: Date;

	constructor();
	constructor(value?: any) {
		if (value === null || value === void 0) return;

		this.Guid = value.Guid;
		this.CreatedOn = value.CreatedOn;
	}
}

export class PersonViewModel extends ViewModel {
	Identifier: string;
	Name: string;
	Surname: string;
	Gender: Gender | number;
	Guid: string;
	CreatedOn: Date;

	constructor();
	constructor(value?: any) {
		super();
		
		if (value === null || value === void 0) return;

		this.Identifier = value.Identifier;
		this.Name = value.Name;
		this.Surname = value.Surname;
		this.Gender = value.Gender;
		this.Guid = value.Guid;
		this.CreatedOn = value.CreatedOn;
	}
}

export class StudentViewModel extends PersonViewModel {
	Grade: number;
	School: SchoolViewModel | null;
	Identifier: string;
	Name: string;
	Surname: string;
	Gender: Gender | number;
	Guid: string;
	CreatedOn: Date;

	constructor();
	constructor(value?: any) {
		super();
		
		if (value === null || value === void 0) return;

		this.Grade = value.Grade;
		this.School = value.School;
		this.Identifier = value.Identifier;
		this.Name = value.Name;
		this.Surname = value.Surname;
		this.Gender = value.Gender;
		this.Guid = value.Guid;
		this.CreatedOn = value.CreatedOn;
	}
}

export class SchoolViewModel extends ViewModel {
	Name: string;
	Owner: PersonViewModel | null;
	AmountOfStudents: number;
	Address: string;
	ZipCode: string;
	HouseNumber: number;
	HouseNumberAddition: string;
	Students: Array<StudentViewModel | null>;
	Guid: string;
	CreatedOn: Date;

	constructor();
	constructor(value?: any) {
		super();
		
		if (value === null || value === void 0) return;

		this.Name = value.Name;
		this.Owner = value.Owner;
		this.AmountOfStudents = value.AmountOfStudents;
		this.Address = value.Address;
		this.ZipCode = value.ZipCode;
		this.HouseNumber = value.HouseNumber;
		this.HouseNumberAddition = value.HouseNumberAddition;
		this.Students = value.Students;
		this.Guid = value.Guid;
		this.CreatedOn = value.CreatedOn;
	}
}

export class TypeModel extends ViewModel {
	NullableBool: boolean;
	Guid: string;
	Student: StudentViewModel | null;
	Students: Array<StudentViewModel | null>;
	StudentPerClass: Array<Array<StudentViewModel | null>>;
	CreatedOn: Date;
	ReadonlyString: string;

	constructor();
	constructor(value?: any) {
		super();
		
		if (value === null || value === void 0) return;

		this.NullableBool = value.NullableBool;
		this.Guid = value.Guid;
		this.Student = value.Student;
		this.Students = value.Students;
		this.StudentPerClass = value.StudentPerClass;
		this.CreatedOn = value.CreatedOn;
		this.ReadonlyString = value.ReadonlyString;
	}
}

