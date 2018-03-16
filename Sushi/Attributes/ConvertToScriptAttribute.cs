using System;

namespace Sushi.Attributes
{
    /// <summary>
    ///     Used to tell what classes should be converted to specified script language.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class ConvertToScriptAttribute : Attribute
    {
    }
}
