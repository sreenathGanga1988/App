﻿using App.Context;
using App.Migrations;
using App.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.UI
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<POSDataContext, Configuration>());
            Company objCompany = new Company();
            objCompany.CompanyId = DateTime.Now.ToString();
            objCompany.Name = "Sree";

           

            POSDataContext objContext = new POSDataContext();
            //objContext.Companies.Add(objCompany);
            objContext.SaveChanges();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        public void KeyPressed(Button btn)
        {

            if (btn.Text == "OK")
            {

                try
                {
                    Repository.UserRepository usrrep = new Repository.UserRepository();

                    if (usrrep.IsuserValid(int.Parse(txt_PasscodeDisplay.Text)))
                    {
                        this.Hide();
                        StartForm frm = new StartForm();
                        frm.Show();

                    }
                    else
                    {

                        MessageBox.Show("Passcode not Valid");
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Hi Dude You lost connection to DB");
                }

            }
            else if (btn.Text == "Back")
            {
                txt_PasscodeDisplay.Text = Extensions.MyExtensions.TrimLastCharacter(txt_PasscodeDisplay.Text);

            }
            else
            {
                txt_PasscodeDisplay.Text = txt_PasscodeDisplay.Text.Trim() + btn.Text.Trim();
            }

        }

        private void buttonclicked_Click(object sender, EventArgs e)
        {
            KeyPressed((Button)sender);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            KeyPressed((Button)sender);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            lbl_datetimenow.Text = DateTime.Now.ToString();
            lbl_dayname.Text = DateTime.Now.Date.DayOfWeek.ToString();
        }
    }
}
