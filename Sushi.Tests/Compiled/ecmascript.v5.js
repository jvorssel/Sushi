
/**
 * The PersonViewModel that represents a Person.
 *
 * Server-side generated model: Sushi.TestModels.PersonViewModel.
 * @name PersonViewModel
 * @namespace Sushi.TestModels
 * @param {Object<PersonViewModel>} [value] The object to convert to the match the 'PersonViewModel' class.
 */
function PersonViewModel(value) {
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

	// Create object to avoid null/undefined TypeError
	if (value === void 0 || value === null)
		value = {};

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
 * @name tryParse
 * @namespace Sushi.TestModels.PersonViewModel
 * @param {Object=} value The object to parse.
 * @return {boolean} If the given 'value' can match the 'PersonViewModel' class.
 */
PersonViewModel.prototype.tryParse = function (value) {
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

window.PersonViewModel = PersonViewModel;

/**
 * Basic information about a School.
 *
 * Server-side generated model: Sushi.TestModels.SchoolViewModel.
 * @name SchoolViewModel
 * @namespace Sushi.TestModels
 * @param {Object<SchoolViewModel>} [value] The object to convert to the match the 'SchoolViewModel' class.
 */
function SchoolViewModel(value) {
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

	// Create object to avoid null/undefined TypeError
	if (value === void 0 || value === null)
		value = {};

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
 * @name tryParse
 * @namespace Sushi.TestModels.SchoolViewModel
 * @param {Object=} value The object to parse.
 * @return {boolean} If the given 'value' can match the 'SchoolViewModel' class.
 */
SchoolViewModel.prototype.tryParse = function (value) {
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

window.SchoolViewModel = SchoolViewModel;

/**
 * Represents a Student in a school.
 *
 * Server-side generated model: Sushi.TestModels.StudentViewModel.
 * @name StudentViewModel
 * @namespace Sushi.TestModels
 * @param {Object<StudentViewModel>} [value] The object to convert to the match the 'StudentViewModel' class.
 */
function StudentViewModel(value) {
	if (value !== void 0 && value !== null) {
		// Check property keys.
		if (!value.hasOwnProperty('Grade')) throw new TypeError("Given object is expected to have a property with name: 'Grade'.");
		if (!value.hasOwnProperty('School')) throw new TypeError("Given object is expected to have a property with name: 'School'.");
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

	// Create object to avoid null/undefined TypeError
	if (value === void 0 || value === null)
		value = {};

	/** What Grade the Student is in. */
	this.Grade = value.Grade || void 0;
	/** The name of the School. */
	this.School = new SchoolViewModel(value.School) || null;
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
 * Check if the given 'value' contains the expected keys and instances to match the 'StudentViewModel' class.
 * @name tryParse
 * @namespace Sushi.TestModels.StudentViewModel
 * @param {Object=} value The object to parse.
 * @return {boolean} If the given 'value' can match the 'StudentViewModel' class.
 */
StudentViewModel.prototype.tryParse = function (value) {
	try {
		if (value === void 0 || value === null)
			return false; // Empty, return false.

		// Check property keys.
		if (!value.hasOwnProperty('Grade')) throw new TypeError("Given object is expected to have a property with name: 'Grade'.");
		if (!value.hasOwnProperty('School')) throw new TypeError("Given object is expected to have a property with name: 'School'.");
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

window.StudentViewModel = StudentViewModel;

/**
 * Base implementation for a ViewModel.
 *
 * Server-side generated model: Sushi.TestModels.ViewModel.
 * @name ViewModel
 * @namespace Sushi.TestModels
 * @param {Object<ViewModel>} [value] The object to convert to the match the 'ViewModel' class.
 */
function ViewModel(value) {
	if (value !== void 0 && value !== null) {
		// Check property keys.
		if (!value.hasOwnProperty('Guid')) throw new TypeError("Given object is expected to have a property with name: 'Guid'.");
		if (!value.hasOwnProperty('CreatedOn')) throw new TypeError("Given object is expected to have a property with name: 'CreatedOn'.");
		
		// Check property type match.
		if (typeof value.Guid !== 'string') throw new TypeError("Given object property 'Guid' is expected to be a string.");
		if (typeof value.CreatedOn !== 'string') throw new TypeError("Given object property 'CreatedOn' is expected to be a string.");
	}

	// Create object to avoid null/undefined TypeError
	if (value === void 0 || value === null)
		value = {};

	/** The Guid Idenfifier. */
	this.Guid = value.Guid || '';
	/** The DateTime that this ViewModel was CreatedOn. */
	this.CreatedOn = !isNaN(Date.parse(value.CreatedOn)) ? new Date(value.CreatedOn) : new Date("0001-01-01T00:00:00.000Z");
}

/**
 * Check if the given 'value' contains the expected keys and instances to match the 'ViewModel' class.
 * @name tryParse
 * @namespace Sushi.TestModels.ViewModel
 * @param {Object=} value The object to parse.
 * @return {boolean} If the given 'value' can match the 'ViewModel' class.
 */
ViewModel.prototype.tryParse = function (value) {
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

window.ViewModel = ViewModel;
