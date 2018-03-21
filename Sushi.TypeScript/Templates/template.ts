// ReSharper disable UndeclaredGlobalVariableUsing
// ReSharper disable InconsistentNaming
// ReSharper disable WrongExpressionStatement
// ReSharper disable UseOfImplicitGlobalInFunctionScope
/**
 * $$SUMMARY$$
 *
 * Server-side generated model: $$TYPE_NAMESPACE$$.$$TYPENAME$$.
 * @name $$TYPENAME$$
 * @namespace $$TYPE_NAMESPACE$$.$$TYPENAME$$
 */
export class $$TYPENAME$$ $$INHERIT_TYPE$$ {

	$$DEFINE_PROPERTIES$$;

	/**
	 * $$SUMMARY$$
	 *
	 * FullName: $$TYPE_NAMESPACE$$.$$TYPENAME$$
	 * @param {Object<$$TYPENAME$$>} [$$ARGUMENT_NAME$$] The object to convert to the match the '$$TYPENAME$$' class.
	 */
	constructor($$ARGUMENT_NAME$$ : any) {
		if ($$DEFINED_CHECK$$) {
			$$VALIDATE_OBJECT$$;
		}

		$$SET_PROPERTY_VALUES$$;
	}

	/**
	 * Check if the given '$$ARGUMENT_NAME$$' contains the expected keys and instances to match the '$$TYPENAME$$' class.
	 * @param {Object=} $$ARGUMENT_NAME$$ The object to parse.
	 */
	static tryParse($$ARGUMENT_NAME$$ : any) : boolean {
		try {
			if ($$UNDEFINED_CHECK$$)
				return false; // Empty, return false.

			$$VALIDATE_OBJECT$$;

			return true;
		}
		catch (exc) {
			console.warn(exc);
			return false;
		}
	}
}