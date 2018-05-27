// ReSharper disable UndeclaredGlobalVariableUsing
// ReSharper disable InconsistentNaming
// ReSharper disable WrongExpressionStatement
// ReSharper disable UseOfImplicitGlobalInFunctionScope

/**
 * $$SUMMARY$$
 *
 * Server-side generated model: $$TYPE_NAMESPACE$$.$$TYPENAME$$.
 * @name $$TYPENAME$$
 * @namespace $$TYPE_NAMESPACE$$
 * @param {Object<$$TYPENAME$$>} [$$ARGUMENT_NAME$$] The object to convert to the match the '$$TYPENAME$$' class.
 */
function $$TYPENAME$$($$ARGUMENT_NAME$$) {
	if ($$DEFINED_CHECK$$) {
		$$VALIDATE_OBJECT$$;
	}

	// Create object to avoid null/undefined TypeError
	if ($$UNDEFINED_CHECK$$)
		$$ARGUMENT_NAME$$ = {};

	$$SET_PROPERTY_VALUES$$;
}

/**
 * Check if the given '$$ARGUMENT_NAME$$' contains the expected keys and instances to match the '$$TYPENAME$$' class.
 * @name tryParse
 * @namespace $$TYPE_NAMESPACE$$.$$TYPENAME$$
 * @param {Object=} $$ARGUMENT_NAME$$ The object to parse.
 * @return {boolean} If the given '$$ARGUMENT_NAME$$' can match the '$$TYPENAME$$' class.
 */
$$TYPENAME$$.prototype.tryParse = function ($$ARGUMENT_NAME$$) {
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

window.$$TYPENAME$$ = $$TYPENAME$$;