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

namespace App.UI
{
    public partial class FrmDailyReports : Form
    {
        public FrmDailyReports()
        {
            InitializeComponent();
            fillInvoicedetailsDetails();
        }


        public void fillInvoicedetailsDetails()
        {
            InvoiceRepository invrepo = new InvoiceRepository();

            List<InvoiceviewModal> invemstr = invrepo.GetInvoicePending(Program.LocationID); ;

            dataGridView1.DataSource = invemstr;

            lbl_totalPaid.Text =  CalculateTotal(invemstr).ToString() + "AED";

        }




        public float CalculateTotal(List<InvoiceviewModal> invemstr)
        {
            var q = invemstr.Sum(u => u.TotalPaid);

            return float.Parse(q.ToString());
        }


        private void FrmPOS1_Load(object sender, EventArgs e)
        {
           
        }

        private void btn_updateOdoo_Click(object sender, EventArgs e)
        {
            Repository.OdooUpdator odoupd = new Repository.OdooUpdator();
            odoupd.uploadInvoiceMaster();
        }
    }
}
