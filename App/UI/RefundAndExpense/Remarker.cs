using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.UI.RefundAndExpense
{
    public partial class Remarker : Form
    {
        public String EnteredRemark { get; set; }
        public Remarker()
        {
            InitializeComponent();
        }
        public Remarker(String message)
        {
      
            InitializeComponent();
            lbl_header.Text = message;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            EnteredRemark = rht_remark.Text;
            this.Close();
        }
    }
}
