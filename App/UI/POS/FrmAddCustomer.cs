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
    public partial class FrmAddCustomer : Form
    {
        public FrmAddCustomer()
        {
            InitializeComponent();
            LoadAllcustomer();
            dgv.RowTemplate.Height = 40;
        }

        public String SelectedCustomerName { get; set; }
        public String SelectedCustomerID { get; set; }
        public void LoadAllcustomer()
        {
            CustomerRepositiry custrepo = new CustomerRepositiry();
            List<Customer> customerlist = custrepo.GetcustomerofLocation(Program.LocationID);

            loadcustomer(customerlist);
        }


        public void loadcustomer(List<Customer> customerlist)
        {

            dgv.Rows.Clear();
            foreach (Customer customer in customerlist)
            {
                var index = dgv.Rows.Add();
                dgv.Rows[index].Cells["CustomerID"].Value = customer.CustomerID.ToString();
                dgv.Rows[index].Cells["OdooID"].Value = customer.OdooID.ToString();
                dgv.Rows[index].Cells["CustomerName"].Value = customer.CustomerName.ToString();
                dgv.Rows[index].Cells["PhoneNumber"].Value = customer.PhoneNumber == null ? "" : customer.PhoneNumber.ToString();
                dgv.Rows[index].Cells["CustomerDetails"].Value = customer.CustomerDetails == null ? "" : customer.CustomerDetails.ToString();
                dgv.Rows[index].Cells["PaymentDue"].Value = customer.PaymentDue == null ? "" : customer.PaymentDue.ToString();
                dgv.Rows[index].Cells["BarcodeNum"].Value = customer.BarcodeNum == null ? "" : customer.BarcodeNum.ToString();
                dgv.Rows[index].Cells["Discount"].Value = customer.Discount == null ? "" : customer.Discount.ToString();
            }
            
        }

     

      
        
        public void clearcontrol()
        {
            lbl_cutomerid.Text = "0";
            txt_name.Text = "";
            txt_mobnumber.Text = "";
            txt_address.Text = "";
        }
       

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lbl_cutomerid.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            lbl_odooid.Text = dgv.Rows[e.RowIndex].Cells["OdooID"].Value.ToString();
            txt_name.Text = dgv.Rows[e.RowIndex].Cells["CustomerName"].Value.ToString();
            txt_mobnumber.Text = dgv.Rows[e.RowIndex].Cells["PhoneNumber"].Value.ToString();
            txt_address.Text = dgv.Rows[e.RowIndex].Cells["CustomerDetails"].Value.ToString();

            
        }

       

        private void btn_addCustomer_Click_1(object sender, EventArgs e)
        {
            if (lbl_cutomerid.Text == "0")
            {
                Customer customer = new Customer();
                customer.CustomerName = txt_name.Text.Trim();
                customer.PhoneNumber = txt_mobnumber.Text.Trim();
                customer.CustomerDetails = txt_address.Text.Trim();
                customer.StoreID = Program.LocationID;
                customer.AddedDate = DateTime.Now.ToString();
                customer.PaymentDue = Decimal.Parse(txt_due.Text);
                customer.Discount = Decimal.Parse(txt_discount.Text);
                customer.BarcodeNum = txt_barcode.Text;
                customer.AddedBy = Program.Username;
                customer.IsDetailChanged = true;
                CustomerRepositiry custrepo = new CustomerRepositiry();

                if (custrepo.GetCustomerByMobilnum(customer.PhoneNumber).Count == 0)
                {
                    customer= custrepo.AddCustomer(customer);
                   
                    MessageBox.Show("Customer Added");
                    LoadAllcustomer();
                    clearcontrol();
                    SelectedCustomerID =customer.CustomerID.ToString();
                    SelectedCustomerName = customer.CustomerName.ToString();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mobile Number Already Present");
                }
              
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (lbl_cutomerid.Text != "0")
            {

                Customer CTGRY = new Customer() { CustomerName = txt_name.Text, CustomerID = int.Parse(lbl_cutomerid.Text), PhoneNumber = txt_mobnumber.Text,
                    CustomerDetails = txt_address.Text, StoreID = Program.LocationID, AddedDate = DateTime.Now.ToString(), AddedBy = Program.Username, IsDetailChanged = true,

                     PaymentDue = Decimal.Parse(txt_due.Text),
                Discount = Decimal.Parse(txt_discount.Text),
                BarcodeNum = txt_barcode.Text

                };
                CustomerRepositiry custrepo = new CustomerRepositiry();
                custrepo.UpdateCustomer(CTGRY);
                MessageBox.Show("Sucessfully Updated");
                clearcontrol();
                LoadAllcustomer();
            }
        }

        private void dgv_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            seleectcustomer(e);
        }

        private void btn_searcharea_TextChanged(object sender, EventArgs e)
        {
            string texttodearch = btn_searcharea.Text.Trim();
            CustomerRepositiry custrepo = new CustomerRepositiry();
            List<Customer> customerlist = custrepo.GetcustomerofLocation(texttodearch, Program.LocationID);
            loadcustomer(customerlist);

        }

        private void dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            seleectcustomer(e);
        }

        public void seleectcustomer(DataGridViewCellEventArgs e)
        {
            SelectedCustomerID = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            SelectedCustomerName = dgv.Rows[e.RowIndex].Cells["CustomerName"].Value.ToString();
            this.Close();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lbl_cutomerid.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();

            txt_name.Text = dgv.Rows[e.RowIndex].Cells["CustomerName"].Value.ToString();
            txt_mobnumber.Text = dgv.Rows[e.RowIndex].Cells["PhoneNumber"].Value.ToString();
            txt_address.Text = dgv.Rows[e.RowIndex].Cells["CustomerDetails"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
