/**
 * Sushi.Tests.Models.GenericComplexStandalone`2
 * @typedef {Object} GenericComplexStandalone
 */
function GenericComplexStandalone(obj) {
    var value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.first = value.first;
    this.second = value.second;
    this.totalAmount = value.totalAmount;

}

GenericComplexStandalone.prototype.mapFrom = function(obj) {
    return _.extend(new GenericComplexStandalone(), obj); 
};

/**
 * Sushi.Tests.Models.GenericStandalone`1
 * @typedef {Object} GenericStandalone
 */
function GenericStandalone(obj) {
    var value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.values = value.values;
    this.totalAmount = value.totalAmount;

}

GenericStandalone.prototype.mapFrom = function(obj) {
    return _.extend(new GenericStandalone(), obj); 
};

/**
 * The view model base class.
 * @typedef {Object} ViewModel
 */
function ViewModel(obj) {
    var value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.guid = value.guid;
    this.createdOn = value.createdOn;

}

ViewModel.prototype.mapFrom = function(obj) {
    return _.extend(new ViewModel(), obj); 
};

/**
 * Sushi.Tests.Models.BaseViewModel
 * @typedef {Object} BaseViewModel
 * @extends ViewModel 
 */
function BaseViewModel(obj) {
    var value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.value = value.value;
    this.guid = value.guid;
    this.base = value.base;
    this.createdOn = value.createdOn;

}

BaseViewModel.prototype.mapFrom = function(obj) {
    return _.extend(new BaseViewModel(), obj); 
};

/**
 * Sushi.Tests.Models.InheritedViewModel
 * @typedef {Object} InheritedViewModel
 * @extends BaseViewModel 
 */
function InheritedViewModel(obj) {
    var value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.value = value.value;
    this.guid = value.guid;
    this.addition = value.addition;
    this.guid = value.guid;
    this.base = value.base;
    this.createdOn = value.createdOn;

}

InheritedViewModel.prototype.mapFrom = function(obj) {
    return _.extend(new InheritedViewModel(), obj); 
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

    this.identifier = value.identifier;
    this.name = value.name;
    this.surname = value.surname;
    this.gender = value.gender;
    this.guid = value.guid;
    this.createdOn = value.createdOn;

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

    this.grade = value.grade;
    this.school = value.school;
    this.identifier = value.identifier;
    this.name = value.name;
    this.surname = value.surname;
    this.gender = value.gender;
    this.guid = value.guid;
    this.createdOn = value.createdOn;

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

    this.name = value.name;
    this.amountOfStudents = value.amountOfStudents;
    this.owner = value.owner;
    this.address = value.address;
    this.zipCode = value.zipCode;
    this.houseNumber = value.houseNumber;
    this.houseNumberAddition = value.houseNumberAddition;
    this.averageGrade = value.averageGrade;
    this.students = value.students;
    this.timmy = value.timmy;
    this.guid = value.guid;
    this.createdOn = value.createdOn;

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

    this.nullableBool = value.nullableBool;
    this.nullableString = value.nullableString;
    this.guid = value.guid;
    this.date = value.date;
    this.student = value.student;
    this.students = value.students;
    this.studentPerClass = value.studentPerClass;
    this.createdOn = value.createdOn;
    this.readonlyString = value.readonlyString;

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

    this.name = value.name;

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

    this.surname = value.surname;
    this.name = value.name;

}

AbstractParentModel.prototype.mapFrom = function(obj) {
    return _.extend(new AbstractParentModel(), obj); 
};

/**
 * Sushi.Tests.BugFixes.NoParameterlessCtorTests+CtorFixModel
 * @typedef {Object} CtorFixModel
 */
function CtorFixModel(obj) {
    var value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.name = value.name;

}

CtorFixModel.prototype.mapFrom = function(obj) {
    return _.extend(new CtorFixModel(), obj); 
};

/**
 * Sushi.Tests.BugFixes.NoXmlDocumentation+NoXmlDocumentationModel
 * @typedef {Object} NoXmlDocumentationModel
 */
function NoXmlDocumentationModel(obj) {
    var value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.name = value.name;

}

NoXmlDocumentationModel.prototype.mapFrom = function(obj) {
    return _.extend(new NoXmlDocumentationModel(), obj); 
};

