using App.Context;
using App.Model;
using Npgsql;
using System;
using System.Collections.Generic;
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

                InsertInvoicemaster(element);





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
                        Program.MyOoodoDetasils.Server.Trim(), Program.MyOoodoDetasils.PortNum.ToString().Trim(), Program.MyOoodoDetasils.UserId.ToString().Trim(),
                       Program.MyOoodoDetasils.Password.ToString().Trim(), Program.MyOoodoDetasils.DataBasename.ToString().Trim());
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(@"insert into pos_order_invoice(create_uid, user_id, store_id, round_off, invoice_date, write_uid, table_id, pos_invoice_id, total_discount, total_paid,
 write_date, create_date, customer_id, kot_master_id) values(:create_uid, :user_id, :store_id, :round_off, :invoice_date, :write_uid, :table_id, :pos_invoice_id, :total_discount, :total_paid,
 :write_date, :create_date, :customer_id, :kot_master_id)", conn);
                //NpgsqlCommand cmd = new NpgsqlCommand("insert into login (Name, Password) values(:name, :pw)", conn);
                cmd.Parameters.Add(new NpgsqlParameter("create_uid", invmstr.UserID));
                cmd.Parameters.Add(new NpgsqlParameter("user_id", invmstr.UserID));
                cmd.Parameters.Add(new NpgsqlParameter("store_id", invmstr.StoreID));
                cmd.Parameters.Add(new NpgsqlParameter("round_off", "0"));
                cmd.Parameters.Add(new NpgsqlParameter("round_off", "0"));
                cmd.Parameters.Add(new NpgsqlParameter("invoice_date", invmstr.InvoiceDate));
                cmd.Parameters.Add(new NpgsqlParameter("write_uid", invmstr.UserID));
                cmd.Parameters.Add(new NpgsqlParameter("table_id", invmstr.TableID));
                cmd.Parameters.Add(new NpgsqlParameter("pos_invoice_id", invmstr.InvoicemasterID));
                cmd.Parameters.Add(new NpgsqlParameter("total_discount", "0"));
                cmd.Parameters.Add(new NpgsqlParameter("total_discount", "0"));
                cmd.Parameters.Add(new NpgsqlParameter("total_paid", "0"));
                cmd.Parameters.Add(new NpgsqlParameter("write_date", "0"));
                cmd.Parameters.Add(new NpgsqlParameter("create_date", "0"));

                cmd.Parameters.Add(new NpgsqlParameter("customer_id", invmstr.CustomerID));               
             
              
                cmd.ExecuteNonQuery();




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
    }
}
