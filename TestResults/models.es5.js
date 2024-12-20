/**
 * Sushi.TestModels.ConstrainedGeneric`1
 * @template {any} T
 */
function ConstrainedGeneric(obj) {
    let value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.data = value.data;
    this.name = value.name;
}

/**
 * A class with const values.
 * Sushi.TestModels.ConstValues
 */
function ConstValues(obj) {
    let value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.static = value.static;
    this.first = value.first;
    this.last = value.last;
}

/**
 * Sushi.TestModels.GenericComplexStandalone`2
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

/**
 * Sushi.TestModels.GenericStandalone`1
 * @template {any} TEntry
 */
function GenericStandalone(obj) {
    let value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.values = value.values;
    this.totalAmount = value.totalAmount;
}

/**
 * .
 * Sushi.TestModels.ScriptModel
 */
function ScriptModel(obj) {
    let value = obj;
    if (!(value instanceof Object)) 
        value = {};

}

/**
 * The view model base class.
 * Sushi.TestModels.ViewModel
 * @extends ScriptModel
 */
function ViewModel(obj) {
    let value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.guid = value.guid;
    this.createdOn = value.createdOn;
}

/**
 * Sushi.TestModels.BaseViewModel
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

/**
 * Sushi.TestModels.InheritedViewModel
 * @extends BaseViewModel
 */
function InheritedViewModel(obj) {
    let value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.value = value.value;
    this.addition = value.addition;
}

/**
 * For testing nullable properties.
 * Sushi.TestModels.NullablePropertiesViewModel
 * @extends ViewModel
 */
function NullablePropertiesViewModel(obj) {
    let value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.value2 = value.value2;
    this.guid = value.guid;
    this.value = value.value;
}

/**
 * The PersonViewModel that represents a Person.
 * Sushi.TestModels.PersonViewModel
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

/**
 * Represents a Student in a school.
 * Sushi.TestModels.StudentViewModel
 * @extends PersonViewModel
 */
function StudentViewModel(obj) {
    let value = obj;
    if (!(value instanceof Object)) 
        value = {};

    this.grade = value.grade;
    this.school = value.school;
}

/**
 * Basic information about a School.
 * Sushi.TestModels.SchoolViewModel
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

/**
 * Simple model to verify complex types.
 * Sushi.TestModels.TypeModel
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

