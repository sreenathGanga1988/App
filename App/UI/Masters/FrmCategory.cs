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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace App.UI.Masters
{
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
            fillcategory();
            //PopulateInstalledPrintersCombo();
        }

        //private void PopulateInstalledPrintersCombo()
        //{
        //    // Add list of installed printers found to the combo box.
        //    // The pkInstalledPrinters string will be used to provide the display string.
        //    String pkInstalledPrinters;
        //    for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
        //    {
        //        pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
        //        cmb_pos.Items.Add(pkInstalledPrinters);

        //    }

        //    PrinterRepository printerRepository = new PrinterRepository();

        //    List<Printer> prntr = printerRepository.GetPrinterList(Program.LocationID);

        //    foreach(Printer printer in prntr)
        //    {
         

        //        cmb_pos.Items.Add(printer.PrinterName);
        //    }

        //}
        public void fillcategory()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
           
            List <Category> catgr=      categoryRepository.GetCategoryList();

            dgv.RowCount = 0;
            foreach (Category ctgry in catgr)
            {

                var index = dgv.Rows.Add();
                dgv.Rows[index].Cells["Id"].Value = ctgry.Id.ToString();
                dgv.Rows[index].Cells["OdooCategoryId"].Value = ctgry.OdooCategoryId.ToString();
                dgv.Rows[index].Cells["CategoryName"].Value = ctgry.CategoryName.ToString();
                dgv.Rows[index].Cells["Color"].Value = ctgry.Color==null ? "" : ctgry.Color.ToString();
                try
                {
                    dgv.Rows[index].Cells["Printer"].Value = ctgry.PrinterName.ToString();
                }
                catch (Exception)
                {

                   
                }
            }


            lbl_id.Text = "0";
            btn_save.Text = "Save";
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (btn_save.Text == "Save")
            {

                Category CTGRY = new Category() { CategoryName = txt_cATEGORYNAME.Text, OdooCategoryId = int.Parse(TXT_OODOID.Text),Color= txt_color.Text ,PrinterName=txt_printername.Text};

                CategoryRepository categoryRepository = new CategoryRepository();
                categoryRepository.Addcategory(CTGRY);

                MessageBox.Show("Sucessfully Added");
                fillcategory();

            }
            else
            {
                if (lbl_id.Text != "0")
                {
                    Category CTGRY = new Category() { CategoryName = txt_cATEGORYNAME.Text, OdooCategoryId = int.Parse(TXT_OODOID.Text),Id=int.Parse (lbl_id.Text), Color = txt_color.Text ,PrinterName = txt_printername.Text };
                    CategoryRepository categoryRepository = new CategoryRepository();
                    categoryRepository.UpdateCategory(CTGRY);
                    MessageBox.Show("Sucessfully Updated");
                    fillcategory(); 
                }
               



            }

        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lbl_id.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_color.Text = "";
            TXT_OODOID.Text= dgv.Rows[e.RowIndex].Cells["OdooCategoryId"].Value.ToString();
            try
            {
                txt_printername.Text = dgv.Rows[e.RowIndex].Cells["Printer"].Value.ToString();
            }
            catch (Exception)
            {

              
            }
            txt_cATEGORYNAME.Text= dgv.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();
            btn_save.Text = "Update";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            getProductsfromOdoo();
        }

        public void getProductsfromOdoo()
        {
            OdooUpdator odooUpdator = new OdooUpdator();
            odooUpdator.GetCategoryfromODOO();
            odooUpdator.GetProductfromODOO();

            MessageBox.Show("Sucessfully Updated From Odoo");
        }
    }
}
