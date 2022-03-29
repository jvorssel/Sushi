(function (window) {
    'use strict';

        
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
    

})(window);