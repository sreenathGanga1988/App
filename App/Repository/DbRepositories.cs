﻿using App.ApplicationSettingRepository;
using App.Context;
using App.Model;
using App.ViewModal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace App.Repository
{
    class ProductRepositories
    {
        POSDataContext cntxt = new POSDataContext();
        public List<ProductlistViewModal> GetProductList(int? categoryID = 0)
        {

            if (categoryID != 0)
            {
                var q = (cntxt.Products.Where(u => u.CategoryId == categoryID).
                Select(x => new ProductlistViewModal { ProductID = x.Id, ProductName = x.ProductName, Color = x.Color })).ToList();
                return q;

            }
            else
            {
                var q = (cntxt.Products.
                Select(x => new ProductlistViewModal { ProductID = x.Id, ProductName = x.ProductName, Color = x.Color })).ToList();
                return q;
            }


        }

        public List<ProductlistViewModal> GetMarchingProductlist(int? categoryID = 0)
        {
         

          
                var q = (cntxt.Products.Where(u => u.Id.ToString().Contains(categoryID.ToString())).
                Select(x => new ProductlistViewModal { ProductID = x.Id, ProductName = x.ProductName, Color = x.Color })).ToList();
                return q;

          


        }
        public List<ProductlistViewModal> GetTodaySpecial(int? categoryID = 0)
        {



            var q = (cntxt.Products.Where(u => u.IsTodaySpecial==true).
            Select(x => new ProductlistViewModal { ProductID = x.Id, ProductName = x.ProductName, Color = x.Color })).ToList();
            return q;




        }
        public Product GetProduct(int Id)
        {

            var q = cntxt.Products.Where(u => u.Id == Id).First();
            return q;

        }
        public List<Product> GetProductList()
        {

            var q = cntxt.Products.ToList();
            return q;

        }

        public List<Product> GetProductSearch(String searchtext, int? LocationID = 0)
        {

            var q = cntxt.Products.Where(u => u.Id.ToString().Contains(searchtext) || u.ProductName.Contains(searchtext) || u.Category.CategoryName.Contains(searchtext)).ToList();

            return q;
        }


        public void UpdateTodaySpoecial(int ID ,Boolean status)
        {
            var q = from product in cntxt.Products
                    where product.Id == ID
                    select product;

            foreach (var element in q) {
                element.IsTodaySpecial = status;
            }

            cntxt.SaveChanges();
        }

    }

    public class UserRepository
    {
        POSDataContext cntxt = new POSDataContext();

        public User GetUserDetails(int PassID ,int usserid)
        {

            var q = (from usr in cntxt.Users
                     where usr.PassCode == PassID && usr.UserID==usserid
                     select usr).FirstOrDefault();

            return q;
        }

        public Boolean IsuserValid(int PassID,int userid)
        {
            Boolean isvalid = false;
            try
            {
                User usr = GetUserDetails(PassID, userid);


                if (usr == null)
                {
                    isvalid = false;
                }
                else
                {
                    if (usr.UserID.ToString().Trim() != "")
                    {
                        isvalid = true;
                        
                        SetUserDetails(usr);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                isvalid = false;
            }

            return isvalid;
        }



        public void SetUserDetails(User usr)
        {
            if (usr != null)
            {

                Program.UserID = usr.UserID;
                Program.Username = usr.UserName;
                Program.LocationID = usr.StoreID;
                Program.StoreName = usr.Store.StoreName;
                Program.StoreAddress = usr.Store.StoreAddress;
                SettingRepository sysrepo = new SettingRepository();
                AppuserSettingRepository appuserrepo = new AppuserSettingRepository();
                // OdooDetail odoDetails = sysrepo.LoadOdooDetails(Program.LocationID);
                SettingViewModal myset = new SettingViewModal();
                myset.MyOoodoDetasils =sysrepo.LoadOdooDetails(Program.LocationID);
                myset.MyPrinterDetails = sysrepo.LoadtPrinterDetails(Program.LocationID);
                myset.AppUserSettings = appuserrepo.LoadAppUserSetting(Program.LocationID);
                Program.MySettingViewModal = myset;

              
            }
        }


    }


    public class LocationRepository
    {
        POSDataContext cntxt = new POSDataContext();


        //public Store GetLocationDetails


    }



    public class CustomerRepositiry
    {
        POSDataContext cntxt = new POSDataContext();
        public List<Customer> GetcustomerofLocation(int? LocationID = 0)
        {

            var q = cntxt.Customers.Where(u => u.StoreID == LocationID).ToList();

            return q;
        }
        public Customer GetCustomer(int Id)
        {

            var q = cntxt.Customers.Where(u => u.CustomerID == Id).First();
            return q;

        }
        public String GetCustomer(String CustomerName)
        {

            var q = cntxt.Customers.Where(u => u.CustomerName == CustomerName).Select(u=>u.CustomerName).First();
            return q.ToString().Trim();

        }
        public int GetOrginalCategoryID(int odooCategoryID)
        {
            int categoryid = 0;

            var q = cntxt.Categorys.Where(u => u.OdooCategoryId == odooCategoryID).Select(u => u.Id).FirstOrDefault();

            categoryid = int.Parse(q.ToString());
            return categoryid;
        }

        public List<Customer> GetcustomerofLocationSearch(String searchtext, int? LocationID = 0)
        {

            var q = cntxt.Customers.Where(u => u.StoreID == LocationID && (u.PhoneNumber.Contains(searchtext)||u.CustomerName.Contains(searchtext)) ).ToList();

            return q;
        }


        public void AddCustomer(Customer customer)
        {

            cntxt.Customers.Add(customer);
            cntxt.SaveChanges();
        }
        public void UpdateCustomer(Customer customer)
        {

            cntxt.Entry(customer).State = EntityState.Modified;
            cntxt.SaveChanges();
        }

    }

    public class CategoryRepository
    {
        POSDataContext cntxt = new POSDataContext();
        public List<Category> GetCategoryList(int? LocationID = 0)
        {

            var q = cntxt.Categorys.ToList();

            return q;
        }


        public void Addcategory(Category ctgry) {

            cntxt.Categorys.Add(ctgry);
            cntxt.SaveChanges();
        }

        public void UpdateCategory(Category ctgry)
        {

            cntxt.Entry(ctgry).State = EntityState.Modified;
            cntxt.SaveChanges();
        }
        public int GetOrginalCategoryID(int odooCategoryID)
        {
            int categoryid = 0;

            var q = cntxt.Categorys.Where(u => u.OdooCategoryId == odooCategoryID).Select(u => u.Id).FirstOrDefault();

            categoryid = int.Parse(q.ToString());
            return categoryid;
        }

    }

    public class TableRepository
    {
        POSDataContext cntxt = new POSDataContext();
        public List<Table> GetTableList(int? LocationID = 0)
        {

            var q = cntxt.Tables.Where(u => u.StoreID == LocationID).ToList();

            return q;
        }

    }

   


    public class BuzzerRepository
    {
        POSDataContext cntxt = new POSDataContext();
        public List<Buzzer> GetBuzzerList(int? LocationID = 0)
        {

            var q = cntxt.Buzzers.Where(u => u.StoreID == LocationID).ToList();

            return q;
        }
        public Boolean IsBuzzerAlloted(int  buzzerid,int storeid)
        {
            Boolean issucess = false;
            var q = (from ododet in cntxt.Buzzers
                    where ododet.StoreID == storeid && ododet.BuzzerID== buzzerid
                    select ododet).ToList();
            foreach (var element in q)
            {
                issucess = element.IsLocked;

            }

          
        

            return issucess;
        }



        public Boolean MarkBuzzerLockedorUnlocked(int buzzerid, int storeid, Boolean status)
        {
            Boolean issucess = false;
            var q = from ododet in cntxt.Buzzers
                    where ododet.StoreID == storeid && ododet.BuzzerID == buzzerid
                    select ododet;
            foreach (var element in q)
            {
                element.IsLocked = status;

            }

            cntxt.SaveChanges();
            issucess = true;

            return issucess;
        }





    }
    public class PaymentModeRepository
    {
        POSDataContext cntxt = new POSDataContext();
        public List<PaymentModeMaster> GetPaymnetModeList(int? LocationID = 0)
        {

            //var q = cntxt.PaymentModeMasters.Where(u => u.StoreID == LocationID).ToList();
            var q = cntxt.PaymentModeMasters.ToList();

            return q;
        }
        public Boolean IsBuzzerAlloted(int buzzerid, int storeid)
        {
            Boolean issucess = false;
            var q = (from ododet in cntxt.Buzzers
                     where ododet.StoreID == storeid && ododet.BuzzerID == buzzerid
                     select ododet).ToList();
            foreach (var element in q)
            {
                issucess = element.IsLocked;

            }




            return issucess;
        }



        public Boolean MarkBuzzerLockedorUnlocked(int buzzerid, int storeid, Boolean status)
        {
            Boolean issucess = false;
            var q = from ododet in cntxt.Buzzers
                    where ododet.StoreID == storeid && ododet.BuzzerID == buzzerid
                    select ododet;
            foreach (var element in q)
            {
                element.IsLocked = status;

            }

            cntxt.SaveChanges();
            issucess = true;

            return issucess;
        }





    }

    public class KotRepository
    {
        POSDataContext cntxt = new POSDataContext();

        public KotMaster InsertKOT(KotMaster kotmaster)
        {
            cntxt.KotMasters.Add(kotmaster);
            cntxt.SaveChanges();
            kotmaster.KotNum = Program.MySettingViewModal.AppUserSettings.InvoicePrefix + kotmaster.KotMasterID;
            cntxt.SaveChanges();
            return kotmaster;
        }


        public List <KotMaster> GetKotPending(int storeid)
        {
            var q = (cntxt.KotMasters.Where(u => u.StoreID == storeid)).ToList();

            return q;
        }

        public KotMaster GetKOT(int kotmasterId)
        {


            var q = cntxt.KotMasters.Where(u => u.KotMasterID == kotmasterId).FirstOrDefault();

            return q;
        }
    }



    public class InvoiceRepository
    {
        POSDataContext cntxt = new POSDataContext();




        public Invoicemaster UpdateInvoicemaster(Invoicemaster invoicemaster)
        {


            
           

            var q = from invmstr in cntxt.Invoicemasters
                    where invmstr.InvoicemasterID == invoicemaster.InvoicemasterID
                    select invmstr;


            foreach(var element in q)
            {
                element.StoreID = invoicemaster.StoreID;
                element.UserID = invoicemaster.UserID;
                element.InvoiceDate = invoicemaster.InvoiceDate;
                element.CustomerID = invoicemaster.CustomerID;
                element.TableID = invoicemaster.TableID;
                element.TotalPaid = invoicemaster.TotalPaid;
                element.TotalBill = invoicemaster.TotalBill;
                element.StoreName = invoicemaster.StoreName;
                element.StoreAddress = invoicemaster.StoreAddress;
                element.Cashier = invoicemaster.Cashier;
                element.CustomerName = invoicemaster.CustomerName;
                element.IsUploaded = invoicemaster.IsUploaded;
                element.IstableBill = invoicemaster.IstableBill;
                invoicemaster.InvoiceNum = element.InvoiceNum;
            }



            foreach (InvoiceDetail invdet  in invoicemaster.InvoiceDetails )
            {

                if (!cntxt.InvoiceDetails.Any(f => f.InvoicemasterID == invdet.InvoicemasterID && f.ProductId == invdet.ProductId ))
                {
                    InvoiceDetail invoicedetail = new InvoiceDetail();
                    invoicedetail.ProductId = invdet.ProductId;
                    invoicedetail.ProductName = invdet.ProductName;

                    invoicedetail.IsDeleted = invdet.IsDeleted;
                    invoicedetail.UnitPrice = invdet.UnitPrice;
                    invoicedetail.Qty = invdet.Qty;
                    invoicedetail.DiscountPerUOM = invdet.DiscountPerUOM;
                    invoicedetail.Total = invdet.Total;
                    invoicedetail.IsUploaded = invdet.IsUploaded;
                    invoicedetail.PreviousQty = invdet.PreviousQty;
                    invoicedetail.AdjustedQty = invdet.AdjustedQty;
                    invoicedetail.InvoicemasterID = invdet.InvoicemasterID;

                    cntxt.InvoiceDetails.Add(invoicedetail);
                }
                else
                {
                    var q1 = from ivoidedetail in cntxt.InvoiceDetails
                            where ivoidedetail.InvoicemasterID == invdet.InvoicemasterID && ivoidedetail.ProductId == invdet.ProductId
                            select ivoidedetail;
                    foreach (var element in q1)
                    {
                        element.PreviousQty = element.Qty;

                        element.ProductId = invdet.ProductId;
                        element.ProductName = invdet.ProductName;

                        element.IsDeleted = invdet.IsDeleted;
                        element.UnitPrice = invdet.UnitPrice;
                        element.Qty = invdet.Qty;
                        element.DiscountPerUOM = invdet.DiscountPerUOM;
                        element.Total = invdet.Total;
                        element.IsUploaded = invdet.IsUploaded;

                      
                        element.AdjustedQty = invdet.Qty - element.PreviousQty;
                   

                    }

                }




           










                cntxt.SaveChanges();


            }




            var alreadyenteredinvoicelist = from ivoidedetail in cntxt.InvoiceDetails
                                            where ivoidedetail.InvoicemasterID == invoicemaster.InvoicemasterID
                                            select ivoidedetail;



            foreach(var element in alreadyenteredinvoicelist)
            {


                if (!invoicemaster.InvoiceDetails.Any(f => f.ProductId ==element.ProductId))
                {

                    element.IsDeleted = true;
                    element.PreviousQty = element.Qty;
                    element.Qty = 0;
                    element.AdjustedQty = element.AdjustedQty = element.Qty - element.PreviousQty;
                }

             }



            cntxt.SaveChanges();

            return invoicemaster;


        }


        public Invoicemaster InsertInvoiceLocal(Invoicemaster invoicemaster)
        {
            if(invoicemaster.InvoicemasterID!=0)
            { 
         
                return UpdateInvoicemaster(invoicemaster);

            }
            else
            {
                cntxt.Invoicemasters.Add(invoicemaster);
                cntxt.SaveChanges();
                invoicemaster.InvoiceNum = Program.MySettingViewModal.AppUserSettings.InvoicePrefix + invoicemaster.InvoicemasterID;
                cntxt.SaveChanges();
                return invoicemaster;
            }
           

        }
        public List <InvoiceviewModal> GetInvoicePending(int storeid)
        {
            var q = (from invoicemstr in cntxt.Invoicemasters
                    where invoicemstr.IsUploaded == false && invoicemstr.StoreID==storeid
                     select new InvoiceviewModal { InvoicemasterID= invoicemstr.InvoicemasterID, InvoiceDate= invoicemstr.InvoiceDate,InvoiceNum= invoicemstr.InvoiceNum, TableName= invoicemstr.Table.TableName, StoreName= invoicemstr.Store.StoreName,  CustomerName=invoicemstr.Customer.CustomerName,TotalBill= invoicemstr.TotalBill, TotalPaid=invoicemstr.TotalPaid }).ToList();
            //foreach (var element in q)
            //{

            //    var total = (cntxt.InvoiceDetails.Where(u => u.InvoicemasterID == element.InvoicemasterID).Sum(u => u.Total));

            //    element.TotalBill=cntxt.
            //}

            return q;
        }


        public Invoicemaster GetInvoice(int invoicemasterid)
        {


            var q = cntxt.Invoicemasters.Where(u => u.InvoicemasterID == invoicemasterid).FirstOrDefault();

            return q;
        }

        public List<Invoicemaster> GetInvoiPendingtoBill(int storeid)
        {
            var q = (cntxt.Invoicemasters.Where(u => u.StoreID == storeid && u.IstableBill == true || u.IsKOT == true)).ToList();

            return q;
        }
    }


    public class RefundRepository
    {
        POSDataContext cntxt = new POSDataContext();

        public RefundMaster InsertRefund(RefundMaster refundmaster)
        {

            cntxt.RefundMasters.Add(refundmaster);
            cntxt.SaveChanges();
         
            return refundmaster;

        }
    }

}
namespace App.ApplicationSettingRepository
{

    public class SettingRepository
    {
        POSDataContext cntxt = new POSDataContext();
        public void UpdateOdooReopository(OdooDetail odetails)
        {
            if (MarkOdoddetailsObsolute(odetails))
            {
                cntxt.OdooDetails.Add(odetails);
                cntxt.SaveChanges();
            }

        }


        public Boolean MarkOdoddetailsObsolute(OdooDetail odetails)
        {
            Boolean issucess = false;
            var q = from ododet in cntxt.OdooDetails
                    where ododet.StoreID == odetails.StoreID
                    select ododet;
            foreach (var element in q)
            {
                element.IsActive = false;

            }

            cntxt.SaveChanges();
            issucess = true;

            return issucess;
        }

        public void UpdatePrinterReopository(PrinterDetail printerDetail)
        {
            if (MarkPrinterDetailsObsolute(printerDetail))
            {
                cntxt.PrinterDetails.Add(printerDetail);
                cntxt.SaveChanges();
            }

        }

        public Boolean MarkPrinterDetailsObsolute(PrinterDetail printerDetail)
        {
            Boolean issucess = false;
            var q = from printdet in cntxt.PrinterDetails
                    where printdet.StoreID == printerDetail.StoreID
                    select printdet;
            foreach (var element in q)
            {
                element.IsActive = false;

            }

            cntxt.SaveChanges();
            issucess = true;

            return issucess;
        }




        public void UpdateUsersettingReopository(AppUserSetting appusersetting)
        {
            if (MarkUserSettingDetailsObsolute(appusersetting))
            {
                cntxt.AppUserSettings.Add(appusersetting);
                cntxt.SaveChanges();
            }

        }

        public Boolean MarkUserSettingDetailsObsolute(AppUserSetting printerDetail)
        {
            Boolean issucess = false;
            var q = from ppusersetting in cntxt.AppUserSettings
                    where ppusersetting.StoreID == printerDetail.StoreID
                    select ppusersetting;
            foreach (var element in q)
            {
                element.IsActive = false;

            }

            cntxt.SaveChanges();
            issucess = true;

            return issucess;
        }






        public OdooDetail LoadOdooDetails(int storeid)
        {
            var q = cntxt.OdooDetails.Where(u => u.StoreID == storeid&& u.IsActive==true).FirstOrDefault();
            return q;
        }

        public PrinterDetail LoadtPrinterDetails(int storeid)
        {
            var q = cntxt.PrinterDetails.Where(u => u.StoreID == storeid && u.IsActive == true).FirstOrDefault();
            return q;
        }



    }


    public class PrinterRepository
    {
        POSDataContext cntxt = new POSDataContext();
        public List<Printer> GetPrinterList(int? LocationID = 0)
        {

            var q = cntxt.Printers.Where (u=>u.StoreID== LocationID).ToList();

            return q;
        }


        public void Addcategory(Printer ctgry)
        {

            cntxt.Printers.Add(ctgry);
            cntxt.SaveChanges();
        }

        public void UpdateCategory(Printer ctgry)
        {

            cntxt.Entry(ctgry).State = EntityState.Modified;
            cntxt.SaveChanges();
        }

    }

    public class AppuserSettingRepository
    {
        POSDataContext cntxt = new POSDataContext();

        public void UpdateAppusersettingReopository(AppUserSetting appusersetting)
        {
            if (cntxt.AppUserSettings.Any(o => o.StoreID == appusersetting.StoreID))
            {
                cntxt.AppUserSettings.Add(appusersetting);
                cntxt.SaveChanges();
            }
            else
            {
                var q = from app in cntxt.AppUserSettings
                        where app.StoreID == appusersetting.StoreID
                        select app;

                foreach(var element in q)
                {

                    element.ProductperRow = appusersetting.ProductperRow;
                    element.InvoicePrefix = appusersetting.InvoicePrefix;
                    element.PaddingNumber = appusersetting.PaddingNumber;
                    element.ProductButtonWidth = appusersetting.ProductButtonWidth;
                    element.ProductButtonHeigth = appusersetting.ProductButtonHeigth;

                    element.RealtimeInvoiceUpdate = appusersetting.RealtimeInvoiceUpdate;
                    element.FastLoading = appusersetting.FastLoading;
                    element.AutoSizebutton = appusersetting.AutoSizebutton;
                    cntxt.SaveChanges();
                }
            }

        }

        public AppUserSetting LoadAppUserSetting(int storeid)
        {
            var q = cntxt.AppUserSettings.Where(u => u.StoreID == storeid && u.IsActive == true).FirstOrDefault();
            return q;
        }

    }


}

