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
    public partial class FrmPOS1Table : Form
    {
        int invoiceid = 0;
        public FrmPOS1Table()
        {
            InitializeComponent();
            SalesViewModal salesViewmodal = new SalesViewModal();
            LoadCategory(salesViewmodal);
            UpdateFont();
          //  LoadTable(salesViewmodal);
        }


        private void UpdateFont()
        {
            //Change cell font
            grd_ProductDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            grd_ProductDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grd_ProductDetails.ColumnHeadersDefaultCellStyle.Font =new Font(grd_ProductDetails.Font, FontStyle.Bold);
            grd_ProductDetails.RowTemplate.Height = 40;
            foreach (DataGridViewColumn c in grd_ProductDetails.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 12.5F,FontStyle.Bold);
                c.DefaultCellStyle.ForeColor = Color.Black;
               
            }
            
            grd_ProductDetails.Columns["Item"].Width = 150;
            grd_ProductDetails.Columns["Price"].Width = 60;
            grd_ProductDetails.Columns["Qty"].Width = 60;
            grd_ProductDetails.Columns["Total"].Width = 75;
        }
        //
        // source code 
        // Code Snippet for disabling close button
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        public FrmPOS1Table(Invoicemaster invoicemaster)
        {
            InitializeComponent();
            SalesViewModal salesViewmodal = new SalesViewModal();
            invoiceid = invoicemaster.InvoicemasterID;
            LoadCategory(salesViewmodal);
            UpdateFont();
            //LoadTable(salesViewmodal);
            LoadInvoicedata(invoicemaster);

        }


        public void LoadInvoicedata(Invoicemaster invoicemaster)
        {





            lbl_custid.Text = invoicemaster.CustomerID.ToString();
            lbl_customer.Text = invoicemaster.Customer.CustomerName;
            lbl_tableID.Text = invoicemaster.TableID.ToString();
            lbl_table.Text = invoicemaster.Table.TableName;

            foreach (InvoiceDetail invdet in invoicemaster.InvoiceDetails)
            {
                if (invdet.IsDeleted == false)
                {
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



            if (Category != null)
            {
                if (Category.Count > 0)
                {

                    int categorycount = Category.Count;

                    float parentheight = float.Parse(this.pnl_category.Height.ToString());
                    float parentwidth = float.Parse(this.pnl_category.Width.ToString());
                    buttonheight = (int)Math.Ceiling(parentheight) / categorycount;
                    buttonwidth = (int)Math.Ceiling(parentwidth);
                }
            }

            foreach (Category catgry in Category)
            {
                ValueButton temp = new ValueButton();
                temp.Name = "button" + catgry.Id.ToString();
                temp.Text = catgry.CategoryName;
                temp._value = catgry.Id.ToString();
                temp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                temp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(187)))), ((int)(((byte)(166)))));
              
                temp.ForeColor = System.Drawing.Color.White;
                temp.Location = new System.Drawing.Point(0, 0);
             
                temp.Size = new System.Drawing.Size(103, 50);
                temp.TabIndex = 0;
             
               

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
             //   temp.Location = new System.Drawing.Point((temp.Width * buttonindex), (temp.Height * colcount));//please adjust location as per your need


                temp.Location = new System.Drawing.Point(0, (temp.Height * i));//please adjust location as per your need
                temp.Tag = i;

                temp.Click += new EventHandler(OnButtonClick);
                this.pnl_category.Controls.Add(temp);
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
            int categoryId = int.Parse(((ValueButton)sender)._value);
            ProductRepositories productrep = new ProductRepositories();

            List<ProductlistViewModal> Products = productrep.GetProductList(categoryId);
            LoadProducts(Products);
            //your code for the event.
        }
        private void OnProductButtonClick(object sender, EventArgs e)
        {
            int ProductID = int.Parse(((ValueButton)sender)._value);
            LoadSelectedProduct(ProductID);

        }



        public void LoadSelectedProduct(int ProductID)
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


      


        /// <summary>
        /// check whether the item is already avaiable in the grid and will send false if not there
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>

        public Boolean IsItemAlreadyAdded(int productid)
        {
            Boolean ispresent = false;
            foreach (DataGridViewRow row in grd_ProductDetails.Rows)
            {


                if (int.Parse(row.Cells["ID"].Value.ToString().Trim()) == productid)
                {

                    ispresent = true;
                    row.Cells["Qty"].Value = int.Parse(row.Cells["Qty"].Value.ToString()) + 1;
                    //    row.Cells["Total"].Value = int.Parse(row.Cells["Qty"].Value.ToString()) * (Decimal.Parse(row.Cells["Price"].Value.ToString()) - Decimal.Parse(row.Cells["Discount"].Value.ToString()));
                }

            }

            return ispresent;

        }


        /// <summary>
        /// add the decimal point to the typing
        /// </summary>
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

            int allowedproduct = 2;


            if (Productlist != null)
            {
                if (Productlist.Count > 0)
                {

                    int tablecount = Productlist.Count;

                    float parentheight = float.Parse(parent.Height.ToString());
                    float parentwidth = float.Parse(parent.Width.ToString());
                    buttonwidth = (int)Math.Ceiling(parentwidth) / allowedproduct;

                    buttonheight = buttonwidth;
                }
            }

            foreach (ProductlistViewModal product in Productlist)
            {
                ValueButton temp = new ValueButton();

                // 
                temp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(121)))), ((int)(((byte)(166)))));
                temp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                temp.ForeColor = System.Drawing.Color.White;
                temp.Location = new System.Drawing.Point(6, 271);

                temp.Size = new System.Drawing.Size(130, 81);
                temp.TabIndex = 12;
                temp.Text = "button24";
                temp.UseVisualStyleBackColor = false;

                temp.Name = "button" + product.ProductID.ToString();
                temp.Text = product.ProductName;
                temp._value = product.ProductID.ToString();
                // temp.AutoSize = true;
             
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


             //   temp.Location = new System.Drawing.Point((buttonwidth * buttonindex), (buttonheight * colcount));//please adjust location as per your need
                temp.Location = new System.Drawing.Point((temp.Width * buttonindex), (temp.Height * colcount));//please adjust location as per your need
                if (buttonindex % allowedproduct == 0 && buttonindex != 0)
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

        private void SalesForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (DataGridViewRow r in grd_ProductDetails.SelectedRows)
                {
                    if (!r.IsNewRow)
                    {
                        grd_ProductDetails.Rows.RemoveAt(r.Index);
                    }
                }
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int ProductID = int.Parse(((TextBox)sender).Text);
                LoadSelectedProduct(ProductID);
            }
        }

        Button Lastbuttonclicked;
        Color LastButtonActualControl;
        private void numericbuttonclicked_Click(object sender, EventArgs e)
        {


            LastButtonClicker(sender, e);


        }




        public void LastButtonClicker(object sender, EventArgs e)
        {
            Button button = (Button)sender;
          

            if (string.Equals(button.Text.Trim(), "Tables", StringComparison.CurrentCultureIgnoreCase)){ button.Text = "Tables";   }
            else if (string.Equals(button.Text.Trim(), "Qty", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "Qty"; }
            else if (string.Equals(button.Text.Trim(), "Disc", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "Disc"; }
            else if (string.Equals(button.Text.Trim(), "Price", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "Price"; }
            else if (string.Equals(button.Text.Trim(), "Add item", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "Add item"; }
            else if (string.Equals(button.Text.Trim(), "Payment method", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "Payment method"; }
            else if (string.Equals(button.Text.Trim(), "Buzzer", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "Buzzer"; }
            else if (string.Equals(button.Text.Trim(), "Table Bill", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "Table Bill"; }
            else if (string.Equals(button.Text.Trim(), "KOT", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "KOT"; }
            else if (string.Equals(button.Text.Trim(), "Action", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "Action"; }
            else if (string.Equals(button.Text.Trim(), "Clear", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "Clear"; }
            else if (string.Equals(button.Text.Trim(), "Print", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "Print"; }
            else if (string.Equals(button.Text.Trim(), "Hold", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "Hold"; }
            else if (string.Equals(button.Text.Trim(), "Customer", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "Customer"; }
            else if (string.Equals(button.Text.Trim(), "<", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "<"; }
            else if (string.Equals(button.Text.Trim(), "Todays Special", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "Todays Special"; }

            KeyPressed(button);

        }

        public void KeyPressed(Button btn)
        {

            List<string> ExceptionList = new List<string> { "Add item", "Qty", "Price", "Cash", "Customer" };
            


           
          
             if (btn.Text.Trim() == "<")
            {
                BackSpace();
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
                if (ValidateforTableBill())
                {
                    AddInvoice("Table");
                    clearGridView();
                }

            }
            else if (btn.Text.Trim() == "Action")
            {
                
                ShowAction();
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

            else if (btn.Text.Trim() == "Payment Term")
            {

                clearGridView();


            }
            else
            {
                if (!ExceptionList.Contains(btn.Text.Trim()))
                {
                    txt_producrtcode.Text = txt_producrtcode.Text + btn.Text.Trim();
                   
                }
                else
                {
                    try
                    {
                        Lastbuttonclicked.BackColor = LastButtonActualControl;
                    }
                    catch (Exception)
                    {

                       
                    }
                    txt_producrtcode.Text = "";
                    Lastbuttonclicked = btn;
                    LastButtonActualControl = btn.BackColor;
                    btn.BackColor = Color.Yellow;

                }
                if(Lastbuttonclicked != null) {
                    CheckLastbutton(Lastbuttonclicked);
                }
            
            }

        }




        public void CheckLastbutton( Button lastbutton)
        {
            if (lastbutton.Text.Trim() == "Add item")
            {
                try
                {
                    //Additem();
                    SearchItem();
                }
                catch (Exception)
                {

                   
                }
            }
           else  if (lastbutton.Text.Trim() == "Qty")
            {
                try
                {
                    IncreaseItemQty();
                }
                catch (Exception)
                {


                }
            }
            else if (lastbutton.Text.Trim() == "Price" || lastbutton.Text.Trim() == "Cash")
                {
                    try
                    {
                        AddCash();
                }
                catch (Exception)
                {


                }
            }
            else if (lastbutton.Text.Trim() == "Customer")
                    {
                try
                {
                    FrmAddCustomer cstmr = new FrmAddCustomer();
                    cstmr.ShowDialog();
                   
                }
                catch (Exception)
                {


                }

            }
        }



        /// <summary>
        /// Add the selected Item
        /// </summary>
        public void Additem()
        {
            int ProductID = int.Parse((txt_producrtcode.Text));
            LoadSelectedProduct(ProductID);
        }

        /// <summary>
        /// Removes the last typed in Product
        /// </summary>
        public void BackSpace()
        {
            txt_producrtcode.Text = Extensions.MyExtensions.TrimLastCharacter(txt_producrtcode.Text);

        }


        /// <summary>
        /// Select the supplier based on code applied
        /// </summary>
        public void SelectCustomer()
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


        /// <summary>
        /// Increase the qty of selected item in grid
        /// </summary>
        public void IncreaseItemQty()
        {

            foreach (DataGridViewRow row in grd_ProductDetails.SelectedRows)
            {
                row.Cells["Qty"].Value = int.Parse(txt_producrtcode.Text.ToString());

            }
            CalculateTotal();
        }


        /// <summary>
        /// Insert the cash received from customer
        /// </summary>
        public void AddCash()
        {

            try
            {
                txt_cash.Text = Decimal.Parse(txt_producrtcode.Text.Trim()).ToString(); ;
                fillchange();
            }
            catch (Exception)
            {

                MessageBox.Show("Wrong Cash Entered");
            }
        }



        /// <summary>
        /// select table
        /// </summary>
        /// <param name="btn"></param>
        public void SelectTable( Button btn)
        {
            FrmTables frm = new FrmTables();
            frm.ShowDialog();
            btn.Text = frm.Selectedtablename;
            lbl_tableID.Text = frm.SelectedTableID.ToString();
            frm.Dispose();
        }
        /// <summary>
        /// select payment method
        /// </summary>
        public void selectPaymentMode( Button btn)
        {
            FrmPaymentMethods frmpymntmethode = new FrmPaymentMethods();
            frmpymntmethode.ShowDialog();
            btn.Text = frmpymntmethode.SelectedPaymentMode;
            frmpymntmethode.Dispose();
            if (btn.Text== "") { btn.Text = "Payment Method"; }
            lbl_paymentMode.Text = btn.Text;
        }
        /// <summary>
        /// select buzzers
        /// </summary>
        public void selectBuzzer()
        {
            FrmBuzzers frmbuzzers = new FrmBuzzers();
            frmbuzzers.ShowDialog();
        }
        public void fillchange()
        {

            if (calculateChange() > 0) { txt_change.Text = calculateChange().ToString(); } else { txt_change.Text = "0"; };

        }


        /// <summary>
        /// calculate the total value of the grid after discount and show it
        /// </summary>
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





        public Decimal calculateChange()
        {
            Decimal Total = Decimal.Parse(txt_total.Text);
            Decimal cash = Decimal.Parse(txt_cash.Text);
            Decimal change = cash - Total;
            return change;
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


        public void AddInvoice(String BillType)
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

            invoicemaster = invrrepo.InsertInvoiceLocal(invoicemaster);
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
            else if (txt_cash.Text.Trim() == "" || txt_cash.Text == null)
            {
                MessageBox.Show("Enter Cash");
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
            else if (Decimal.Parse(txt_total.Text.Trim()) > Decimal.Parse(txt_cash.Text.Trim()))
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


        public void ShowAction() { 
            FrmActions actions = new FrmActions();
            actions.ShowDialog();
        }


        public void clearGridView()
        {

            grd_ProductDetails.Rows.Clear();
            txt_total.Text = "0";
            txt_cash.Text = "0";
            txt_change.Text = "0";
            invoiceid = 0;
            
            
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

        private void FrmPOS1Table_Load(object sender, EventArgs e)
        {
            lbl_datettime.Text = DateTime.Now.ToString();
            lbl_userid.Text = Program.Username;
        }
        

        private void panel17_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Un Saved Transactions may loss ,Want  to Close? ", "Are You Sure", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
              
            }
           
        }

        private void lbl_table_Click(object sender, EventArgs e)
        {
                SelectTable((Button)sender);


            
        }

        private void btn_paymentmode_MouseClick(object sender, MouseEventArgs e)
        {
            selectPaymentMode((Button)sender);
        }

        private void btn_buzzer_MouseClick(object sender, MouseEventArgs e)
        {
            selectBuzzer();
        }

        private void btn_paymentmode_Click(object sender, EventArgs e)
        {

        }

        private void button52_Click(object sender, EventArgs e)
        {

        }



        public void SearchItem()
        {
            int categoryId = int.Parse((txt_producrtcode.Text));
            ProductRepositories productrep = new ProductRepositories();

            List<ProductlistViewModal> Products = productrep.GetMarchingProductlist(categoryId);
            LoadProducts(Products);
        }
    }
}
