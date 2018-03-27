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

namespace App.UI.POS
{
    public partial class UpdatePendingForm : Form
    {
        List<InvoiceviewModal> invemstrFinal = null;
        public UpdatePendingForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            invemstrFinal = BetweendateReport();
            fillInvoicedetailsDetails(invemstrFinal);
        }
        public List<InvoiceviewModal> BetweendateReport()
        {
            InvoiceRepository invrepo = new InvoiceRepository();
            List<InvoiceviewModal> invemstr = invrepo.GetInvoicePendingBetweenNotUploaded(Program.LocationID, dtp_from.Value.Date, dtp_to.Value.Date);

            return invemstr;
        }
        public void fillInvoicedetailsDetails(List<InvoiceviewModal> invemstr)
        {


            dataGridView1.DataSource = invemstr;

            lbl_msg.Text = "Total Sale Amount : " + CalculateTotal(invemstr).ToString() + "AED";

        }




        public float CalculateTotal(List<InvoiceviewModal> invemstr)
        {
            var q = invemstr.Sum(u => u.TotalPaid);

            return float.Parse(q.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Repository.OdooUpdator odoupd = new Repository.OdooUpdator();
            odoupd.UploadInvoiceBetweendate(dtp_from.Value.Date, dtp_to.Value.Date); 
            MessageBox.Show("Updated to ODOO Sucessfully and Closing the Section.POS Will close Now");
            Application.Exit();
        }
    }
}
