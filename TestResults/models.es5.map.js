
/**
 * Sushi.Tests.Models.ViewModel
 * @typedef {Object} ViewModel
 */
function ViewModel(obj) {
    var value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.Guid = value.Guid;
    this.CreatedOn = value.CreatedOn;

}

ViewModel.prototype.mapFrom = function(obj) {
    return _.extend(new ViewModel(), obj); 
};

/**
 * The PersonViewModel that represents a Person.
 * @typedef {Object} PersonViewModel
 * @extends ViewModel 
 */
function PersonViewModel(obj) {
    var value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.Identifier = value.Identifier;
    this.Name = value.Name;
    this.Surname = value.Surname;
    this.Gender = value.Gender;
    this.Guid = value.Guid;
    this.CreatedOn = value.CreatedOn;

}

PersonViewModel.prototype.mapFrom = function(obj) {
    return _.extend(new PersonViewModel(), obj); 
};

/**
 * Represents a Student in a school.
 * @typedef {Object} StudentViewModel
 * @extends PersonViewModel 
 */
function StudentViewModel(obj) {
    var value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.Grade = value.Grade;
    this.School = value.School;
    this.Identifier = value.Identifier;
    this.Name = value.Name;
    this.Surname = value.Surname;
    this.Gender = value.Gender;
    this.Guid = value.Guid;
    this.CreatedOn = value.CreatedOn;

}

StudentViewModel.prototype.mapFrom = function(obj) {
    return _.extend(new StudentViewModel(), obj); 
};

/**
 * Basic information about a School.
 * @typedef {Object} SchoolViewModel
 * @extends ViewModel 
 */
function SchoolViewModel(obj) {
    var value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.Name = value.Name;
    this.Owner = value.Owner;
    this.AmountOfStudents = value.AmountOfStudents;
    this.Address = value.Address;
    this.ZipCode = value.ZipCode;
    this.HouseNumber = value.HouseNumber;
    this.HouseNumberAddition = value.HouseNumberAddition;
    this.AverageGrade = value.AverageGrade;
    this.Students = value.Students;
    this.Timmy = value.Timmy;
    this.Guid = value.Guid;
    this.CreatedOn = value.CreatedOn;

}

SchoolViewModel.prototype.mapFrom = function(obj) {
    return _.extend(new SchoolViewModel(), obj); 
};

/**
 * Simple model to verify complex types.
 * @typedef {Object} TypeModel
 * @extends ViewModel 
 */
function TypeModel(obj) {
    var value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.NullableBool = value.NullableBool;
    this.NullableString = value.NullableString;
    this.Guid = value.Guid;
    this.Student = value.Student;
    this.Students = value.Students;
    this.StudentPerClass = value.StudentPerClass;
    this.CreatedOn = value.CreatedOn;
    this.ReadonlyString = value.ReadonlyString;

}

TypeModel.prototype.mapFrom = function(obj) {
    return _.extend(new TypeModel(), obj); 
};

/**
 * Sushi.Tests.BugFixes.AbstractBaseClass+AbstractBaseModel
 * @typedef {Object} AbstractBaseModel
 */
function AbstractBaseModel(obj) {
    var value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.Name = value.Name;

}

AbstractBaseModel.prototype.mapFrom = function(obj) {
    return _.extend(new AbstractBaseModel(), obj); 
};

/**
 * Sushi.Tests.BugFixes.AbstractBaseClass+AbstractParentModel
 * @typedef {Object} AbstractParentModel
 * @extends AbstractBaseModel 
 */
function AbstractParentModel(obj) {
    var value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.Surname = value.Surname;
    this.Name = value.Name;

}

AbstractParentModel.prototype.mapFrom = function(obj) {
    return _.extend(new AbstractParentModel(), obj); 
};

/**
 * Sushi.Tests.BugFixes.NoXmlDocumentation+NoXmlDocumentationModel
 * @typedef {Object} NoXmlDocumentationModel
 */
function NoXmlDocumentationModel(obj) {
    var value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.Name = value.Name;

}

NoXmlDocumentationModel.prototype.mapFrom = function(obj) {
    return _.extend(new NoXmlDocumentationModel(), obj); 
};

