using App.Extensions;
using App.Model;
using App.Repository;
using App.UI.POS;
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
        public int selectedCustomerID = 0;
        public int selectedBuzzerID = 0;
        public int selectedTableID = 0;
        public int selectedPaymentID = 0;

        public String selectedCustomerName = "";
        public String selectedBuzzerName = "";
        public String selectedTableName = "";
        public String selectedPaymentName = "";
        SalesViewModal salesViewmodal = null;
        public FrmPOS1Table()
        {
            InitializeComponent();
            salesViewmodal = new SalesViewModal();
            LoadCategory(salesViewmodal);
            UpdateFont();
            Intializeselecteditems();

            //this.TopMost = true;
           this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;

            this.WindowState = FormWindowState.Maximized;
            //this.Location = new Point(0, 0);
          
            //Screen currentScreen = Screen.FromHandle(this.Handle);
            //this.Size = new System.Drawing.Size(currentScreen.Bounds.Width, currentScreen.Bounds.Height);
            //this.StartPosition = FormStartPosition.CenterScreen;
        }



      


        public void Intializeselecteditems()
        {
         selectedCustomerID = 0;
         selectedBuzzerID = 0;
         selectedTableID = 0;
         selectedPaymentID = 0;

         selectedCustomerName = "";
         selectedBuzzerName = "";
         selectedTableName = "";
         selectedPaymentName = "";


            lbl_customer.Text = "New";
           btn_Tables.Text = "Tables";
           Btn_buzzer.Text = "Buzzer";
            btn_paymentMethod.Text = "Payment Method";

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
            lbl_invoicenum.Text = invoicemaster.InvoiceNum;
            //LoadTable(salesViewmodal);
            LoadInvoicedata(invoicemaster);

        }


        public void LoadInvoicedata(Invoicemaster invoicemaster)
        {





            selectedCustomerID = invoicemaster.CustomerID;
            lbl_customer.Text = invoicemaster.Customer.CustomerName;
           

            selectedTableID = int.Parse(invoicemaster.TableID.ToString());
            selectedTableName = invoicemaster.Table.TableName;
            btn_Tables.Text = selectedTableName;

            selectedBuzzerID = int.Parse(invoicemaster.BuzzerID.ToString());
            selectedBuzzerName = invoicemaster.BuzzerName;
            Btn_buzzer.Text = selectedBuzzerName;

            selectedPaymentID = int.Parse(invoicemaster.PayMentModeId.ToString());
            selectedPaymentName = invoicemaster.PaymentMode;
            btn_paymentMethod.Text = selectedPaymentName;

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
                    grd_ProductDetails.Rows[index].Cells["Notes"].Value = invdet.Notes.ToString();


                    
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
            int colcount = 0;
            
         
            int buttonindex = 0;
            List<Category> Category = salesViewmodal.CategoryList;
            int allowedproduct = 1;


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


                temp.Location = new System.Drawing.Point((temp.Width * buttonindex)+15, (temp.Height * colcount)+10);//please adjust location as per your need
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

                temp.Click += new EventHandler(OnButtonClick);
                this.pnl_category.Controls.Add(temp);
                i++;
            }

            this.pnl_category.AutoScroll = true;

        }


      

        private void OnTableButtonClick(object sender, EventArgs e)
        {
            btn_tablebill.Text = ((ValueButton)sender).Text;
            selectedTableID =int.Parse ( ((ValueButton)sender)._value.ToString());
            selectedTableName= ((ValueButton)sender).Text;

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
                    grd_ProductDetails.Rows[index].Cells["Notes"].Value ="";
                    
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
            else if (string.Equals(button.Text.Trim(), "Payment Method", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "Payment Method"; }
            else if (string.Equals(button.Text.Trim(), "Buzzer", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "Buzzer"; }
            else if (string.Equals(button.Text.Trim(), "Table Bill", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "Table Bill"; }
            else if (string.Equals(button.Text.Trim(), "KOT", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "KOT"; }
            else if (string.Equals(button.Text.Trim(), "Order", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "Order"; }
            else if (string.Equals(button.Text.Trim(), "Clear", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "Clear"; }
            else if (string.Equals(button.Text.Trim(), "Print", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "Print"; }
            else if (string.Equals(button.Text.Trim(), "Hold", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "Hold"; }
            else if (string.Equals(button.Text.Trim(), "Customer", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "Customer"; }
            else if (string.Equals(button.Text.Trim(), "<", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "<"; }
            else if (string.Equals(button.Text.Trim(), "Todays Special", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "Todays Special"; }
            else if (string.Equals(button.Text.Trim(), "Notes", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "Notes"; }
            else if (string.Equals(button.Text.Trim(), "Check Out", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "Check Out"; }
            else if (string.Equals(button.Text.Trim(), "Price Change", StringComparison.CurrentCultureIgnoreCase)) { button.Text = "Price Change"; }

            KeyPressed(button);

        }

        public void KeyPressed(Button btn)
        {

            List<string> ExceptionList = new List<string> { "Add item", "Qty", "Price", "Cash", "Customer", "Todays Specials", "Buzzer", "Tables", "Payment Method", "Reset", "Check Out", "Clear", "Order", "Hold", "Table Bill", "KOT", "Price Change" };

 




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
            else if (btn.Text.Trim() == "Hold")
            {
                if (ValidateforTableBill())
                {
                    AddInvoice("Hold");
                    clearGridView();
                }

            }
            else if (btn.Text.Trim() == "Order")
            {
                
                ShowAction();
            }

           
            else if (btn.Text.Trim() == "Clear")
            {
                txt_producrtcode.Text = "";

            }
            else if (btn.Text.Trim() == "Check Out")
            {
                if (ValidateforCheckOut())
                {
                    AddInvoice("");
                    clearGridView();
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

            else if (btn.Text.Trim() == "Payment Method" || btn.Name == "btn_paymentMethod")
            {

                selectPaymentMode(btn);


            }
            else if (btn.Text.Trim() == "Customer")
            {

                SelectCustomerOnclick(btn);
               

            }
            else if (btn.Text.Trim() == "")
            {

                SelectTable(btn);
           

            }
            else if (btn.Text.Trim() == "Buzzer"|| btn.Name== "Btn_buzzer")
            {
                



                selectBuzzer(btn);

               
            }
            else if (btn.Text.Trim() == "Tables" || btn.Name == "btn_Tables")
            {




                SelectTable(btn);


            }
            
            else if (btn.Text.Trim() == "Todays Special")
            {

                SelectTodaysSpecial();


            }
            else if (btn.Text.Trim() == "Price Change")
            {



                Pricechange();
            }
            else if (btn.Text.Trim() == "Notes")
            {



                EnterNotes();
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
            //else if (lastbutton.Text.Trim() == "Customer")
            //        {
            //    SelectCustomerOnclick(lastbutton);
            //}
        }

        public void SelectCustomerOnclick(Button lastbutton)
        {
            try
            {
                FrmAddCustomer cstmr = new FrmAddCustomer();
                cstmr.ShowDialog();

                selectedCustomerID = int.Parse (cstmr.SelectedCustomerID);
                selectedCustomerName = cstmr.SelectedCustomerName;
                lbl_customer.Text = cstmr.SelectedCustomerName;
            }
            catch (Exception)
            {


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
            int CustomerID = int.Parse((txt_producrtcode.Text));
            selectCustomerByID(CustomerID);
        }
        public void selectCustomerByID(int id)
        {
            try
            {
               
                CustomerRepositiry custrepo = new CustomerRepositiry();

                Customer cust = custrepo.GetCustomer(id);


                lbl_customer.Text = cust.CustomerName;
                selectedCustomerID = cust.CustomerID;
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

                if (txt_producrtcode.Text.Trim() == "")
                {
                   
                }
                else
                {
                    MessageBox.Show("Wrong Cash Entered");
                }
               
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
            if (btn.Text == "") { btn.Text = "Tables"; }
            selectedTableID = frm.SelectedTableID;
            selectedTableName = btn.Text;
            frm.Dispose();
        }
        /// <summary>
        /// select Payment Method
        /// </summary>
        public void selectPaymentMode( Button btn)
        {
            FrmPaymentMethods frmpymntmethode = new FrmPaymentMethods();
            frmpymntmethode.ShowDialog();
            btn.Text = frmpymntmethode.SelectedPaymentMode;
            frmpymntmethode.Dispose();
            if (btn.Text== "") { btn.Text = "Payment Method"; }
            selectedPaymentName = btn.Text;
        }
        /// <summary>
        /// select Buzzer
        /// </summary>
        public void selectBuzzer(Button btn)
        {
            FrmBuzzers frmBuzzer = new FrmBuzzers();
            frmBuzzer.ShowDialog();
            btn.Text = frmBuzzer.SelectedBuzzername;
            if (btn.Text == "") { btn.Text = "Buzzer"; }
           selectedBuzzerName = btn.Text;
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





        public void SelectTodaysSpecial()
        {
            ProductRepositories productrep = new ProductRepositories();

            List<ProductlistViewModal> Products = productrep.GetTodaySpecial(0);
            LoadProducts(Products);
        }

        public void Pricechange()
        {
            
            ValueInPut input = new ValueInPut(DateTime.Now,"PriceChange");
            input.ShowDialog();
            Decimal Newprice = input.Selectedvalue;

            if (Newprice != 0)
            {
                foreach (DataGridViewRow r in grd_ProductDetails.SelectedRows)
                {
                    if (!r.IsNewRow)
                    {
                        grd_ProductDetails.Rows[r.Index].Cells["Price"].Value= Newprice;
                    }
                }

                CalculateTotal();
            }
           
        }


        public void EnterNotes()
        {

        

          
                foreach (DataGridViewRow r in grd_ProductDetails.SelectedRows)
                {
                    if (!r.IsNewRow)
                    {

                        FrmNotes input = new FrmNotes(grd_ProductDetails.Rows[r.Index].Cells["Notes"].Value.ToString());
                        input.ShowDialog();
                        string note = input.Selectednote;

                      grd_ProductDetails.Rows[r.Index].Cells["Notes"].Value = note;
                    }
                }

                CalculateTotal();
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
           
          
            invoicemaster.TotalPaid = Decimal.Parse(txt_total.Text);
            invoicemaster.TotalBill = Decimal.Parse(txt_total.Text);
            invoicemaster.StoreName = Program.StoreName;
            invoicemaster.StoreAddress = Program.StoreAddress;
            invoicemaster.Cashier = Program.Username;
         
            invoicemaster.IsUploaded = false;

            invoicemaster.BuzzerID = selectedBuzzerID;
            invoicemaster.CustomerID = selectedCustomerID;
            invoicemaster.TableID = int.Parse(selectedTableID.ToString());
          
            invoicemaster.PayMentModeId = selectedPaymentID;

            invoicemaster.CustomerName = selectedCustomerName;
            invoicemaster.PaymentMode = selectedPaymentName;
            invoicemaster.TableName = selectedTableName;
            invoicemaster.BuzzerName = selectedBuzzerName;

            invoicemaster = AdjustAutoSelection(invoicemaster);

            if (BillType == "Table" || BillType=="Hold")
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
                invoicedetail.Notes = row.Cells["Notes"].Value.ToString().Trim();
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
            Intializeselecteditems();
            try
            {
                PrintReceipt prnt = new PrintReceipt();

                if (BillType == "kot")
                {
                    prnt = new PrintReceipt();
                    prnt.printKOTreport(invoicemaster);

                    MessageBox.Show("KOT #:" + invoicemaster.InvoiceNum);
                }
                else if (BillType == "Hold")
                {
                   

                    MessageBox.Show("Hold #:" + invoicemaster.InvoiceNum);
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
        public Invoicemaster AdjustAutoSelection(Invoicemaster invoicemaster)
        {
           
            invoicemaster.CustomerID = selectedCustomerID;
            invoicemaster.TableID = int.Parse(selectedTableID.ToString());
            invoicemaster.PaymentMode = selectedPaymentName;
            if (invoicemaster.BuzzerID == 0)
            {
               
                invoicemaster.BuzzerName = "Buzzer";
                invoicemaster.BuzzerID = 15;

            }
            if (invoicemaster.CustomerID ==0)
            {
                invoicemaster.CustomerName = "New";
                invoicemaster.CustomerID = 8;
            }
            if (invoicemaster.TableID == 0)
            {
                invoicemaster.TableName = "Take Away";
                invoicemaster.TableID = 1;

            }
            if (invoicemaster.PayMentModeId == 0)
            {
                invoicemaster.PaymentMode = "Cash";
                invoicemaster.PayMentModeId = 1;
            }

            return invoicemaster;
        }

        public Boolean ValidateforKot()
        {
            Boolean isvalidforKot = false;

            if (selectedCustomerID.ToString().Trim() == "")
            {
                MessageBox.Show("Enter Customer ID");
            }
            else if (selectedTableID.ToString().Trim() == "")
            {

                MessageBox.Show("Select A Table");
            }
            else if (grd_ProductDetails.Rows.Count <= 0)
            {

                MessageBox.Show("No Item Selected");
            }

            else if (!MyExtensions.CheckifNumeric(selectedCustomerID.ToString().Trim()))
            {

                MessageBox.Show("Enter Valid Customer ID");
            }
            else if (!MyExtensions.CheckifNumeric(selectedTableID.ToString().Trim()))
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
           
            this.Close();
            Showpending();
        }

        public void closeaction()
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
        public void clearGridView()
        {

            grd_ProductDetails.Rows.Clear();
            txt_total.Text = "0";
            txt_cash.Text = "0";
            txt_change.Text = "0";
            
            invoiceid = 0;

            Intializeselecteditems();
        }

      public void Showpending()
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
           


            String Headertext = "LIMSPOS    " + Program.Username + "  " + DateTime.Now.ToString("dd/MM/yyyy");
            this.Text = Headertext;
        }
        

        private void panel17_Click(object sender, EventArgs e)
        {
            closeaction();
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
            selectBuzzer((Button)sender);
        }

       



        public void SearchItem()
        {
            int categoryId = int.Parse((txt_producrtcode.Text));
            ProductRepositories productrep = new ProductRepositories();

            List<ProductlistViewModal> Products = productrep.GetMarchingProductlist(categoryId);
            LoadProducts(Products);
        }



       

        private void panel10_MouseClick(object sender, MouseEventArgs e)
        {
            closeaction();
        }

        private void button53_Click(object sender, EventArgs e)
        {
            IpPrint print = new IpPrint();
            print.PrinttoIP("192.168.1.103", ".\\tmpPrint.print");
            MessageBox.Show("Sucess");
        }
    }
}
