import {Gender, ViewModel} from "./models.latest";

/**
 * The PersonViewModel that represents a Person.
 * @extends ViewModel
 */
export class PersonViewModel extends ViewModel {
    /** The Identifier that this Model refers to. */
    identifier: string = "e5fef186-8cd4-44e7-b60a-091a8e916683";
    /** The Name of the person. */
    name!: string;
    /** The Surname of the person. */
    surname!: string;
    /** The Gender of the person. */
    gender: Gender | number = 1;

    constructor(value: any = null) {
        super(value);

        if (Object.prototype.hasOwnProperty.call(value, 'identifier'))
            this.identifier = value.identifier;

        if (Object.prototype.hasOwnProperty.call(value, 'name'))
            this.name = value.name;

        if (Object.prototype.hasOwnProperty.call(value, 'surname'))
            this.surname = value.surname;

        if (Object.prototype.hasOwnProperty.call(value, 'gender'))
            this.gender = value.gender;

        if (Object.prototype.hasOwnProperty.call(value, 'guid'))
            this.guid = value.guid;

        if (Object.prototype.hasOwnProperty.call(value, 'createdOn'))
            this.createdOn = value.createdOn;

    }
}