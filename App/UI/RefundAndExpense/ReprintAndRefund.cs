using App.Extensions;
using App.Model;
using App.Repository;
using App.UI.RefundAndExpense;
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
    public partial class ReprintAndRefund : Form
    {
        int invoiceid = 0;
        public Invoicemaster invmstr = new Invoicemaster();
        public ReprintAndRefund()
        {
            InitializeComponent();
        }

        public ReprintAndRefund( int invoicemasterID)
        {
            InitializeComponent();
            InvoiceRepository invrepo = new InvoiceRepository();
            invmstr = invrepo.GetInvoice(invoicemasterID);
            invmstr.StoreName = invmstr.Store.StoreName;
            invmstr.StoreAddress = invmstr.Store.StoreAddress;
            invmstr.Cashier = invmstr.User.UserName;
            invmstr.CustomerName = invmstr.Customer.CustomerName;
            invoiceid = invoicemasterID;
            try
            {
                lbl_invoice.Text = invmstr.InvoiceNum.ToString();
            }
            catch (Exception)
            {

               
            }
            lbl_invoiceId.Text = invmstr.InvoicemasterID.ToString();
            lbl_invoiceId.Visible = false;
        }

        private void btn_repreint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintReceipt prnt = new PrintReceipt();
                prnt.printInvoicereport(invmstr);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Printer Malfunction.But Invoice Done");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValueInPut valinput = new ValueInPut(invoiceid,"Refund", invmstr.InvoiceNum);
            valinput.ShowDialog();
        }
    }
}
