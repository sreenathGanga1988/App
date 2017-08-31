﻿using App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    static class Program
    {

        public static String  Username ;
        public static int UserID;
        public static int LocationID;
        public static String StoreName;
        public static String StoreAddress;
        public static String KotPrinter;
        public static String Invoiceprinter;
        public static OdooDetail MyOoodoDetasils { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UI.Login());
        }
    }
}
