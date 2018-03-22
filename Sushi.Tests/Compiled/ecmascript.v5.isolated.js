(function (window) {
	"use strict";

	/**
	 * A model with a LOT of lists.
	 *
	 * Server-side generated model: Sushi.Tests.Models.ModelWithManyLists.
	 * @name ModelWithManyLists
	 * @namespace Sushi.Tests.Models.ModelWithManyLists
	 * @param {Object<ModelWithManyLists>} [value] The object to convert to the match the 'ModelWithManyLists' class.
	 */
	function ModelWithManyLists(value) {
		if (value !== void 0 && value !== null) {
			// Check property keys.
			if (!value.hasOwnProperty('List'))
				throw new TypeError("Given object is expected to have a property with name: 'List'."); 
			if (!value.hasOwnProperty('HashSet'))
				throw new TypeError("Given object is expected to have a property with name: 'HashSet'."); 
			if (!value.hasOwnProperty('Enumerable'))
				throw new TypeError("Given object is expected to have a property with name: 'Enumerable'."); 
			if (!value.hasOwnProperty('Collection'))
				throw new TypeError("Given object is expected to have a property with name: 'Collection'."); 
			if (!value.hasOwnProperty('ReadOnlyList'))
				throw new TypeError("Given object is expected to have a property with name: 'ReadOnlyList'."); 
			if (!value.hasOwnProperty('Dictionary'))
				throw new TypeError("Given object is expected to have a property with name: 'Dictionary'."); 
			
			// Check property type match.
			if (typeof (value['List']) !== 'object')
				throw new TypeError("Given object property 'List' is expected to be a object.");
			if (typeof (value['HashSet']) !== 'object')
				throw new TypeError("Given object property 'HashSet' is expected to be a object.");
			if (typeof (value['Enumerable']) !== 'object')
				throw new TypeError("Given object property 'Enumerable' is expected to be a object.");
			if (typeof (value['Collection']) !== 'object')
				throw new TypeError("Given object property 'Collection' is expected to be a object.");
			if (typeof (value['ReadOnlyList']) !== 'object')
				throw new TypeError("Given object property 'ReadOnlyList' is expected to be a object.");
			if (typeof (value['Dictionary']) !== 'object')
				throw new TypeError("Given object property 'Dictionary' is expected to be a object.");
		}

		// Create object to avoid null/undefind TypeError
		if (value === void 0 || value === null)
			value = {};

		/**
		  * @summary A beautiful list!
		  */
		this.List = value.List || [];
		/**
		  * @summary Another one!
		  */
		this.HashSet = value.HashSet || [];
		/**
		  * @summary Wow another one!
		  */
		this.Enumerable = value.Enumerable || [];
		/**
		  * @summary Dude another one! WOW!
		  */
		this.Collection = value.Collection || [];
		/**
		  * @summary This one is readonly? WOAH!
		  */
		this.ReadOnlyList = value.ReadOnlyList || [];
		/**
		  * @summary DUDE THIS IS NOT A LIST BUT AN OBJECT!
		  */
		this.Dictionary = value.Dictionary || {};
	}

	window.ModelWithManyLists = ModelWithManyLists;

	;

	/**
	 * Check if the given 'value' contains the expected keys and instances to match the 'ModelWithManyLists' class.
	 * @name tryParse
	 * @namespace Sushi.Tests.Models.ModelWithManyLists.tryParse
	 * @param {Object=} value The object to parse.
	 * @return {boolean} If the given 'value' can match the 'ModelWithManyLists' class.
	 */
	ModelWithManyLists.prototype.tryParse = function (value) {
		try {
			if (value === void 0 || value === null)
				return false; // Empty, return false.

			// Check property keys.
			if (!value.hasOwnProperty('List'))
				throw new TypeError("Given object is expected to have a property with name: 'List'."); 
			if (!value.hasOwnProperty('HashSet'))
				throw new TypeError("Given object is expected to have a property with name: 'HashSet'."); 
			if (!value.hasOwnProperty('Enumerable'))
				throw new TypeError("Given object is expected to have a property with name: 'Enumerable'."); 
			if (!value.hasOwnProperty('Collection'))
				throw new TypeError("Given object is expected to have a property with name: 'Collection'."); 
			if (!value.hasOwnProperty('ReadOnlyList'))
				throw new TypeError("Given object is expected to have a property with name: 'ReadOnlyList'."); 
			if (!value.hasOwnProperty('Dictionary'))
				throw new TypeError("Given object is expected to have a property with name: 'Dictionary'."); 
			
			// Check property type match.
			if (typeof (value['List']) !== 'object')
				throw new TypeError("Given object property 'List' is expected to be a object.");
			if (typeof (value['HashSet']) !== 'object')
				throw new TypeError("Given object property 'HashSet' is expected to be a object.");
			if (typeof (value['Enumerable']) !== 'object')
				throw new TypeError("Given object property 'Enumerable' is expected to be a object.");
			if (typeof (value['Collection']) !== 'object')
				throw new TypeError("Given object property 'Collection' is expected to be a object.");
			if (typeof (value['ReadOnlyList']) !== 'object')
				throw new TypeError("Given object property 'ReadOnlyList' is expected to be a object.");
			if (typeof (value['Dictionary']) !== 'object')
				throw new TypeError("Given object property 'Dictionary' is expected to be a object.");

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
	 * Server-side generated model: Sushi.Tests.Models.NameModel.
	 * @name NameModel
	 * @namespace Sushi.Tests.Models.NameModel
	 * @param {Object<NameModel>} [value] The object to convert to the match the 'NameModel' class.
	 */
	function NameModel(value) {
		if (value !== void 0 && value !== null) {
			// Check property keys.
			if (!value.hasOwnProperty('Name'))
				throw new TypeError("Given object is expected to have a property with name: 'Name'."); 
			if (!value.hasOwnProperty('Insertion'))
				throw new TypeError("Given object is expected to have a property with name: 'Insertion'."); 
			if (!value.hasOwnProperty('Surname'))
				throw new TypeError("Given object is expected to have a property with name: 'Surname'."); 
			
			// Check property type match.
			if (typeof (value['Name']) !== 'string')
				throw new TypeError("Given object property 'Name' is expected to be a string.");
			if (typeof (value['Insertion']) !== 'string')
				throw new TypeError("Given object property 'Insertion' is expected to be a string.");
			if (typeof (value['Surname']) !== 'string')
				throw new TypeError("Given object property 'Surname' is expected to be a string.");
		}

		// Create object to avoid null/undefind TypeError
		if (value === void 0 || value === null)
			value = {};

		this.Name = value.Name || "Jeroen";
		this.Insertion = value.Insertion || '';
		this.Surname = value.Surname || "Vorsselman";
	}

	window.NameModel = NameModel;

	;

	/**
	 * Check if the given 'value' contains the expected keys and instances to match the 'NameModel' class.
	 * @name tryParse
	 * @namespace Sushi.Tests.Models.NameModel.tryParse
	 * @param {Object=} value The object to parse.
	 * @return {boolean} If the given 'value' can match the 'NameModel' class.
	 */
	NameModel.prototype.tryParse = function (value) {
		try {
			if (value === void 0 || value === null)
				return false; // Empty, return false.

			// Check property keys.
			if (!value.hasOwnProperty('Name'))
				throw new TypeError("Given object is expected to have a property with name: 'Name'."); 
			if (!value.hasOwnProperty('Insertion'))
				throw new TypeError("Given object is expected to have a property with name: 'Insertion'."); 
			if (!value.hasOwnProperty('Surname'))
				throw new TypeError("Given object is expected to have a property with name: 'Surname'."); 
			
			// Check property type match.
			if (typeof (value['Name']) !== 'string')
				throw new TypeError("Given object property 'Name' is expected to be a string.");
			if (typeof (value['Insertion']) !== 'string')
				throw new TypeError("Given object property 'Insertion' is expected to be a string.");
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
	 * Server-side generated model: Sushi.Tests.Models.PersonReferenceToUser.
	 * @name PersonReferenceToUser
	 * @namespace Sushi.Tests.Models.PersonReferenceToUser
	 * @param {Object<PersonReferenceToUser>} [value] The object to convert to the match the 'PersonReferenceToUser' class.
	 */
	function PersonReferenceToUser(value) {
		if (value !== void 0 && value !== null) {
			// Check property keys.
			if (!value.hasOwnProperty('Name'))
				throw new TypeError("Given object is expected to have a property with name: 'Name'."); 
			if (!value.hasOwnProperty('Insertion'))
				throw new TypeError("Given object is expected to have a property with name: 'Insertion'."); 
			if (!value.hasOwnProperty('Surname'))
				throw new TypeError("Given object is expected to have a property with name: 'Surname'."); 
			if (!value.hasOwnProperty('User'))
				throw new TypeError("Given object is expected to have a property with name: 'User'."); 
			
			// Check property type match.
			if (typeof (value['Name']) !== 'string')
				throw new TypeError("Given object property 'Name' is expected to be a string.");
			if (typeof (value['Insertion']) !== 'string')
				throw new TypeError("Given object property 'Insertion' is expected to be a string.");
			if (typeof (value['Surname']) !== 'string')
				throw new TypeError("Given object property 'Surname' is expected to be a string.");
			if (typeof (value['User']) !== 'object')
				throw new TypeError("Given object property 'User' is expected to be a object.");
			
			// Check property class instance match.
			if (!(value['User'] === void 0 || value['User'] === null) && !(value['User'] instanceof UserReferenceToPerson))
				throw new TypeError("Given object property 'User' is expected to be an instance of the 'UserReferenceToPerson' constructor.");
		}

		// Create object to avoid null/undefind TypeError
		if (value === void 0 || value === null)
			value = {};

		this.Name = value.Name || '';
		this.Insertion = value.Insertion || '';
		this.Surname = value.Surname || '';
		this.User = value.User || null;
	}

	window.PersonReferenceToUser = PersonReferenceToUser;

	;

	/**
	 * Check if the given 'value' contains the expected keys and instances to match the 'PersonReferenceToUser' class.
	 * @name tryParse
	 * @namespace Sushi.Tests.Models.PersonReferenceToUser.tryParse
	 * @param {Object=} value The object to parse.
	 * @return {boolean} If the given 'value' can match the 'PersonReferenceToUser' class.
	 */
	PersonReferenceToUser.prototype.tryParse = function (value) {
		try {
			if (value === void 0 || value === null)
				return false; // Empty, return false.

			// Check property keys.
			if (!value.hasOwnProperty('Name'))
				throw new TypeError("Given object is expected to have a property with name: 'Name'."); 
			if (!value.hasOwnProperty('Insertion'))
				throw new TypeError("Given object is expected to have a property with name: 'Insertion'."); 
			if (!value.hasOwnProperty('Surname'))
				throw new TypeError("Given object is expected to have a property with name: 'Surname'."); 
			if (!value.hasOwnProperty('User'))
				throw new TypeError("Given object is expected to have a property with name: 'User'."); 
			
			// Check property type match.
			if (typeof (value['Name']) !== 'string')
				throw new TypeError("Given object property 'Name' is expected to be a string.");
			if (typeof (value['Insertion']) !== 'string')
				throw new TypeError("Given object property 'Insertion' is expected to be a string.");
			if (typeof (value['Surname']) !== 'string')
				throw new TypeError("Given object property 'Surname' is expected to be a string.");
			if (typeof (value['User']) !== 'object')
				throw new TypeError("Given object property 'User' is expected to be a object.");
			
			// Check property class instance match.
			if (!(value['User'] === void 0 || value['User'] === null) && !(value['User'] instanceof UserReferenceToPerson))
				throw new TypeError("Given object property 'User' is expected to be an instance of the 'UserReferenceToPerson' constructor.");

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
	 * Server-side generated model: Sushi.Tests.Models.UserReferenceToPerson.
	 * @name UserReferenceToPerson
	 * @namespace Sushi.Tests.Models.UserReferenceToPerson
	 * @param {Object<UserReferenceToPerson>} [value] The object to convert to the match the 'UserReferenceToPerson' class.
	 */
	function UserReferenceToPerson(value) {
		if (value !== void 0 && value !== null) {
			// Check property keys.
			if (!value.hasOwnProperty('RegisteredOn'))
				throw new TypeError("Given object is expected to have a property with name: 'RegisteredOn'."); 
			if (!value.hasOwnProperty('Guid'))
				throw new TypeError("Given object is expected to have a property with name: 'Guid'."); 
			if (!value.hasOwnProperty('Username'))
				throw new TypeError("Given object is expected to have a property with name: 'Username'."); 
			if (!value.hasOwnProperty('Password'))
				throw new TypeError("Given object is expected to have a property with name: 'Password'."); 
			if (!value.hasOwnProperty('Person'))
				throw new TypeError("Given object is expected to have a property with name: 'Person'."); 
			
			// Check property type match.
			if (typeof (value['RegisteredOn']) !== 'object')
				throw new TypeError("Given object property 'RegisteredOn' is expected to be a object.");
			if (typeof (value['Guid']) !== 'object')
				throw new TypeError("Given object property 'Guid' is expected to be a object.");
			if (typeof (value['Username']) !== 'string')
				throw new TypeError("Given object property 'Username' is expected to be a string.");
			if (typeof (value['Password']) !== 'string')
				throw new TypeError("Given object property 'Password' is expected to be a string.");
			if (typeof (value['Person']) !== 'object')
				throw new TypeError("Given object property 'Person' is expected to be a object.");
			
			// Check property class instance match.
			if (!(value['Person'] === void 0 || value['Person'] === null) && !(value['Person'] instanceof PersonReferenceToUser))
				throw new TypeError("Given object property 'Person' is expected to be an instance of the 'PersonReferenceToUser' constructor.");
		}

		// Create object to avoid null/undefind TypeError
		if (value === void 0 || value === null)
			value = {};

		this.RegisteredOn = value.RegisteredOn || "2018-03-22T13:45:36.6127233+01:00";
		this.Guid = value.Guid || "00000000-0000-0000-0000-000000000000";
		this.Username = value.Username || "MrAwesome";
		this.Password = value.Password || "Secret";
		this.Person = value.Person || null;
	}

	window.UserReferenceToPerson = UserReferenceToPerson;

	;

	/**
	 * Check if the given 'value' contains the expected keys and instances to match the 'UserReferenceToPerson' class.
	 * @name tryParse
	 * @namespace Sushi.Tests.Models.UserReferenceToPerson.tryParse
	 * @param {Object=} value The object to parse.
	 * @return {boolean} If the given 'value' can match the 'UserReferenceToPerson' class.
	 */
	UserReferenceToPerson.prototype.tryParse = function (value) {
		try {
			if (value === void 0 || value === null)
				return false; // Empty, return false.

			// Check property keys.
			if (!value.hasOwnProperty('RegisteredOn'))
				throw new TypeError("Given object is expected to have a property with name: 'RegisteredOn'."); 
			if (!value.hasOwnProperty('Guid'))
				throw new TypeError("Given object is expected to have a property with name: 'Guid'."); 
			if (!value.hasOwnProperty('Username'))
				throw new TypeError("Given object is expected to have a property with name: 'Username'."); 
			if (!value.hasOwnProperty('Password'))
				throw new TypeError("Given object is expected to have a property with name: 'Password'."); 
			if (!value.hasOwnProperty('Person'))
				throw new TypeError("Given object is expected to have a property with name: 'Person'."); 
			
			// Check property type match.
			if (typeof (value['RegisteredOn']) !== 'object')
				throw new TypeError("Given object property 'RegisteredOn' is expected to be a object.");
			if (typeof (value['Guid']) !== 'object')
				throw new TypeError("Given object property 'Guid' is expected to be a object.");
			if (typeof (value['Username']) !== 'string')
				throw new TypeError("Given object property 'Username' is expected to be a string.");
			if (typeof (value['Password']) !== 'string')
				throw new TypeError("Given object property 'Password' is expected to be a string.");
			if (typeof (value['Person']) !== 'object')
				throw new TypeError("Given object property 'Person' is expected to be a object.");
			
			// Check property class instance match.
			if (!(value['Person'] === void 0 || value['Person'] === null) && !(value['Person'] instanceof PersonReferenceToUser))
				throw new TypeError("Given object property 'Person' is expected to be an instance of the 'PersonReferenceToUser' constructor.");

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
	 * Server-side generated model: Sushi.Tests.Models.TypeModel.
	 * @name TypeModel
	 * @namespace Sushi.Tests.Models.TypeModel
	 * @param {Object<TypeModel>} [value] The object to convert to the match the 'TypeModel' class.
	 */
	function TypeModel(value) {
		if (value !== void 0 && value !== null) {
			// Check property keys.
			if (!value.hasOwnProperty('Name'))
				throw new TypeError("Given object is expected to have a property with name: 'Name'."); 
			if (!value.hasOwnProperty('Number'))
				throw new TypeError("Given object is expected to have a property with name: 'Number'."); 
			if (!value.hasOwnProperty('Decimal'))
				throw new TypeError("Given object is expected to have a property with name: 'Decimal'."); 
			if (!value.hasOwnProperty('Value'))
				throw new TypeError("Given object is expected to have a property with name: 'Value'."); 
			if (!value.hasOwnProperty('Char'))
				throw new TypeError("Given object is expected to have a property with name: 'Char'."); 
			
			// Check property type match.
			if (typeof (value['Name']) !== 'string')
				throw new TypeError("Given object property 'Name' is expected to be a string.");
			if (typeof (value['Number']) !== 'number')
				throw new TypeError("Given object property 'Number' is expected to be a number.");
			if (typeof (value['Decimal']) !== 'number')
				throw new TypeError("Given object property 'Decimal' is expected to be a number.");
			if (typeof (value['Value']) !== 'boolean')
				throw new TypeError("Given object property 'Value' is expected to be a boolean.");
			if (typeof (value['Char']) !== 'string')
				throw new TypeError("Given object property 'Char' is expected to be a string.");
		}

		// Create object to avoid null/undefind TypeError
		if (value === void 0 || value === null)
			value = {};

		this.Name = value.Name || "Jeroen";
		this.Number = value.Number || 1337;
		this.Decimal = value.Decimal || 1.47;
		this.Value = value.Value || true;
		this.Char = value.Char || "a";
	}

	window.TypeModel = TypeModel;

	;

	/**
	 * Check if the given 'value' contains the expected keys and instances to match the 'TypeModel' class.
	 * @name tryParse
	 * @namespace Sushi.Tests.Models.TypeModel.tryParse
	 * @param {Object=} value The object to parse.
	 * @return {boolean} If the given 'value' can match the 'TypeModel' class.
	 */
	TypeModel.prototype.tryParse = function (value) {
		try {
			if (value === void 0 || value === null)
				return false; // Empty, return false.

			// Check property keys.
			if (!value.hasOwnProperty('Name'))
				throw new TypeError("Given object is expected to have a property with name: 'Name'."); 
			if (!value.hasOwnProperty('Number'))
				throw new TypeError("Given object is expected to have a property with name: 'Number'."); 
			if (!value.hasOwnProperty('Decimal'))
				throw new TypeError("Given object is expected to have a property with name: 'Decimal'."); 
			if (!value.hasOwnProperty('Value'))
				throw new TypeError("Given object is expected to have a property with name: 'Value'."); 
			if (!value.hasOwnProperty('Char'))
				throw new TypeError("Given object is expected to have a property with name: 'Char'."); 
			
			// Check property type match.
			if (typeof (value['Name']) !== 'string')
				throw new TypeError("Given object property 'Name' is expected to be a string.");
			if (typeof (value['Number']) !== 'number')
				throw new TypeError("Given object property 'Number' is expected to be a number.");
			if (typeof (value['Decimal']) !== 'number')
				throw new TypeError("Given object property 'Decimal' is expected to be a number.");
			if (typeof (value['Value']) !== 'boolean')
				throw new TypeError("Given object property 'Value' is expected to be a boolean.");
			if (typeof (value['Char']) !== 'string')
				throw new TypeError("Given object property 'Char' is expected to be a string.");

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
	 * Server-side generated model: Sushi.Tests.Models.Inheritance.Gender.
	 * @name Gender
	 * @namespace Sushi.Tests.Models.Inheritance.Gender
	 * @param {Object<Gender>} [value] The object to convert to the match the 'Gender' class.
	 */
	function Gender(value) {
		if (value !== void 0 && value !== null) {
		}

		// Create object to avoid null/undefind TypeError
		if (value === void 0 || value === null)
			value = {};

	}

	window.Gender = Gender;

	;

	/**
	 * Check if the given 'value' contains the expected keys and instances to match the 'Gender' class.
	 * @name tryParse
	 * @namespace Sushi.Tests.Models.Inheritance.Gender.tryParse
	 * @param {Object=} value The object to parse.
	 * @return {boolean} If the given 'value' can match the 'Gender' class.
	 */
	Gender.prototype.tryParse = function (value) {
		try {
			if (value === void 0 || value === null)
				return false; // Empty, return false.


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
(function (window) {
	"use strict";

	/**
	 *
	 * Server-side generated model: Sushi.Tests.Models.Ignore.DoNotIgnoreMe.
	 * @name DoNotIgnoreMe
	 * @namespace Sushi.Tests.Models.Ignore.DoNotIgnoreMe
	 * @param {Object<DoNotIgnoreMe>} [value] The object to convert to the match the 'DoNotIgnoreMe' class.
	 */
	function DoNotIgnoreMe(value) {
		if (value !== void 0 && value !== null) {
			// Check property keys.
			if (!value.hasOwnProperty('ShouldExist'))
				throw new TypeError("Given object is expected to have a property with name: 'ShouldExist'."); 
			
			// Check property type match.
			if (typeof (value['ShouldExist']) !== 'string')
				throw new TypeError("Given object property 'ShouldExist' is expected to be a string.");
		}

		// Create object to avoid null/undefind TypeError
		if (value === void 0 || value === null)
			value = {};

		this.ShouldExist = value.ShouldExist || '';
	}

	window.DoNotIgnoreMe = DoNotIgnoreMe;

	DoNotIgnoreMe.prototype = new IgnoreTestRoot();;

	/**
	 * Check if the given 'value' contains the expected keys and instances to match the 'DoNotIgnoreMe' class.
	 * @name tryParse
	 * @namespace Sushi.Tests.Models.Ignore.DoNotIgnoreMe.tryParse
	 * @param {Object=} value The object to parse.
	 * @return {boolean} If the given 'value' can match the 'DoNotIgnoreMe' class.
	 */
	DoNotIgnoreMe.prototype.tryParse = function (value) {
		try {
			if (value === void 0 || value === null)
				return false; // Empty, return false.

			// Check property keys.
			if (!value.hasOwnProperty('ShouldExist'))
				throw new TypeError("Given object is expected to have a property with name: 'ShouldExist'."); 
			
			// Check property type match.
			if (typeof (value['ShouldExist']) !== 'string')
				throw new TypeError("Given object property 'ShouldExist' is expected to be a string.");

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
	 * Server-side generated model: Sushi.Tests.Models.Ignore.IgnoreTestRoot.
	 * @name IgnoreTestRoot
	 * @namespace Sushi.Tests.Models.Ignore.IgnoreTestRoot
	 * @param {Object<IgnoreTestRoot>} [value] The object to convert to the match the 'IgnoreTestRoot' class.
	 */
	function IgnoreTestRoot(value) {
		if (value !== void 0 && value !== null) {
		}

		// Create object to avoid null/undefind TypeError
		if (value === void 0 || value === null)
			value = {};

	}

	window.IgnoreTestRoot = IgnoreTestRoot;

	;

	/**
	 * Check if the given 'value' contains the expected keys and instances to match the 'IgnoreTestRoot' class.
	 * @name tryParse
	 * @namespace Sushi.Tests.Models.Ignore.IgnoreTestRoot.tryParse
	 * @param {Object=} value The object to parse.
	 * @return {boolean} If the given 'value' can match the 'IgnoreTestRoot' class.
	 */
	IgnoreTestRoot.prototype.tryParse = function (value) {
		try {
			if (value === void 0 || value === null)
				return false; // Empty, return false.


			return true;
		}
		catch (exc) {
			console.warn(exc);
			return false;
		}
	}

})(window);
