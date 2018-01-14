using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


    public static class ErrorLogger
    {



        // *************************************************************
        //NAME:          WriteToErrorLog
        //PURPOSE:       Open or create an error log and submit error message
        //PARAMETERS:    msg - message to be written to error file
        //               stkTrace - stack trace from error message
        //               title - title of the error file entry
        //RETURNS:       Nothing
        //*************************************************************
        public static void WriteToErrorLog(string msg, string stkTrace, string title)
        {
            if (!(System.IO.Directory.Exists(Application.StartupPath + "\\Errors\\")))
            {
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Errors\\");
            }
            FileStream fs = new FileStream(Application.StartupPath + "\\Errors\\errlog.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter s = new StreamWriter(fs);
            s.Close();
            fs.Close();
            FileStream fs1 = new System.IO.FileStream(Application.StartupPath + "\\Errors\\errlog.txt", FileMode.Append, FileAccess.Write);
            StreamWriter s1 = new StreamWriter(fs1);
            s1.Write("Title: " + title + Environment.NewLine);
            s1.Write("Message: " + msg + Environment.NewLine);
            s1.Write("StackTrace: " + stkTrace + Environment.NewLine);
            s1.Write("Date/Time: " + DateTime.Now.ToString() + Environment.NewLine);
            s1.Write("===========================================================================================" + Environment.NewLine);
            s1.Close();
            fs1.Close();
        }


    }
}
