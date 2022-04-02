
/**
 * The PersonViewModel that represents a Person.
 * FullName = Sushi.TestModels.PersonViewModel
 */
export interface PersonViewModel {
	/** The Identifier that this Model refers to. */
	Identifier: string;
	/** The Name of the person. */
	Name: string;
	/** The Surname of the person. */
	Surname: string;
	/** The Gender of the person. */
	Gender: number;
	/** The Guid Identifier. */
	Guid: string;
	/** The DateTime that this ViewModel was CreatedOn. */
	CreatedOn: Date;
}


/**
 * Basic information about a School.
 * FullName = Sushi.TestModels.SchoolViewModel
 */
export interface SchoolViewModel {
	/** The Name of this SchoolViewModel. */
	Name: string;
	/** The Owner of this SchoolViewModel. */
	Owner: PersonViewModel;
	/** The AmountOfStudents of this SchoolViewModel. */
	AmountOfStudents: number;
	/** The Address of this SchoolViewModel. */
	Address: string;
	/** The ZipCode of this SchoolViewModel. */
	ZipCode: string;
	/** The HouseNumber of this SchoolViewModel. */
	HouseNumber: number;
	/** The HouseNumberAddition of this SchoolViewModel. */
	HouseNumberAddition: string;
	/** The Students of this SchoolViewModel. */
	Students: Array<any>;
	/** The Guid Identifier. */
	Guid: string;
	/** The DateTime that this ViewModel was CreatedOn. */
	CreatedOn: Date;
}


/**
 * Represents a Student in a school.
 * FullName = Sushi.TestModels.StudentViewModel
 */
export interface StudentViewModel {
	/** What Grade the Student is in. */
	Grade: number;
	/** The name of the School. */
	School: SchoolViewModel;
	/** The Identifier that this Model refers to. */
	Identifier: string;
	/** The Name of the person. */
	Name: string;
	/** The Surname of the person. */
	Surname: string;
	/** The Gender of the person. */
	Gender: number;
	/** The Guid Identifier. */
	Guid: string;
	/** The DateTime that this ViewModel was CreatedOn. */
	CreatedOn: Date;
}


/**
 * Simple model to verify complex types.
 * FullName = Sushi.TestModels.TypeModel
 */
export interface TypeModel {
	/** A nullable boolean. */
	NullableBool: boolean;
}


/**
 * Base implementation for a ViewModel.
 * FullName = Sushi.TestModels.ViewModel
 */
export interface ViewModel {
	/** The Guid Identifier. */
	Guid: string;
	/** The DateTime that this ViewModel was CreatedOn. */
	CreatedOn: Date;
}

