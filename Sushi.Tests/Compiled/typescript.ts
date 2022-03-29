/**
 * The PersonViewModel that represents a Person.
 *
 * Server-side generated model: Sushi.TestModels.PersonViewModel.
 * @name PersonViewModel
 * @namespace Sushi.TestModels.PersonViewModel
 */
export class PersonViewModel {

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

	/**
	 * The PersonViewModel that represents a Person.
	 *
	 * FullName: Sushi.TestModels.PersonViewModel
	 * @param {Object<PersonViewModel>} [value] The object to convert to the match the 'PersonViewModel' class.
	 */
	constructor(value : any) {
		if (value !== void 0 && value !== null) {
			// Check property keys.
			if (!value.hasOwnProperty('Identifier')) throw new TypeError("Given object is expected to have a property with name: 'Identifier'.");
			if (!value.hasOwnProperty('Name')) throw new TypeError("Given object is expected to have a property with name: 'Name'.");
			if (!value.hasOwnProperty('Surname')) throw new TypeError("Given object is expected to have a property with name: 'Surname'.");
			if (!value.hasOwnProperty('Gender')) throw new TypeError("Given object is expected to have a property with name: 'Gender'.");
			if (!value.hasOwnProperty('Guid')) throw new TypeError("Given object is expected to have a property with name: 'Guid'.");
			if (!value.hasOwnProperty('CreatedOn')) throw new TypeError("Given object is expected to have a property with name: 'CreatedOn'.");
			
			// Check property type match.
			if (typeof value.Identifier !== 'string') throw new TypeError("Given object property 'Identifier' is expected to be a string.");
			if (typeof value.Guid !== 'string') throw new TypeError("Given object property 'Guid' is expected to be a string.");
			if (typeof value.CreatedOn !== 'string') throw new TypeError("Given object property 'CreatedOn' is expected to be a string.");
		}

		/** The Identifier that this Model refers to. */
		this.Identifier = value.Identifier || '';
		/** The Name of the person. */
		this.Name = value.Name || void 0;
		/** The Surname of the person. */
		this.Surname = value.Surname || void 0;
		/** The Gender of the person. */
		this.Gender = value.Gender || void 0;
		/** The Guid Idenfifier. */
		this.Guid = value.Guid || '';
		/** The DateTime that this ViewModel was CreatedOn. */
		this.CreatedOn = !isNaN(Date.parse(value.CreatedOn)) ? new Date(value.CreatedOn) : new Date("0001-01-01T00:00:00.000Z");
	}

	/**
	 * Check if the given 'value' contains the expected keys and instances to match the 'PersonViewModel' class.
	 * @param {Object=} value The object to parse.
	 */
	static tryParse(value : any) : boolean {
		try {
			if (value === void 0 || value === null)
				return false; // Empty, return false.

			// Check property keys.
			if (!value.hasOwnProperty('Identifier')) throw new TypeError("Given object is expected to have a property with name: 'Identifier'.");
			if (!value.hasOwnProperty('Name')) throw new TypeError("Given object is expected to have a property with name: 'Name'.");
			if (!value.hasOwnProperty('Surname')) throw new TypeError("Given object is expected to have a property with name: 'Surname'.");
			if (!value.hasOwnProperty('Gender')) throw new TypeError("Given object is expected to have a property with name: 'Gender'.");
			if (!value.hasOwnProperty('Guid')) throw new TypeError("Given object is expected to have a property with name: 'Guid'.");
			if (!value.hasOwnProperty('CreatedOn')) throw new TypeError("Given object is expected to have a property with name: 'CreatedOn'.");
			
			// Check property type match.
			if (typeof value.Identifier !== 'string') throw new TypeError("Given object property 'Identifier' is expected to be a string.");
			if (typeof value.Guid !== 'string') throw new TypeError("Given object property 'Guid' is expected to be a string.");
			if (typeof value.CreatedOn !== 'string') throw new TypeError("Given object property 'CreatedOn' is expected to be a string.");

			return true;
		}
		catch (exc) {
			console.warn(exc);
			return false;
		}
	}
}
/**
 * Basic information about a School.
 *
 * Server-side generated model: Sushi.TestModels.SchoolViewModel.
 * @name SchoolViewModel
 * @namespace Sushi.TestModels.SchoolViewModel
 */
