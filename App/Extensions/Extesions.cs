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


        public static Boolean CheckifNumeric(String txt)
        {
            Boolean isnumeric = false;

            try
            {
                int k = int.Parse(txt);
                isnumeric = true;
            }
            catch (Exception)
            {

                isnumeric = false;
            }


            return isnumeric;
        }




        public static Boolean CheckifDecimal(String txt)
        {
            Boolean isfloat = false;

            try
            {
                float k = float.Parse(txt);
                isfloat = true;
            }
            catch (Exception)
            {

                isfloat = false;
            }


            return isfloat;
        }






    }
}
