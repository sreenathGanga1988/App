using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Repository;
using App.ViewModal;

namespace App.UI.Reports
{
    public partial class PosReports : Form
    {
        List<CreditViewModel> creditlist;
        public PosReports()
        {
            InitializeComponent();
        }


        public PosReports(String reporttype ,DateTime  fromdate,DateTime todate)
        {
            InitializeComponent();

          
            if (reporttype == "Credit")
            {
                creditlist = new List<CreditViewModel>();
                tc_report.SelectedTab = tpg_credit;
                
                    tc_report.TabPages.Remove(tabPage2);

                CreditRepository credrepo = new CreditRepository();
                creditlist = credrepo.CreditOverAPeriod(fromdate, todate);

                loadcustomerCredit(creditlist,dgv);

            }
        }




        public void loadcustomerCredit(List<CreditViewModel> myList ,DataGridView dgv)
        {
           

            dgv.Rows.Clear();

            var q = myList.Sum(u => u.PaymentDue).GetValueOrDefault ();
            lbl_totalPaid.Text = "Total Credit Amount is AED " + q.ToString();
            // dgv.DataSource = customerlist;
            foreach (var  item in myList)
            {
                var index = dgv.Rows.Add();
                dgv.Rows[index].Cells["CreditMasterID"].Value = item.CreditMasterID.ToString();
                dgv.Rows[index].Cells["InvoiceDate"].Value = item.InvoiceDate.ToString();
                dgv.Rows[index].Cells["CustomerName"].Value = item.CustomerName == null ? "" : item.CustomerName.ToString();
                dgv.Rows[index].Cells["PhoneNumber"].Value = item.PhoneNumber == null ? "" : item.PhoneNumber.ToString();
                dgv.Rows[index].Cells["InvoiceNum"].Value = item.InvoiceNum == null ? "" : item.InvoiceNum.ToString();
                dgv.Rows[index].Cells["PaymentDue"].Value = item.PaymentDue == null ? "0" : item.PaymentDue.ToString();
               
            }

        }


        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_searcharea_TextChanged(object sender, EventArgs e)
        {
            var q = creditlist.Where(u =>(u.PhoneNumber.ToUpper() .Contains(btn_searcharea.Text.ToUpper () ) || u.CustomerName.ToUpper().Contains(btn_searcharea.Text.ToUpper()))).ToList();
            loadcustomerCredit(q, dgv);

        }
    }
}
