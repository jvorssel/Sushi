(function (window) {
	"use strict";

	/**
	 *
	 * Server-side generated model: Sushi.Tests.Models.Inheritance.PersonModel.
	 * @name PersonModel
	 * @namespace Sushi.Tests.Models.Inheritance.PersonModel
	 * @param {Object<PersonModel>} [value] The object to convert to the match the 'PersonModel' class.
	 */
	function PersonModel(value) {
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

		// Create object to avoid null/undefind TypeError
		if (value === void 0 || value === null)
			value = {};

		this.Name = value.Name || "Jeroen";
		this.Surname = value.Surname || "Vorsselman";
	}

	window.PersonModel = PersonModel;

	;

	/**
	 * Check if the given 'value' contains the expected keys and instances to match the 'PersonModel' class.
	 * @name tryParse
	 * @namespace Sushi.Tests.Models.Inheritance.PersonModel.tryParse
	 * @param {Object=} value The object to parse.
	 * @return {boolean} If the given 'value' can match the 'PersonModel' class.
	 */
	PersonModel.prototype.tryParse = function (value) {
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

})(window);
(function (window) {
	"use strict";

	/**
	 *
	 * Server-side generated model: Sushi.Tests.Models.Inheritance.StudentModel.
	 * @name StudentModel
	 * @namespace Sushi.Tests.Models.Inheritance.StudentModel
	 * @param {Object<StudentModel>} [value] The object to convert to the match the 'StudentModel' class.
	 */
	function StudentModel(value) {
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

		// Create object to avoid null/undefind TypeError
		if (value === void 0 || value === null)
			value = {};

		this.Grade = value.Grade || 9;
		this.School = value.School || "Sint Jan";
		this.Gender = value.Gender || 0;
		this.Name = value.Name || "Jeroen";
		this.Surname = value.Surname || "Vorsselman";
	}

	window.StudentModel = StudentModel;

	StudentModel.prototype = new PersonModel();;

	/**
	 * Check if the given 'value' contains the expected keys and instances to match the 'StudentModel' class.
	 * @name tryParse
	 * @namespace Sushi.Tests.Models.Inheritance.StudentModel.tryParse
	 * @param {Object=} value The object to parse.
	 * @return {boolean} If the given 'value' can match the 'StudentModel' class.
	 */
	StudentModel.prototype.tryParse = function (value) {
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

})(window);
