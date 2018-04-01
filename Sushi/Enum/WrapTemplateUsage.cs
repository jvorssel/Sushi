namespace Sushi.Enum {
    public enum WrapTemplateUsage
    {
        /// <summary>
        ///     The script models wont be placed in a wrap template.
        /// </summary>
        None = 0,
        
        /// <summary>
        ///     Wrap the template around the resulting set of Script models.
        /// </summary>
        Global = 1,

        /// <summary>
        ///     Wrap the template around each created script model.
        /// </summary>
        Each = 2,

        
    }
}