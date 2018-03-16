// ReSharper disable UndeclaredGlobalVariableUsing
// ReSharper disable InconsistentNaming
// ReSharper disable WrongExpressionStatement
// ReSharper disable UseOfImplicitGlobalInFunctionScope
// ECMA 6 - $$TYPENAME$$

/**
 * @summary Server-side generated model for the '$$TYPENAME$$' class.
 */
class $$TYPENAME$$ $$INHERIT_TYPE$$ {
	/**
	 * @name $$TYPENAME$$
	 * @class $$TYPENAME$$
	 * @classdesc Server-side generated constructor for the '$$TYPENAME$$' class.
	 * @param {Object<$$TYPENAME$$>} [$$ARGUMENT_NAME$$] The object to convert to the match the '$$TYPENAME$$' class.
	 */
	constructor($$ARGUMENT_NAME$$) {
		if ($$DEFINED_CHECK$$) {
			$$VALIDATE_OBJECT$$;
		}

		$$SET_VALUES$$;
	}

	/**
	 * @name tryParse
	 * @description Check if the given '$$ARGUMENT_NAME$$' contains the expected keys and instances to match the '$$TYPENAME$$' class.
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