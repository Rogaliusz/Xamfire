using System;
using System.Collections.Generic;
using System.Text;

namespace Xamfire.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string value)
            => string.IsNullOrEmpty(value);
    }
}