export class SchoolViewModel {

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

	/**
	 * Basic information about a School.
	 *
	 * FullName: Sushi.TestModels.SchoolViewModel
	 * @param {Object<SchoolViewModel>} [value] The object to convert to the match the 'SchoolViewModel' class.
	 */
	constructor(value : any) {
		if (value !== void 0 && value !== null) {
			// Check property keys.
			if (!value.hasOwnProperty('Name')) throw new TypeError("Given object is expected to have a property with name: 'Name'.");
			if (!value.hasOwnProperty('Owner')) throw new TypeError("Given object is expected to have a property with name: 'Owner'.");
			if (!value.hasOwnProperty('AmountOfStudents')) throw new TypeError("Given object is expected to have a property with name: 'AmountOfStudents'.");
			if (!value.hasOwnProperty('Address')) throw new TypeError("Given object is expected to have a property with name: 'Address'.");
			if (!value.hasOwnProperty('ZipCode')) throw new TypeError("Given object is expected to have a property with name: 'ZipCode'.");
			if (!value.hasOwnProperty('HouseNumber')) throw new TypeError("Given object is expected to have a property with name: 'HouseNumber'.");
			if (!value.hasOwnProperty('HouseNumberAddition')) throw new TypeError("Given object is expected to have a property with name: 'HouseNumberAddition'.");
			if (!value.hasOwnProperty('Students')) throw new TypeError("Given object is expected to have a property with name: 'Students'.");
			if (!value.hasOwnProperty('Guid')) throw new TypeError("Given object is expected to have a property with name: 'Guid'.");
			if (!value.hasOwnProperty('CreatedOn')) throw new TypeError("Given object is expected to have a property with name: 'CreatedOn'.");
			
			// Check property type match.
			if (typeof value.Guid !== 'string') throw new TypeError("Given object property 'Guid' is expected to be a string.");
			if (typeof value.CreatedOn !== 'string') throw new TypeError("Given object property 'CreatedOn' is expected to be a string.");
		}

		/** The Name of this SchoolViewModel. */
		this.Name = value.Name || void 0;
		/** The Owner of this SchoolViewModel. */
		this.Owner = new PersonViewModel(value.Owner) || null;
		/** The AmountOfStudents of this SchoolViewModel. */
		this.AmountOfStudents = value.AmountOfStudents || void 0;
		/** The Address of this SchoolViewModel. */
		this.Address = value.Address || void 0;
		/** The ZipCode of this SchoolViewModel. */
		this.ZipCode = value.ZipCode || void 0;
		/** The HouseNumber of this SchoolViewModel. */
		this.HouseNumber = value.HouseNumber || void 0;
		/** The HouseNumberAddition of this SchoolViewModel. */
		this.HouseNumberAddition = value.HouseNumberAddition || void 0;
		/** The Students of this SchoolViewModel. */
		this.Students = value.Students || [];
		/** The Guid Idenfifier. */
		this.Guid = value.Guid || '';
		/** The DateTime that this ViewModel was CreatedOn. */
		this.CreatedOn = !isNaN(Date.parse(value.CreatedOn)) ? new Date(value.CreatedOn) : new Date("0001-01-01T00:00:00.000Z");
	}

