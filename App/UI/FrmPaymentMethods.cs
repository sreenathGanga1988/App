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
    public partial class FrmPaymentMethods : Form
    {
        public FrmPaymentMethods()
        {
            InitializeComponent();
        }
        public String SelectedPaymentMode { get; set; }
       
        private void button9_Click(object sender, EventArgs e)
        {
            markSelected(((Button)sender));
        }


        public void markSelected(Button btn)
        {
            SelectedPaymentMode = btn.Text;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            markSelected(((Button)sender));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            markSelected(((Button)sender));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            markSelected(((Button)sender));
        }
    }
}
