using App.Context;
using App.Extensions;
using App.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Extensions;
namespace App.Repository
{
    public  class OdooUpdator
    {

        POSDataContext cntxt = new POSDataContext();

      

        public void Updatemaster()
        {
            try
            {
                GetStorefromODOO();
                MessageBox.Show("GetStorefromODOO Completed");
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog("At GetStorefromODOO", ex.StackTrace, ex.Message);
                MessageBox.Show("ErrorAt" + Environment.NewLine + "GetStorefromODOO " + ex.ToString());
            }
            try
            {
                GetTablefromODOO();
                MessageBox.Show("GetTablefromODOO Completed");
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog("At GetTablefromODOO", ex.StackTrace, ex.Message);
                MessageBox.Show("ErrorAt" + Environment.NewLine + "GetTablefromODOO " + ex.ToString());
            }
            try
            {
                GetUserfromODOO();
              
                MessageBox.Show("GetUserfromODOO Completed");
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog("At GetUserfromODOO", ex.StackTrace, ex.Message);
                MessageBox.Show("ErrorAt" + Environment.NewLine + "GetUserfromODOO " + ex.ToString());
            }
            try
            {
                GetBuzzerfromODOO();
                MessageBox.Show("GetBuzzerfromODOO Completed");
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog("At GetBuzzerfromODOO", ex.StackTrace, ex.Message);
                MessageBox.Show("ErrorAt" + Environment.NewLine + "GetBuzzerfromODOO " + ex.ToString());
            }
            try
            {
                GetCategoryfromODOO();
                MessageBox.Show("GetCategoryfromODOO Completed");
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog("At GetCategoryfromODOO", ex.StackTrace, ex.Message);
                MessageBox.Show("ErrorAt" + Environment.NewLine + "GetCategoryfromODOO " + ex.ToString());
            }
            try
            {
                GetProductfromODOO();
                MessageBox.Show("GetProductfromODOO Completed");
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog("At GetProductfromODOO", ex.StackTrace, ex.Message);
                MessageBox.Show("ErrorAt" + Environment.NewLine + "GetProductfromODOO " + ex.ToString());
            }
           try {
                InsertCustomertoOdoofromlocal();
                MessageBox.Show("InsertCustomertoOdoofromlocal Completed");
            }
            catch (Exception ex)
            {
                
                    ErrorLogger.WriteToErrorLog("At InsertCustomertoOdoofromlocal", ex.StackTrace, ex.Message);
                MessageBox.Show("ErrorAt"+Environment.NewLine+ "InsertCustomertoOdoofromlocal " + ex.ToString());
            }
            

        }



        public void uploadInvoiceMaster()
        {

            int uloaded = 0;

            int Shiftid = Program.ShiftId;

            //  InsertShiftOdoofromlocal();
            InsertShiftOdoofromlocal(Program.ShiftId);

            try
            {
                var q = from invoiceMaster in cntxt.Invoicemasters
                        where invoiceMaster.IsUploaded == false
                        select invoiceMaster;

                List<Invoicemaster> invoicemasters = cntxt.Invoicemasters.Where(U => U.IsUploaded == false && U.ShiftID==Shiftid && U.IsDeleted==false).ToList();

                var Shifids = invoicemasters.Select(u => u.ShiftID).Distinct();

               
                foreach (Invoicemaster element in invoicemasters)
                {

                    if (InsertInvoicemaster(element))
                    {


                        element.IsUploaded = true;
                        uloaded++;
                    };
                    cntxt.SaveChanges();


                }




                List<SettleMaster> settlementlist = cntxt.SettleMasters.Where(U => U.IsUploaded == false && U.ShiftID == Shiftid).ToList();

                foreach (SettleMaster element in settlementlist)
                {
                    try
                    {
                        insertSettlement(element);
                        element.IsUploaded = true;
                    }
                    catch (Exception exp)
                    {
                        ErrorLogger.WriteToErrorLog("At Login insertSettlement", exp.StackTrace, exp.Message);
                        
                    }
                }

                    List<RefundMaster> refundlist = cntxt.RefundMasters.Where(U => U.IsUploaded == false && U.ShiftID == Shiftid).ToList();
                foreach (RefundMaster element in refundlist)
                {
                    try
                    {
                        insertRefund(element);
                        element.IsUploaded = true;
                    }
                    catch (Exception exp)
                    {
                        ErrorLogger.WriteToErrorLog("At Login insertRefund", exp.StackTrace, exp.Message);

                    }
                }

                List<CashOutMaster> cashouitlist = cntxt.CashOutMasters.Where(U => U.IsUploaded == false && U.ShiftID == Shiftid).ToList();
                foreach (CashOutMaster element in cashouitlist)
                {
                    try
                    {
                        InsertCashOut(element);
                        element.IsUploaded = true;
                    }
                    catch (Exception exp)
                    {
                        ErrorLogger.WriteToErrorLog("At Login InsertCashOut", exp.StackTrace, exp.Message);

                    }
                }

                cntxt.SaveChanges();
                MessageBox.Show(uloaded + "Out Of " + invoicemasters.Count + "Uploaded");
                foreach (int shifid in Shifids)
                {
                    LoadClosereport(shifid);
                }


            }
            catch (Exception)
            {
                System.Windows.Forms.Application.Exit();

            }
        }



