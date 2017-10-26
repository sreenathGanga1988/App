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

namespace App.UI.Masters
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getProductsfromOdoo()
        }

        public void getProductsfromOdoo()
        {
            OdooUpdator odooUpdator = new OdooUpdator();
            odooUpdator.GetCategoryfromODOO();
            odooUpdator.GetProductfromODOO();

            MessageBox.Show("Sucessfully Updated From Odoo");
        }



        public void fillProduct()
        {
            ProductRepositories productRepositories = new ProductRepositories();

            List<Model.Product> products = productRepositories.GetProductList().ToList();
            




        }




    }
}
