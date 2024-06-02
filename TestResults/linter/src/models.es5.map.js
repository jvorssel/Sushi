/**
 * Sushi.Tests.Models.ConstrainedGeneric`1
 * @template {any} T
 */
function ConstrainedGeneric(obj) {
    let value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.data = value.data;
    this.name = value.name;
}

ConstrainedGeneric.prototype.mapFrom = function(obj) {
    return _.extend(new ConstrainedGeneric(), obj); 
};

/**
 * A class with const values.
 * Sushi.Tests.Models.ConstValues
 */
function ConstValues(obj) {
    let value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.static = value.static;
    this.first = value.first;
    this.last = value.last;
}

ConstValues.prototype.mapFrom = function(obj) {
    return _.extend(new ConstValues(), obj); 
};

/**
 * Sushi.Tests.Models.GenericComplexStandalone`2
 * @template {any} TFirst
 * @template {any} TSecond
 */
function GenericComplexStandalone(obj) {
    let value = obj;
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
 * @template {any} TEntry
 */
function GenericStandalone(obj) {
    let value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.values = value.values;
    this.totalAmount = value.totalAmount;
}

GenericStandalone.prototype.mapFrom = function(obj) {
    return _.extend(new GenericStandalone(), obj); 
};

/**
 * .
 * Sushi.Tests.Models.ScriptModel
 */
function ScriptModel(obj) {
    let value = obj;
    if (!(value instanceof Object)) 
        value = {};

}

ScriptModel.prototype.mapFrom = function(obj) {
    return _.extend(new ScriptModel(), obj); 
};

/**
 * The view model base class.
 * Sushi.Tests.Models.ViewModel
 * @extends ScriptModel
 */
function ViewModel(obj) {
    let value = obj;
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
 * @extends ViewModel
 */
function BaseViewModel(obj) {
    let value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.value = value.value;
    this.guid = value.guid;
    this.base = value.base;
}

BaseViewModel.prototype.mapFrom = function(obj) {
    return _.extend(new BaseViewModel(), obj); 
};

/**
 * Sushi.Tests.Models.InheritedViewModel
 * @extends BaseViewModel
 */
function InheritedViewModel(obj) {
    let value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.value = value.value;
    this.addition = value.addition;
}

InheritedViewModel.prototype.mapFrom = function(obj) {
    return _.extend(new InheritedViewModel(), obj); 
};

/**
 * For testing nullable properties.
 * Sushi.Tests.Models.NullablePropertiesViewModel
 * @extends ViewModel
 */
function NullablePropertiesViewModel(obj) {
    let value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.guid = value.guid;
    this.value2 = value.value2;
    this.value = value.value;
}

NullablePropertiesViewModel.prototype.mapFrom = function(obj) {
    return _.extend(new NullablePropertiesViewModel(), obj); 
};

/**
 * The PersonViewModel that represents a Person.
 * Sushi.Tests.Models.PersonViewModel
 * @extends ViewModel
 */
function PersonViewModel(obj) {
    let value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.identifier = value.identifier;
    this.name = value.name;
    this.surname = value.surname;
    this.gender = value.gender;
}

PersonViewModel.prototype.mapFrom = function(obj) {
    return _.extend(new PersonViewModel(), obj); 
};

/**
 * Represents a Student in a school.
 * Sushi.Tests.Models.StudentViewModel
 * @extends PersonViewModel
 */
function StudentViewModel(obj) {
    let value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.grade = value.grade;
    this.school = value.school;
}

StudentViewModel.prototype.mapFrom = function(obj) {
    return _.extend(new StudentViewModel(), obj); 
};

/**
 * Basic information about a School.
 * Sushi.Tests.Models.SchoolViewModel
 * @extends ViewModel
 */
function SchoolViewModel(obj) {
    let value = obj;
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
}

SchoolViewModel.prototype.mapFrom = function(obj) {
    return _.extend(new SchoolViewModel(), obj); 
};

/**
 * Simple model to verify complex types.
 * Sushi.Tests.Models.TypeModel
 * @extends ViewModel
 */
function TypeModel(obj) {
    let value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.nullableBool = value.nullableBool;
    this.nullableString = value.nullableString;
    this.guid = value.guid;
    this.date = value.date;
    this.student = value.student;
    this.students = value.students;
    this.studentPerClass = value.studentPerClass;
    this.readonlyString = value.readonlyString;
}

TypeModel.prototype.mapFrom = function(obj) {
    return _.extend(new TypeModel(), obj); 
};

/**
 * Sushi.Tests.BugFixes.AbstractBaseClass+AbstractBaseModel
 */
function AbstractBaseModel(obj) {
    let value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.name = value.name;
}

AbstractBaseModel.prototype.mapFrom = function(obj) {
    return _.extend(new AbstractBaseModel(), obj); 
};

/**
 * Sushi.Tests.BugFixes.AbstractBaseClass+ChildModel
 * @extends AbstractBaseModel
 */
function ChildModel(obj) {
    let value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.surname = value.surname;
}

ChildModel.prototype.mapFrom = function(obj) {
    return _.extend(new ChildModel(), obj); 
};

/**
 * Sushi.Tests.BugFixes.NoParameterlessCtorTests+CtorFixModel
 */
function CtorFixModel(obj) {
    let value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.name = value.name;
}

CtorFixModel.prototype.mapFrom = function(obj) {
    return _.extend(new CtorFixModel(), obj); 
};

/**
 * Sushi.Tests.BugFixes.NoXmlDocumentation+NoXmlDocumentationModel
 */
function NoXmlDocumentationModel(obj) {
    let value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.name = value.name;
}

NoXmlDocumentationModel.prototype.mapFrom = function(obj) {
    return _.extend(new NoXmlDocumentationModel(), obj); 
};

