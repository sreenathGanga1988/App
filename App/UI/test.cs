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
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void test_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'limsDBDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.limsDBDataSet.Products);

        }
    }
}
