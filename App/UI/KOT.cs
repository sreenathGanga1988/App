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
        public KOT()
        {
            InitializeComponent();
          
            ShowpendingInvoice();
        }



      
        public void ShowpendingInvoice()
        {

            InvoiceRepository InvoiceRepository = new InvoiceRepository();
            List<Invoicemaster> invoicemaster = InvoiceRepository.GetInvoiPendingtoBill(Program.LocationID);
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
                temp.Name = "button" + invmaster.InvoicemasterID.ToString();
                temp.Text = invmaster.InvoiceNum + " / " + invmaster.Table.TableName + " / " + invmaster.InvoiceDetails.Count() + "Items";
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

        private void OnInvoiceButtonClick(object sender, EventArgs e)
        {
          int invoiceid= int.Parse( ((ValueButton)sender)._value.ToString());
            MessageBox.Show(invoiceid.ToString());
            InvoiceRepository invoiceRepository = new InvoiceRepository();

            Invoicemaster mstr = invoiceRepository.GetInvoice(invoiceid);

            SalesForm frm = new SalesForm(mstr);
            frm.Show();
        }
    }
}
