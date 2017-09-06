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

    }
    public  class SalesViewModal
    {
        CategoryRepository catrepo = new CategoryRepository();
        TableRepository tablerepo = new TableRepository();


        public List<Category> CategoryList { get => catrepo.GetCategoryList(); set => CategoryList = value; }
        public List<Table> TableList { get => tablerepo.GetTableList(Program.LocationID); set => TableList = value; }

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

    }
   
}
