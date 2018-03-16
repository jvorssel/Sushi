using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelConverter.Attributes
{
    /// <summary>
    ///     Used to tell what classes should be converted to specified script language.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class ConvertToScriptAttribute : Attribute
    {
    }
}
