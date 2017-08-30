using App.Extensions;
using Npgsql;
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
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();

            lbl_welcome.Text = "Welcome " + Program.Username.Trim();

            lbl_Location.Text = Program.StoreName.Trim();

            MdiClient ctlMDI;
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    ctlMDI = (MdiClient)ctl;

                    // Set the BackColor of the MdiClient control.
                    ctlMDI.BackColor = Color.White;
                }
                catch (InvalidCastException exc)
                {
                    // Catch and ignore the error if casting failed.
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SalesForm frm = new SalesForm();
          
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            test tst = new test();
            tst.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Setting.oodoSetting odoosetting = new Setting.oodoSetting(int.Parse(Program.LocationID.ToString()));
            odoosetting.Show();





        }

        private void button3_Click(object sender, EventArgs e)
        {
            Repository.OdooUpdator odoupd = new Repository.OdooUpdator();
            odoupd.uploadInvoiceMaster();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PrintReceipt prnt = new PrintReceipt();
            prnt.printreport();
        }
    }
}
