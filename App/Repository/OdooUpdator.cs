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



//        public void uploadInvoiceDetails()
//        {
//            var q = from invoiceDetail in cntxt.InvoiceDetails
//                    where invoiceDetail.IsUploaded == false
//                    select invoiceDetail;

//            foreach (var element in q)
//            {

//                if (InsertInvoicemaster(element))
//                {


//                    element.IsUploaded = true;

//                };



//            }

//            cntxt.SaveChanges();
//        }






//        public Boolean InsertInvoiceDetails(InvoiceDetail invdet)
//        {
//            Boolean isok = false;

//            try
//            {
//                //string connstring = String.Format("Server=192.168.1.73;Port=5432;User Id=odoo;Password=at123;Database=ken-aug20;");
//                string connstring = String.Format("Server={0};Port={1};" +
//                        "User Id={2};Password={3};Database={4};",
//                        Program.MySettingViewModal.MyOoodoDetasils.Server.Trim(), Program.MySettingViewModal.MyOoodoDetasils.PortNum.ToString().Trim(), Program.MySettingViewModal.MyOoodoDetasils.UserId.ToString().Trim(),
//                       Program.MySettingViewModal.MyOoodoDetasils.Password.ToString().Trim(), Program.MySettingViewModal.MyOoodoDetasils.DataBasename.ToString().Trim());
//                NpgsqlConnection conn = new NpgsqlConnection(connstring);
//                conn.Open();
//                NpgsqlCommand cmd = new NpgsqlCommand(@"insert into pos_order_invoice_details 
//(create_uid,create_date,product_id,discount,unit_price,write_uid,line_id,pos_invoice_id,write_date,qty,pos_invoice_details_id,product_name)
//values(:create_uid,)", conn);
//                cmd.Parameters.Add(new NpgsqlParameter("create_uid", invdet.Invoicemaster.UserID));
//                cmd.Parameters.Add(new NpgsqlParameter("create_date", DateTime.Now));

//                cmd.Parameters.Add(new NpgsqlParameter("product_id", invdet.ProductId));
//                cmd.Parameters.Add(new NpgsqlParameter("discount", invdet.DiscountPerUOM));
//                cmd.Parameters.Add(new NpgsqlParameter("unit_price", invdet.UnitPrice));
//                cmd.Parameters.Add(new NpgsqlParameter("write_uid", invdet.Invoicemaster.UserID)); ;
              



//             //   cmd.Parameters.Add(new NpgsqlParameter("line_id", invdet.TableID));
//                cmd.Parameters.Add(new NpgsqlParameter("pos_invoice_id", invdet.InvoicemasterID));
//                cmd.Parameters.Add(new NpgsqlParameter("write_date", DateTime.Now));
//                cmd.Parameters.Add(new NpgsqlParameter("qty", invdet.Qty));
//                cmd.Parameters.Add(new NpgsqlParameter("pos_invoice_details_id", invdet.InvoiceDetailID));
              
          
//                cmd.ExecuteNonQuery();




//                // since we only showing the result we don't need connection anymore
//                conn.Close();



//                isok = true;
//            }
//            catch (Exception Ex)
//            {
//                isok = false;

//            }

//            return isok;
//        }








    }
}
