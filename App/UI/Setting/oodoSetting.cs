using App.Model;
using App.Repository;
using App.ApplicationSettingRepository;
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
using System.Drawing.Printing;

namespace App.UI.Setting
{
    public partial class oodoSetting : Form
    {
        public oodoSetting()
        {
            InitializeComponent();
        }
        public oodoSetting(int storid)
        {
            InitializeComponent();
            try
            {
                showOdoodetails();
                PopulateInstalledPrintersCombo();
                showPrinterDetails();
                ShowAppuserSetting();
            }
            catch (Exception)
            {

              
            }
        }


        public void showOdoodetails()
        {
           tbHost.Text = Program.MySettingViewModal.MyOoodoDetasils.Server;
            tbPort.Text = Program.MySettingViewModal.MyOoodoDetasils.PortNum.ToString();
            tbUser.Text = Program.MySettingViewModal.MyOoodoDetasils.UserId.ToString();
          tbPass.Text = Program.MySettingViewModal.MyOoodoDetasils.Password.ToString();
            tbDataBaseName.Text = Program.MySettingViewModal.MyOoodoDetasils.DataBasename.ToString();



        }
        public void showPrinterDetails()
        {
            cmb_pos.Text = Program.MySettingViewModal.MyPrinterDetails.PosPrinter;
            cmb_kot.Text = Program.MySettingViewModal.MyPrinterDetails.KotPrinter.ToString();
            cmb_juice.Text = Program.MySettingViewModal.MyPrinterDetails.JuicePrinter.ToString();
          


        }


        public void ShowAppuserSetting()
        {
            AppUserSetting appUserSetting = Program.MySettingViewModal.AppUserSettings;
            txt_noofproductonrow.Text = appUserSetting.ProductperRow.ToString();

            txt_invoiceprefix.Text = appUserSetting.InvoicePrefix;
            txt_kotprefix.Text= appUserSetting.KotPrefix;
            txt_padding.Text = appUserSetting.PaddingNumber.ToString();
            txt_buttonwidth.Text = appUserSetting.ProductButtonWidth.ToString();
            txt_buttonHeight.Text = appUserSetting.ProductButtonHeigth.ToString();
            chk_realtime.Checked = appUserSetting.RealtimeInvoiceUpdate;
            chk_fastloading.Checked = appUserSetting.FastLoading;
            chk_autosizeproduct.Checked = appUserSetting.AutoSizebutton;
         


        }





        private void button2_Click(object sender, EventArgs e)
        {

        }


        public Boolean TestConnection()
        {
            Boolean isok = false;

            try
            {
                //string connstring = String.Format("Server=192.168.1.73;Port=5432;User Id=odoo;Password=at123;Database=ken-aug20;");
                string connstring = String.Format("Server={0};Port={1};" +
                        "User Id={2};Password={3};Database={4};",
                        tbHost.Text.Trim(), tbPort.Text.Trim(), tbUser.Text.Trim(),
                        tbPass.Text.Trim(), tbDataBaseName.Text.Trim());
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                conn.Open();


                // since we only showing the result we don't need connection anymore
                conn.Close();

                MessageBox.Show("Sucessfully Connected");
         
                isok = true;
            }
            catch (Exception Ex)
            {
                isok = false;
                MessageBox.Show("Some issue with Connection" + Ex);
            }

            return isok;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (TestConnection())
            {
                btn_saveodoosetting.Enabled = true;
            }
            else
            {

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btn_saveodoosetting_Click(object sender, EventArgs e)
        {
            if (TestConnection())
            {
                SettingRepository sysrepo = new SettingRepository();

                OdooDetail odetails = new OdooDetail { Server = tbHost.Text.Trim(), PortNum = int.Parse(tbPort.Text.Trim()), UserId = tbUser.Text.Trim(), Password = tbPass.Text.Trim(), DataBasename = tbDataBaseName.Text.Trim() ,IsActive=true ,StoreID=Program.LocationID };
                sysrepo.UpdateOdooReopository(odetails);
                MessageBox.Show("Odoo settings Updated Correctly. Please Logout the App and login");

            }
        }



        public void SaveOODOSetting()
        {




        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AppUserSetting appUserSetting = new AppUserSetting();
            appUserSetting.ProductperRow = int.Parse(txt_noofproductonrow.Text);
            appUserSetting.InvoicePrefix = txt_invoiceprefix.Text.Trim();
            appUserSetting.KotPrefix = txt_kotprefix.Text.Trim();
            appUserSetting.PaddingNumber = int.Parse(txt_padding.Text);
            appUserSetting.ProductButtonWidth = Decimal.Parse(txt_buttonwidth.Text);
            appUserSetting.ProductButtonHeigth = Decimal.Parse(txt_buttonHeight.Text);
           
            appUserSetting.StoreID = Program.LocationID;
            appUserSetting.IsActive = true;
            appUserSetting.RealtimeInvoiceUpdate = (chk_realtime.Checked) ? true : false;
            appUserSetting.FastLoading = (chk_fastloading.Checked) ? true : false;
            appUserSetting.AutoSizebutton = (chk_autosizeproduct.Checked) ? true : false;
            SettingRepository sysrepo = new SettingRepository();
            sysrepo.UpdateUsersettingReopository(appUserSetting);
            MessageBox.Show("App Store settings Updated Correctly. Please Logout the App and login");

        }







        private void PopulateInstalledPrintersCombo()
        {
            // Add list of installed printers found to the combo box.
            // The pkInstalledPrinters string will be used to provide the display string.
            String pkInstalledPrinters;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                cmb_pos.Items.Add(pkInstalledPrinters);
                cmb_kot.Items.Add(pkInstalledPrinters);
                cmb_juice.Items.Add(pkInstalledPrinters);
            }
        }

        private void comboInstalledPrinters_SelectionChanged(object sender, System.EventArgs e)
        {

            //// Set the printer to a printer in the combo box when the selection changes.

            //if (comboInstalledPrinters.SelectedIndex != -1)
            //{
            //    // The combo box's Text property returns the selected item's text, which is the printer name.
            //    printDoc.PrinterSettings.PrinterName = comboInstalledPrinters.Text;
            //}

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SettingRepository sysrepo = new SettingRepository();
            PrinterDetail printerDetails = new PrinterDetail { PosPrinter = cmb_pos.Text.Trim(),
                KotPrinter = cmb_kot.Text.Trim(), JuicePrinter = cmb_juice.Text.Trim(),
               IsActive = true, StoreID = Program.LocationID };
            sysrepo.UpdatePrinterReopository(printerDetails);
            MessageBox.Show("Printer settings Updated Correctly. Please Logout the App and login");
        }
    }
}