	/**
	 * Check if the given 'value' contains the expected keys and instances to match the 'SchoolViewModel' class.
	 * @param {Object=} value The object to parse.
	 */
	static tryParse(value : any) : boolean {
		try {
			if (value === void 0 || value === null)
				return false; // Empty, return false.

			// Check property keys.
			if (!value.hasOwnProperty('Name')) throw new TypeError("Given object is expected to have a property with name: 'Name'.");
			if (!value.hasOwnProperty('Owner')) throw new TypeError("Given object is expected to have a property with name: 'Owner'.");
			if (!value.hasOwnProperty('AmountOfStudents')) throw new TypeError("Given object is expected to have a property with name: 'AmountOfStudents'.");
			if (!value.hasOwnProperty('Address')) throw new TypeError("Given object is expected to have a property with name: 'Address'.");
			if (!value.hasOwnProperty('ZipCode')) throw new TypeError("Given object is expected to have a property with name: 'ZipCode'.");
			if (!value.hasOwnProperty('HouseNumber')) throw new TypeError("Given object is expected to have a property with name: 'HouseNumber'.");
			if (!value.hasOwnProperty('HouseNumberAddition')) throw new TypeError("Given object is expected to have a property with name: 'HouseNumberAddition'.");
			if (!value.hasOwnProperty('Students')) throw new TypeError("Given object is expected to have a property with name: 'Students'.");
			if (!value.hasOwnProperty('Guid')) throw new TypeError("Given object is expected to have a property with name: 'Guid'.");
			if (!value.hasOwnProperty('CreatedOn')) throw new TypeError("Given object is expected to have a property with name: 'CreatedOn'.");
			
			// Check property type match.
			if (typeof value.Guid !== 'string') throw new TypeError("Given object property 'Guid' is expected to be a string.");
			if (typeof value.CreatedOn !== 'string') throw new TypeError("Given object property 'CreatedOn' is expected to be a string.");

			return true;
		}
		catch (exc) {
			console.warn(exc);
			return false;
		}
	}
}
/**
 * Represents a Student in a school.
 *
 * Server-side generated model: Sushi.TestModels.StudentViewModel.
 * @name StudentViewModel
 * @namespace Sushi.TestModels.StudentViewModel
 */
export class StudentViewModel {

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

	/**
	 * Represents a Student in a school.
	 *
	 * FullName: Sushi.TestModels.StudentViewModel
	 * @param {Object<StudentViewModel>} [value] The object to convert to the match the 'StudentViewModel' class.
	 */
	constructor(value : any) {
		if (value !== void 0 && value !== null) {
			// Check property keys.
			if (!value.hasOwnProperty('Grade')) throw new TypeError("Given object is expected to have a property with name: 'Grade'.");
			if (!value.hasOwnProperty('School')) throw new TypeError("Given object is expected to have a property with name: 'School'.");
			if (!value.hasOwnProperty('Gender')) throw new TypeError("Given object is expected to have a property with name: 'Gender'.");
			if (!value.hasOwnProperty('Identifier')) throw new TypeError("Given object is expected to have a property with name: 'Identifier'.");
			if (!value.hasOwnProperty('Name')) throw new TypeError("Given object is expected to have a property with name: 'Name'.");
			if (!value.hasOwnProperty('Surname')) throw new TypeError("Given object is expected to have a property with name: 'Surname'.");
			if (!value.hasOwnProperty('Guid')) throw new TypeError("Given object is expected to have a property with name: 'Guid'.");
			if (!value.hasOwnProperty('CreatedOn')) throw new TypeError("Given object is expected to have a property with name: 'CreatedOn'.");
			
			// Check property type match.
			if (typeof value.Identifier !== 'string') throw new TypeError("Given object property 'Identifier' is expected to be a string.");
			if (typeof value.Guid !== 'string') throw new TypeError("Given object property 'Guid' is expected to be a string.");
			if (typeof value.CreatedOn !== 'string') throw new TypeError("Given object property 'CreatedOn' is expected to be a string.");
		}

		/** What Grade the Student is in. */
		this.Grade = value.Grade || void 0;
		/** The name of the School. */
		this.School = new SchoolViewModel(value.School) || null;
		/** The Gender of the Student. */
		this.Gender = value.Gender || void 0;
		/** The Identifier that this Model refers to. */
		this.Identifier = value.Identifier || '';
		/** The Name of the person. */
		this.Name = value.Name || void 0;
		/** The Surname of the person. */
		this.Surname = value.Surname || void 0;
		/** The Guid Idenfifier. */
		this.Guid = value.Guid || '';
		/** The DateTime that this ViewModel was CreatedOn. */
		this.CreatedOn = !isNaN(Date.parse(value.CreatedOn)) ? new Date(value.CreatedOn) : new Date("0001-01-01T00:00:00.000Z");
	}

