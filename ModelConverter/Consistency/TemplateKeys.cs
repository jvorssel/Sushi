namespace ModelConverter.Consistency
{
    /// <summary>
    ///     Template key constants.
    /// </summary>
    public static class TemplateKeys
    {
        public const string TYPE_NAME_KEY = @"$$TYPENAME$$";
        public const string VALIDATION_KEY = @"$$VALIDATE_OBJECT$$";
        public const string VALUES_KEY = @"$$SET_VALUES$$";
        public const string PROPERTY_KEY = @"$$PROPERTY$$";
        public const string VALUE_KEY = @"$$VALUE$$";
        
        public const string IS_DEFINED_CHECK = @"$$DEFINED_CHECK$$";
        public const string IS_UNDEFINED_CHECK = @"$$UNDEFINED_CHECK$$";
        public const string ARGUMENT_NAME = @"$$ARGUMENT_NAME$$";
    }
}