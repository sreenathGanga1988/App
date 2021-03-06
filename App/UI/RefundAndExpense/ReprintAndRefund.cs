﻿using App.Extensions;
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
            invmstr.CustomerAdress = invmstr.Customer.CustomerDetails;
            invmstr.CustomerPhone = invmstr.Customer.PhoneNumber;
            invoiceid = invoicemasterID;
            try
            {
                lbl_invoice.Text = invmstr.InvoiceNum.ToString();
            }
            catch (Exception)
            {

               
            }
            lbl_invoiceId.Text = invmstr.InvoicemasterID.ToString();
            lbl_paymentmode.Text = invmstr.PaymentMode.ToString();
            lbl_invoiceId.Visible = false;
            paymentmodeadjust();
        }



        public void paymentmodeadjust()
        {
            if (invmstr.PaymentMode == "CREDIT")
            {
                btn_card.Enabled = false;
                btn_cash.Enabled = false;
                btn_zomato.Enabled = false;
               

            }
            else if (invmstr.PaymentMode == "CASH")
            {
                btn_card.Enabled = true;
                btn_cash.Enabled = false;
                btn_zomato.Enabled = false;
            }
            else if (invmstr.PaymentMode == "CARD")
            {
                btn_card.Enabled = false;
                btn_cash.Enabled = true;
                btn_zomato.Enabled = false;
            }
            else if (invmstr.PaymentMode == "zOMATO")
            {
                btn_card.Enabled = false;
                btn_cash.Enabled = false;
                btn_zomato.Enabled = false;
            }

        }



        private void btn_repreint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintReceiptnew prnt = new PrintReceiptnew();
                prnt.ReprintprintInvoicereport(invmstr);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Printer Malfunction.But Invoice Done");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        { PassCoder passCoder = new PassCoder();
            passCoder.ShowDialog();
            Boolean IsAuthenticated = passCoder.IsAuthenticated;


            if (IsAuthenticated)
            {
                ValueInPut valinput = new ValueInPut(invoiceid,"Refund", invmstr.InvoiceNum);
            valinput.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Not Authenticated");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          if(invmstr.ShiftID == Program.ShiftId)
            {

                int invoiceid = invmstr.InvoicemasterID;

                PassCoder passCoder = new PassCoder();
                passCoder.ShowDialog();
                Boolean IsAuthenticated = passCoder.IsAuthenticated;


                if (IsAuthenticated)
                {
                    InvoiceRepository invoiceRepository = new InvoiceRepository();
                    invoiceRepository.DeleteInvoicemaster(invoiceid);
                    MessageBox.Show("Deleted Sucessfully");
                }
                else
                {
                    MessageBox.Show("Not Authenticated");
                }

            }
            else
            {
                MessageBox.Show("Cannot Delete  Invoice of Different Shift");
            }

           
        }

        private void btn_card_Click(object sender, EventArgs e)
        {
            InvoiceRepository invoiceRepository = new InvoiceRepository();
            invoiceRepository.UpdatePaymentInvoicemaster(invoiceid,"CARD");
            MessageBox.Show("Updated");
            this.Close();


        }

        private void btn_cash_Click(object sender, EventArgs e)
        {
            InvoiceRepository invoiceRepository = new InvoiceRepository();
            invoiceRepository.UpdatePaymentInvoicemaster(invoiceid, "CASH");
            MessageBox.Show("Updated");
            this.Close();
        }

        private void btn_zomato_Click(object sender, EventArgs e)
        {

        }
    }
}
