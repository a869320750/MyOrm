using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.Common
{
    public static class RegexJudge
    {
        public static bool IsNumeric(this string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
        }
        public static bool IsInt(this string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*$");
        }
        public static bool IsUnsign(this string value)
        {
            return Regex.IsMatch(value, @"^\d*[.]?\d*$");
        }

        public static bool IsTel(this string strInput)
        {
            return Regex.IsMatch(strInput, @"\d{3}-\d{8}|\d{4}-\d{7}");
        }
    }
}
