using App.Repository;
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

namespace App.UI.RefundAndExpense
{
    public partial class ActionBoard : Form
    {
        public ActionBoard()
        {
            InitializeComponent();
            fillInvoicedetailsDetails();
        }


        public void fillInvoicedetailsDetails()
        {
            InvoiceRepository invrepo = new InvoiceRepository();

            List<InvoiceviewModal> invemstr = invrepo.GetInvoicePending(Program.LocationID); ;

            dataGridView1.DataSource = invemstr;

            lbl_totalPaid.Text = "Total Sales  is :" + CalculateTotal(invemstr).ToString() + "AED";

        }




        public float CalculateTotal(List<InvoiceviewModal> invemstr)
        {
            var q = invemstr.Sum(u => u.TotalPaid);

            return float.Parse(q.ToString());
        }


        private void btn_updateOODO_Click(object sender, EventArgs e)
        {
            Repository.OdooUpdator odoupd = new Repository.OdooUpdator();
            odoupd.uploadInvoiceMaster();
        }

       

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ReprintAndRefund repref = new ReprintAndRefund(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
            repref.ShowDialog();
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
    }
}
