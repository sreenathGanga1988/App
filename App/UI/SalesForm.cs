using App.Extensions;
using App.Model;
using App.Repository;
using App.UI.RefundAndExpense;
using App.ViewModal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.UI
{
    public partial class SalesForm : Form
    {

        int invoiceid = 0;

        public SalesForm()
        {
            InitializeComponent();
            SalesViewModal salesViewmodal = new SalesViewModal();
            LoadCategory(salesViewmodal);
            LoadTable(salesViewmodal);
        }
        public SalesForm(Invoicemaster  invoicemaster)
        {
            InitializeComponent();
            SalesViewModal salesViewmodal = new SalesViewModal();
            invoiceid = invoicemaster.InvoicemasterID;
            LoadCategory(salesViewmodal);
            LoadTable(salesViewmodal);
            LoadInvoicedata(invoicemaster);
        }


        public void LoadInvoicedata(Invoicemaster invoicemaster)
        {





            lbl_custid.Text = invoicemaster.CustomerID.ToString();
            lbl_customer.Text = invoicemaster.Customer.CustomerName;
            lbl_tableID.Text = invoicemaster.TableID.ToString();
            lbl_table.Text = invoicemaster.Table.TableName;

            foreach( InvoiceDetail invdet in invoicemaster.InvoiceDetails)
            {
                if (invdet.IsDeleted == false) { 
                var index = grd_ProductDetails.Rows.Add();
                grd_ProductDetails.Rows[index].Cells["ID"].Value = invdet.ProductId.ToString();
                grd_ProductDetails.Rows[index].Cells["Item"].Value = invdet.Product.ProductName.ToString();
                grd_ProductDetails.Rows[index].Cells["Price"].Value = invdet.UnitPrice.ToString();
                grd_ProductDetails.Rows[index].Cells["Qty"].Value = invdet.Qty.ToString(); ;
                grd_ProductDetails.Rows[index].Cells["Discount"].Value = invdet.DiscountPerUOM.ToString();

                grd_ProductDetails.Rows[index].Cells["ID"].ReadOnly = true;
                grd_ProductDetails.Rows[index].Cells["Item"].ReadOnly = true;
                grd_ProductDetails.Rows[index].Cells["Price"].ReadOnly = true;
                grd_ProductDetails.Rows[index].Cells["Discount"].ReadOnly = true;
                if (invdet.Product.IsRateChangable == true)
                {
                    grd_ProductDetails.Rows[index].Cells["Price"].ReadOnly = false;

                }
                }
                CalculateTotal();
            }
            

        }


        public void LoadCategory(SalesViewModal salesViewmodal)
        {
          
            int i = 0;
            int buttonheight = 0;
            int buttonwidth = 0;
            List<Category> Category = salesViewmodal.CategoryList;


        
            if (Category!=null)
            {
                if(Category.Count>0)
                {

                    int categorycount = Category.Count;
                     
                    float parentheight = float.Parse(this.pnl_category.Height.ToString());
                    float parentwidth = float.Parse(this.pnl_category.Width.ToString());
                    buttonheight = (int)Math.Ceiling(parentheight)/ categorycount;
                    buttonwidth = (int)Math.Ceiling(parentwidth);
                }
            }

            foreach(Category catgry in Category)
            {
                ValueButton temp = new ValueButton();
                temp.Name = "button" + catgry.Id.ToString();
                temp.Text = catgry.CategoryName;
                temp._value = catgry.Id.ToString();
                // temp.AutoSize = true;
                temp.Width = buttonwidth;
                temp.Height = buttonheight;
                try
                {
                    if (catgry.Color != null && catgry.Color.Trim() != "")
                    {
                        temp.BackColor = Color.FromName(catgry.Color);
                    }
                }
                catch (Exception)
                {

                 
                }
              
               
                temp.Location = new System.Drawing.Point(0, (buttonheight*i));//please adjust location as per your need
                temp.Tag = i;
                
                temp.Click += new EventHandler(OnButtonClick);
                this.pnl_category. Controls.Add(temp);
                    i++;
            }
            


        }


        public void  LoadTable(SalesViewModal salesViewmodal)
        {

            int i = 0;
            int buttonheight = 0;
            int buttonwidth = 0;
            List<Table> tableList = salesViewmodal.TableList;



            if (tableList != null)
            {
                if (tableList.Count > 0)
                {

                    int tablecount = tableList.Count;

                    float parentheight = float.Parse(this.grp_table.Height.ToString());
                    float parentwidth = float.Parse(this.grp_table.Width.ToString());
                    buttonwidth = (int)Math.Ceiling(parentwidth) / tablecount;
                    
                    buttonheight = (int)Math.Ceiling(parentheight);
                }
            }

            foreach (Table table in tableList)
            {
                ValueButton temp = new ValueButton();
                temp.Name = "button" + table.TableID.ToString();
                temp.Text = table.TableName;
                temp._value = table.TableID.ToString();
                // temp.AutoSize = true;
                temp.Width = buttonwidth;
                temp.Height = buttonheight;
                try
                {
                    if (table.Color != null && table.Color.Trim() != "")
                    {
                        temp.BackColor = Color.FromName(table.Color);
                    }
                }
                catch (Exception)
                {


                }


                temp.Location = new System.Drawing.Point((buttonwidth * i) , 0);//please adjust location as per your need
                temp.Tag = i;

                temp.Click += new EventHandler(OnTableButtonClick);
                this.grp_table.Controls.Add(temp);
                i++;
            }

        }

        private void OnTableButtonClick(object sender, EventArgs e)
        {
            lbl_table.Text = ((ValueButton)sender).Text;
            lbl_tableID.Text = ((ValueButton)sender)._value.ToString();
            //your code for the event.
        }


        private void OnButtonClick(object sender, EventArgs e)
        {
            int categoryId =int.Parse( ((ValueButton)sender)._value);
            ProductRepositories productrep = new ProductRepositories();

            List<ProductlistViewModal> Products=productrep.GetProductList(categoryId);
            LoadProducts(Products);
            //your code for the event.
        }
        private void OnProductButtonClick(object sender, EventArgs e)
        {
            int ProductID = int.Parse(((ValueButton)sender)._value);
            LoadSelectedBills(ProductID);
            
        }



        public void LoadSelectedBills(int ProductID)
        {
            ProductRepositories productrep = new ProductRepositories();
      
               
                try
            {
                if (!IsItemAlreadyAdded(ProductID))
                {
                    Product product = productrep.GetProduct(ProductID);
                    var index = grd_ProductDetails.Rows.Add();
                    grd_ProductDetails.Rows[index].Cells["ID"].Value = product.Id.ToString();
                    grd_ProductDetails.Rows[index].Cells["Item"].Value = product.ProductName.ToString();
                    grd_ProductDetails.Rows[index].Cells["Price"].Value = product.UnitPrice.ToString();
                    grd_ProductDetails.Rows[index].Cells["Qty"].Value = 1;
                    grd_ProductDetails.Rows[index].Cells["Discount"].Value = product.DiscountForLocation.ToString();

                    grd_ProductDetails.Rows[index].Cells["ID"].ReadOnly = true;
                    grd_ProductDetails.Rows[index].Cells["Item"].ReadOnly = true;
                    grd_ProductDetails.Rows[index].Cells["Price"].ReadOnly = true;
                    grd_ProductDetails.Rows[index].Cells["Discount"].ReadOnly = true;

                    //     grd_ProductDetails.Rows[index].Cells["Total"].Value = product.UnitPrice.ToString();
                    if (product.IsRateChangable == true)
                    {
                        grd_ProductDetails.Rows[index].Cells["Price"].ReadOnly = false;

                    }
                }
                CalculateTotal();
            }
                catch (Exception)
                {

                    MessageBox.Show("Wrong ItemCode");
                }
                
         
        }

        public void CalculateTotal()
        {
            Decimal TotalValue = 0;
            foreach (DataGridViewRow row in grd_ProductDetails.Rows)
            {
        
                row.Cells["Total"].Value = decimal.Parse(row.Cells["Qty"].Value.ToString()) * (Decimal.Parse(row.Cells["Price"].Value.ToString()) - Decimal.Parse(row.Cells["Discount"].Value.ToString()));

                TotalValue = TotalValue + decimal.Parse(row.Cells["Total"].Value.ToString());
                row.Cells["Total"].ReadOnly = true;
            }

            txt_total.Text = TotalValue.ToString();
        }





        public Boolean IsItemAlreadyAdded( int productid)
        { Boolean ispresent = false;
            foreach (DataGridViewRow row in grd_ProductDetails.Rows)
            {


                if(int.Parse (row.Cells["ID"].Value.ToString ().Trim())== productid)
                {

                    ispresent = true;
                    row.Cells["Qty"].Value = int.Parse(row.Cells["Qty"].Value.ToString())+1;
                //    row.Cells["Total"].Value = int.Parse(row.Cells["Qty"].Value.ToString()) * (Decimal.Parse(row.Cells["Price"].Value.ToString()) - Decimal.Parse(row.Cells["Discount"].Value.ToString()));
                }

            }

            return ispresent;

        }


        public void AddFloatPoint()
        {
            try
            {
                float k = float.Parse(txt_producrtcode.Text);
                k = float.Parse(txt_producrtcode.Text.Trim() + ".");
                txt_producrtcode.Text = txt_producrtcode.Text.Trim() + ".";
            }
            catch (Exception)
            {
                MessageBox.Show("Error");

            };
        }


        public void LoadProducts(List<ProductlistViewModal> Productlist)
        {
           
            Panel parent = this.pnl_product;
            parent.Controls.Clear();
            int i = 0;
            int colcount = 0;
            int buttonheight = 0;
            int buttonwidth = 0;
            int buttonindex = 0;



            if (Productlist != null)
            {
                if (Productlist.Count > 0)
                {

                    int tablecount = Productlist.Count;

                    float parentheight = float.Parse(parent.Height.ToString());
                    float parentwidth = float.Parse(parent.Width.ToString());
                    buttonwidth = (int)Math.Ceiling(parentwidth) / 6;

                    buttonheight = buttonwidth;
                }
            }

            foreach (ProductlistViewModal product in Productlist)
            {
                ValueButton temp = new ValueButton();
                temp.Name = "button" + product.ProductID.ToString();
                temp.Text = product.ProductName;
                temp._value = product.ProductID.ToString();
               // temp.AutoSize = true;
                temp.Width = buttonwidth;
                temp.Height = buttonheight;
                temp.Font = new Font(temp.Font, FontStyle.Bold);

                //temp.Width = 200;
                //temp.Height = 150;
                try
                {
                    if (product.Color != null && product.Color.Trim() != "")
                    {
                        temp.BackColor = Color.FromName(product.Color);
                    }
                }
                catch (Exception)
                {


                }
                

                    temp.Location = new System.Drawing.Point((buttonwidth * buttonindex), (buttonheight * colcount));//please adjust location as per your need

                if (buttonindex % 5 == 0&& buttonindex != 0)
                {
                    colcount++;
                    buttonindex = 0;


                }
                else
                {
                    buttonindex++;
                }
                temp.Tag = i;

                temp.Click += new EventHandler(OnProductButtonClick);
                parent.Controls.Add(temp);
                i++;
            }
            parent.AutoScroll = true;
        }

        private void SalesForm_KeyDown(object sender, KeyEventArgs e) { 
        //{           
        //    if (e.KeyCode == Keys.Delete)
        //    {
        //        foreach (DataGridViewRow r in grd_ProductDetails.SelectedRows)
        //        {
        //            if (!r.IsNewRow)
        //            {
        //                grd_ProductDetails.Rows.RemoveAt(r.Index);
        //            }
        //        }
        //    }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int ProductID = int.Parse(((TextBox)sender).Text);
                LoadSelectedBills(ProductID);
            }
        }

        private void btn_addItembyCode_Click(object sender, EventArgs e)
        {
       
        }

        

        private void numericbuttonclicked_Click(object sender, EventArgs e)
        {
          KeyPressed((Button)sender);
        }
        public void KeyPressed(Button btn)
        {

            if (btn.Text.Trim () == "Add Item")
            {

                int ProductID = int.Parse((txt_producrtcode.Text));
                LoadSelectedBills(ProductID);
            }
            else if (btn.Text.Trim() == "Back")
            {
                txt_producrtcode.Text = Extensions.MyExtensions.TrimLastCharacter(txt_producrtcode.Text);

            }
            else if (btn.Text.Trim() == "Customer")
            {
                try
                {
                    int CustomerID = int.Parse((txt_producrtcode.Text));
                    CustomerRepositiry custrepo = new CustomerRepositiry();

                    Customer cust = custrepo.GetCustomer(CustomerID);


                    lbl_customer.Text = cust.CustomerName;
                    lbl_custid.Text = cust.CustomerID.ToString();
                }
                catch (Exception)
                {

                    MessageBox.Show("Wrong customer ID");
                }

            }
            else if (btn.Text.Trim() == "Qty")
            {

                foreach (DataGridViewRow row in grd_ProductDetails.SelectedRows)
                {
                    row.Cells["Qty"].Value = int.Parse(txt_producrtcode.Text.ToString());

                }
                CalculateTotal();
            }
            else if (btn.Text.Trim() == "Cash")
            {

                try
                {
                    txt_cash.Text = Decimal.Parse(txt_producrtcode.Text.Trim()).ToString(); ;
                }
                catch (Exception)
                {

                    MessageBox.Show("Wrong Cash Entered");
                }
            }
            else if (btn.Text.Trim() == "KOT")
            {
                if (ValidateforKot())
                {
                    //AddKoT();
                    AddInvoice("kot");


                    clearGridView();
                }

            }
            else if (btn.Text.Trim() == "Table Bill")
            {
                if (ValidateforKot())
                {
                    //AddKoT();
                    AddInvoice("kot");


                    clearGridView();
                }

            }
            else if (btn.Text.Trim() == "Clear")
            {
                txt_producrtcode.Text = "";

            }
            else if (btn.Text.Trim() == "CheckOut")
            {
                if (ValidateforCheckOut())
                {
                    AddInvoice("");
                }
              
            }
            else if (btn.Text.Trim() == ".")
            {

                AddFloatPoint();


            }

            else if (btn.Text.Trim() == "Reset")
            {

                clearGridView();


            }


            else
            {
                txt_producrtcode.Text = txt_producrtcode.Text+btn.Text.Trim() ;
            }

        }




        public void fillchange()
        {

            if (calculateChange() > 0) { txt_change.Text = calculateChange().ToString(); } else { txt_change.Text = "0"; };
            
        }
        public Decimal calculateChange()
        {
            Decimal Total = Decimal.Parse(txt_total.Text);
            Decimal cash = Decimal.Parse(txt_cash.Text);
            Decimal change = cash - Total;
            return change;
        }

        private void txt_total_TextChanged(object sender, EventArgs e)
        {
            try
            {
                fillchange();
            }
            catch (Exception)
            {

               
            }
        }

        private void txt_change_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_cash_TextChanged(object sender, EventArgs e)
        {
            try
            {
                fillchange();
            }
            catch (Exception)
            {

                
            }
        }

        //public void AddKoT()
        //{
        //    KotMaster komstr = new KotMaster();
        //    komstr.StoreID = Program.LocationID;
        //    komstr.UserID = Program.UserID;
        //    komstr.InvoiceDate = DateTime.Now;
        //    komstr.CustomerID = int.Parse(lbl_custid.Text);
        //    komstr.TableID = int.Parse(lbl_tableID.Text);
        //    komstr.StoreName = Program.StoreName;
        //    komstr.StoreAddress = Program.StoreAddress;
        //    komstr.Cashier = Program.Username;
        //    komstr.CustomerName = lbl_customer.Text;
        //    List<KotDetail> KotDetails = new List<KotDetail> { };
        //    foreach (DataGridViewRow row in grd_ProductDetails.Rows)
        //    {
        //        KotDetail kotdetail = new KotDetail();
        //        kotdetail.ProductId = int.Parse( row.Cells["ID"].Value.ToString());
        //        kotdetail.ProductName = row.Cells["Item"].Value.ToString();
        //        kotdetail.UnitPrice = Decimal.Parse(row.Cells["Price"].Value.ToString());
        //        kotdetail.Qty = Decimal.Parse(row.Cells["Qty"].Value.ToString());
        //        kotdetail.DiscountPerUOM = Decimal.Parse(row.Cells["Discount"].Value.ToString());

        //        KotDetails.Add(kotdetail);
        //    }
        //    komstr.KotDetails = KotDetails;
        //    KotRepository kotrepo = new KotRepository();
        //    komstr= kotrepo.InsertKOT(komstr);
           

        //    try
        //    {
        //        PrintReceipt prnt = new PrintReceipt();
        //        prnt.printKOTreport(komstr);

        //        MessageBox.Show("KOT #:" + komstr.KotNum);
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show("Printer Malfunction.But Invoice Done");
        //    }

        //}


        public void AddInvoice( String BillType)
        {
            Invoicemaster invoicemaster = new Invoicemaster();
            invoicemaster.StoreID = Program.LocationID;
            invoicemaster.UserID = Program.UserID;
            invoicemaster.InvoiceDate = DateTime.Now;
            invoicemaster.CustomerID = int.Parse(lbl_custid.Text);
            invoicemaster.TableID = int.Parse(lbl_tableID.Text);
            invoicemaster.TotalPaid = Decimal.Parse(txt_total.Text);
            invoicemaster.TotalBill = Decimal.Parse(txt_total.Text);
            invoicemaster.StoreName = Program.StoreName;
            invoicemaster.StoreAddress = Program.StoreAddress;
            invoicemaster.Cashier = Program.Username;
            invoicemaster.CustomerName = lbl_customer.Text;
            invoicemaster.IsUploaded = false;
            if (BillType == "Table")
            {
                invoicemaster.IstableBill = true;

            }
            else
            {
                invoicemaster.IstableBill = false;
            }
            if (BillType == "kot")
            {
                invoicemaster.IsKOT = true;

            }
            else
            {
                invoicemaster.IsKOT = false;
            }
            if (invoiceid != 0)
            {
                invoicemaster.InvoicemasterID = invoiceid;
            }
            List<InvoiceDetail> invoicedetails = new List<InvoiceDetail> { };
            foreach (DataGridViewRow row in grd_ProductDetails.Rows)
            {
                InvoiceDetail invoicedetail = new InvoiceDetail();
                invoicedetail.ProductId = int.Parse(row.Cells["ID"].Value.ToString());
                invoicedetail.ProductName = row.Cells["Item"].Value.ToString().Trim();

                invoicedetail.IsDeleted = false;               
                invoicedetail.UnitPrice = Decimal.Parse(row.Cells["Price"].Value.ToString());
                invoicedetail.Qty = Decimal.Parse(row.Cells["Qty"].Value.ToString());
                invoicedetail.DiscountPerUOM = Decimal.Parse(row.Cells["Discount"].Value.ToString());
                invoicedetail.Total = Decimal.Parse(row.Cells["Total"].Value.ToString());
                invoicedetail.IsUploaded = false;
                invoicedetail.PreviousQty = invoicedetail.Qty;
                invoicedetail.AdjustedQty = 0;
                if (invoiceid != 0)
                {
                    invoicedetail.InvoicemasterID = invoiceid;
                }

                invoicedetails.Add(invoicedetail);
            }
            invoicemaster.InvoiceDetails = invoicedetails;
            InvoiceRepository invrrepo = new InvoiceRepository();

            invoicemaster= invrrepo.InsertInvoiceLocal(invoicemaster);
            try
            {
                PrintReceipt prnt = new PrintReceipt();

                if (BillType == "kot")
                {
                    prnt = new PrintReceipt();
                    prnt.printKOTreport(invoicemaster);

                    MessageBox.Show("KOT #:" + invoicemaster.InvoiceNum);
                }
                else
                {
                    prnt.printInvoicereport(invoicemaster);

                    MessageBox.Show("Bill #:" + invoicemaster.InvoiceNum);
                }
             
            }
            catch (Exception ex)
            {

               MessageBox.Show("Printer Malfunction.But Invoice Done");
            }
        }


        public Boolean ValidateforKot()
        {
            Boolean isvalidforKot = false;

            if (lbl_custid.Text.Trim() == "")
            {
                MessageBox.Show("Enter Customer ID");
            }
            else if (lbl_tableID.Text.Trim() == "")
            {

                MessageBox.Show("Select A Table");
            }
            else if (grd_ProductDetails.Rows.Count <= 0)
            {

                MessageBox.Show("No Item Selected");
            }

            else if (!MyExtensions.CheckifNumeric(lbl_custid.Text.Trim()))
            {

                MessageBox.Show("Enter Valid Customer ID");
            }
            else if (!MyExtensions.CheckifNumeric(lbl_tableID.Text.Trim()))
            {

                MessageBox.Show("Select A  Valid Table");
            }
            else
            {
                isvalidforKot = true;
            }

            return isvalidforKot;
        }



        public Boolean ValidateforCheckOut()
        {
            Boolean isvalidforInvoice = false;
            if (!ValidateforKot())
            {

            }
            else if (txt_cash.Text.Trim()==""||txt_cash.Text==null)
            {
                MessageBox.Show("Enter Cash");
            }
            else if (txt_total.Text.Trim() == "" || txt_total.Text == null)
            {
                MessageBox.Show("Wrong total Select one more item ");
            }
            else if(!MyExtensions.CheckifDecimal(txt_cash.Text.Trim())){
                MessageBox.Show("Enter Cash Correctly");
            }
            else if (!MyExtensions.CheckifDecimal(txt_total.Text.Trim()))
            {
                MessageBox.Show("Wrong total");
            }
            else if (Decimal.Parse (txt_total.Text.Trim())> Decimal.Parse(txt_cash.Text.Trim()))
            {
                MessageBox.Show("Insufficeint cash..");

            }
            else
            {
                isvalidforInvoice = true;
            }

            return isvalidforInvoice;
        }



        public Boolean ValidateforTableBill()
        {
            Boolean isvalidforInvoice = false;
            if (!ValidateforKot())
            {

            }
          
            else if (txt_total.Text.Trim() == "" || txt_total.Text == null)
            {
                MessageBox.Show("Wrong total Select one more item ");
            }
            else if (!MyExtensions.CheckifDecimal(txt_cash.Text.Trim()))
            {
                MessageBox.Show("Enter Cash Correctly");
            }
            else if (!MyExtensions.CheckifDecimal(txt_total.Text.Trim()))
            {
                MessageBox.Show("Wrong total");
            }
          
            else
            {
                isvalidforInvoice = true;
            }

            return isvalidforInvoice;
        }


        private void btn_printCheckOut_Click(object sender, EventArgs e)
        {
            if (ValidateforCheckOut())
            {
                AddInvoice("");
                clearGridView();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (ValidateforTableBill())
            {
                AddInvoice("Table");
                clearGridView();
            }
        }

        private void btn_actionBoard_Click(object sender, EventArgs e)
        {
            ActionBoard Board = new ActionBoard();
            Board.ShowDialog();
        }


        public void clearGridView()
        {

            grd_ProductDetails.Rows.Clear();
            txt_total.Text = "0";
            txt_cash.Text = "0";
            txt_change.Text = "0";
            invoiceid = 0;

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void btn_pending_Click(object sender, EventArgs e)
        {
            KOT frm = new KOT();

            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_producrtcode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
