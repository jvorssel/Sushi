
/**
 * The PersonViewModel that represents a Person.
 * FullName = Sushi.TestModels.PersonViewModel
 */
export interface PersonViewModel {
	/** The Identifier that this Model refers to. */
	Identifier: string;
	/** The Name of the person. */
	Name: void;
	/** The Surname of the person. */
	Surname: void;
	/** The Gender of the person. */
	Gender: void;
	/** The Guid Idenfifier. */
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
	Name: void;
	/** The Owner of this SchoolViewModel. */
	Owner: PersonViewModel;
	/** The AmountOfStudents of this SchoolViewModel. */
	AmountOfStudents: void;
	/** The Address of this SchoolViewModel. */
	Address: void;
	/** The ZipCode of this SchoolViewModel. */
	ZipCode: void;
	/** The HouseNumber of this SchoolViewModel. */
	HouseNumber: void;
	/** The HouseNumberAddition of this SchoolViewModel. */
	HouseNumberAddition: void;
	/** The Students of this SchoolViewModel. */
	Students: Array<void>;
	/** The Guid Idenfifier. */
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
	Grade: void;
	/** The name of the School. */
	School: SchoolViewModel;
	/** The Gender of the Student. */
	Gender: void;
	/** The Identifier that this Model refers to. */
	Identifier: string;
	/** The Name of the person. */
	Name: void;
	/** The Surname of the person. */
	Surname: void;
	/** The Guid Idenfifier. */
	Guid: string;
	/** The DateTime that this ViewModel was CreatedOn. */
	CreatedOn: Date;
}


/**
 * Base implementation for a ViewModel.
 * FullName = Sushi.TestModels.ViewModel
 */
export interface ViewModel {
	/** The Guid Idenfifier. */
	Guid: string;
	/** The DateTime that this ViewModel was CreatedOn. */
	CreatedOn: Date;
}