        public void LoadClosereport( int shiftid)
        {
            ShiftViewModel shiftViewModel = new ShiftViewModel();
            Shift shift= cntxt.Shifts.Where(U => U.ShiftID == shiftid).First();
            List<Invoicemaster> invoicemasters = cntxt.Invoicemasters.Where(U => U.ShiftID == shiftid && U.IsDeleted == false).ToList();
            shiftViewModel.invoicemstrlist = invoicemasters;
            shiftViewModel. StoreName = shift.Store.StoreName;
            shiftViewModel. ShiftName =shift.ShiftName;
            shiftViewModel. User =shift.CloseUserName;
            shiftViewModel. Shiftfrom =shift.StartTime.ToString();
            shiftViewModel. ShiftTo = shift.EndTime.ToString();

            shiftViewModel. TotalSales =0;
         shiftViewModel. TotalCharges =0;
         shiftViewModel. TotalDiscount =0;
         shiftViewModel. Netsales =0;
         shiftViewModel. TotalCC =0;
         shiftViewModel. TotalByCash =0;
         shiftViewModel. TotalByCurrency =0;
         shiftViewModel. TottalByCC =0;
         shiftViewModel. TotalByCheque =0;
         shiftViewModel. TotalByGift =0;
         shiftViewModel. TotalByCredit =0;
         shiftViewModel. TotalTax =0;
         shiftViewModel. NetAmount =0;
            shiftViewModel.TotalCashout = 0;
            shiftViewModel.TotalCredit = 0;
            shiftViewModel.TotalRefund = 0;
            shiftViewModel.TotalSetllement = 0;
            shiftViewModel.TableBill = 0;
            shiftViewModel.Deletedvalue = 0;
            shiftViewModel.SettlementAmount = 0;
            


            try
            {
                shiftViewModel.TableBill = invoicemasters.Where(u=>u.IstableBill==true || u.IsKOT == true).Sum(u => u.TotalBill);

               
            }
            catch (Exception)
            {


            }
            try
            {
                shiftViewModel.TotalSales = invoicemasters.Sum(u => u.TotalBill);

                shiftViewModel.Netsales = invoicemasters.Sum(u => u.TotalBill);
            }
            catch (Exception)
            {

               
            }
            try
            {
                shiftViewModel.TotalDiscount = invoicemasters.Sum(u => u.TotalDiscount);
              
            }
            catch (Exception)
            {


            }

            try
            {
                shiftViewModel.TotalTax = Decimal.Parse( invoicemasters.Sum(u => u.Taxamount).ToString());

            }
            catch (Exception)
            {


            }
            try
            {
                shiftViewModel.TotalByCash = invoicemasters.Where(u=>u.PaymentMode== "CASH").Sum(u => u.TotalBill);
            }
            catch (Exception)
            {


            }
            try
            {
                shiftViewModel.TotalByCredit = invoicemasters.Where(u => u.PaymentMode == "CREDIT").Sum(u => u.TotalBill);
            }
            catch (Exception)
            {


            }
            try
            {
                shiftViewModel.TotalCC = invoicemasters.Where(u => u.PaymentMode == "CARD").Sum(u => u.TotalBill);
            }
            catch (Exception)
            {


            }
            try
            {
                shiftViewModel.TotalCC = invoicemasters.Where(u => u.PaymentMode == "ZOMATO").Sum(u => u.TotalBill);
            }
            catch (Exception)
            {


            }

           
            try
            {
                Decimal totalcashout = Decimal.Parse(cntxt.CashOutMasters.Where(u=>u.ShiftID==Program.ShiftId).Sum(u=>u.TotalCashOut).ToString());
                shiftViewModel.TotalCashout = totalcashout;
            }
            catch (Exception)
            {


            }
            try
            {
                Decimal refundmstr = Decimal.Parse(cntxt.RefundMasters.Where(u => u.ShiftID == Program.ShiftId).Sum(u => u.TotalRefund).ToString());
                shiftViewModel.TotalRefund = refundmstr;
            }
            catch (Exception)
            {


            }
            try
            {
                Decimal crdmstr = Decimal.Parse(cntxt.CreditMasters.Where(u => u.ShiftID == Program.ShiftId).Sum(u => u.PaymentDue).ToString());
                shiftViewModel.TotalCredit = crdmstr;
            }
            catch (Exception)
            {


            }
            try
            {
                Decimal totalcashout = Decimal.Parse(cntxt.SettleMasters.Where(u => u.ShiftID == Program.ShiftId).Sum(u => u.TotalRefund).ToString());
                shiftViewModel.SettlementAmount = totalcashout;
            }
            catch (Exception)
            {


            }
            try
            {
                Decimal NETAMOUNT = (shiftViewModel.Netsales - shiftViewModel.TotalCashout - shiftViewModel.TotalRefund - shiftViewModel.TotalCredit) + shiftViewModel.SettlementAmount;
                shiftViewModel.NetAmount = NETAMOUNT;
            }
            catch (Exception)
            {

            }
            try
            {
                PrintReceipt prnt = new PrintReceipt();
                prnt.printClosingreport(shiftViewModel);

               
            }
            catch (Exception ex)
            {

                MessageBox.Show("Printer Malfunction.But Invoice Done");
            }

        }

