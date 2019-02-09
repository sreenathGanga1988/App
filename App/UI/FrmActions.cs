using App.Repository;
using App.UI.POS;
using App.UI.RefundAndExpense;
using App.ViewModal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.UI
{
    public partial class FrmActions : Form
    {

        public FrmActions()
        {
            InitializeComponent();
        }

        private void FrmPOS1_Load(object sender, EventArgs e)
        {
            loadShift();
        }

        public void loadShift()
        {
            using(App.Context.POSDataContext cntxt= new Context.POSDataContext())
            {
                
                cmb_shift.ValueMember = "ShiftID";
                cmb_shift.DisplayMember = "ShiftName";
                cmb_shift.DataSource = cntxt.Shifts.OrderByDescending(x=>x.ShiftID ).ToList();
            }
        }

        private void btn_purchase_Click(object sender, EventArgs e)
        {
            ValueInPut valinput = new ValueInPut(DateTime.Now, "Purchase");
            valinput.ShowDialog();
        }

        private void btn_PosOut_Click(object sender, EventArgs e)
        {
            PassCoder passCoder = new PassCoder();
            passCoder.ShowDialog();
            Boolean IsAuthenticated = passCoder.IsAuthenticated;


            if (IsAuthenticated)
            {
                ValueInPut valinput = new ValueInPut(DateTime.Now, "Encash");
                valinput.ShowDialog();
            }
            else
            {
                MessageBox.Show("Not Authenticated");
            }
           
        }

        private void btn_posAmount_Click(object sender, EventArgs e)
        {
            ValueInPut valinput = new ValueInPut(DateTime.Now, "CashIN");
            valinput.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CurrentSelectedShiftreport();
            pnl_filter.Visible = false;
        }


        public void CurrentSelectedShiftreport()
        {
            InvoiceRepository invrepo = new InvoiceRepository();

            List<InvoiceviewModal> invemstr = invrepo.GetInvoicOfShift(Program.LocationID,int.Parse(cmb_shift.SelectedValue.ToString()));
            dataGridView1.DataSource = invemstr;

            lbl_totalPaid.Text = "Total Sales  is :" + CalculateTotal(invemstr).ToString() + "AED";
           
        }

        public void CurrentSelectedShiftcashoutreport( string outornot)
        {
            CashOutRepository  invrepo = new CashOutRepository();
            if (outornot == "in")
            {
                List<CashoutViewModel> invemstr = invrepo.GetCashInofShift( int.Parse(cmb_shift.SelectedValue.ToString()));
                dataGridView1.DataSource = invemstr;
                lbl_totalPaid.Text = "Total Sales  is :" + CalculatecashoutTotal(invemstr).ToString() + "AED";

            }
            else
            {
                List<CashoutViewModel> invemstr = invrepo.GetCashOutofShift( int.Parse(cmb_shift.SelectedValue.ToString()));
                dataGridView1.DataSource = invemstr;
                lbl_totalPaid.Text = "Total Sales  is :" + CalculatecashoutTotal(invemstr).ToString() + "AED";

            }


        }
        public float CalculateTotal(List<InvoiceviewModal> invemstr)
        {
            var q = invemstr.Sum(u => u.TotalPaid);

            return float.Parse(q.ToString());
        }

        public float CalculatecashoutTotal(List<CashoutViewModel> invemstr)
        {
            var q = invemstr.Sum(u => u.TotalCashOut);

            return float.Parse(q.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PassCoder passCoder = new PassCoder();
            passCoder.ShowDialog();
            Boolean IsAuthenticated = passCoder.IsAuthenticated;


            if (IsAuthenticated)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {

                    int id =int.Parse( row.Cells["InvoicemasterID"].Value. ToString());
                    InvoiceRepository invoiceRepository = new InvoiceRepository();
                    invoiceRepository.DeleteInvoicemaster(id);
                };
                MessageBox.Show("Deleted");
                CurrentSelectedShiftreport();
            }
            else
            {
                MessageBox.Show("Not Authenticated");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdatePendingForm u = new UpdatePendingForm();
            u.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ValueInPut valinput = new ValueInPut(DateTime.Now, "PayOut");
            valinput.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CurrentSelectedShiftcashoutreport("out");
            pnl_filter.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CurrentSelectedShiftcashoutreport("in");
            pnl_filter.Visible = false;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ProductRepositories prodrepo = new ProductRepositories();

            dataGridView1.DataSource = prodrepo.productConsumption(dtp_from.Value.Date, dt_to.Value.Date);
            pnl_filter.Visible = true;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_category_TextChanged(object sender, EventArgs e)             
        {
            Filtertext("Category", txt_category.Text);
        }

        private void txt_product_TextChanged(object sender, EventArgs e)
        {

            Filtertext("Name", txt_product.Text);
        }


        public void Filtertext(string Columnname, String searchtext)
        {

            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView1.DataSource];
            currencyManager1.SuspendBinding();
            Debug.WriteLine(dataGridView1.Rows.Count.ToString() + "Rows");

            int i = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string tempstring = row.Cells[Columnname].Value.ToString().Trim();


                Debug.WriteLine(  i++.ToString ()+" " +dataGridView1.Rows.Count.ToString() );

                if (tempstring.ToUpper().Contains(searchtext.Trim().ToUpper())) {

                    row.Visible = true;

                }
                else
                {
                    row.Visible = false;
                }
               
            };

            currencyManager1.ResumeBinding();




        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Reports.PosReports psreport = new Reports.PosReports("Credit",dtp_from.Value.Date, dt_to.Value.Date);
            psreport.ShowDialog();
        }

        private void btnPrintCloseReport_Click(object sender, EventArgs e)
        {
            Extensions.PrintReceiptnew printReceiptnew = new Extensions.PrintReceiptnew();
            printReceiptnew.PrintCopy(cmb_shift.Text);
        }
    }
}
