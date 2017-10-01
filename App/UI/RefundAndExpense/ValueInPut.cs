using App.Model;
using App.Repository;
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
    public partial class ValueInPut : Form
    {
        
           String FormActionType = "";
              String invoicenum = "";
        int Invoiceid = 0;
        public ValueInPut()
        {
            InitializeComponent();
        }


        public ValueInPut(int InoiceID ,String ActionType,String frminvoicenum )
        {
            InitializeComponent();

            if (ActionType == "Refund")
            {
                btn_refund.Enabled = true;
                Invoiceid = InoiceID;
                FormActionType = ActionType;
                invoicenum = frminvoicenum;
            }
        }

        public ValueInPut(DateTime DateTime, String ActionType)
        {
            InitializeComponent();

            if (ActionType == "Purchase")
            {
               
               
                FormActionType = ActionType;
                btn_purchase.Enabled = true;
           
            }
            if (ActionType == "Encash")
            {
                

                FormActionType = ActionType;
                btn_PosOut.Enabled = true;

            }
        }
        private void buttonclicked_Click(object sender, EventArgs e)
        {
            KeyPressed((Button)sender);
        }

        public void KeyPressed(Button btn)
        {

            if (btn.Text == "OK")
            {

                try
                {
                    Repository.UserRepository usrrep = new Repository.UserRepository();

                    if (usrrep.IsuserValid(int.Parse(txt_PasscodeDisplay.Text),1))
                    {
                        this.Hide();
                        StartForm frm = new StartForm();
                        frm.Show();

                    }
                    else
                    {

                        MessageBox.Show("Passcode not Valid");
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Hi Dude You lost connection to DB");
                }

            }
            else if (btn.Text == "Back")
            {
                txt_PasscodeDisplay.Text = Extensions.MyExtensions.TrimLastCharacter(txt_PasscodeDisplay.Text);

            }
            else
            {
                txt_PasscodeDisplay.Text = txt_PasscodeDisplay.Text.Trim() + btn.Text.Trim();
            }

        }

        private void btn_refund_Click(object sender, EventArgs e)
        {
            RefundMaster refmaster = new RefundMaster();
            refmaster.InvoicemasterID = Invoiceid;
            refmaster.RefundDate = DateTime.Now;
            refmaster.TotalRefund = Decimal.Parse(txt_PasscodeDisplay.Text);
            refmaster.UserID = Program.UserID;
            refmaster.StoreID = Program.LocationID;
            refmaster.RefundNum = "R" + invoicenum;
            RefundRepository refundrepo = new RefundRepository();
            refmaster= refundrepo.InsertRefund(refmaster);

            MessageBox.Show("Refund #" + refmaster.RefundNum + "Generated Sucessfully");


        }
    }
}
