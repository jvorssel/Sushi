
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
		if (typeof value.Name !== 'string') throw new TypeError("Given object property 'Name' is expected to be a string.");
		if (typeof value.Surname !== 'string') throw new TypeError("Given object property 'Surname' is expected to be a string.");
		if (typeof value.Gender !== 'number') throw new TypeError("Given object property 'Gender' is expected to be a number.");
		if (typeof value.Guid !== 'string') throw new TypeError("Given object property 'Guid' is expected to be a string.");
		if (typeof value.CreatedOn !== 'string') throw new TypeError("Given object property 'CreatedOn' is expected to be a string.");
	}

	// Create object to avoid null/undefined TypeError
	if (value === void 0 || value === null)
		value = {};

	/** The Identifier that this Model refers to. */
	this.Identifier = '';
	/** The Name of the person. */
	this.Name = '';
	/** The Surname of the person. */
	this.Surname = '';
	/** The Gender of the person. */
	this.Gender = 0;
	/** The Guid Identifier. */
	this.Guid = '';
	/** The DateTime that this ViewModel was CreatedOn. */
	this.CreatedOn = new Date("0001-01-01T00:00:00.000Z");
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
		if (typeof value.Name !== 'string') throw new TypeError("Given object property 'Name' is expected to be a string.");
		if (typeof value.Surname !== 'string') throw new TypeError("Given object property 'Surname' is expected to be a string.");
		if (typeof value.Gender !== 'number') throw new TypeError("Given object property 'Gender' is expected to be a number.");
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
		if (typeof value.Name !== 'string') throw new TypeError("Given object property 'Name' is expected to be a string.");
		if (typeof value.Owner !== 'object') throw new TypeError("Given object property 'Owner' is expected to be a object.");
		if (typeof value.AmountOfStudents !== 'number') throw new TypeError("Given object property 'AmountOfStudents' is expected to be a number.");
		if (typeof value.Address !== 'string') throw new TypeError("Given object property 'Address' is expected to be a string.");
		if (typeof value.ZipCode !== 'string') throw new TypeError("Given object property 'ZipCode' is expected to be a string.");
		if (typeof value.HouseNumber !== 'number') throw new TypeError("Given object property 'HouseNumber' is expected to be a number.");
		if (typeof value.HouseNumberAddition !== 'string') throw new TypeError("Given object property 'HouseNumberAddition' is expected to be a string.");
		if (typeof value.Students !== 'object') throw new TypeError("Given object property 'Students' is expected to be a object.");
		if (typeof value.Guid !== 'string') throw new TypeError("Given object property 'Guid' is expected to be a string.");
		if (typeof value.CreatedOn !== 'string') throw new TypeError("Given object property 'CreatedOn' is expected to be a string.");
		
		// Check property class instance match.
		if (value.Owner !== void 0 && value.Owner !== null && !PersonViewModel.tryParse(value.Owner)) throw new TypeError("Given object property 'Owner' is expected to be an instance of the 'PersonViewModel' constructor.");
	}

	// Create object to avoid null/undefined TypeError
	if (value === void 0 || value === null)
		value = {};

	/** The Name of this SchoolViewModel. */
	this.Name = '';
	/** The Owner of this SchoolViewModel. */
	this.Owner = null;
	/** The AmountOfStudents of this SchoolViewModel. */
	this.AmountOfStudents = -1;
	/** The Address of this SchoolViewModel. */
	this.Address = '';
	/** The ZipCode of this SchoolViewModel. */
	this.ZipCode = '';
	/** The HouseNumber of this SchoolViewModel. */
	this.HouseNumber = -1;
	/** The HouseNumberAddition of this SchoolViewModel. */
	this.HouseNumberAddition = '';
	/** The Students of this SchoolViewModel. */
	this.Students = [];
	/** The Guid Identifier. */
	this.Guid = '';
	/** The DateTime that this ViewModel was CreatedOn. */
	this.CreatedOn = new Date("0001-01-01T00:00:00.000Z");
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
		if (typeof value.Name !== 'string') throw new TypeError("Given object property 'Name' is expected to be a string.");
		if (typeof value.Owner !== 'object') throw new TypeError("Given object property 'Owner' is expected to be a object.");
		if (typeof value.AmountOfStudents !== 'number') throw new TypeError("Given object property 'AmountOfStudents' is expected to be a number.");
		if (typeof value.Address !== 'string') throw new TypeError("Given object property 'Address' is expected to be a string.");
		if (typeof value.ZipCode !== 'string') throw new TypeError("Given object property 'ZipCode' is expected to be a string.");
		if (typeof value.HouseNumber !== 'number') throw new TypeError("Given object property 'HouseNumber' is expected to be a number.");
		if (typeof value.HouseNumberAddition !== 'string') throw new TypeError("Given object property 'HouseNumberAddition' is expected to be a string.");
		if (typeof value.Students !== 'object') throw new TypeError("Given object property 'Students' is expected to be a object.");
		if (typeof value.Guid !== 'string') throw new TypeError("Given object property 'Guid' is expected to be a string.");
		if (typeof value.CreatedOn !== 'string') throw new TypeError("Given object property 'CreatedOn' is expected to be a string.");
		
		// Check property class instance match.
		if (value.Owner !== void 0 && value.Owner !== null && !PersonViewModel.tryParse(value.Owner)) throw new TypeError("Given object property 'Owner' is expected to be an instance of the 'PersonViewModel' constructor.");

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
		if (typeof value.Grade !== 'number') throw new TypeError("Given object property 'Grade' is expected to be a number.");
		if (typeof value.School !== 'object') throw new TypeError("Given object property 'School' is expected to be a object.");
		if (typeof value.Identifier !== 'string') throw new TypeError("Given object property 'Identifier' is expected to be a string.");
		if (typeof value.Name !== 'string') throw new TypeError("Given object property 'Name' is expected to be a string.");
		if (typeof value.Surname !== 'string') throw new TypeError("Given object property 'Surname' is expected to be a string.");
		if (typeof value.Gender !== 'number') throw new TypeError("Given object property 'Gender' is expected to be a number.");
		if (typeof value.Guid !== 'string') throw new TypeError("Given object property 'Guid' is expected to be a string.");
		if (typeof value.CreatedOn !== 'string') throw new TypeError("Given object property 'CreatedOn' is expected to be a string.");
		
		// Check property class instance match.
		if (value.School !== void 0 && value.School !== null && !SchoolViewModel.tryParse(value.School)) throw new TypeError("Given object property 'School' is expected to be an instance of the 'SchoolViewModel' constructor.");
	}

	// Create object to avoid null/undefined TypeError
	if (value === void 0 || value === null)
		value = {};

	/** What Grade the Student is in. */
	this.Grade = -1;
	/** The name of the School. */
	this.School = null;
	/** The Identifier that this Model refers to. */
	this.Identifier = '';
	/** The Name of the person. */
	this.Name = '';
	/** The Surname of the person. */
	this.Surname = '';
	/** The Gender of the person. */
	this.Gender = 0;
	/** The Guid Identifier. */
	this.Guid = '';
	/** The DateTime that this ViewModel was CreatedOn. */
	this.CreatedOn = new Date("0001-01-01T00:00:00.000Z");
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
		if (typeof value.Grade !== 'number') throw new TypeError("Given object property 'Grade' is expected to be a number.");
		if (typeof value.School !== 'object') throw new TypeError("Given object property 'School' is expected to be a object.");
		if (typeof value.Identifier !== 'string') throw new TypeError("Given object property 'Identifier' is expected to be a string.");
		if (typeof value.Name !== 'string') throw new TypeError("Given object property 'Name' is expected to be a string.");
		if (typeof value.Surname !== 'string') throw new TypeError("Given object property 'Surname' is expected to be a string.");
		if (typeof value.Gender !== 'number') throw new TypeError("Given object property 'Gender' is expected to be a number.");
		if (typeof value.Guid !== 'string') throw new TypeError("Given object property 'Guid' is expected to be a string.");
		if (typeof value.CreatedOn !== 'string') throw new TypeError("Given object property 'CreatedOn' is expected to be a string.");
		
		// Check property class instance match.
		if (value.School !== void 0 && value.School !== null && !SchoolViewModel.tryParse(value.School)) throw new TypeError("Given object property 'School' is expected to be an instance of the 'SchoolViewModel' constructor.");

		return true;
	}
	catch (exc) {
		console.warn(exc);
		return false;
	}
}

