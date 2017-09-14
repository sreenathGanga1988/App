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
    public partial class MasterForm : Form
    {
        public MasterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UI.Masters.FrmCategory frm = new Masters.FrmCategory();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UI.Masters.PrinterForm frm = new Masters.PrinterForm();
            frm.Show();
        }
    }
}
