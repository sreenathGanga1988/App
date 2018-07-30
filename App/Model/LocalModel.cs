using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    class LocalModel
    {
    }
    public class LocalPrinter
    {
        public string DefaultPrinter;
        public string DefaultKOTPrinter;
    }


    public class ShiftViewModel
    {

        public String StoreName { get; set; }
        public String ShiftName { get; set; }
        public String User { get; set; }
        public String Shiftfrom { get; set; }
        public String ShiftTo { get; set; }
        public Decimal Deletedvalue { get; set; }
        public Decimal TotalSales { get; set; }
        public Decimal TotalCharges { get; set; }
        public Decimal TotalDiscount { get; set; }

        public Decimal Netsales { get; set; }
        public Decimal TotalCC{ get; set; }
        public Decimal TotalByCash { get; set; }
        public Decimal TotalByCurrency { get; set; }
        public Decimal TottalByCC { get; set; }
        public Decimal TotalByZomato { get; set; }
        public Decimal TotalByCheque { get; set; }
        public Decimal TotalByGift { get; set; }
        public Decimal TotalByCredit { get; set; }
        public Decimal TotalTax { get; set; }
        public Decimal NetAmount { get; set; }
        public Decimal SettlementAmount { get; set; }

        public Decimal TableBill { get; set; }
        public Decimal TotalCashout { get; set; }
        public Decimal TotalCashIn{ get; set; }
        public Decimal TotalCredit { get; set; }
        public Decimal TotalRefund { get; set; }
        public Decimal TotalSetllement { get; set; }

        public List<Invoicemaster> invoicemstrlist { get; set; }
    }

}
