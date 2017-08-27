using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    public class Product
    {
       

        [Key]
        public int Id { get; set; }

        public string ProductName { get; set; }
        public int CategoryId { get; set; }
       
        public Decimal UnitPrice { get; set; }
        public Decimal DiscountForLocation { get; set; }
        public Decimal MinimumSPForLocation { get; set; }
        public virtual Category Category { get; set; }
        public String Color { get; set; }
        public String Image { get; set; }
        public Boolean IsAvailable { get; set; }
        public Boolean? IsRateChangable { get; set; }
        public virtual List<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual List<KotDetail> KotDetails { get; set; }
    }
    public class Category
    {
      

        [Key]
        public int Id { get; set; }

        public String CategoryName { get; set; }
        public String Color { get; set; }
        
        public virtual List<Product> Products { get; set; }
    }


    public class User
    {

        [Key]
        public int UserID { get; set; }

        public int PassCode { get; set; }

        public int StoreID { get; set; }

        public String UserName { get; set; }

        public virtual Store Store { get; set; }
    }



    public class Store
    {

        [Key]
        public int StoreID { get; set; }

        public String StoreName { get; set; }

        public String  StoreAddress { get; set; }

        public virtual List<User> Users { get; set; }
        public virtual List<ControlDiemension> ControlDiemensions { get; set; }
        public virtual List<Table> Tables { get; set; }
        public virtual List<Invoicemaster> Invoicemasters { get; set; }
        public virtual List<KotMaster> KotMasters { get; set; }
    }

    public class Company
    {
        public String CompanyId
        {
            get;
            set;
        }
        public String Name
        {
            get;
            set;
        }
      
    }



    public class Table
    {

        [Key]
        public int TableID { get; set; }

       
        public int StoreID { get; set; }

        public String TableName { get; set; }

        public virtual Store Store { get; set; }
        
        public String Color { get; set; }

        public virtual List<KotMaster> KotMasters { get; set; }
        public virtual List<Invoicemaster> Invoicemasters { get; set; }
    }




    public class Customer
    {

        [Key]
        public int CustomerID { get; set; }


        public int StoreID { get; set; }

        public String CustomerName { get; set; }

        public string PhoneNumber { get; set; }

        public string CustomerDetails { get; set; }

        public virtual Store Store { get; set; }

        public String Color { get; set; }
        public virtual List<Invoicemaster> Invoicemasters { get; set; }
        public virtual List<KotMaster> KotMasters { get; set; }
    }


    public class Invoicemaster
    {

        [Key]
        public int InvoicemasterID { get; set; }


        public int StoreID { get; set; }
        public int UserID { get; set; }
        public int? KotMasterID { get; set; }
        public int CustomerID { get; set; }
        public int TableID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public virtual Table Table { get; set; }
        public Decimal TotalPaid { get; set; }
        public Decimal RoundOffAmount { get; set; }
        public virtual Store Store { get; set; }
        public virtual User User { get; set; }
        public virtual Customer Customer { get; set; }
        public Boolean IsUploaded { get; set; }
        public virtual List<InvoiceDetail> InvoiceDetails { get; set; }
        public String Color { get; set; }
    }

    public class InvoiceDetail
    {

        [Key]
        public int InvoiceDetailID { get; set; }
        public int InvoicemasterID { get; set; }

        public int ProductId { get; set; }
        public Decimal UnitPrice { get; set; }
        public Decimal Qty { get; set; }
        public Decimal DiscountPerUOM { get; set; }
        public Decimal Total { get; set; }
        public Boolean IsUploaded { get; set; }
        public virtual Product Product { get; set; }
        public virtual Invoicemaster Invoicemaster { get; set; }
      
        
    }

  
    public class OdooDetail
    {

        [Key]
        public int OdooDetailID { get; set; }
        public String Server { get; set; }
        public int PortNum { get; set; }
        public String UserId { get; set; }
        public String Password { get; set; }
        public String DataBasename { get; set; }
        public Boolean IsActive { get; set; }
        public int StoreID { get; set; }
        public virtual Store Store { get; set; }
    }


    public  class AppUserSetting
    {
        [Key]
        public int AppUserSettingID { get; set; }
        public  int ProductperRow { get; set; }

        public  String InvoicePrefix { get; set; }

        public  int PaddingNumber { get; set; }

        public  Decimal ProductButtonWidth { get; set; }
        public  Decimal ProductButtonHeigth { get; set; }

        public  int StoreID { get; set; }

        public  Boolean RealtimeInvoiceUpdate { get; set; }

        public  Boolean FastLoading { get; set; }

        public  Boolean AutoSizebutton { get; set; }
        public virtual Store Store { get; set; }
    }
   
    public class KotMaster
    {
        [Key]
        public int KotMasterID { get; set; }
        public int StoreID { get; set; }
        public int UserID { get; set; }
       
        public int CustomerID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int TableID { get; set; }
        public Decimal TotalPaid { get; set; }
        public Decimal RoundOffAmount { get; set; }
        public virtual Store Store { get; set; }
        public virtual User User { get; set; }
        public virtual Table Table { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<KotDetail> KotDetails { get; set; }
        public String Color { get; set; }

    }
    public class KotDetail
    {

        [Key]
        public int KotDetailID { get; set; }
        public int KotMasterID { get; set; }
        public String ProductName { get; set; }
        public int ProductId { get; set; }
        public Decimal UnitPrice { get; set; }
        public Decimal Qty { get; set; }
        public Decimal DiscountPerUOM { get; set; }
        public Decimal Total { get; set; }
        public Boolean IsUploaded { get; set; }
        public virtual Product Product { get; set; }
       public virtual KotMaster KotMasters { get; set; }


    }

}