        public Boolean InsertInvoicemaster(Invoicemaster invmstr)
        {
            Boolean isok = false;

            try
            {
                //string connstring = String.Format("Server=192.168.1.73;Port=5432;User Id=odoo;Password=at123;Database=ken-aug20;");
                string connstring = String.Format("Server={0};Port={1};" +
                        "User Id={2};Password={3};Database={4};",
                        Program.MySettingViewModal.MyOoodoDetasils.Server.Trim(), Program.MySettingViewModal.MyOoodoDetasils.PortNum.ToString().Trim(), Program.MySettingViewModal.MyOoodoDetasils.UserId.ToString().Trim(),
                       Program.MySettingViewModal.MyOoodoDetasils.Password.ToString().Trim(), Program.MySettingViewModal.MyOoodoDetasils.DataBasename.ToString().Trim());
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                conn.Open();


               

                    NpgsqlCommand cmd = new NpgsqlCommand(@"insert into pos_order_master
( 
create_uid, 
write_date, 
user_id, 
write_uid,  
create_date,  
store_id , 
name ,  
order_date,  
date ,  
partner_id , 
table_id, 

payment_method,  
pos_invoice_id, 
state,total_paid,total_discount,total_bill,total_tax
)
values(
:create_uid,  
:write_date,  
:user_id, 
:write_uid, 
:create_date, 
:store_id, 
:name,  
:order_date, 
:date,  
:partner_id, 
:table_id,  

:payment_method, 
:pos_invoice_id, 
:state,:total_paid,:total_discount,:total_bill,:total_tax) RETURNING id;", conn);





                    cmd.Parameters.Add(new NpgsqlParameter("create_uid", invmstr.User.OdooUserID));
                    cmd.Parameters.Add(new NpgsqlParameter("write_date", DateTime.Now));
                    cmd.Parameters.Add(new NpgsqlParameter("user_id", invmstr.User.OdooUserID));
                    cmd.Parameters.Add(new NpgsqlParameter("write_uid", invmstr.User.OdooUserID));
                    cmd.Parameters.Add(new NpgsqlParameter("create_date", DateTime.Now));
                    cmd.Parameters.Add(new NpgsqlParameter("store_id", Program.LocationID));
                    cmd.Parameters.Add(new NpgsqlParameter("name", invmstr.InvoiceNum));
                    cmd.Parameters.Add(new NpgsqlParameter("order_date", invmstr.InvoiceDate));
                    cmd.Parameters.Add(new NpgsqlParameter("date", invmstr.InvoiceDate.Date));
                    cmd.Parameters.Add(new NpgsqlParameter("partner_id", invmstr.CustomerID));
                    cmd.Parameters.Add(new NpgsqlParameter("session_id", invmstr.ShiftID));
                    cmd.Parameters.Add(new NpgsqlParameter("table_id", invmstr.TableID));
                    cmd.Parameters.Add(new NpgsqlParameter("payment_method", invmstr.PaymentMode));
                    cmd.Parameters.Add(new NpgsqlParameter("state", "draft"));
                    cmd.Parameters.Add(new NpgsqlParameter("pos_invoice_id", invmstr.InvoicemasterID));
                    cmd.Parameters.Add(new NpgsqlParameter("total_discount", invmstr.TotalDiscount));
                    cmd.Parameters.Add(new NpgsqlParameter("total_paid", invmstr.TotalPaid));
                    cmd.Parameters.Add(new NpgsqlParameter("total_bill", invmstr.TotalBill));
                    cmd.Parameters.Add(new NpgsqlParameter("total_tax", invmstr.Taxamount));



                    //cmd.Parameters.Add(new NpgsqlParameter("round_off", invmstr.RoundOffAmount));

                    var id = cmd.ExecuteScalar();
              

                foreach (InvoiceDetail invdet in invmstr.InvoiceDetails)
                {


                   


                        NpgsqlCommand cmd1 = new NpgsqlCommand(@"insert into pos_order_master_line
(
create_uid ,
write_date ,
user_id ,
write_uid ,
create_date ,
name,
line_id ,
product_id ,
order_date ,
date ,
category_id ,
quantity ,
unit_price ,
discount ,
tax_amount ,
total_paid ,
pos_invoice_line_id)

values(

:create_uid ,
:write_date ,
:user_id ,
:write_uid ,
:create_date ,
:name , 
:line_id , 
:product_id ,
:order_date ,
:date , 
:category_id , 
:quantity , 
:unit_price , 
:discount , 
:tax_amount , 
:total_paid ,
:pos_invoice_line_id) RETURNING id;", conn);
                        cmd1.Parameters.Add(new NpgsqlParameter("create_uid", invmstr.User.OdooUserID));
                        cmd1.Parameters.Add(new NpgsqlParameter("write_date", DateTime.Now));
                        cmd1.Parameters.Add(new NpgsqlParameter("user_id", invmstr.User.OdooUserID));
                        cmd1.Parameters.Add(new NpgsqlParameter("write_uid", invmstr.User.OdooUserID));
                        cmd1.Parameters.Add(new NpgsqlParameter("create_date", DateTime.Now));
                        cmd1.Parameters.Add(new NpgsqlParameter("name", invdet.Product.ProductName));
                        cmd1.Parameters.Add(new NpgsqlParameter("line_id", int.Parse(id.ToString())));
                        cmd1.Parameters.Add(new NpgsqlParameter("product_id", invdet.Product.OdooProductId));
                        cmd1.Parameters.Add(new NpgsqlParameter("order_date", invmstr.InvoiceDate));
                        cmd1.Parameters.Add(new NpgsqlParameter("date", invmstr.InvoiceDate.Date));
                        cmd1.Parameters.Add(new NpgsqlParameter("category_id", invdet.Product.OdooCategoryId));
                        cmd1.Parameters.Add(new NpgsqlParameter("quantity", invdet.Qty));
                        cmd1.Parameters.Add(new NpgsqlParameter("unit_price", invdet.UnitPrice));
                        cmd1.Parameters.Add(new NpgsqlParameter("discount", invdet.DiscountPerUOM));
                        cmd1.Parameters.Add(new NpgsqlParameter("tax_amount", invdet.Taxamount));
                        cmd1.Parameters.Add(new NpgsqlParameter("total_paid", invdet.Total));
                        cmd1.Parameters.Add(new NpgsqlParameter("pos_invoice_line_id", invdet.InvoiceDetailID));
                        var newid = cmd1.ExecuteScalar();
                    
                     
                       
                    
                }














                // since we only showing the result we don't need connection anymore
                conn.Close();

                

                isok = true;
            }
            catch (Exception Ex)
            {
                ErrorLogger.WriteToErrorLog("At Up At"+ invmstr.InvoiceNum  , Ex.StackTrace, "InsertInvoicemaster ");

                isok = false;
              
            }

            return isok;
        }



        public void GetProductfromODOO()
        {

            CategoryRepository repo = new CategoryRepository();
         
            NpgsqlCommand cmd = new NpgsqlCommand(@"select a.id,b.name,b.pos_categ_id,b.list_price,sum(d.amount) as tax_amount,b.default_code from product_product a, product_template b,product_taxes_rel c,account_tax d
where a.product_tmpl_id=b.id and c.prod_id=b.id and d.id=c.tax_id group by a.id,b.name,b.pos_categ_id,b.list_price ,b.default_code order by b.name");
            DataTable dt = GetDataTable(cmd);
            List<Product> Products = new List<Product>();
            foreach (DataRow row in dt.Rows)
            {
                int odooProductID = int.Parse(row["id"].ToString());
                if (!cntxt.Products.Any(f => f.OdooProductId == odooProductID))
                {
                    Product product = new Product();
                    product.ProductName = row["name"].ToString();
                    product.OdooCategoryId = int.Parse(row["pos_categ_id"].ToString());
                    product.CategoryId = repo.GetOrginalCategoryID(int.Parse(row["pos_categ_id"].ToString()));
                    product.UnitPrice = decimal.Parse(row["list_price"].ToString());
                    product.OdooProductId = int.Parse(row["id"].ToString());
                    product.Taxamount = Decimal.Parse(row["tax_amount"].ToString())/100;
                    product.DiscountForLocation = 0;
                    product.MinimumSPForLocation = product.UnitPrice;
                    product.Color = row["default_code"].ToString().Trim(); 
                    product.Image = "";

                    product.IsAvailable = true;
                    product.IsRateChangable = true;
                    product.IsTodaySpecial = true;
                    cntxt.Products.Add(product);
                }
                else
                {
                    var q = from product in cntxt.Products
                            where product.OdooProductId == odooProductID
                            select product;
                    foreach(var element in q)
                    {

                        element.ProductName = row["name"].ToString();
                        element.OdooCategoryId = int.Parse(row["pos_categ_id"].ToString());
                        element.CategoryId = repo.GetOrginalCategoryID(int.Parse(row["pos_categ_id"].ToString()));
                        element.UnitPrice = decimal.Parse(row["list_price"].ToString());
                        element.OdooProductId = int.Parse(row["id"].ToString());
                        element.Taxamount = Decimal.Parse(row["tax_amount"].ToString()) / 100;
                        element.DiscountForLocation = 0;
                        element.MinimumSPForLocation = element.UnitPrice;
                        element.Color = row["default_code"].ToString().Trim();
                        element.Image = "";

                        element.IsAvailable = true;
                        element.IsRateChangable = true;
                        element.IsTodaySpecial = true;


                    }
                }
                



            }

            cntxt.SaveChanges();

        }



          public void GetCategoryfromODOO()
        {

           
            NpgsqlCommand cmd = new NpgsqlCommand(@"select id , name from pos_category");

            DataTable dt = GetDataTable(cmd);
            List<Product> Products = new List<Product>();
            foreach (DataRow row in dt.Rows)
            {
                int OdooCategoryId = int.Parse(row["id"].ToString());
                if (!cntxt.Categorys.Any(f => f.OdooCategoryId == OdooCategoryId ))
                {
                    Category category = new Category();
                    category.CategoryName = row["name"].ToString();
                    category.OdooCategoryId = OdooCategoryId;
                    category.Color = "";
                    cntxt.Categorys.Add(category);
                }


            }

            cntxt.SaveChanges();

        }
        public void GetStorefromODOO()
        {

           
            NpgsqlCommand cmd = new NpgsqlCommand(@"select a.id,a.name,a.phone,b.vat,b.street from res_company a, res_partner b where a.partner_id = b.id");

            DataTable dt = GetDataTable(cmd);

            foreach (DataRow row in dt.Rows)
            {
                int OdooStoreId = int.Parse(row["id"].ToString());
                if (!cntxt.Stores.Any(f => f.OdooStoreId == OdooStoreId))
                {
                    Store store = new Store();
                    store.StoreName = row["name"].ToString();
                    store.Street= row["street"].ToString();
                    store.Phone= row["phone"].ToString();
                    store.OdooStoreId = OdooStoreId;

                    cntxt.Stores.Add(store);
                }
                else
                {
                    var q = from store in cntxt.Stores
                            where store.OdooStoreId == OdooStoreId
                            select store;
                    foreach(var element in q)
                    {
                        element.StoreName = row["name"].ToString();
                        element.Street = row["street"].ToString();
                        element.Phone = row["phone"].ToString();
                    }

                }


            }

            cntxt.SaveChanges();

        }

        public void GetTablefromODOO()
        {

            
            NpgsqlCommand cmd = new NpgsqlCommand(@"select id , name from restaurant_table");

            DataTable dt = GetDataTable(cmd);


            var storeid = cntxt.Stores.Where(u => u.OdooStoreId == 1).Select(u => u.StoreID).FirstOrDefault();
            foreach (DataRow row in dt.Rows)
            {
                int OdooTableId = int.Parse(row["id"].ToString());
                if (!cntxt.Tables.Any(f => f.OdooTableID == OdooTableId))
                {
                    Table table = new Table();
                    table.TableName = row["name"].ToString();
                    table.OdooTableID = OdooTableId;
                    table.StoreID= int.Parse(storeid.ToString());
                    table.Color = "";
                    cntxt.Tables.Add(table);
                }


            }

            cntxt.SaveChanges();

        }

       

        public void GetUserfromODOO()
        {

            NpgsqlCommand cmd = new NpgsqlCommand(@"select id,login,company_id,pos_security_pin from res_users");

            DataTable dt = GetDataTable(cmd);
           
            var storeid = cntxt.Stores.Where(u => u.OdooStoreId == 1).Select(u => u.StoreID).FirstOrDefault();

            foreach (DataRow row in dt.Rows)
            {
                int OdooUserID = int.Parse(row["id"].ToString());
                if (!cntxt.Users.Any(f => f.OdooUserID == OdooUserID))
                {
                    User user = new User();
                    user.UserName = row["login"].ToString();
                    user.OdooUserID = OdooUserID;
                    user.PassCode = int.Parse(row["pos_security_pin"].ToString());
                    
                    user.StoreID = int.Parse(storeid.ToString());
                    cntxt.Users.Add(user);
                }


            }

            cntxt.SaveChanges();

        }

        public void GetBuzzerfromODOO()
        {

        
          
            NpgsqlCommand cmd = new NpgsqlCommand(@"Select id,name from pos_buzzer ");

            DataTable dt = GetDataTable(cmd);
            var storeid = cntxt.Stores.Where(u => u.OdooStoreId == 1).Select(u => u.StoreID).FirstOrDefault();

            foreach (DataRow row in dt.Rows)
            {
                int OdooBuzzerID = int.Parse(row["id"].ToString());
                if (!cntxt.Buzzers.Any(f => f.OdooBuzzerID == OdooBuzzerID))
                {
                    Buzzer user = new Buzzer();
                    user.BuzzerName = row["name"].ToString();
                    user.OdooBuzzerID = OdooBuzzerID;
                    user.IsLocked = false;

                    user.StoreID = int.Parse(storeid.ToString());
                    cntxt.Buzzers.Add(user);
                }


            }

            cntxt.SaveChanges();

        }


        public void InsertCustomertoOdoofromlocal()
        {
            CustomerRepositiry custrepo = new CustomerRepositiry();

            var customerlist = custrepo.GetListofuserForUpload();


            var newcustomerlist = customerlist.Where(u => u.OdooID == 0 && u.IsDetailChanged == true);

            foreach(Customer cust in newcustomerlist)
            {
             int oddodid=   InsertCustomertoODoo(cust);
                cust.OdooID = oddodid;
                cust.IsDetailChanged = false;
            
                custrepo.UpdateCustomer(cust);
            }

            var oldcustomerlist = customerlist.Where(u => u.OdooID != 0).ToList();
            foreach (Customer cust in oldcustomerlist)
            {
               // InsertCustomertoODoo(cust);
            }





        }

        public void InsertShiftOdoofromlocal()
        {
            ShiftRepository shiftRepository = new ShiftRepository();
            List<Shift> Shiftlist = shiftRepository.GetListofOpenShift();


           

            foreach (Shift shft in Shiftlist)
            {
                shft.EndTime = DateTime.Now;
                shft.CloseUserName = Program.Username;
                shft.IsClosed = true;

                int oddodid = InsertSessionToODoo(shft);
                shft.OdooShiftId = oddodid;
                shiftRepository.UpdateShift(shft);
            }

           





        }

        public void InsertShiftOdoofromlocal(int ID)
        {
            ShiftRepository shiftRepository = new ShiftRepository();
            

            Shift shft = shiftRepository.GetShift(ID);


           
                shft.EndTime = DateTime.Now;
                shft.CloseUserName = Program.Username;
                shft.IsClosed = true;

                int oddodid = InsertSessionToODoo(shft);
                shft.OdooShiftId = oddodid;
                shiftRepository.UpdateShift(shft);
           







        }


        public int InsertCustomertoODoo( Customer cust)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(@"insert into res_partner
(name, display_name, mobile, phone, street, is_company, partner_share, customer, supplier, employee, email, comment, notify_email,
invoice_warn,  picking_warn,  type, active, company_id, create_date, create_uid, write_date, write_uid,pos_cust_id,purchase_warn,sale_warn)
values(:name,:display_name, :mobile, :phone, :street, False, True, True, False, False, 'emd@dkd.com', '00000000000000', 'always', False, False, 
'contact', True, 1, :createdDate, 1, :editdDate, 1,:pos_cust_id,:purchase_warn,:sale_warn)RETURNING id");

            if (cust.PhoneNumber == null)
            {
                cust.PhoneNumber = "0";
            }
            cmd.Parameters.AddWithValue("name", cust.CustomerName);
            cmd.Parameters.AddWithValue("purchase_warn", cust.CustomerName);
            cmd.Parameters.AddWithValue("sale_warn", cust.CustomerName);
            


            cmd.Parameters.AddWithValue("display_name", cust.CustomerName);
            cmd.Parameters.AddWithValue("mobile", cust.PhoneNumber);
            cmd.Parameters.AddWithValue("phone", cust.PhoneNumber);
            cmd.Parameters.AddWithValue("street", cust.CustomerDetails);
            cmd.Parameters.AddWithValue("pos_cust_id", cust.CustomerID);
            
            try
            {
                cmd.Parameters.AddWithValue("createdDate", DateTime.Parse(cust.AddedDate.ToString()));
                cmd.Parameters.AddWithValue("editdDate", DateTime.Parse(cust.AddedDate.ToString()));
            }
            catch (Exception)
            {

                cmd.Parameters.AddWithValue("createdDate", DateTime.Now);
                cmd.Parameters.AddWithValue("editdDate", DateTime.Now);
            }
          

            return InsertAndGetID(cmd);

        }

        public int InsertSessionToODoo(Shift shift)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(@"insert into session_master(create_uid,create_date,write_uid,write_date,name,session_from,session_to,session_date,sessionstartuser,sessionenduser,pos_session_id,state)
values(1,:create_date,1,:write_date,:name,:session_from,:session_to,:session_date,:sessionstartuser,:sessionenduser,:pos_session_id,'draft')RETURNING id");
            cmd.Parameters.AddWithValue("create_date", shift.StartTime);
            cmd.Parameters.AddWithValue("write_date", DateTime.Now);
            cmd.Parameters.AddWithValue("name", shift.ShiftName);
            cmd.Parameters.AddWithValue("session_from", shift.StartTime);
            cmd.Parameters.AddWithValue("session_to", shift.EndTime);
            cmd.Parameters.AddWithValue("session_date", shift.StartTime.Date);
            cmd.Parameters.AddWithValue("sessionstartuser", shift.StartUserName);

            cmd.Parameters.AddWithValue("sessionenduser", shift.CloseUserName);
            cmd.Parameters.AddWithValue("pos_session_id", shift.ShiftID);
          

            return InsertAndGetID(cmd);

        }





        public int insertRefund(RefundMaster refundMaster)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(@"insert into refund_master (name,pos_store_id,refund_date,total_refund,pos_user_id,pos_invoice_id,pos_refund_id,pos_shift_id,
create_uid,create_date,write_uid,write_date)values(:name,:pos_store_id,:refund_date,:total_refund,:pos_user_id,:pos_invoice_id,:pos_refund_id,:pos_shift_id,
:create_uid,:create_date,:write_uid,:write_date) RETURNING id");

            
            cmd.Parameters.AddWithValue("name", refundMaster.RefundNum);
            cmd.Parameters.AddWithValue("pos_store_id", refundMaster.StoreID);
            cmd.Parameters.AddWithValue("refund_date", refundMaster.RefundDate);
            cmd.Parameters.AddWithValue("total_refund", refundMaster.TotalRefund);
            cmd.Parameters.AddWithValue("pos_user_id", refundMaster.UserID);
            cmd.Parameters.AddWithValue("pos_invoice_id", refundMaster.InvoicemasterID);
            cmd.Parameters.AddWithValue("pos_refund_id", refundMaster.RefundMasterID);
            cmd.Parameters.AddWithValue("pos_shift_id", refundMaster.ShiftID);
            cmd.Parameters.AddWithValue("create_uid", 1);
            cmd.Parameters.AddWithValue("create_date", DateTime.Now);
            cmd.Parameters.AddWithValue("write_uid", 1);
            cmd.Parameters.AddWithValue("write_date", DateTime.Now);

            return InsertAndGetID(cmd);
        }

        public int insertSettlement(SettleMaster settleMaster)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(@"insert into settle_master (name,pos_customer_id,pos_settle_id,pos_user_id,settle_date,total_settle,pos_store_id,pos_shift_id,
create_uid,create_date,write_uid,write_date)values(:name,:pos_customer_id,:pos_settle_id,:pos_user_id,:settle_date,:total_settle,:pos_store_id,:pos_shift_id,
:create_uid,:create_date,:write_uid,:write_date) RETURNING id");


            cmd.Parameters.AddWithValue("name", settleMaster.SettleMasterID.ToString());
            cmd.Parameters.AddWithValue("pos_customer_id", settleMaster.CustomerID);
            cmd.Parameters.AddWithValue("pos_settle_id", settleMaster.SettleMasterID);
            cmd.Parameters.AddWithValue("pos_user_id", settleMaster.UserID);
            cmd.Parameters.AddWithValue("settle_date", settleMaster.SettleDate);
            cmd.Parameters.AddWithValue("total_settle", settleMaster.TotalRefund);
            cmd.Parameters.AddWithValue("pos_store_id", settleMaster.StoreID);
            cmd.Parameters.AddWithValue("pos_shift_id", settleMaster.ShiftID);
            cmd.Parameters.AddWithValue("create_uid", 1);
            cmd.Parameters.AddWithValue("create_date", DateTime.Now);
            cmd.Parameters.AddWithValue("write_uid", 1);
            cmd.Parameters.AddWithValue("write_date", DateTime.Now);

            return InsertAndGetID(cmd);
        }
        public int InsertCashOut(CashOutMaster cashOutMaster)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(@"insert into cashout_master (name,pos_user_id,total_cashout,cashout_date,pos_store_id,pos_shift_id,pos_cashout_id,
create_uid,create_date,write_uid,write_date)values(:name,:pos_user_id,:total_cashout,:cashout_date,:pos_store_id,:pos_shift_id,:pos_cashout_id,
:create_uid,:create_date,:write_uid,:write_date) RETURNING id");


            cmd.Parameters.AddWithValue("name", cashOutMaster.CashOutNum.ToString());
            cmd.Parameters.AddWithValue("pos_user_id", cashOutMaster.UserID);
            cmd.Parameters.AddWithValue("total_cashout", cashOutMaster.TotalCashOut);
            cmd.Parameters.AddWithValue("cashout_date", cashOutMaster.CashOutDate);
            cmd.Parameters.AddWithValue("pos_store_id", cashOutMaster.StoreID);
            cmd.Parameters.AddWithValue("pos_shift_id", cashOutMaster.ShiftID);
            cmd.Parameters.AddWithValue("pos_cashout_id", cashOutMaster.StoreID);
           
            cmd.Parameters.AddWithValue("create_uid", 1);
            cmd.Parameters.AddWithValue("create_date", DateTime.Now);
            cmd.Parameters.AddWithValue("write_uid", 1);
            cmd.Parameters.AddWithValue("write_date", DateTime.Now);

            return InsertAndGetID(cmd);

        }






