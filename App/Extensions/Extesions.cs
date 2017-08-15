using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Extensions
{
   
    public static class MyExtensions
    {
        public static string TrimLastCharacter(this String str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return str;
            }
            else
            {
                return str.TrimEnd(str[str.Length - 1]);
            }
        }
    }
}
