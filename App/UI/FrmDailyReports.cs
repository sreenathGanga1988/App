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
        List<InvoiceviewModal> invemstrFinal = null;

        public FrmDailyReports()
        {
            InitializeComponent();
           
        }





        public List<InvoiceviewModal> CurrentShiftreport()
        {
            InvoiceRepository invrepo = new InvoiceRepository();

            List<InvoiceviewModal> invemstr = invrepo.GetInvoicePending(Program.LocationID);

            return invemstr;
        }

        public List<InvoiceviewModal> BetweendateReport()
        {
            InvoiceRepository invrepo = new InvoiceRepository();

            List<InvoiceviewModal> invemstr = invrepo.GetInvoicePendingBetween(Program.LocationID,dtp_from.Value.Date,dtp_to.Value.Date);

            return invemstr;
        }

        public List<InvoiceviewModal> InovoicesofDay()
        {
            InvoiceRepository invrepo = new InvoiceRepository();

            List<InvoiceviewModal> invemstr = invrepo.GetInvoiceofDay(Program.LocationID);

            return invemstr;
        }

        public void FillReport(String type)
        {
           


            if (type =="Shift") {
                invemstrFinal = CurrentShiftreport();
            }
            else if (type == "Today")
            {
                invemstrFinal = InovoicesofDay();
            }
            else if (type == "Between")
            {
                invemstrFinal = BetweendateReport();
            }
            fillInvoicedetailsDetails(invemstrFinal);
        }



        public void fillInvoicedetailsDetails(List<InvoiceviewModal> invemstr)
        {
           

            dataGridView1.DataSource = invemstr;

            lbl_totalPaid.Text =  CalculateTotal(invemstr).ToString() + "AED";

        }




        public float CalculateTotal(List<InvoiceviewModal> invemstr)
        {
            var q = invemstr.Sum(u => u.TotalPaid);

            return float.Parse(q.ToString());
        }


        private void btn_updateOdoo_Click(object sender, EventArgs e)
        {
            Repository.OdooUpdator odoupd = new Repository.OdooUpdator();
            odoupd.uploadInvoiceMaster();
            MessageBox.Show("Updated to ODOO Sucessfully and Closing the Section.POS Will close Now");
            Application.Exit();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void rbt_todaySales_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void rbt_shiftsales_CheckedChanged(object sender, EventArgs e)
        {
            FillReport("Shift");
        }

        private void rbt_salesbet_CheckedChanged(object sender, EventArgs e)
        {
            FillReport("Between");
        }



        public void filterDataonPaymentMode(String Cashity)
        {
            List<InvoiceviewModal> invemstrFinaltemp = invemstrFinal.Where(u => u.PaymentMode == Cashity).ToList();


            if (Cashity == "All") { fillInvoicedetailsDetails(invemstrFinal); }
            else { fillInvoicedetailsDetails(invemstrFinaltemp); }
          
        }

        private void rbt_cash_CheckedChanged(object sender, EventArgs e)
        {
            filterDataonPaymentMode("CASH");
        }

        private void rbt_credit_CheckedChanged(object sender, EventArgs e)
        {
            filterDataonPaymentMode("CREDIT");
        }

        private void rbt_card_CheckedChanged(object sender, EventArgs e)
        {
            filterDataonPaymentMode("CARD");
        }

        private void rbt_all_CheckedChanged(object sender, EventArgs e)
        {
            filterDataonPaymentMode("All");
        }

        private void FrmDailyReports_Load(object sender, EventArgs e)
        {
            FillReport("Shift");
        }

        private void rbt_todaySales_Click(object sender, EventArgs e)
        {
            FillReport("Today");
        }

        private void rbt_shiftsales_Click(object sender, EventArgs e)
        {
            FillReport("Shift");
        }

        private void rbt_salesbet_Click(object sender, EventArgs e)
        {
            FillReport("Between");

        }
    }
}
