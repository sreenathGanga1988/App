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
        int catid = 0;
        public SalesForm()
        {
            InitializeComponent();
            SalesViewModal salesViewmodal = new SalesViewModal();
            LoadCategory(salesViewmodal);
           
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


                temp.Location = new System.Drawing.Point((temp.Width * buttonindex) + 15, (temp.Height * colcount) + 10);//please adjust location as per your need
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


        private void OnButtonClick(object sender, EventArgs e)
        {
            int categoryId = int.Parse(((ValueButton)sender)._value);
            fILLpRODUCTS(categoryId);
            catid = categoryId;
            //your code for the event.
        }

        public void fILLpRODUCTS(int categoryId)
        {
           
            ProductRepositories productrep = new ProductRepositories();

            List<ProductlistViewModal> Products = productrep.GetProductList(categoryId);
            LoadProducts(Products);
        }

        private void OnProductButtonClick(object sender, EventArgs e)
        {
            int ProductID = int.Parse(((ValueButton)sender)._value);

            

            ProductRepositories productRepositories = new ProductRepositories();

            Product product = productRepositories.GetProduct(ProductID);

            if (product.IsAvailable==true)
            {
                productRepositories.UpdateAvailailty(ProductID,  false);
                MessageBox.Show(product.ProductName+  " Marker Unavailable");
            }
            else
            {
                productRepositories.UpdateAvailailty(ProductID, true);
                MessageBox.Show(product.ProductName + " Marker Available");

            }
            fILLpRODUCTS(catid);
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

            int allowedproduct = 3;


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
                    if (product.IsAvailable == false)
                    {
                        temp.BackColor = Color.Orange;
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




    }
}
