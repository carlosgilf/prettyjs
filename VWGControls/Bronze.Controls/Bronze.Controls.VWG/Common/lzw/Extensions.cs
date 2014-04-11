using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bronze.Controls.VWG.Common
{
    public static class Extensions
    {
        public static bool IsNull(this object obj)
        {
            if(obj==null) return true;

            if (obj is string)
            {
                return string.IsNullOrEmpty(obj.ToString());
            }
            return false;
        }

        public static bool NotNull(this object obj)
        {
            return !IsNull(obj);
        }

        public static int charCodeAt(this string str, int i)
        {
            return (int)str[i];
        }

        public static char charAt(this string str,int i)
        {
            return str[i];
        }






   









        
    }
}