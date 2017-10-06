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
            //SalesForm frm = new SalesForm();

            FrmPOS1Table frm = new FrmPOS1Table();

            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UI.Masters.MasterForm frm = new Masters.MasterForm();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Setting.oodoSetting odoosetting = new Setting.oodoSetting(int.Parse(Program.LocationID.ToString()));
            odoosetting.Show();


           

        }

        private void button3_Click(object sender, EventArgs e)
        {

            EndOfDay frm = new EndOfDay();

            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();

           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmPOS1Table frm = new FrmPOS1Table();

            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();


        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FrmAddCustomer cstmr = new FrmAddCustomer();
            cstmr.Show();
        }
    }
}
