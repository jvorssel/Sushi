(function (window) {
    'use strict';

        
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
    

})(window);