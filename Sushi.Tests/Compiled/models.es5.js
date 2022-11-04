/**
 * Sushi.Tests.Models.ViewModel. 
 * @typedef {Object} ViewModel
 */
function ViewModel(value) {
	if (!(value instanceof Object)) value = {};
	this.Guid = value.Guid;
	this.CreatedOn = value.CreatedOn;
}

/**
 * The PersonViewModel that represents a Person. 
 * @typedef {Object} PersonViewModel
 * @extends ViewModel 
 */
function PersonViewModel(value) {
	if (!(value instanceof Object)) value = {};
	/** The Identifier that this Model refers to. */
	this.Identifier = value.Identifier;
	/** The Name of the person. */
	this.Name = value.Name;
	/** The Surname of the person. */
	this.Surname = value.Surname;
	/** The Gender of the person. */
	this.Gender = value.Gender;
	this.Guid = value.Guid;
	this.CreatedOn = value.CreatedOn;
}

/**
 * Represents a Student in a school. 
 * @typedef {Object} StudentViewModel
 * @extends PersonViewModel 
 */
function StudentViewModel(value) {
	if (!(value instanceof Object)) value = {};
	/** What Grade the Student is in. */
	this.Grade = value.Grade;
	/** The name of the School. */
	this.School = value.School;
	/** The Identifier that this Model refers to. */
	this.Identifier = value.Identifier;
	/** The Name of the person. */
	this.Name = value.Name;
	/** The Surname of the person. */
	this.Surname = value.Surname;
	/** The Gender of the person. */
	this.Gender = value.Gender;
	this.Guid = value.Guid;
	this.CreatedOn = value.CreatedOn;
}

/**
 * Basic information about a School. 
 * @typedef {Object} SchoolViewModel
 * @extends ViewModel 
 */
function SchoolViewModel(value) {
	if (!(value instanceof Object)) value = {};
	/** The Name of this SchoolViewModel. */
	this.Name = value.Name;
	/** The Owner of this SchoolViewModel. */
	this.Owner = value.Owner;
	/** The AmountOfStudents of this SchoolViewModel. */
	this.AmountOfStudents = value.AmountOfStudents;
	/** The Address of this SchoolViewModel. */
	this.Address = value.Address;
	/** The ZipCode of this SchoolViewModel. */
	this.ZipCode = value.ZipCode;
	/** The HouseNumber of this SchoolViewModel. */
	this.HouseNumber = value.HouseNumber;
	/** The HouseNumberAddition of this SchoolViewModel. */
	this.HouseNumberAddition = value.HouseNumberAddition;
	/** The Students of this SchoolViewModel. */
	this.Students = value.Students;
	this.Guid = value.Guid;
	this.CreatedOn = value.CreatedOn;
}

/**
 * Simple model to verify complex types. 
 * @typedef {Object} TypeModel
 * @extends ViewModel 
 */
function TypeModel(value) {
	if (!(value instanceof Object)) value = {};
	/** A nullable boolean. */
	this.NullableBool = value.NullableBool;
	this.Guid = value.Guid;
	this.CreatedOn = value.CreatedOn;
	/** A readonly string. */
	this.ReadonlyString = value.ReadonlyString;
}

