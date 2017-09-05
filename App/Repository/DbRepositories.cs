using App.ApplicationSettingRepository;
using App.Context;
using App.Model;
using App.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Product GetProduct(int Id)
        {

            var q = cntxt.Products.Where(u => u.Id == Id).First();
            return q;

        }


    }

    public class UserRepository
    {
        POSDataContext cntxt = new POSDataContext();

        public User GetUserDetails(int PassID)
        {

            var q = (from usr in cntxt.Users
                     where usr.PassCode == PassID
                     select usr).FirstOrDefault();

            return q;
        }

        public Boolean IsuserValid(int PassID)
        {
            Boolean isvalid = false;
            try
            {
                User usr = GetUserDetails(PassID);


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

               // OdooDetail odoDetails = sysrepo.LoadOdooDetails(Program.LocationID);
                SettingViewModal myset = new SettingViewModal();
                myset.MyOoodoDetasils =sysrepo.LoadOdooDetails(Program.LocationID);
                myset.MyPrinterDetails = sysrepo.LoadtPrinterDetails(Program.LocationID);
                Program.MySettingViewModal = myset;

                Program.KotPrinter = "KOT1";
                Program.Invoiceprinter = "POS1";
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
        public List<Table> GetCustomerListofLocation(int? LocationID = 0)
        {

            var q = cntxt.Tables.Where(u => u.StoreID == LocationID).ToList();

            return q;
        }
        public Customer GetCustomer(int Id)
        {

            var q = cntxt.Customers.Where(u => u.CustomerID == Id).First();
            return q;

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



    public class KotRepository
    {
        POSDataContext cntxt = new POSDataContext();

        public void InsertKOT(KotMaster kotmaster)
        {
            cntxt.KotMasters.Add(kotmaster);
            cntxt.SaveChanges();
        }
    }



    public class InvoiceRepository
    {
        POSDataContext cntxt = new POSDataContext();

        public Invoicemaster InsertInvoiceLocal(Invoicemaster invoicemaster)
        {
        
            cntxt.Invoicemasters.Add(invoicemaster);
            cntxt.SaveChanges();
            invoicemaster.InvoiceNum = "" + invoicemaster.InvoicemasterID;
            cntxt.SaveChanges();
            return invoicemaster;

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

    }


}