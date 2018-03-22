/**
 * A model with a LOT of lists.
 *
 * Server-side generated model: Sushi.Tests.Models.ModelWithManyLists.
 * @name ModelWithManyLists
 * @namespace Sushi.Tests.Models.ModelWithManyLists
 */
export class ModelWithManyLists  {

	/**
	  * A beautiful list!
	  */
	List: Array<string>;
	/**
	  * Another one!
	  */
	HashSet: Array<string>;
	/**
	  * Wow another one!
	  */
	Enumerable: Array<any>;
	/**
	  * Dude another one! WOW!
	  */
	Collection: Array<string>;
	/**
	  * This one is readonly? WOAH!
	  */
	ReadOnlyList: Array<number>;
	/**
	  * DUDE THIS IS NOT A LIST BUT AN OBJECT!
	  */
	Dictionary: Array<string>;

	/**
	 * A model with a LOT of lists.
	 *
	 * FullName: Sushi.Tests.Models.ModelWithManyLists
	 * @param {Object<ModelWithManyLists>} [value] The object to convert to the match the 'ModelWithManyLists' class.
	 */
	constructor(value : any) {
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

	/**
	 * Check if the given 'value' contains the expected keys and instances to match the 'ModelWithManyLists' class.
	 * @param {Object=} value The object to parse.
	 */
	static tryParse(value : any) : boolean {
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
}
/**
 *
 * Server-side generated model: Sushi.Tests.Models.NameModel.
 * @name NameModel
 * @namespace Sushi.Tests.Models.NameModel
 */
export class NameModel  {

	Name: string;
	Insertion: string;
	Surname: string;

	/**
	 *
	 * FullName: Sushi.Tests.Models.NameModel
	 * @param {Object<NameModel>} [value] The object to convert to the match the 'NameModel' class.
	 */
	constructor(value : any) {
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

	/**
	 * Check if the given 'value' contains the expected keys and instances to match the 'NameModel' class.
	 * @param {Object=} value The object to parse.
	 */
	static tryParse(value : any) : boolean {
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
}
/**
 *
 * Server-side generated model: Sushi.Tests.Models.PersonReferenceToUser.
 * @name PersonReferenceToUser
 * @namespace Sushi.Tests.Models.PersonReferenceToUser
 */
export class PersonReferenceToUser  {

	Name: string;
	Insertion: string;
	Surname: string;
	User: any;

	/**
	 *
	 * FullName: Sushi.Tests.Models.PersonReferenceToUser
	 * @param {Object<PersonReferenceToUser>} [value] The object to convert to the match the 'PersonReferenceToUser' class.
	 */
	constructor(value : any) {
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
		}

		this.Name = value.Name || '';
		this.Insertion = value.Insertion || '';
		this.Surname = value.Surname || '';
		this.User = value.User || null;
	}

	/**
	 * Check if the given 'value' contains the expected keys and instances to match the 'PersonReferenceToUser' class.
	 * @param {Object=} value The object to parse.
	 */
	static tryParse(value : any) : boolean {
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

			return true;
		}
		catch (exc) {
			console.warn(exc);
			return false;
		}
	}
}
/**
 *
 * Server-side generated model: Sushi.Tests.Models.UserReferenceToPerson.
 * @name UserReferenceToPerson
 * @namespace Sushi.Tests.Models.UserReferenceToPerson
 */
export class UserReferenceToPerson  {

	RegisteredOn: any;
	Guid: any;
	Username: string;
	Password: string;
	Person: any;

	/**
	 *
	 * FullName: Sushi.Tests.Models.UserReferenceToPerson
	 * @param {Object<UserReferenceToPerson>} [value] The object to convert to the match the 'UserReferenceToPerson' class.
	 */
	constructor(value : any) {
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
		}

		this.RegisteredOn = value.RegisteredOn || "2018-03-22T13:45:36.7942442+01:00";
		this.Guid = value.Guid || "00000000-0000-0000-0000-000000000000";
		this.Username = value.Username || "MrAwesome";
		this.Password = value.Password || "Secret";
		this.Person = value.Person || null;
	}

	/**
	 * Check if the given 'value' contains the expected keys and instances to match the 'UserReferenceToPerson' class.
	 * @param {Object=} value The object to parse.
	 */
	static tryParse(value : any) : boolean {
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

			return true;
		}
		catch (exc) {
			console.warn(exc);
			return false;
		}
	}
}
/**
 *
 * Server-side generated model: Sushi.Tests.Models.TypeModel.
 * @name TypeModel
 * @namespace Sushi.Tests.Models.TypeModel
 */
export class TypeModel  {

	Name: string;
	Number: number;
	Decimal: number;
	Value: boolean;
	Char: string;

