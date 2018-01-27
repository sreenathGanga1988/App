using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int? OdooProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }

        public Decimal? UnitPrice { get; set; }
        public Decimal? DiscountForLocation { get; set; }
        public Decimal? MinimumSPForLocation { get; set; }
        public Decimal? Taxamount { get; set; }
        public virtual Category Category { get; set; }
        public String Color { get; set; }
        public String Image { get; set; }
        public Boolean? IsAvailable { get; set; }
        public Boolean? IsRateChangable { get; set; }
        public int? OdooCategoryId { get; set; }
        public Boolean? IsTodaySpecial { get; set; }

        public virtual List<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual List<KotDetail> KotDetails { get; set; }
    }
    public class Category
    {


        [Key]
        public int Id { get; set; }
        public int? OdooCategoryId { get; set; }
        public String CategoryName { get; set; }
        public String Color { get; set; }
        public int? PrinterId { get; set; }
        public virtual List<Product> Products { get; set; }
        public String PrinterName { get; set; }
        public virtual Printer Printer { get; set; }
    }


    public class Shift
    {
        public int ShiftID { get; set; }
        public String ShiftName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Boolean? IsClosed { get; set; }
        public int StoreID { get; set; }
        public int OdooShiftId { get; set; }
        public String PosName { get; set; }
        public String StartUserName { get; set; }
        public String CloseUserName { get; set; }
        public virtual Store Store { get; set; }
    }

    public class User
    {

        [Key]
        public int UserID { get; set; }

        public int PassCode { get; set; }
        public int OdooUserID { get; set; }
        public int StoreID { get; set; }

        public String UserName { get; set; }

        public virtual Store Store { get; set; }
        public virtual List<RefundMaster> RefundMasters { get; set; }
    }



    public class Store
    {

        [Key]
        public int StoreID { get; set; }

        public String StoreName { get; set; }
        public int? OdooStoreId { get; set; }
        public String StoreAddress { get; set; }
        public String Street { get; set; }
        public String Phone { get; set; }
        public String StoreDBId { get; set; }

        public virtual List<User> Users { get; set; }
        public virtual List<ControlDiemension> ControlDiemensions { get; set; }
        public virtual List<Table> Tables { get; set; }
        public virtual List<Invoicemaster> Invoicemasters { get; set; }
        public virtual List<KotMaster> KotMasters { get; set; }
        public virtual List<PrinterDetail> PrinterDetails { get; set; }

        public virtual List<RefundMaster> RefundMasters { get; set; }
        public virtual List<Printer> Printers { get; set; }
        public virtual List<Buzzer> Buzzers { get; set; }
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

        public int OdooTableID { get; set; }

        public String TableName { get; set; }

        public virtual Store Store { get; set; }

        public String Color { get; set; }

        public virtual List<KotMaster> KotMasters { get; set; }
        public virtual List<Invoicemaster> Invoicemasters { get; set; }
    }


    public class Buzzer
    {

        [Key]
        public int BuzzerID { get; set; }

        public int OdooBuzzerID { get; set; }
        public int StoreID { get; set; }

        public String BuzzerName { get; set; }

        public virtual Store Store { get; set; }

        public String Color { get; set; }

        public Boolean IsLocked { get; set; }
       
    }


    public class Customer
    {

        [Key]
        public int CustomerID { get; set; }


        public int StoreID { get; set; }

        public String CustomerName { get; set; }

        public string PhoneNumber { get; set; }

        public Decimal? PaymentDue { get; set; }

        public Decimal? Discount { get; set; }

        public string CustomerDetails { get; set; }

        public string AddedBy { get; set; }

        public String BarcodeNum { get; set; }
        public string AddedDate { get; set; }

        public int OdooID { get; set; }
        public virtual Store Store { get; set; }


        public Boolean IsDetailChanged { get; set; }
        public String Color { get; set; }
        public virtual List<Invoicemaster> Invoicemasters { get; set; }
        public virtual List<KotMaster> KotMasters { get; set; }

     
    }


    public class Invoicemaster
    {

        [Key]
        public int InvoicemasterID { get; set; }
        public string InvoiceNum { get; set; }
       
        public int StoreID { get; set; }
        public int UserID { get; set; }
        public int? KotMasterID { get; set; }
        public int CustomerID { get; set; }
        public int TableID { get; set; }
        public int PayMentModeId { get; set; }
        public int? BuzzerID { get; set; }

        public Decimal? Taxamount { get; set; }

        public DateTime InvoiceDate { get; set; }
        public virtual Table Table { get; set; }
        public Decimal TotalPaid { get; set; }
        public Decimal TotalBill { get; set; }
        public Decimal TotalDiscount { get; set; }
        public Decimal RoundOffAmount { get; set; }
        public virtual Store Store { get; set; }
        public virtual User User { get; set; }
        public virtual Customer Customer { get; set; }
        public Boolean IsUploaded { get; set; }
        public Boolean? IstableBill { get; set; }
        public Boolean? IsKOT { get; set; }
        public virtual List<InvoiceDetail> InvoiceDetails { get; set; }
        public String Color { get; set; }
        public String TableName { get; set; }
      
        public String PaymentMode { get; set; }
        public String BuzzerName { get; set; }
        public String ShiftName { get; set; }

        public Boolean? IsDeleted { get; set; }
        public String DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public int? ShiftID { get; set; }
        public virtual Shift Shift { get; set; }

        public virtual Buzzer Buzzer { get; set; }
        [NotMapped]
        public string StoreName { get; set; }
        [NotMapped]
        public string StoreAddress { get; set; }

        [NotMapped]
        public string StoreStreet { get; set; }
        [NotMapped]
        public string StorePhone { get; set; }


        [NotMapped]
        public string Cashier { get; set; }
        [NotMapped]
        public string CustomerName { get; set; }
        [NotMapped]
        public string CustomerAdress { get; set; }

        [NotMapped]
        public string CustomerPhone { get; set; }
        public virtual List<RefundMaster> RefundMasters { get; set; }
  
    }

    public class PaymentModeMaster
    {
        [Key]
        public int PaymentModeID { get; set; }

        public String PaymentMode { get; set; }
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
        public Boolean? IsDeleted { get; set; }
        public String Notes { get; set; }
        
        public Decimal PreviousQty { get; set; }
        public int? Kotnum { get; set; }

        public Decimal AdjustedQty { get; set; }
        public Decimal? Taxamount { get; set; }
        public virtual Product Product { get; set; }
        public virtual Invoicemaster Invoicemaster { get; set; }
        [NotMapped]
        public string ProductName { get; set; }

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


    public class AppUserSetting
    {
        [Key]
        public int AppUserSettingID { get; set; }
        public int ProductperRow { get; set; }

        public String InvoicePrefix { get; set; }

        public string KotPrefix { get; set; }


        public int PaddingNumber { get; set; }

        public Decimal ProductButtonWidth { get; set; }
        public Decimal ProductButtonHeigth { get; set; }

        public int StoreID { get; set; }

        public Boolean RealtimeInvoiceUpdate { get; set; }

        public Boolean FastLoading { get; set; }

        public Boolean AutoSizebutton { get; set; }
        public virtual Store Store { get; set; }
        public Boolean IsActive { get; set; }
    }


    public class PrinterDetail
    {

        [Key]
        public int PrinterDetailId { get; set; }
        public String PosPrinter { get; set; }

        public String KotPrinter { get; set; }

        public String JuicePrinter { get; set; }

        public int StoreID { get; set; }
        public virtual Store Store { get; set; }
        public Boolean IsActive { get; set; }
    }


    public class Printer
    {


        [Key]
        public int PrinterId { get; set; }
        public String PrinterName { get; set; }
        public String Remark { get; set; }
        public int StoreID { get; set; }
        public virtual List<Category> Categorys { get; set; }
        public virtual Store Store { get; set; }
    }

    public class KotMaster
    {
        [Key]
        public int KotMasterID { get; set; }
        public string KotNum { get; set; }
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

        [NotMapped]
        public string StoreName { get; set; }
        [NotMapped]
        public string StoreAddress { get; set; }
        [NotMapped]
        public string Cashier { get; set; }
        [NotMapped]
        public string CustomerName { get; set; }

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
        public Boolean IsDeleted { get; set; }
        public Boolean IsPrinted { get; set; }
        public virtual Product Product { get; set; }
        public virtual KotMaster KotMasters { get; set; }


    }



    public class RefundMaster
    {
        [Key]
        public int RefundMasterID { get; set; }
        public string RefundNum { get; set; }
        public int StoreID { get; set; }
        public int UserID { get; set; }
        public int? ShiftID { get; set; }
        public int InvoicemasterID { get; set; }
        public Boolean IsUploaded { get; set; }
        public String Approvedby { get; set; }
        public DateTime RefundDate { get; set; }
        public Decimal TotalRefund { get; set; }
        public virtual Store Store { get; set; }
        public virtual User User { get; set; }
        public virtual Invoicemaster Invoicemaster { get; set; }
        public virtual Shift Shift { get; set; }
    }

    public class CashOutMaster
    {
        [Key]
        public int CashOutMasterID { get; set; }
        public string CashOutNum { get; set; }
        public int StoreID { get; set; }
        public int UserID { get; set; }
        public int? ShiftID { get; set; }
        public Boolean IsUploaded { get; set; }
        public DateTime CashOutDate { get; set; }
        public Decimal TotalCashOut{ get; set; }
        public String Approvedby { get; set; }
        public String CashOutType { get; set; }
        public virtual Store Store { get; set; }
        public virtual User User { get; set; }       
        public virtual Shift Shift { get; set; }
    }
    public class SettleMaster
    {
        [Key]
        public int SettleMasterID { get; set; }       
        public int StoreID { get; set; }
        public int UserID { get; set; }
        public int? ShiftID { get; set; }
        public int CustomerID { get; set; }
        public Boolean IsUploaded { get; set; }
        public DateTime SettleDate { get; set; }
        public Decimal TotalRefund { get; set; }

        public virtual Store Store { get; set; }
        public virtual User User { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Shift Shift { get; set; }
    }

    public class CreditMaster
    {
        [Key]
        public int CreditMasterID { get; set; }
        public int CustomerID { get; set; }
        public Decimal? PaymentDue { get; set; }
        public int InvoicemasterID { get; set; }
        public int StoreID { get; set; }
        public int? ShiftID { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Invoicemaster Invoicemaster { get; set; }
        public virtual Store Store { get; set; }
        public virtual Shift Shift { get; set; }
    }



}