        public NpgsqlConnection OpenConnection()
        {
            string connstring = String.Format("Server ={0};Port={1};" +
                      "User Id={2};Password={3};Database={4};",
                      Program.MySettingViewModal.MyOoodoDetasils.Server.Trim(), Program.MySettingViewModal.MyOoodoDetasils.PortNum.ToString().Trim(), Program.MySettingViewModal.MyOoodoDetasils.UserId.ToString().Trim(),
                     Program.MySettingViewModal.MyOoodoDetasils.Password.ToString().Trim(), Program.MySettingViewModal.MyOoodoDetasils.DataBasename.ToString().Trim());
            NpgsqlConnection conn = new NpgsqlConnection(connstring);


            return conn
            ;
        }

        public DataTable GetDataTable(NpgsqlCommand cmd)
        {
            NpgsqlConnection conn = OpenConnection();
            conn.Open();
            cmd.Connection = conn;
            DataTable dt = new DataTable();
            NpgsqlDataReader rdr = cmd.ExecuteReader();

            dt.Load(rdr);
            conn.Close();
            return dt;
        }


        public int InsertAndGetID(NpgsqlCommand cmd)
        {
            

            NpgsqlConnection conn = OpenConnection();
            conn.Open();
            cmd.Connection = conn;
            var newid = cmd.ExecuteScalar();
            return int.Parse(newid.ToString());
        }
    }
}
