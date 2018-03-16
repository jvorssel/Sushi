namespace Sushi.JavaScript.Enum
{
    /// <summary>
    ///     What ECMAScript <see cref="ErrorType"/> is referenced.
    /// </summary>
    public enum ErrorType
    {
        /// <summary>
        ///     The base Error implementation.
        /// </summary>
        Error = 1,

        /// <summary>
        ///     Thrown when the Syntax contains unexpected character(s).
        /// </summary>
        SyntaxError = 2,

        /// <summary>
        ///     Thrown for validation purposes or if a value is out-of-range.
        /// </summary>
        RangeError = 3,

        /// <summary>
        ///      Thrown when a non-existend variable is referenced.
        /// </summary>
        ReferenceError = 4,

        /// <summary>
        ///     Thrown when a value is not of the expected type.
        /// </summary>
        TypeError = 5,

        /// <summary>
        ///     Thrown when a global URI handling function was used in a wrong way.
        /// </summary>
        UriError = 6,

        /// <summary>
        ///     Thrown when a method causes an internal error, for example a infinite call chain.
        /// </summary>
        InternalError = 7,

        /// <summary>
        ///     Thrown when evaluating EcmaScript code caused an unexpected result.
        /// </summary>
        EvalError = 8,
    }
}