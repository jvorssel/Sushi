// Definitely Typed - ModelWithManyLists

/**
 * A model with a LOT of lists.
 * FullName = Sushi.Tests.Models.ModelWithManyLists
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
 * FullName = Sushi.Tests.Models.NameModel
 */
interface NameModelConstructor {
	Name: string;
	Insertion: string;
	Surname: string;
}

declare const NameModel: NameModelConstructor;


// Definitely Typed - PersonReferenceToUser

/**
 * FullName = Sushi.Tests.Models.PersonReferenceToUser
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
 * FullName = Sushi.Tests.Models.UserReferenceToPerson
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
 * FullName = Sushi.Tests.Models.TypeModel
 */
interface TypeModelConstructor {
	Name: string;
	Number: number;
	Decimal: number;
	Value: boolean;
	Char: string;
}

declare const TypeModel: TypeModelConstructor;


// Definitely Typed - Gender

/**
 * FullName = Sushi.Tests.Models.Inheritance.Gender
 */
interface GenderConstructor {
}

declare const Gender: GenderConstructor;


// Definitely Typed - PersonModel

/**
 * FullName = Sushi.Tests.Models.Inheritance.PersonModel
 */
interface PersonModelConstructor {
	Name: string;
	Surname: string;
}

declare const PersonModel: PersonModelConstructor;


// Definitely Typed - StudentModel

/**
 * FullName = Sushi.Tests.Models.Inheritance.StudentModel
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
 * FullName = Sushi.Tests.Models.Ignore.DoNotIgnoreMe
 */
interface DoNotIgnoreMeConstructor extends IgnoreTestRootConstructor {
	ShouldExist: string;
}

declare const DoNotIgnoreMe: DoNotIgnoreMeConstructor;


// Definitely Typed - IgnoreTestRoot

/**
 * FullName = Sushi.Tests.Models.Ignore.IgnoreTestRoot
 */
interface IgnoreTestRootConstructor {
}

declare const IgnoreTestRoot: IgnoreTestRootConstructor;