	/**
	 * Check if the given 'value' contains the expected keys and instances to match the 'StudentViewModel' class.
	 * @param {Object=} value The object to parse.
	 */
	static tryParse(value : any) : boolean {
		try {
			if (value === void 0 || value === null)
				return false; // Empty, return false.

			// Check property keys.
			if (!value.hasOwnProperty('Grade')) throw new TypeError("Given object is expected to have a property with name: 'Grade'.");
			if (!value.hasOwnProperty('School')) throw new TypeError("Given object is expected to have a property with name: 'School'.");
			if (!value.hasOwnProperty('Gender')) throw new TypeError("Given object is expected to have a property with name: 'Gender'.");
			if (!value.hasOwnProperty('Identifier')) throw new TypeError("Given object is expected to have a property with name: 'Identifier'.");
			if (!value.hasOwnProperty('Name')) throw new TypeError("Given object is expected to have a property with name: 'Name'.");
			if (!value.hasOwnProperty('Surname')) throw new TypeError("Given object is expected to have a property with name: 'Surname'.");
			if (!value.hasOwnProperty('Guid')) throw new TypeError("Given object is expected to have a property with name: 'Guid'.");
			if (!value.hasOwnProperty('CreatedOn')) throw new TypeError("Given object is expected to have a property with name: 'CreatedOn'.");
			
			// Check property type match.
			if (typeof value.Identifier !== 'string') throw new TypeError("Given object property 'Identifier' is expected to be a string.");
			if (typeof value.Guid !== 'string') throw new TypeError("Given object property 'Guid' is expected to be a string.");
			if (typeof value.CreatedOn !== 'string') throw new TypeError("Given object property 'CreatedOn' is expected to be a string.");

			return true;
		}
		catch (exc) {
			console.warn(exc);
			return false;
		}
	}
}
/**
 * Base implementation for a ViewModel.
 *
 * Server-side generated model: Sushi.TestModels.ViewModel.
 * @name ViewModel
 * @namespace Sushi.TestModels.ViewModel
 */
export class ViewModel {

	/** The Guid Idenfifier. */
	Guid: string;
	/** The DateTime that this ViewModel was CreatedOn. */
	CreatedOn: Date;

	/**
	 * Base implementation for a ViewModel.
	 *
	 * FullName: Sushi.TestModels.ViewModel
	 * @param {Object<ViewModel>} [value] The object to convert to the match the 'ViewModel' class.
	 */
	constructor(value : any) {
		if (value !== void 0 && value !== null) {
			// Check property keys.
			if (!value.hasOwnProperty('Guid')) throw new TypeError("Given object is expected to have a property with name: 'Guid'.");
			if (!value.hasOwnProperty('CreatedOn')) throw new TypeError("Given object is expected to have a property with name: 'CreatedOn'.");
			
			// Check property type match.
			if (typeof value.Guid !== 'string') throw new TypeError("Given object property 'Guid' is expected to be a string.");
			if (typeof value.CreatedOn !== 'string') throw new TypeError("Given object property 'CreatedOn' is expected to be a string.");
		}

		/** The Guid Idenfifier. */
		this.Guid = value.Guid || '';
		/** The DateTime that this ViewModel was CreatedOn. */
		this.CreatedOn = !isNaN(Date.parse(value.CreatedOn)) ? new Date(value.CreatedOn) : new Date("0001-01-01T00:00:00.000Z");
	}

	/**
	 * Check if the given 'value' contains the expected keys and instances to match the 'ViewModel' class.
	 * @param {Object=} value The object to parse.
	 */
	static tryParse(value : any) : boolean {
		try {
			if (value === void 0 || value === null)
				return false; // Empty, return false.

			// Check property keys.
			if (!value.hasOwnProperty('Guid')) throw new TypeError("Given object is expected to have a property with name: 'Guid'.");
			if (!value.hasOwnProperty('CreatedOn')) throw new TypeError("Given object is expected to have a property with name: 'CreatedOn'.");
			
			// Check property type match.
			if (typeof value.Guid !== 'string') throw new TypeError("Given object property 'Guid' is expected to be a string.");
			if (typeof value.CreatedOn !== 'string') throw new TypeError("Given object property 'CreatedOn' is expected to be a string.");

			return true;
		}
		catch (exc) {
			console.warn(exc);
			return false;
		}
	}
}
