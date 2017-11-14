using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Model;
namespace App.ViewModal
{
    public  class SettingViewModal
    {

        public  OdooDetail MyOoodoDetasils { get; set; }
        public  PrinterDetail MyPrinterDetails { get; set; }
        public AppUserSetting AppUserSettings { get; set; }
        public LocalPrinter LocalPrinterSetting { get; set; }
    }
}
