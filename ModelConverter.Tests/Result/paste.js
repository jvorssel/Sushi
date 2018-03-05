
(function (window) {
	"use strict";

	/**
	 * @name NameModel
	 * @namespace Generated.NameModel
	 * @class NameModel
	 * @classdesc Server-side generated constructor for the 'NameModel' class.
	 * @param {Object<NameModel>} value The object to convert to the match the 'NameModel' class.
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

		this.Name = value.Name || "Jeroen";
		this.Insertion = value.Insertion || '';
		this.Surname = value.Surname || "Vorsselman";
	}

	window.NameModel = NameModel;

	/**
	 * @name tryParse
	 * @namespace Generated.NameModel.tryParse
	 * @description Check if the given 'value' contains the expected keys and instances to match the 'NameModel' class.
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
	 * @name PersonReferenceToUser
	 * @namespace Generated.PersonReferenceToUser
	 * @class PersonReferenceToUser
	 * @classdesc Server-side generated constructor for the 'PersonReferenceToUser' class.
	 * @param {Object<PersonReferenceToUser>} value The object to convert to the match the 'PersonReferenceToUser' class.
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

		this.Name = value.Name || '';
		this.Insertion = value.Insertion || '';
		this.Surname = value.Surname || '';
		this.User = value.User || null;
	}

	window.PersonReferenceToUser = PersonReferenceToUser;

	/**
	 * @name tryParse
	 * @namespace Generated.PersonReferenceToUser.tryParse
	 * @description Check if the given 'value' contains the expected keys and instances to match the 'PersonReferenceToUser' class.
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
	 * @name UserReferenceToPerson
	 * @namespace Generated.UserReferenceToPerson
	 * @class UserReferenceToPerson
	 * @classdesc Server-side generated constructor for the 'UserReferenceToPerson' class.
	 * @param {Object<UserReferenceToPerson>} value The object to convert to the match the 'UserReferenceToPerson' class.
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

		this.RegisteredOn = value.RegisteredOn || new Date(2018, 3, 5, 1, 46, 8, 552);
		this.Guid = value.Guid || '00000000-0000-0000-0000-000000000000';
		this.Username = value.Username || "MrAwesome";
		this.Password = value.Password || "Secret";
		this.Person = value.Person || null;
	}

	window.UserReferenceToPerson = UserReferenceToPerson;

	/**
	 * @name tryParse
	 * @namespace Generated.UserReferenceToPerson.tryParse
	 * @description Check if the given 'value' contains the expected keys and instances to match the 'UserReferenceToPerson' class.
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
	 * @name TypeModel
	 * @namespace Generated.TypeModel
	 * @class TypeModel
	 * @classdesc Server-side generated constructor for the 'TypeModel' class.
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

		this.Name = value.Name || "Jeroen";
		this.Number = value.Number || 1337;
		this.Decimal = value.Decimal || 1.47;
		this.Value = value.Value || true;
		this.Char = value.Char || "a";
	}

	window.TypeModel = TypeModel;
	
	/**
	 * @name tryParse
	 * @namespace Generated.TypeModel.tryParse
	 * @description Check if the given 'value' contains the expected keys and instances to match the 'TypeModel' class.
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

