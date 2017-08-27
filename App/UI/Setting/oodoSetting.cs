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

namespace App.UI.Setting
{
    public partial class oodoSetting : Form
    {
        public oodoSetting()
        {
            InitializeComponent();
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
            appUserSetting.PaddingNumber = int.Parse(txt_padding.Text);
            appUserSetting.ProductButtonWidth = Decimal.Parse(txt_buttonwidth.Text);
            appUserSetting.ProductButtonHeigth = Decimal.Parse(txt_buttonHeight.Text);
            appUserSetting.StoreID = Program.LocationID;
            appUserSetting.RealtimeInvoiceUpdate = (chk_realtime.Checked) ? true : false;
            appUserSetting.FastLoading = (chk_fastloading.Checked) ? true : false;
            appUserSetting.AutoSizebutton = (chk_autosizeproduct.Checked) ? true : false;
        }
    }
}
