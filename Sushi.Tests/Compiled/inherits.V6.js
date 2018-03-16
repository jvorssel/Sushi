// ECMA 6 - PersonModel

/**
 * @summary Server-side generated model for the 'PersonModel' class.
 */
class PersonModel  {
	/**
	 * @name PersonModel
	 * @namespace ModelConverter.Tests.Models.Inheritance.PersonModel
	 * @class PersonModel
	 * @classdesc Server-side generated constructor for the 'PersonModel' class.
	 * @param {Object<PersonModel>} [value] The object to convert to the match the 'PersonModel' class.
	 */
	constructor(value) {
		if (value !== void 0 && value !== null) {
			// Check property keys.
			if (!value.hasOwnProperty('Name'))
				throw new TypeError("Given object is expected to have a property with name: 'Name'."); 
			if (!value.hasOwnProperty('Surname'))
				throw new TypeError("Given object is expected to have a property with name: 'Surname'."); 
			
			// Check property type match.
			if (typeof (value['Name']) !== 'string')
				throw new TypeError("Given object property 'Name' is expected to be a string.");
			if (typeof (value['Surname']) !== 'string')
				throw new TypeError("Given object property 'Surname' is expected to be a string.");
		}

		this.Name = value.Name || "Jeroen";
		this.Surname = value.Surname || "Vorsselman";
	}

	/**
	 * @name tryParse
	 * @namespace ModelConverter.Tests.Models.Inheritance.PersonModel.tryParse
	 * @description Check if the given 'value' contains the expected keys and instances to match the 'PersonModel' class.
	 * @param {Object=} value The object to parse.
	 * @return {boolean} If the given 'value' can match the 'PersonModel' class.
	 */
	static tryParse(value) {
		try {
			if (value === void 0 || value === null)
				return false; // Empty, return false.

			// Check property keys.
			if (!value.hasOwnProperty('Name'))
				throw new TypeError("Given object is expected to have a property with name: 'Name'."); 
			if (!value.hasOwnProperty('Surname'))
				throw new TypeError("Given object is expected to have a property with name: 'Surname'."); 
			
			// Check property type match.
			if (typeof (value['Name']) !== 'string')
				throw new TypeError("Given object property 'Name' is expected to be a string.");
			if (typeof (value['Surname']) !== 'string')
				throw new TypeError("Given object property 'Surname' is expected to be a string.");

			return true;
		}
		catch (exc) {
			console.warn(exc);
			return false;
		}
	}
}
// ECMA 6 - StudentModel

/**
 * @summary Server-side generated model for the 'StudentModel' class.
 */
class StudentModel  extends PersonModel {
	/**
	 * @name StudentModel
	 * @namespace ModelConverter.Tests.Models.Inheritance.StudentModel
	 * @class StudentModel
	 * @classdesc Server-side generated constructor for the 'StudentModel' class.
	 * @param {Object<StudentModel>} [value] The object to convert to the match the 'StudentModel' class.
	 */
	constructor(value) {
		if (value !== void 0 && value !== null) {
			// Check property keys.
			if (!value.hasOwnProperty('Grade'))
				throw new TypeError("Given object is expected to have a property with name: 'Grade'."); 
			if (!value.hasOwnProperty('School'))
				throw new TypeError("Given object is expected to have a property with name: 'School'."); 
			if (!value.hasOwnProperty('Gender'))
				throw new TypeError("Given object is expected to have a property with name: 'Gender'."); 
			if (!value.hasOwnProperty('Name'))
				throw new TypeError("Given object is expected to have a property with name: 'Name'."); 
			if (!value.hasOwnProperty('Surname'))
				throw new TypeError("Given object is expected to have a property with name: 'Surname'."); 
			
			// Check property type match.
			if (typeof (value['Grade']) !== 'number')
				throw new TypeError("Given object property 'Grade' is expected to be a number.");
			if (typeof (value['School']) !== 'string')
				throw new TypeError("Given object property 'School' is expected to be a string.");
			if (typeof (value['Gender']) !== 'number')
				throw new TypeError("Given object property 'Gender' is expected to be a number.");
			if (typeof (value['Name']) !== 'string')
				throw new TypeError("Given object property 'Name' is expected to be a string.");
			if (typeof (value['Surname']) !== 'string')
				throw new TypeError("Given object property 'Surname' is expected to be a string.");
		}

		this.Grade = value.Grade || 9;
		this.School = value.School || "Sint Jan";
		this.Gender = value.Gender || 0;
		this.Name = value.Name || "Jeroen";
		this.Surname = value.Surname || "Vorsselman";
	}

	/**
	 * @name tryParse
	 * @namespace ModelConverter.Tests.Models.Inheritance.StudentModel.tryParse
	 * @description Check if the given 'value' contains the expected keys and instances to match the 'StudentModel' class.
	 * @param {Object=} value The object to parse.
	 * @return {boolean} If the given 'value' can match the 'StudentModel' class.
	 */
	static tryParse(value) {
		try {
			if (value === void 0 || value === null)
				return false; // Empty, return false.

			// Check property keys.
			if (!value.hasOwnProperty('Grade'))
				throw new TypeError("Given object is expected to have a property with name: 'Grade'."); 
			if (!value.hasOwnProperty('School'))
				throw new TypeError("Given object is expected to have a property with name: 'School'."); 
			if (!value.hasOwnProperty('Gender'))
				throw new TypeError("Given object is expected to have a property with name: 'Gender'."); 
			if (!value.hasOwnProperty('Name'))
				throw new TypeError("Given object is expected to have a property with name: 'Name'."); 
			if (!value.hasOwnProperty('Surname'))
				throw new TypeError("Given object is expected to have a property with name: 'Surname'."); 
			
			// Check property type match.
			if (typeof (value['Grade']) !== 'number')
				throw new TypeError("Given object property 'Grade' is expected to be a number.");
			if (typeof (value['School']) !== 'string')
				throw new TypeError("Given object property 'School' is expected to be a string.");
			if (typeof (value['Gender']) !== 'number')
				throw new TypeError("Given object property 'Gender' is expected to be a number.");
			if (typeof (value['Name']) !== 'string')
				throw new TypeError("Given object property 'Name' is expected to be a string.");
			if (typeof (value['Surname']) !== 'string')
				throw new TypeError("Given object property 'Surname' is expected to be a string.");

			return true;
		}
		catch (exc) {
			console.warn(exc);
			return false;
		}
	}
}
