﻿using App.Extensions;
using App.Model;
using App.Repository;
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
        public SalesForm()
        {
            InitializeComponent();
            SalesViewModal salesViewmodal = new SalesViewModal();
            LoadCategory(salesViewmodal);
            LoadTable(salesViewmodal);
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
                     
                    float parentheight = float.Parse(this.grp_Category.Height.ToString());
                    float parentwidth = float.Parse(this.grp_Category.Width.ToString());
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
                this.grp_Category. Controls.Add(temp);
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
        
                row.Cells["Total"].Value = int.Parse(row.Cells["Qty"].Value.ToString()) * (Decimal.Parse(row.Cells["Price"].Value.ToString()) - Decimal.Parse(row.Cells["Discount"].Value.ToString()));

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
            else
            {
                txt_producrtcode.Text = txt_producrtcode.Text.Trim() + btn.Text.Trim();
            }

        }
    }
}