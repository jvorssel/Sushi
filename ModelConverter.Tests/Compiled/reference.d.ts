// Definitely Typed - ModelWithManyLists

/**
 * @name ModelWithManyLists
 * @namespace ModelConverter.Tests.Models.ModelWithManyLists
 * @class ModelWithManyLists
 * @classdesc Server-side generated constructor for the 'ModelWithManyLists' class.
 * @summary A model with a LOT of lists.
 */
interface ModelWithManyListsConstructor {
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
}

declare const ModelWithManyLists: ModelWithManyListsConstructor;


// Definitely Typed - NameModel

/**
 * @name NameModel
 * @namespace ModelConverter.Tests.Models.NameModel
 * @class NameModel
 * @classdesc Server-side generated constructor for the 'NameModel' class.
 */
interface NameModelConstructor {
	Name: string;
	Insertion: string;
	Surname: string;
}

declare const NameModel: NameModelConstructor;


// Definitely Typed - PersonReferenceToUser

/**
 * @name PersonReferenceToUser
 * @namespace ModelConverter.Tests.Models.PersonReferenceToUser
 * @class PersonReferenceToUser
 * @classdesc Server-side generated constructor for the 'PersonReferenceToUser' class.
 */
interface PersonReferenceToUserConstructor {
	Name: string;
	Insertion: string;
	Surname: string;
	User: any;
}

declare const PersonReferenceToUser: PersonReferenceToUserConstructor;


// Definitely Typed - UserReferenceToPerson

/**
 * @name UserReferenceToPerson
 * @namespace ModelConverter.Tests.Models.UserReferenceToPerson
 * @class UserReferenceToPerson
 * @classdesc Server-side generated constructor for the 'UserReferenceToPerson' class.
 */
interface UserReferenceToPersonConstructor {
	RegisteredOn: any;
	Guid: any;
	Username: string;
	Password: string;
	Person: any;
}

declare const UserReferenceToPerson: UserReferenceToPersonConstructor;


// Definitely Typed - TypeModel

/**
 * @name TypeModel
 * @namespace ModelConverter.Tests.Models.TypeModel
 * @class TypeModel
 * @classdesc Server-side generated constructor for the 'TypeModel' class.
 */
interface TypeModelConstructor {
	Name: string;
	Number: number;
	Decimal: number;
	Value: boolean;
	Char: string;
}

declare const TypeModel: TypeModelConstructor;


// Definitely Typed - PersonModel

/**
 * @name PersonModel
 * @namespace ModelConverter.Tests.Models.Inheritance.PersonModel
 * @class PersonModel
 * @classdesc Server-side generated constructor for the 'PersonModel' class.
 */
interface PersonModelConstructor {
	Name: string;
	Surname: string;
}

declare const PersonModel: PersonModelConstructor;


// Definitely Typed - StudentModel

/**
 * @name StudentModel
 * @namespace ModelConverter.Tests.Models.Inheritance.StudentModel
 * @class StudentModel
 * @classdesc Server-side generated constructor for the 'StudentModel' class.
 */
interface StudentModelConstructor extends PersonModelConstructor {
	Grade: number;
	School: string;
	Gender: number;
	Name: string;
	Surname: string;
}

declare const StudentModel: StudentModelConstructor;


// Definitely Typed - DoNotIgnoreMe

/**
 * @name DoNotIgnoreMe
 * @namespace ModelConverter.Tests.Models.Ignore.DoNotIgnoreMe
 * @class DoNotIgnoreMe
 * @classdesc Server-side generated constructor for the 'DoNotIgnoreMe' class.
 */
interface DoNotIgnoreMeConstructor extends IgnoreTestRootConstructor {
	ShouldExist: string;
}

declare const DoNotIgnoreMe: DoNotIgnoreMeConstructor;


// Definitely Typed - IgnoreTestRoot

/**
 * @name IgnoreTestRoot
 * @namespace ModelConverter.Tests.Models.Ignore.IgnoreTestRoot
 * @class IgnoreTestRoot
 * @classdesc Server-side generated constructor for the 'IgnoreTestRoot' class.
 */
interface IgnoreTestRootConstructor {
}

declare const IgnoreTestRoot: IgnoreTestRootConstructor;


