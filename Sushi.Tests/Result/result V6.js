
// ECMA 6 - SomeModel

class SomeModel {
	constructor(value) {
		if (!value.hasOwnProperty('Name')) throw new TypeError("Given object is expected to have a property with name: 'Name'."); 
		if (typeof (value['Name']) !== 'string') throw new TypeError("Given object property 'Name' is expected to be a string.");

		if (!value.hasOwnProperty('Insertion')) throw new TypeError("Given object is expected to have a property with name: 'Insertion'."); 
		if (typeof (value['Insertion']) !== 'string') throw new TypeError("Given object property 'Insertion' is expected to be a string.");

		if (!value.hasOwnProperty('Surname')) throw new TypeError("Given object is expected to have a property with name: 'Surname'."); 
		if (typeof (value['Surname']) !== 'string') throw new TypeError("Given object property 'Surname' is expected to be a string.");


		this.Name = "Jeroen";
		this.Insertion = "";
		this.Surname = "Vorsselman";
	}

	static tryParse(value) {
		try {
			if (!value.hasOwnProperty('Name')) throw new TypeError("Given object is expected to have a property with name: 'Name'."); 
			if (typeof (value['Name']) !== 'string') throw new TypeError("Given object property 'Name' is expected to be a string.");

			if (!value.hasOwnProperty('Insertion')) throw new TypeError("Given object is expected to have a property with name: 'Insertion'."); 
			if (typeof (value['Insertion']) !== 'string') throw new TypeError("Given object property 'Insertion' is expected to be a string.");

			if (!value.hasOwnProperty('Surname')) throw new TypeError("Given object is expected to have a property with name: 'Surname'."); 
			if (typeof (value['Surname']) !== 'string') throw new TypeError("Given object property 'Surname' is expected to be a string.");


			return true;
		}
		catch (exc) {
			console.warn(exc);
			return false;
		}
	}
}