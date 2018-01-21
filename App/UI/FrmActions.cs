using App.Repository;
using App.UI.RefundAndExpense;
using App.ViewModal;
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
                cmb_shift.DataSource = cntxt.Shifts.ToList();
            }
        }

        private void btn_purchase_Click(object sender, EventArgs e)
        {
            ValueInPut valinput = new ValueInPut(DateTime.Now, "Purchase");
            valinput.ShowDialog();
        }

        private void btn_PosOut_Click(object sender, EventArgs e)
        {
            ValueInPut valinput = new ValueInPut(DateTime.Now, "Encash");
            valinput.ShowDialog();
        }

        private void btn_posAmount_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CurrentSelectedShiftreport();
        }


        public void CurrentSelectedShiftreport()
        {
            InvoiceRepository invrepo = new InvoiceRepository();

            List<InvoiceviewModal> invemstr = invrepo.GetInvoicOfShift(Program.LocationID,int.Parse(cmb_shift.SelectedValue.ToString()));
            dataGridView1.DataSource = invemstr;

            lbl_totalPaid.Text = "Total Sales  is :" + CalculateTotal(invemstr).ToString() + "AED";
           
        }
        public float CalculateTotal(List<InvoiceviewModal> invemstr)
        {
            var q = invemstr.Sum(u => u.TotalPaid);

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
    }
}
