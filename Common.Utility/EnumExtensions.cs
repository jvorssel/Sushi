using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utility
{
    public static class EnumExtensions
    {
        /// <summary>
        ///     If the <typeparamref name="TEnum"/> <paramref name="@this"/> has the <see cref="FlagsAttribute"/>.
        /// </summary>
        public static bool HasFlagsAttr<TEnum>(this TEnum @this)
            where TEnum : struct, IComparable, IFormattable, IConvertible
            => typeof(TEnum).GetCustomAttributes(typeof(FlagsAttribute), false).Any();
    }
}
