﻿using App.Repository;
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

      

        private void btn_category_Click(object sender, EventArgs e)
        {
            UI.Masters.FrmCategory frm = new Masters.FrmCategory();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void btn_product_Click(object sender, EventArgs e)
        {
            UI.Masters.FrmProduct frm = new Masters.FrmProduct();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void btn_customer_Click(object sender, EventArgs e)
        {

        }

        private void btn_printer_Click(object sender, EventArgs e)
        {
            UI.Masters.PrinterForm frm = new Masters.PrinterForm();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OdooUpdator odooUpdator = new OdooUpdator();
            odooUpdator.Updatemaster();
            MessageBox.Show("Updated");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Setting.oodoSetting odoosetting = new Setting.oodoSetting(int.Parse(Program.LocationID.ToString()));
            odoosetting.StartPosition = FormStartPosition.CenterScreen;
            odoosetting.Show();
        }
    }
}
