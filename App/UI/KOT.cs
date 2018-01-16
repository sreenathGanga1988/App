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

namespace App.UI
{
    public partial class KOT : Form
    {
        List<Invoicemaster> invoicemaster = null;
        public KOT()
        {
            InitializeComponent();
          
            ShowpendingInvoice();
        }



      
        public void ShowpendingInvoice()
        {

            InvoiceRepository InvoiceRepository = new InvoiceRepository();
            invoicemaster = InvoiceRepository.GetInvoiPendingtoBill(Program.LocationID).OrderByDescending(e => e.InvoicemasterID).ToList() ;
            LoadInvoicesPending(invoicemaster);

        }


   


        public void LoadInvoicesPending(List<Invoicemaster> invoicemaster)
        {

            Panel parent = this.pnl_inv;
            parent.Controls.Clear();
            int i = 0;
            int colcount = 0;
            int buttonheight = 0;
            int buttonwidth = 0;
            int buttonindex = 0;



            if (invoicemaster != null)
            {
                if (invoicemaster.Count > 0)
                {

                    int tablecount = invoicemaster.Count;

                    float parentheight = float.Parse(parent.Height.ToString());
                    float parentwidth = float.Parse(parent.Width.ToString());
                    buttonwidth = (int)Math.Ceiling(parentwidth) / 6;

                    buttonheight = buttonwidth;
                }
            }

            foreach (Invoicemaster invmaster in invoicemaster)
            {
                ValueButton temp = new ValueButton();
                String Status = invmaster.IsKOT == true ? "KOT" : invmaster.IstableBill == true ? "Hold" : "CheckOUT";
                temp.Name = "button" + invmaster.InvoicemasterID.ToString();
                temp.Text = invmaster.InvoiceNum + " / " + invmaster.Table.TableName +
                    " / " + invmaster.InvoiceDetails.Count() + "Items" + " / Customer: " +
                    invmaster.Customer.CustomerName + " /  Cashier :" + invmaster.User.UserName +
                    " /  At " + invmaster.InvoiceDate.ToString() + " /  Status " + Status;
                temp._value = invmaster.InvoicemasterID.ToString();
                // temp.AutoSize = true;
                temp.Width = buttonwidth;
                temp.Height = buttonheight;
                temp.Font = new Font(temp.Font, FontStyle.Bold);

               
                //temp.Width = 200;
                //temp.Height = 150;
                try
                {
                    if (invmaster.Color != null && invmaster.Color.Trim() != "")
                    {
                        temp.BackColor = Color.FromName(invmaster.Color);
                    }
                    if (Status != "KOT")
                    {
                        temp.BackColor = Color.FromName("Green");
                    }

                    else if (Status == "KOT")
                    {
                        temp.BackColor = Color.FromName("Cyan");
                    }
                }
                catch (Exception)
                {


                }


                temp.Location = new System.Drawing.Point((buttonwidth * buttonindex), (buttonheight * colcount));//please adjust location as per your need

                if (buttonindex % 5 == 0 && buttonindex != 0)
                {
                    colcount++;
                    buttonindex = 0;


                }
                else
                {
                    buttonindex++;
                }
                temp.Tag = i;

                temp.Click += new EventHandler(OnInvoiceButtonClick);
                parent.Controls.Add(temp);
                i++;
            }
            parent.AutoScroll = true;
        }
        private bool IsAlreadyOpen(Type formType)

        {

            bool isOpen = false;



            foreach (Form f in Application.OpenForms)

            {

                if (f.GetType() == formType)

                {

                    f.BringToFront();

                    f.WindowState = FormWindowState.Normal;

                    isOpen = true;

                }

            }


            return isOpen;

        }

        private void OnInvoiceButtonClick(object sender, EventArgs e)
        {
          int invoiceid= int.Parse( ((ValueButton)sender)._value.ToString());
          
            InvoiceRepository invoiceRepository = new InvoiceRepository();

            Invoicemaster mstr = invoiceRepository.GetInvoice(invoiceid);

            FrmPOS1Table frmpos = null;
            bool isFormOpen = IsAlreadyOpen(typeof(FrmPOS1Table));
            if (isFormOpen == false)
            {
                
                frmpos = new FrmPOS1Table(mstr);
                //   frmpos.MdiParent = this;
                //  frmpos.StartPosition = FormStartPosition.CenterScreen;
                frmpos.Show();
                this.Close();
            }
        }
        public void SeaarchInvoice()
        {
            string texttodearch = textBox1.Text.Trim();
          
            List<Invoicemaster> invoicemastertemp = invoicemaster.Where(u => u.InvoicemasterID.ToString().Contains(texttodearch) || u.InvoiceNum.Contains(texttodearch) || u.User.UserName.Contains(texttodearch) || u.TableName.Contains(texttodearch)).ToList();
            LoadInvoicesPending(invoicemastertemp);

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SeaarchInvoice();
        }
    }
}
