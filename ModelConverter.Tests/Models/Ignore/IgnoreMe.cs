using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelConverter.Attributes;

namespace ModelConverter.Tests.Models.Ignore
{
    [IgnoreForScript]
    public class IgnoreMe : IgnoreTestRoot
    {
    }
}
