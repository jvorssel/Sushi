namespace Common.Utility.Enum.ECMAScript
{
    /// <summary>
    ///     What <see cref="JavaScriptType"/> is referenced in Ecmascript.
    /// </summary>
    public enum JavaScriptType
    {
        /// <summary>
        ///     Key or value has not been defined.
        /// </summary>
        Undefined = 1,
        
        /// <summary>
        ///     Instance of a <see cref="Null"/>.
        /// </summary>
        Null = 2,

        /// <summary>
        ///     Instance of a <see cref="Boolean"/> type.
        /// </summary>
        Boolean = 3,

        /// <summary>
        ///     Instance of a <see cref="Number"/> type.
        /// </summary>
        Number = 4,

        /// <summary>
        ///     Instance of a <see cref="String"/> type.
        /// </summary>
        String = 5,

        /// <summary>
        ///     Represents a <see cref="Date"/> type.
        /// </summary>
        Date = 6,

        /// <summary>
        ///     Represents a <see cref="RegExp"/> type.
        /// </summary>
        RegExp = 7,

        /// <summary>
        ///     Represents a Collection of different variables.
        /// </summary>
        Array = 8,

        /// <summary>
        ///     The base of every value is a <see cref="Object"/>.
        /// </summary>
        Object = 9,

        /// <summary>
        ///     Represents a <see cref="Decimal"/> type.
        /// </summary>
        Decimal = 10,
    }
}
