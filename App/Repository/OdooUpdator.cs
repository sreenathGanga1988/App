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

        public void uploadInvoiceMaster()
        {
            var q = from invoiceMaster in cntxt.Invoicemasters
                    where invoiceMaster.IsUploaded == false
                    select invoiceMaster;

            foreach (var element in q)
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
               NpgsqlCommand cmd = new NpgsqlCommand(@"insert into pos_order_invoice
      (create_uid,user_id, store_id,write_uid, create_date, write_date, table_id, pos_invoice_id, total_discount, total_paid,customer_id, round_off, invoice_date,total_bill)
values(:create_uid,:user_id, :store_id,:write_uid ,:create_date,:write_date,:table_id, :pos_invoice_id, :total_discount, :total_paid,:customer_id, :round_off, :invoice_date,:total_bill) RETURNING id;", conn);
                cmd.Parameters.Add(new NpgsqlParameter("create_uid", invmstr.UserID));
                cmd.Parameters.Add(new NpgsqlParameter("user_id", invmstr.UserID));
                cmd.Parameters.Add(new NpgsqlParameter("store_id", Program.LocationID));
                cmd.Parameters.Add(new NpgsqlParameter("write_uid", invmstr.UserID));
                cmd.Parameters.Add(new NpgsqlParameter("write_date", DateTime.Now)); ;
                cmd.Parameters.Add(new NpgsqlParameter("create_date", DateTime.Now));

             

                cmd.Parameters.Add(new NpgsqlParameter("table_id", invmstr.TableID));
                cmd.Parameters.Add(new NpgsqlParameter("pos_invoice_id", invmstr.InvoicemasterID));
                cmd.Parameters.Add(new NpgsqlParameter("total_discount", Decimal.Parse("0")));
                cmd.Parameters.Add(new NpgsqlParameter("total_paid", invmstr.TotalPaid));
                cmd.Parameters.Add(new NpgsqlParameter("total_bill", invmstr.TotalBill));
                cmd.Parameters.Add(new NpgsqlParameter("customer_id", invmstr.CustomerID));
               
                cmd.Parameters.Add(new NpgsqlParameter("round_off", invmstr.RoundOffAmount));
                cmd.Parameters.Add(new NpgsqlParameter("invoice_date", invmstr.InvoiceDate));
      var id=   cmd.ExecuteScalar();




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

                Category category = new Category();
                category.CategoryName = row["name"].ToString();
                category.OdooCategoryId = int.Parse(row["id"].ToString());
                category.Color = "";
                cntxt.Categorys.Add(category);



            }

            cntxt.SaveChanges();

        }





    }
}
