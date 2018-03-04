// ReSharper disable UndeclaredGlobalVariableUsing
// ReSharper disable InconsistentNaming
// ReSharper disable WrongExpressionStatement
(function (window) {
	"use strict";

	// ECMA 5 - $$TYPENAME$$

	function $$TYPENAME$$($$ARGUMENT_NAME$$) {
		if ($$DEFINED_CHECK$$) {
			$$VALIDATE_OBJECT$$;
		}

		$$SET_VALUES$$;
	}

	window.$$TYPENAME$$ = $$TYPENAME$$;

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

})(window);