window.StudentViewModel = StudentViewModel;

/**
 * Simple model to verify complex types.
 *
 * Server-side generated model: Sushi.TestModels.TypeModel.
 * @name TypeModel
 * @namespace Sushi.TestModels
 * @param {Object<TypeModel>} [value] The object to convert to the match the 'TypeModel' class.
 */
function TypeModel(value) {
	if (value !== void 0 && value !== null) {
		// Check property keys.
		if (!value.hasOwnProperty('NullableBool')) throw new TypeError("Given object is expected to have a property with name: 'NullableBool'.");
		
		// Check property type match.
		if (typeof value.NullableBool !== 'boolean') throw new TypeError("Given object property 'NullableBool' is expected to be a boolean.");
	}

	// Create object to avoid null/undefined TypeError
	if (value === void 0 || value === null)
		value = {};

	/** A nullable boolean. */
	this.NullableBool = null;
}

/**
 * Check if the given 'value' contains the expected keys and instances to match the 'TypeModel' class.
 * @name tryParse
 * @namespace Sushi.TestModels.TypeModel
 * @param {Object=} value The object to parse.
 * @return {boolean} If the given 'value' can match the 'TypeModel' class.
 */
TypeModel.prototype.tryParse = function (value) {
	try {
		if (value === void 0 || value === null)
			return false; // Empty, return false.

		// Check property keys.
		if (!value.hasOwnProperty('NullableBool')) throw new TypeError("Given object is expected to have a property with name: 'NullableBool'.");
		
		// Check property type match.
		if (typeof value.NullableBool !== 'boolean') throw new TypeError("Given object property 'NullableBool' is expected to be a boolean.");

		return true;
	}
	catch (exc) {
		console.warn(exc);
		return false;
	}
}

window.TypeModel = TypeModel;

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

	/** The Guid Identifier. */
	this.Guid = '';
	/** The DateTime that this ViewModel was CreatedOn. */
	this.CreatedOn = new Date("0001-01-01T00:00:00.000Z");
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
