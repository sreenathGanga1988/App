using App.ApplicationSettingRepository;
using App.Model;
using App.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.UI.Masters
{
    public partial class PrinterForm : Form
    {
        public PrinterForm()
        {
            InitializeComponent();
            PopulateInstalledPrintersCombo();
            FillPrinter();
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
             
            }
        }
        public void FillPrinter()
        {
            PrinterRepository categoryRepository = new PrinterRepository();

           
            lbl_id.Text = "0";
            dgv.Rows.Clear();
            List<Printer> prntr = categoryRepository.GetPrinterList(Program.LocationID);
            foreach (Printer ctgry in prntr)
            {

                var index = dgv.Rows.Add();
                dgv.Rows[index].Cells["PrinterID"].Value = ctgry.PrinterId.ToString();
                dgv.Rows[index].Cells["PrinterName"].Value = ctgry.PrinterName.ToString();
                dgv.Rows[index].Cells["Remark"].Value = ctgry.Remark.ToString();
            }
            btn_save.Text = "Save";
        }
      


        private void button1_Click(object sender, EventArgs e)
        {
            PrinterRepository categoryRepository = new PrinterRepository();
            if (btn_save.Text == "Save")
            {

                Printer CTGRY = new Printer() { PrinterName = cmb_pos.Text.Trim(), Remark =  rht_remark.Text,StoreID=Program.LocationID };

             
                categoryRepository.Addcategory(CTGRY);

                MessageBox.Show("Sucessfully Added");
                FillPrinter();

            }
            else
            {
                if (lbl_id.Text != "0")
                {
                    Printer CTGRY = new Printer() { PrinterName = cmb_pos.Text.Trim(), Remark = rht_remark.Text,PrinterId=int.Parse (lbl_id.Text), StoreID = Program.LocationID };
                    categoryRepository.UpdateCategory(CTGRY);
                    MessageBox.Show("Sucessfully Added");
                    FillPrinter();
                }




            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_save.Text = "Update";
            lbl_id.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
          
            cmb_pos.Text = dgv.Rows[e.RowIndex].Cells["PrinterName"].Value.ToString();
            rht_remark.Text = dgv.Rows[e.RowIndex].Cells["Remark"].Value.ToString();
        }
    }
}
