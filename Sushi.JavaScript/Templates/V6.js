// ReSharper disable UndeclaredGlobalVariableUsing
// ReSharper disable InconsistentNaming
// ReSharper disable WrongExpressionStatement
// ReSharper disable UseOfImplicitGlobalInFunctionScope
// ECMA 6 - $$TYPENAME$$

/**
 * $$SUMMARY$$
 *
 * Server-side generated model: $$TYPE_NAMESPACE$$.$$TYPENAME$$.
 * @name $$TYPENAME$$
 * @namespace $$TYPE_NAMESPACE$$.$$TYPENAME$$
 */
class $$TYPENAME$$ $$INHERIT_TYPE$$ {
	/**
	 * $$SUMMARY$$
	 *
	 * Server-side generated model: $$TYPE_NAMESPACE$$.$$TYPENAME$$.
	 * @param {Object<$$TYPENAME$$>} [$$ARGUMENT_NAME$$] The object to convert to the match the '$$TYPENAME$$' class.
	 */
	constructor($$ARGUMENT_NAME$$) {
		if ($$DEFINED_CHECK$$) {
			$$VALIDATE_OBJECT$$;
		}

		// Create object to avoid null/undefind TypeError
		if ($$UNDEFINED_CHECK$$)
			$$ARGUMENT_NAME$$ = {};

		$$SET_PROPERTY_VALUES$$;
	}

	/**
	 * Check if the given '$$ARGUMENT_NAME$$' contains the expected keys and instances to match the '$$TYPENAME$$' class.
	 * @name tryParse
	 * @namespace $$TYPE_NAMESPACE$$.$$TYPENAME$$.tryParse
	 * @param {Object=} $$ARGUMENT_NAME$$ The object to parse.
	 * @return {boolean} If the given '$$ARGUMENT_NAME$$' can match the '$$TYPENAME$$' class.
	 */
	static tryParse($$ARGUMENT_NAME$$) {
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