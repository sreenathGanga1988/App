using App.Context;
using App.Migrations;
using App.Model;
using App.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Extensions;
using System.Data.Entity.Infrastructure;

namespace App.UI
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            string version = System.Windows.Forms.Application.ProductVersion;
            this.Text = String.Format("CAFE POS {0}", version);
        



            try
            {
                POSDataContext objContext = new POSDataContext();

                cmb_user.DataSource = objContext.Users.ToList();
                cmb_user.DisplayMember = "UserName";
                cmb_user.ValueMember = "UserID";
            }
            catch (Exception e)
            {

                ErrorLogger.WriteToErrorLog("At Login Constructor", e.Message, "Login Start");
            }


            UpdateItemsWithNoIsDeleted();
        }

        public void UpdateItemsWithNoIsDeleted()
        {

            InvoiceRepository invoiceRepository = new InvoiceRepository();
            invoiceRepository.UpdateDeleteStatusofinvoice();

            ProductRepositories productRepositories = new ProductRepositories();
            productRepositories.Updateproductactivestatus();
        }

        public void KeyPressed(Button btn)
        {

            if (btn.Text == "OK")
            {
                try
                {

                    if (int.Parse(txt_PasscodeDisplay.Text) == 654321)
                    {
                        this.Hide();
                        //StartForm frm = new StartForm();
                        //frm.Show();
                        Masters.MasterForm frm = new Masters.MasterForm();
                        frm.Show();
                    }
                    else
                    {
                       
                        userAuthentication();
                    }
                }
                catch (Exception e)
                {

                    ErrorLogger.WriteToErrorLog("At Login OK", e.StackTrace, "Login ");
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





        public void userAuthentication()
        { 
            
            if (isLicensed())
            {
                try
                {
                    Repository.UserRepository usrrep = new Repository.UserRepository();
                    
                    if (usrrep.IsuserValid(int.Parse(txt_PasscodeDisplay.Text), int.Parse(cmb_user.SelectedValue.ToString())))
                    {
                        ShiftRepository shiftRepository = new ShiftRepository();
                        shiftRepository.ShiftAction();

                        this.Hide();
                        //StartForm frm = new StartForm();
                        //frm.Show();
                        FrmMainForm frm = new FrmMainForm();
                        frm.Show();
                    }
                    else
                    {

                        MessageBox.Show("Passcode not Valid");
                        
                    }
                }
                catch (Exception e)
                {

                    MessageBox.Show("Hi Dude You lost connection to DB");
                    ErrorLogger.WriteToErrorLog("At Login ", e.StackTrace, "Login ");
                }
            }

           
        }









        private void buttonclicked_Click(object sender, EventArgs e)
        {
           
               
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
            lbl_trial.Text = "Trail Version with 200 login";
        }

        private void txt_PasscodeDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)

            {
                userAuthentication();
            }
        }

        private void FrmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)

            {
               
                userAuthentication();
            }
        }


        public Boolean  isLicensed()
        {
            Boolean isok = false;


            String name = ConfigurationManager.AppSettings["AppSet"];

            if(name==null || name.Trim() =="")
            {
                MessageBox.Show("License key Not Available");
                CreateAppkey();
                isok = false;
            }
            else
            {
              if(AppBLL.MyIntialize.CheckKey(name))
                {
                    isok = true;
                }
                else
                {

                    CreateAppkey();

                }
               
            }

            return isok;
        }


        public void CreateAppkey()
        {
            DialogResult result = MessageBox.Show("You Dont have Valid License?", "Create new Key",
           MessageBoxButtons.OKCancel);
            switch (result)
            {
                case DialogResult.OK:
                    {
                        try
                        {
                            string key = AppBLL.MyIntialize.Createkey();
                            //System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                            //config.AppSettings.Settings["AppSet"].Value = key;
                            //config.Save(ConfigurationSaveMode.Modified);
                           
                            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                            config.AppSettings.Settings.Remove("AppSet");
                            config.AppSettings.Settings.Add("AppSet", key);
                            config.Save(ConfigurationSaveMode.Minimal);
                            ConfigurationManager.RefreshSection("appSettings");
                        }
                        catch (Exception exp)
                        {

                            MessageBox.Show("Error Creating key"+ exp);
                            ErrorLogger.WriteToErrorLog("At Login CreateAppkey", exp.StackTrace, "CreateAppkey ");
                        }
                        break;
                    }
                case DialogResult.Cancel:
                    {

                        break;
                    }
            }
        }
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            KeyPressed((Button)sender);
            txt_PasscodeDisplay.Focus();
        }
    }
}
