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
        }



        public void uploadInvoiceMaster()
        {



            var q = from invoiceMaster in cntxt.Invoicemasters
                    where invoiceMaster.IsUploaded == false
                    select invoiceMaster;

            List<Invoicemaster> invoicemasters = cntxt.Invoicemasters.Where(U => U.IsUploaded == false).ToList();

            foreach (Invoicemaster element in invoicemasters)
            {

                if (InsertInvoicemaster(element)) {


                    element.IsUploaded = true;

                };
                         


            }

            cntxt.SaveChanges();
        }


        public void InsertinvoicetoOodo(Invoicemaster invmstr)
        {

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
            POSDataContext cntxt = new POSDataContext();
            string connstring = String.Format("Server={0};Port={1};" +
            "User Id={2};Password={3};Database={4};",
            Program.MySettingViewModal.MyOoodoDetasils.Server.Trim(), Program.MySettingViewModal.MyOoodoDetasils.PortNum.ToString().Trim(), Program.MySettingViewModal.MyOoodoDetasils.UserId.ToString().Trim(),
            Program.MySettingViewModal.MyOoodoDetasils.Password.ToString().Trim(), Program.MySettingViewModal.MyOoodoDetasils.DataBasename.ToString().Trim());
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(@"select a.id,b.name,b.pos_categ_id,b.list_price from product_product a, product_template b 
            where a.product_tmpl_id=b.id", conn);

            DataTable dt = new DataTable();
            NpgsqlDataReader rdr = cmd.ExecuteReader();

            dt.Load(rdr);
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

            CategoryRepository repo = new CategoryRepository();
            POSDataContext cntxt = new POSDataContext();
            string connstring = String.Format("Server={0};Port={1};" +
            "User Id={2};Password={3};Database={4};",
            Program.MySettingViewModal.MyOoodoDetasils.Server.Trim(), Program.MySettingViewModal.MyOoodoDetasils.PortNum.ToString().Trim(), Program.MySettingViewModal.MyOoodoDetasils.UserId.ToString().Trim(),
            Program.MySettingViewModal.MyOoodoDetasils.Password.ToString().Trim(), Program.MySettingViewModal.MyOoodoDetasils.DataBasename.ToString().Trim());
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(@"select id , name from pos_category", conn);

            DataTable dt = new DataTable();
            NpgsqlDataReader rdr = cmd.ExecuteReader();

            dt.Load(rdr);
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

            CategoryRepository repo = new CategoryRepository();
            POSDataContext cntxt = new POSDataContext();
            string connstring = String.Format("Server={0};Port={1};" +
            "User Id={2};Password={3};Database={4};",
            Program.MySettingViewModal.MyOoodoDetasils.Server.Trim(), Program.MySettingViewModal.MyOoodoDetasils.PortNum.ToString().Trim(), Program.MySettingViewModal.MyOoodoDetasils.UserId.ToString().Trim(),
            Program.MySettingViewModal.MyOoodoDetasils.Password.ToString().Trim(), Program.MySettingViewModal.MyOoodoDetasils.DataBasename.ToString().Trim());
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(@"select id , name from res_company", conn);

            DataTable dt = new DataTable();
            NpgsqlDataReader rdr = cmd.ExecuteReader();

            dt.Load(rdr);

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

            CategoryRepository repo = new CategoryRepository();
            POSDataContext cntxt = new POSDataContext();
            string connstring = String.Format("Server={0};Port={1};" +
            "User Id={2};Password={3};Database={4};",
            Program.MySettingViewModal.MyOoodoDetasils.Server.Trim(), Program.MySettingViewModal.MyOoodoDetasils.PortNum.ToString().Trim(), Program.MySettingViewModal.MyOoodoDetasils.UserId.ToString().Trim(),
            Program.MySettingViewModal.MyOoodoDetasils.Password.ToString().Trim(), Program.MySettingViewModal.MyOoodoDetasils.DataBasename.ToString().Trim());
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(@"select id , name from restaurant_table", conn);

            DataTable dt = new DataTable();
            NpgsqlDataReader rdr = cmd.ExecuteReader();

            dt.Load(rdr);


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

            CategoryRepository repo = new CategoryRepository();
            POSDataContext cntxt = new POSDataContext();
            string connstring = String.Format("Server={0};Port={1};" +
            "User Id={2};Password={3};Database={4};",
            Program.MySettingViewModal.MyOoodoDetasils.Server.Trim(), Program.MySettingViewModal.MyOoodoDetasils.PortNum.ToString().Trim(), Program.MySettingViewModal.MyOoodoDetasils.UserId.ToString().Trim(),
            Program.MySettingViewModal.MyOoodoDetasils.Password.ToString().Trim(), Program.MySettingViewModal.MyOoodoDetasils.DataBasename.ToString().Trim());
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(@"select id,login,company_id,pos_security_pin from res_users", conn);

            DataTable dt = new DataTable();
            NpgsqlDataReader rdr = cmd.ExecuteReader();

            dt.Load(rdr);
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




    }
}
