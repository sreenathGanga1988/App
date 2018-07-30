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



        public void UpdateItemsWithNoIsDeleted()
        {



        }


        public List<InvoiceviewModal> CurrentShiftreport()
        {
            InvoiceRepository invrepo = new InvoiceRepository();

            List<InvoiceviewModal> invemstr = invrepo.GetInvoicePendingOfShift(Program.LocationID,Program.ShiftId);
            
            return invemstr;
        }

        public List<InvoiceviewModal> BetweendateReport()
        {
            InvoiceRepository invrepo = new InvoiceRepository();

            //List<InvoiceviewModal> invemstr = invrepo.GetInvoicePendingBetween(Program.LocationID,dtp_from.Value.Date,dtp_to.Value.Date);
            List<InvoiceviewModal> invemstr = null;
            return invemstr;
        }

        public List<InvoiceviewModal> InovoicesofDay()
        {
            InvoiceRepository invrepo = new InvoiceRepository();

            //List<InvoiceviewModal> invemstr = invrepo.GetInvoiceofDay(Program.LocationID);
            List<InvoiceviewModal> invemstr = invrepo.GetInvoiceofDayIrrespectiveofShift(Program.LocationID);
            
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




        public void filterDataonStatus(String Status)
        {
            List<InvoiceviewModal> invemstrFinaltemp = invemstrFinal.Where(u => u.Status == Status).ToList();


            if (Status == "All") { fillInvoicedetailsDetails(invemstrFinal); }
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
            
        }

       

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ReprintAndRefund repref = new ReprintAndRefund(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
            repref.ShowDialog();
            FillReport("Shift");
        }

        private void rbt_todaySales_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void rbt_shiftsales_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void btn_todaysale_Click(object sender, EventArgs e)
        {
            FillReport("Today");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillReport("Shift");
        }

        private void rbt_salesbet_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FillReport("Between");
        }

        private void btn_updateOdoo_Click_1(object sender, EventArgs e)
        {
            Repository.OdooUpdator odoupd = new Repository.OdooUpdator();
            odoupd.uploadInvoiceMaster();
            MessageBox.Show("Updated to ODOO Successfully and Closing the Section.POS Will close Now");
            Application.Exit();
        }

        private void rbt_zomato_CheckedChanged(object sender, EventArgs e)
        {
            filterDataonPaymentMode("ZOMATO");
        }

        private void rbt_KOT_CheckedChanged(object sender, EventArgs e)
        {
            filterDataonStatus("KOT");

        }

        private void rbt_hold_CheckedChanged(object sender, EventArgs e)
        {
            filterDataonStatus("Hold");
            
        }

        private void rbt_checkout_CheckedChanged(object sender, EventArgs e)
        {
            filterDataonStatus("CheckOUT");
           
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            filterDataonStatus("All");
        }
    }
}
