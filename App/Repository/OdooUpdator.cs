using App.Context;
using App.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository
{
    public  class OdooUpdator
    {

        POSDataContext cntxt = new POSDataContext();

      

        public void Updatemaster()
        {
            GetStorefromODOO();
            GetTablefromODOO();
            GetUserfromODOO();
            GetBuzzerfromODOO();
            // GetBuzzerfromODOO();
            GetCategoryfromODOO();
            GetProductfromODOO();
            InsertCustomertoOdoofromlocal();

        }



        public void uploadInvoiceMaster()
        {


         
                InsertShiftOdoofromlocal();

            try
            {
                var q = from invoiceMaster in cntxt.Invoicemasters
                        where invoiceMaster.IsUploaded == false
                        select invoiceMaster;

                List<Invoicemaster> invoicemasters = cntxt.Invoicemasters.Where(U => U.IsUploaded == false).ToList();

                foreach (Invoicemaster element in invoicemasters)
                {

                    if (InsertInvoicemaster(element))
                    {


                        element.IsUploaded = true;

                    };



                }

                cntxt.SaveChanges();

               
            }
            catch (Exception)
            {
                System.Windows.Forms.Application.Exit();

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
state
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
:state) RETURNING id;", conn);


             


                cmd.Parameters.Add(new NpgsqlParameter("create_uid", invmstr.UserID));
                cmd.Parameters.Add(new NpgsqlParameter("write_date", DateTime.Now));
                cmd.Parameters.Add(new NpgsqlParameter("user_id", invmstr.UserID));
                cmd.Parameters.Add(new NpgsqlParameter("write_uid", invmstr.UserID));
                cmd.Parameters.Add(new NpgsqlParameter("create_date", DateTime.Now));
                cmd.Parameters.Add(new NpgsqlParameter("store_id", Program.LocationID));            
                cmd.Parameters.Add(new NpgsqlParameter("name", invmstr.InvoiceNum));
                cmd.Parameters.Add(new NpgsqlParameter("order_date", invmstr.InvoiceDate));
                cmd.Parameters.Add(new NpgsqlParameter("date", invmstr.InvoiceDate.Date));
                cmd.Parameters.Add(new NpgsqlParameter("partner_id", invmstr.CustomerID));
                 cmd.Parameters.Add(new NpgsqlParameter("session_id", Program.ShiftId));
                cmd.Parameters.Add(new NpgsqlParameter("table_id", invmstr.TableID));
                cmd.Parameters.Add(new NpgsqlParameter("payment_method", invmstr.PaymentMode));
                cmd.Parameters.Add(new NpgsqlParameter("state", "draft"));
                cmd.Parameters.Add(new NpgsqlParameter("pos_invoice_id", invmstr.InvoicemasterID));
                //cmd.Parameters.Add(new NpgsqlParameter("total_discount", Decimal.Parse("0")));
                //cmd.Parameters.Add(new NpgsqlParameter("total_paid", invmstr.TotalPaid));
                //cmd.Parameters.Add(new NpgsqlParameter("total_bill", invmstr.TotalBill));
               
               
                //cmd.Parameters.Add(new NpgsqlParameter("round_off", invmstr.RoundOffAmount));
               
      var id=   cmd.ExecuteScalar();

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




                    cmd1.Parameters.Add(new NpgsqlParameter("create_uid", invmstr.UserID));
                    cmd1.Parameters.Add(new NpgsqlParameter("write_date", DateTime.Now));

                    cmd1.Parameters.Add(new NpgsqlParameter("user_id", invmstr.UserID));
                    cmd1.Parameters.Add(new NpgsqlParameter("write_uid", invmstr.UserID));
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



                    cmd1.Parameters.Add(new NpgsqlParameter("tax_amount", "0"));
                    cmd1.Parameters.Add(new NpgsqlParameter("total_paid", invdet.Total));
                    cmd1.Parameters.Add(new NpgsqlParameter("pos_invoice_line_id", invdet.InvoiceDetailID));


                    var newid = cmd.ExecuteScalar();

                }














                // since we only showing the result we don't need connection anymore
                conn.Close();

                

                isok = true;
            }
            catch (Exception Ex)
            {

                
                isok = false;
              
            }

            return isok;
        }



        public void GetProductfromODOO()
        {

            CategoryRepository repo = new CategoryRepository();
         
            NpgsqlCommand cmd = new NpgsqlCommand(@"select a.id,b.name,b.pos_categ_id,b.list_price,sum(d.amount) as tax_amount from product_product a, product_template b,product_taxes_rel c,account_tax d
where a.product_tmpl_id=b.id and c.prod_id=b.id and d.id=c.tax_id group by a.id,b.name,b.pos_categ_id,b.list_price order by b.name");
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
                    product.Taxamount = int.Parse(row["tax_amount"].ToString());
                    product.DiscountForLocation = 0;
                    product.MinimumSPForLocation = product.UnitPrice;
                    product.Color = "";
                    product.Image = "";

                    product.IsAvailable = true;
                    product.IsRateChangable = true;
                    product.IsTodaySpecial = true;
                    cntxt.Products.Add(product);
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

           
            NpgsqlCommand cmd = new NpgsqlCommand(@"select id , name from res_company");

            DataTable dt = GetDataTable(cmd);

            foreach (DataRow row in dt.Rows)
            {
                int OdooStoreId = int.Parse(row["id"].ToString());
                if (!cntxt.Stores.Any(f => f.OdooStoreId == OdooStoreId))
                {
                    Store store = new Store();
                    store.StoreName = row["name"].ToString();
                    store.OdooStoreId = OdooStoreId;

                    cntxt.Stores.Add(store);
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

            var customerlist = cntxt.Customers.Where(u=>u.IsDetailChanged==true).ToList();


            var newcustomerlist = customerlist.Where(u => u.OdooID == 0).ToList();

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
            var Shiftlist = cntxt.Shifts.Where(u => u.IsClosed == false).ToList();


           

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



        public int InsertCustomertoODoo( Customer cust)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(@"insert into res_partner
(name, display_name, mobile, phone, street, is_company, partner_share, customer, supplier, employee, email, comment, notify_email,
invoice_warn, sale_warn, picking_warn, purchase_warn, type, active, company_id, create_date, create_uid, write_date, write_uid)
values(:name,:display_name, :mobile, :phone, :street, False, True, True, False, False, 'emd@dkd.com', '00000000000000', 'always', False, False, False, False,
'contact', True, 1, :createdDate, 1, :editdDate, 1)RETURNING id");

            if (cust.PhoneNumber == null)
            {
                cust.PhoneNumber = "0";
            }
            cmd.Parameters.AddWithValue("name", cust.CustomerName);
            cmd.Parameters.AddWithValue("display_name", cust.CustomerName);
            cmd.Parameters.AddWithValue("mobile", cust.PhoneNumber);
            cmd.Parameters.AddWithValue("phone", cust.PhoneNumber);
            cmd.Parameters.AddWithValue("street", cust.CustomerDetails);
            cmd.Parameters.AddWithValue("createdDate",DateTime.Parse( cust.AddedDate.ToString()));
            cmd.Parameters.AddWithValue("editdDate", DateTime.Parse(cust.AddedDate.ToString()));

            return InsertAndGetID(cmd);

        }

        public int InsertSessionToODoo(Shift shift)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(@"insert into session_master(create_uid,create_date,write_uid,write_date,name,session_from,session_to,session_date,sessionstartuser,sessionenduser,pos_session_id,state)
values(1,:create_date,1,:write_date,:name,:session_from,:session_to,:session_date,:sessionstartuser,:sessionenduser,:pos_session_id,'draft'))RETURNING id");
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