	/**
	 *
	 * FullName: Sushi.Tests.Models.TypeModel
	 * @param {Object<TypeModel>} [value] The object to convert to the match the 'TypeModel' class.
	 */
	constructor(value : any) {
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

	/**
	 * Check if the given 'value' contains the expected keys and instances to match the 'TypeModel' class.
	 * @param {Object=} value The object to parse.
	 */
	static tryParse(value : any) : boolean {
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
}
/**
 *
 * Server-side generated model: Sushi.Tests.Models.Inheritance.Gender.
 * @name Gender
 * @namespace Sushi.Tests.Models.Inheritance.Gender
 */
export class Gender  {


	/**
	 *
	 * FullName: Sushi.Tests.Models.Inheritance.Gender
	 * @param {Object<Gender>} [value] The object to convert to the match the 'Gender' class.
	 */
	constructor(value : any) {
		if (value !== void 0 && value !== null) {
		}

	}

	/**
	 * Check if the given 'value' contains the expected keys and instances to match the 'Gender' class.
	 * @param {Object=} value The object to parse.
	 */
	static tryParse(value : any) : boolean {
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
}
/**
 *
 * Server-side generated model: Sushi.Tests.Models.Inheritance.PersonModel.
 * @name PersonModel
 * @namespace Sushi.Tests.Models.Inheritance.PersonModel
 */
export class PersonModel  {

	Name: string;
	Surname: string;

	/**
	 *
	 * FullName: Sushi.Tests.Models.Inheritance.PersonModel
	 * @param {Object<PersonModel>} [value] The object to convert to the match the 'PersonModel' class.
	 */
	constructor(value : any) {
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
	 * Check if the given 'value' contains the expected keys and instances to match the 'PersonModel' class.
	 * @param {Object=} value The object to parse.
	 */
	static tryParse(value : any) : boolean {
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
/**
 *
 * Server-side generated model: Sushi.Tests.Models.Inheritance.StudentModel.
 * @name StudentModel
 * @namespace Sushi.Tests.Models.Inheritance.StudentModel
 */
export class StudentModel  implements PersonModel {

	Grade: number;
	School: string;
	Gender: number;
	Name: string;
	Surname: string;

	/**
	 *
	 * FullName: Sushi.Tests.Models.Inheritance.StudentModel
	 * @param {Object<StudentModel>} [value] The object to convert to the match the 'StudentModel' class.
	 */
	constructor(value : any) {
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
			if (typeof (value['Gender']) !== 'object')
				throw new TypeError("Given object property 'Gender' is expected to be a object.");
			if (typeof (value['Name']) !== 'string')
				throw new TypeError("Given object property 'Name' is expected to be a string.");
			if (typeof (value['Surname']) !== 'string')
				throw new TypeError("Given object property 'Surname' is expected to be a string.");
			
			// Check property class instance match.
			if (!(value['Gender'] === void 0 || value['Gender'] === null) && !(value['Gender'] instanceof Gender))
				throw new TypeError("Given object property 'Gender' is expected to be an instance of the 'Gender' constructor.");
		}

		this.Grade = value.Grade || 9;
		this.School = value.School || "Sint Jan";
		this.Gender = value.Gender || 0;
		this.Name = value.Name || "Jeroen";
		this.Surname = value.Surname || "Vorsselman";
	}

	/**
	 * Check if the given 'value' contains the expected keys and instances to match the 'StudentModel' class.
	 * @param {Object=} value The object to parse.
	 */
	static tryParse(value : any) : boolean {
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
			if (typeof (value['Gender']) !== 'object')
				throw new TypeError("Given object property 'Gender' is expected to be a object.");
			if (typeof (value['Name']) !== 'string')
				throw new TypeError("Given object property 'Name' is expected to be a string.");
			if (typeof (value['Surname']) !== 'string')
				throw new TypeError("Given object property 'Surname' is expected to be a string.");
			
			// Check property class instance match.
			if (!(value['Gender'] === void 0 || value['Gender'] === null) && !(value['Gender'] instanceof Gender))
				throw new TypeError("Given object property 'Gender' is expected to be an instance of the 'Gender' constructor.");

			return true;
		}
		catch (exc) {
			console.warn(exc);
			return false;
		}
	}
}
/**
 *
 * Server-side generated model: Sushi.Tests.Models.Ignore.DoNotIgnoreMe.
 * @name DoNotIgnoreMe
 * @namespace Sushi.Tests.Models.Ignore.DoNotIgnoreMe
 */
export class DoNotIgnoreMe  implements IgnoreTestRoot {

	ShouldExist: string;

	/**
	 *
	 * FullName: Sushi.Tests.Models.Ignore.DoNotIgnoreMe
	 * @param {Object<DoNotIgnoreMe>} [value] The object to convert to the match the 'DoNotIgnoreMe' class.
	 */
	constructor(value : any) {
		if (value !== void 0 && value !== null) {
			// Check property keys.
			if (!value.hasOwnProperty('ShouldExist'))
				throw new TypeError("Given object is expected to have a property with name: 'ShouldExist'."); 
			
			// Check property type match.
			if (typeof (value['ShouldExist']) !== 'string')
				throw new TypeError("Given object property 'ShouldExist' is expected to be a string.");
		}

		this.ShouldExist = value.ShouldExist || '';
	}

	/**
	 * Check if the given 'value' contains the expected keys and instances to match the 'DoNotIgnoreMe' class.
	 * @param {Object=} value The object to parse.
	 */
	static tryParse(value : any) : boolean {
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
}
/**
 *
 * Server-side generated model: Sushi.Tests.Models.Ignore.IgnoreTestRoot.
 * @name IgnoreTestRoot
 * @namespace Sushi.Tests.Models.Ignore.IgnoreTestRoot
 */
export class IgnoreTestRoot  {


	/**
	 *
	 * FullName: Sushi.Tests.Models.Ignore.IgnoreTestRoot
	 * @param {Object<IgnoreTestRoot>} [value] The object to convert to the match the 'IgnoreTestRoot' class.
	 */
	constructor(value : any) {
		if (value !== void 0 && value !== null) {
		}

	}

	/**
	 * Check if the given 'value' contains the expected keys and instances to match the 'IgnoreTestRoot' class.
	 * @param {Object=} value The object to parse.
	 */
	static tryParse(value : any) : boolean {
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
}
