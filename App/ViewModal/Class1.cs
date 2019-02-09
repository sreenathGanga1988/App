using App.Model;
using App.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModal
{
    class Class1
    {
    }

    public class ProductlistViewModal
    {
        public int ProductID { get; set; }
        public String ProductName { get; set; }
        public String Color { get; set; }
        public Boolean? IsAvailable { get; set; }
        public Boolean? IsActive { get; set; }
    }
    public  class SalesViewModal
    {
        CategoryRepository catrepo = new CategoryRepository();
        TableRepository tablerepo = new TableRepository();
        BuzzerRepository buzzerrepo = new BuzzerRepository();
        CustomerRepositiry custorepo = new CustomerRepositiry();
        PaymentModeRepository payrepo = new PaymentModeRepository();

        public List<Category> CategoryList { get => catrepo.GetCategoryListActive(); set => CategoryList = value; }
        public List<Table> TableList { get => tablerepo.GetTableList(Program.LocationID); set => TableList = value; }

        public List<Customer> CustomerList { get => custorepo.GetcustomerofLocation(Program.LocationID); set => CustomerList = value; }
        public List<Buzzer> BuzzerMasterList { get => buzzerrepo.GetBuzzerList(Program.LocationID); set => BuzzerMasterList = value; }
        public List<PaymentModeMaster> paymentMasterList { get => payrepo.GetPaymnetModeList(Program.LocationID); set => paymentMasterList = value; }

        public List<Buzzer> BuzzerList { get; set; }
    }

    public class InvoiceviewModal
    {
        public int InvoicemasterID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public String InvoiceNum { get; set; }
        public String TableName { get; set; }
        public String StoreName { get; set; }
        public String CustomerName { get; set; }
        public Decimal TotalBill { get; set; }
        public Decimal TotalPaid { get; set; }
        public String PaymentMode { get; set; }
        public String ShiftName { get; set; }
        public String Status { get; set; }
       

    }
   public class CashoutViewModel
    {
        public String CashOutNum { get; set; }
        public String username { get; set; }
        public DateTime CashOutDate { get; set; }
        public  decimal TotalCashOut { get; set; }
        public String Shift { get; set; }
        public String CashOutType { get; set; }
      
        public String Remark { get; set; }
        public String InOrOut { get; set; }
       
    }
    public class CreditViewModel
    {
           public int CreditMasterID { get; set; }
        public String CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal? PaymentDue { get; set; }
        public String PhoneNumber { get; set; }
        public String InvoiceNum { get; set; }

      

    }
}
