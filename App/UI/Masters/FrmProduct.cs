using App.Model;
using App.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.UI.Masters
{
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
            fillProductingrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getProductsfromOdoo();
            fillProductingrid(); 
        }

        public void getProductsfromOdoo()
        {
            OdooUpdator odooUpdator = new OdooUpdator();
            odooUpdator.GetCategoryfromODOO();
            odooUpdator.GetProductfromODOO();

            MessageBox.Show("Sucessfully Updated From Odoo");
           
        }



        public void fillProductingrid()
        {
            ProductRepositories productRepositories = new ProductRepositories();

            List<Model.Product> products = productRepositories.GetProductList().ToList();
            fillProduct(products);
        }

        public void fillProduct(List<Model.Product> products )
        {
            dgv.Rows.Clear();

            foreach (Product prdct in products)
            {
                



                var index = dgv.Rows.Add();
                dgv.Rows[index].Cells["ID"].Value = prdct.Id.ToString();
                dgv.Rows[index].Cells["Code"].Value = prdct.Color.ToString();
                dgv.Rows[index].Cells["ProductName"].Value = prdct.ProductName.ToString();
                dgv.Rows[index].Cells["Category"].Value = prdct.Category.CategoryName.ToString();
                dgv.Rows[index].Cells["SalePrice"].Value =prdct.MinimumSPForLocation.ToString();
                dgv.Rows[index].Cells["SalePrice"].Value = prdct.MinimumSPForLocation.ToString();
                dgv.Rows[index].Cells["TodaySpecial"].Value = prdct.IsTodaySpecial;
                dgv.Rows[index].Cells["Taxamount"].Value = prdct.Taxamount;
                dgv.Rows[index].Cells["IsAvailable"].Value = prdct.IsAvailable;
                dgv.Rows[index].Cells["IsActive"].Value = prdct.Isactive;
                
            }



        }



        public void UpdateTodaySpecial()
        {
            ProductRepositories prodrepo = new ProductRepositories();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                int id = int.Parse(row.Cells["ID"].Value.ToString());

                Boolean Status = Boolean.Parse(row.Cells["TodaySpecial"].Value.ToString());
                prodrepo.UpdateTodaySpoecial(id, Status);
               
            }
            MessageBox.Show("Updated");
        }

        public void UpdateAvailabilty()
        {
            ProductRepositories prodrepo = new ProductRepositories();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                int id = int.Parse(row.Cells["ID"].Value.ToString());

                Boolean Status = Boolean.Parse(row.Cells["IsAvailable"].Value.ToString());
                prodrepo.UpdateAvailailty(id, Status);

            }
            MessageBox.Show("Updated");
        }


        public void SelectAll(Boolean Checked)
       {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells["TodaySpecial"].Value = Checked;

            }

       }

        public void SelectAllavailable(Boolean Checked)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells["IsAvailable"].Value = Checked;

            }

        }

        public void SearchProduct()
        {
            string texttodearch = btn_searcharea.Text.Trim();
            ProductRepositories custrepo = new ProductRepositories();
            List<Product> productlist = custrepo.GetProductSearch(texttodearch, Program.LocationID);
            fillProduct(productlist);
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchProduct();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateTodaySpecial();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SelectAll(checkBox1.Checked);
        }

        private void dgv_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv.IsCurrentCellDirty)
            {
                dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
          //  SelectAllavailable(checkBox2.Checked);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //UpdateAvailabilty();
            SalesForm salesForm = new SalesForm("Availablility");
            salesForm.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SalesForm salesForm = new SalesForm("Active");
            salesForm.ShowDialog();
        }
    }
}
