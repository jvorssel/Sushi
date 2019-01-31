(function (window) {
    'use strict';

        
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
    	this.Name = value.Name || '';
    	/** The Owner of this SchoolViewModel. */
    	this.Owner = new PersonViewModel(value.Owner) || null;
    	/** The AmountOfStudents of this SchoolViewModel. */
    	this.AmountOfStudents = value.AmountOfStudents || -1;
    	/** The Address of this SchoolViewModel. */
    	this.Address = value.Address || '';
    	/** The ZipCode of this SchoolViewModel. */
    	this.ZipCode = value.ZipCode || '';
    	/** The HouseNumber of this SchoolViewModel. */
    	this.HouseNumber = value.HouseNumber || -1;
    	/** The HouseNumberAddition of this SchoolViewModel. */
    	this.HouseNumberAddition = value.HouseNumberAddition || '';
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
    

})(window);