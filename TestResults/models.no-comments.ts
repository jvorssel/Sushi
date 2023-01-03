export enum Gender {
	Undefined = 0,
	Male = 1,
	Female = 2
}

export class ViewModel {
	Guid: string;
	CreatedOn: Date | string | null;

	constructor();
	constructor(value?: any) {
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
	Identifier: string;
	Name: string;
	Surname: string;
	Gender: Gender | number;

	constructor();
	constructor(value?: any) {
		super();

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
	Grade: number;
	School: SchoolViewModel | null;

	constructor();
	constructor(value?: any) {
		super();

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
	Name: string;
	Owner: PersonViewModel | null;
	AmountOfStudents: number;
	Address: string;
	ZipCode: string;
	HouseNumber: number;
	HouseNumberAddition: string;
	Students: Array<StudentViewModel | null>;

	constructor();
	constructor(value?: any) {
		super();

		if (!(value instanceof Object))
			return;

		this.Name = value.Name;
		this.Owner = value.Owner;
		this.AmountOfStudents = value.AmountOfStudents;
		this.Address = value.Address;
		this.ZipCode = value.ZipCode;
		this.HouseNumber = value.HouseNumber;
		this.HouseNumberAddition = value.HouseNumberAddition;
		this.Students = value.Students;
	}

	static mapFrom(obj: any): SchoolViewModel {
		return Object.assign(new SchoolViewModel(), obj);
	}
}

export class TypeModel extends ViewModel {
	NullableBool: boolean | null;
	NullableString: string;
	Student: StudentViewModel | null;
	Students: Array<StudentViewModel | null>;
	StudentPerClass: Array<Array<StudentViewModel | null>>;
	ReadonlyString: string;

	constructor();
	constructor(value?: any) {
		super();

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

