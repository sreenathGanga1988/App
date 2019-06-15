using App.Context;
using App.Extensions;
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
        Decimal Creditamount=0;
        public Decimal Selectedvalue { get; set; }
        public ValueInPut()
        {
            InitializeComponent();
        }
       
        //Refund
        public ValueInPut(int InoiceID ,String ActionType,String frminvoicenum )
        {
            InitializeComponent();

            if (ActionType == "Refund")
            {
                btn_refund.Enabled = true;
                Invoiceid = InoiceID;
                FormActionType = ActionType;
                invoicenum = frminvoicenum;
                RefundAction();
            }
            if (ActionType == "Settle")
            {
                try
                {
                    Invoiceid = InoiceID;
                FormActionType = ActionType;
                SettlementAction();
            }
            catch (Exception)
            {

                MessageBox.Show("Cannot found Credit Amount of Selected Customer");
            }
        }
        }
        //Purchase
        public ValueInPut(DateTime DateTime, String ActionType)
        {
            InitializeComponent();

            if (ActionType == "Purchase")
            {
               
               
                FormActionType = ActionType;
                btn_purchase.Text = ActionType;
                btn_purchase.Enabled = true;
           
            }
            if (ActionType == "PayOut")
            {


                FormActionType = ActionType;
                btn_purchase.Text = ActionType;
                btn_purchase.Enabled = true;

            }
            
           if (ActionType == "CashIN")
            {


                FormActionType = ActionType;
                btn_posAmount.Text = ActionType;
                btn_posAmount.Enabled = true;

            }





            if (ActionType == "Encash")
            {
                

                FormActionType = ActionType;
                btn_Credit.Enabled = true;

            }
            if (ActionType == "PriceChange")
            {
                FormActionType = ActionType;
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
                if (FormActionType == "PriceChange")
                {

                    Selectedvalue = Decimal.Parse(txt_PasscodeDisplay.Text);
                    this.Close();
                }
                else {
                    try
                    {
                        Repository.UserRepository usrrep = new Repository.UserRepository();

                        if (usrrep.IsuserValid(int.Parse(txt_PasscodeDisplay.Text), 1))
                        {
                            this.Hide();
                            

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
            if (Creditamount >= Decimal.Parse(txt_PasscodeDisplay.Text))
            {
                RefundMaster refmaster = new RefundMaster();
                refmaster.InvoicemasterID = Invoiceid;
                refmaster.RefundDate = DateTime.Now;
                try
                {
                    refmaster.TotalRefund = Decimal.Parse(txt_PasscodeDisplay.Text);
                }
                catch (Exception)
                {

                    refmaster.TotalRefund = 0;
                }
                refmaster.ShiftID = Program.ShiftId;
                refmaster.UserID = Program.UserID;
                refmaster.StoreID = Program.LocationID;
                refmaster.RefundNum = "R" + invoicenum;

                Remarker remarker = new Remarker("Remark for " + refmaster.RefundNum);
                remarker.ShowDialog();
                refmaster.Remark = (remarker.EnteredRemark ==null) ? "" : remarker.EnteredRemark ; 


                RefundRepository refundrepo = new RefundRepository();
                refmaster = refundrepo.InsertRefund(refmaster);

               


                MessageBox.Show("Refund #" + refmaster.RefundNum + "Generated Sucessfully");

                this.Close();
            }
            else
            {


                MessageBox.Show("Cannot Refund More than Invoice Value");
            }
              

          
        }



        public void SettlementAction()
        {

           
                CustomerRepositiry custrepo = new CustomerRepositiry();
                Customer cust = custrepo.GetCustomer(Invoiceid);
                lbl_message.Text = "Credit Amount :" + cust.PaymentDue.ToString();
                Creditamount = Decimal.Parse(cust.PaymentDue.ToString());
                btn_Credit.Enabled = true;
           
        }

        public void RefundAction()
        {


            InvoiceRepository invrepo = new InvoiceRepository();
            Invoicemaster invmdstr = invrepo.GetInvoice((Invoiceid));
            lbl_message.Text = "Refundable  Amount :" + invmdstr.TotalBill.ToString();
            Creditamount = Decimal.Parse(invmdstr.TotalBill.ToString());
            btn_Credit.Enabled = true;

        }

        private void btn_PosOut_Click(object sender, EventArgs e)
        {
            PassCoder passCoder = new PassCoder();
            passCoder.ShowDialog();
            Boolean IsAuthenticated = passCoder.IsAuthenticated;


            if (IsAuthenticated)
            {
                if (Creditamount >= Decimal.Parse(txt_PasscodeDisplay.Text))
                {
                    SettleMaster settleMaster = new SettleMaster();
                    settleMaster.StoreID = Program.LocationID;
                    settleMaster.ShiftID = Program.ShiftId;
                    settleMaster.UserID = Program.UserID;
                    settleMaster.CustomerID = Invoiceid;
                    try
                    {
                        settleMaster.TotalRefund = Decimal.Parse(txt_PasscodeDisplay.Text);
                    }
                    catch (Exception)
                    {

                        settleMaster.TotalRefund = 0;
                    }
                    settleMaster.SettleDate = DateTime.Now;
                    Remarker remarker = new Remarker("Remark for Settlement ");
                    remarker.ShowDialog();
                    settleMaster.Remark = (remarker.EnteredRemark == null) ? "" : remarker.EnteredRemark;


                    SettlementRepository settlementRepository = new SettlementRepository();

                    settlementRepository.AddCreditSettlement(settleMaster);

                    MessageBox.Show("Successfully Added");
                    this.Close();

                }
            }
            else
            {
                MessageBox.Show("Not Authenticated");
            }




          

            

        }

        public void CashOutAction(string type)
        {
            CashOutMaster cashoutmaster = new CashOutMaster();
            cashoutmaster.CashOutDate = DateTime.Now; ;
            cashoutmaster.CashOutType = type ;
            try
            {
                cashoutmaster.TotalCashOut = Decimal.Parse(txt_PasscodeDisplay.Text);
            }
            catch (Exception)
            {
                cashoutmaster.TotalCashOut = 0;

            }

            cashoutmaster.Approvedby = "";
            cashoutmaster.ShiftID = Program.ShiftId;
            cashoutmaster.UserID = Program.UserID;
            cashoutmaster.StoreID = Program.LocationID;
            cashoutmaster.CashOutNum = "COUT-";
            cashoutmaster.InOrOut = "OUT" ;
            
            Remarker remarker = new Remarker("Remark for " + cashoutmaster.CashOutNum);
            remarker.ShowDialog();
            cashoutmaster.Remark = (remarker.EnteredRemark == null) ? "" : remarker.EnteredRemark;

            CashOutRepository refundrepo = new CashOutRepository();
            cashoutmaster = refundrepo.InsertCashout(cashoutmaster);
            PrintReceipt prnt = new PrintReceipt();
            prnt.printPayoutreport(cashoutmaster);
            MessageBox.Show("Cash Out #" + cashoutmaster.CashOutNum + "Generated Successfully");

            this.Close();
        }

        public void CashINAction(string type)
        {
            CashOutMaster cashoutmaster = new CashOutMaster();
            cashoutmaster.CashOutDate = DateTime.Now; ;
            cashoutmaster.CashOutType = type;
            try
            {
                cashoutmaster.TotalCashOut = Decimal.Parse(txt_PasscodeDisplay.Text);
            }
            catch (Exception)
            {
                cashoutmaster.TotalCashOut = 0;

            }

            cashoutmaster.Approvedby = "";
            cashoutmaster.ShiftID = Program.ShiftId;
            cashoutmaster.UserID = Program.UserID;
            cashoutmaster.StoreID = Program.LocationID;
            cashoutmaster.CashOutNum = "CIN-";
            cashoutmaster.InOrOut = "IN";

            Remarker remarker = new Remarker("Remark for " + cashoutmaster.CashOutNum);
            remarker.ShowDialog();
            cashoutmaster.Remark = (remarker.EnteredRemark == null) ? "" : remarker.EnteredRemark;

            CashOutRepository refundrepo = new CashOutRepository();
            cashoutmaster = refundrepo.InsertCashout(cashoutmaster);

            MessageBox.Show("Cash IN #" + cashoutmaster.CashOutNum + "Generated Successfully");

            this.Close();
        }


        private void btn_purchase_Click(object sender, EventArgs e)
        {
            CashOutAction(FormActionType);
        }

        private void btn_posAmount_Click(object sender, EventArgs e)
        {
            CashINAction(FormActionType);
        }
    }
}
