using System;

namespace TheBeholder.Business
{
    public static class StringExtension
    {
        public static decimal ToMonetary(this string str)
        {
            if (str.Contains("%"))
                return ToPercent(str);
            
            return ToDecimal(str);
        }
        public static decimal ToDecimal(this string str) => Convert.ToDecimal(str);
        public static decimal ToPercent(this string str)
        {
            if (str.Contains("%"))
                return ToDecimal(str.Replace("%", "")) / 100;

            return ToDecimal(str) / 100;
        }
    }

}