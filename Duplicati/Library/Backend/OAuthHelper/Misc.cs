using System;
using System.Collections.Generic;
using System.Text;

namespace Duplicati.Library
{
    public static class Misc
    {
        public static bool IsNullOrWhiteSpace(String s)
        {
            return s is null || s.Trim() == String.Empty;
        }
    }
}
