﻿using App.Extensions;
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
    public partial class FrmMainForm : Form
    {
        public FrmMainForm()
        {
            InitializeComponent();
            if (LocalDBExtension.IsLocalDBInstalled()) { } else { /*MessageBox.Show("LocalDB Not Installed"); */}
            lbl_welcome.Text = "Welcome " + Program.Username.Trim();

            lbl_Location.Text = Program.StoreName.Trim();
            this.Text = Program.Shiftname;

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

        private bool IsAlreadyOpen(Type formType)

        {

            bool isOpen = false;



            foreach (Form f in Application.OpenForms)

            {

                if (f.GetType() == formType)

                {

                    f.BringToFront();

                    f.WindowState = FormWindowState.Normal;

                    isOpen = true;

                }

            }


            return isOpen;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            
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

     
        private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FrmAddCustomer cstmr = new FrmAddCustomer();
            cstmr.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmTables frm = new FrmTables();
            frm.Show();
        }

       
        private void btn_pos_Click(object sender, EventArgs e)
        {

            FrmPOS1Table frmpos = null;
            bool isFormOpen = IsAlreadyOpen(typeof(FrmPOS1Table));
            if (isFormOpen == false)
            {
                frmpos = new FrmPOS1Table();
             //   frmpos.MdiParent = this;
              //  frmpos.StartPosition = FormStartPosition.CenterScreen;
                frmpos.Show();
            }






            //FrmPOS1Table frmpos = new FrmPOS1Table();
            //frmpos.ShowDialog();
        }

        private void btn_masters_Click(object sender, EventArgs e)
        {
            Masters.MasterForm frm = new Masters.MasterForm();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Setting.oodoSetting odoosetting = new Setting.oodoSetting(int.Parse(Program.LocationID.ToString()));
            odoosetting.StartPosition = FormStartPosition.CenterScreen;
            odoosetting.Show();
        }

        private void btn_misreport_Click(object sender, EventArgs e)
        {
            FrmDailyReports reports = new FrmDailyReports();
            reports.StartPosition = FormStartPosition.CenterScreen;
            reports.ShowDialog();
        }

        private void btn_action_Click(object sender, EventArgs e)
        {
            FrmActions actions = new FrmActions();
            actions.StartPosition = FormStartPosition.CenterScreen;
            actions.ShowDialog();

        }
    }
}
