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
            loadcustomer();
        }

        
        public void loadcustomer()
        {
           
            CustomerRepositiry custrepo = new CustomerRepositiry();
            List<Customer> customerlist= custrepo.GetcustomerofLocation(Program.LocationID);
            foreach(Customer customer in customerlist)
            {
                var index = dgv.Rows.Add();
                dgv.Rows[index].Cells["CustomerID"].Value = customer.CustomerID.ToString();
                dgv.Rows[index].Cells["CustomerName"].Value = customer.CustomerName.ToString();
                dgv.Rows[index].Cells["PhoneNumber"].Value = customer.PhoneNumber == null ? "" : customer.PhoneNumber.ToString(); 
              
                dgv.Rows[index].Cells["CustomerDetails"].Value = customer.CustomerDetails == null ? "" : customer.CustomerDetails.ToString(); 
            }
            
        }

     

      
        private void btn_addCustomer_Click(object sender, EventArgs e)
        {
            if (lbl_cutomerid.Text == "0")
            {
                Customer customer = new Customer();
                customer.CustomerName = txt_name.Text.Trim();
                customer.PhoneNumber = txt_mobnumber.Text.Trim();
                customer.CustomerDetails = txt_address.Text.Trim();
                customer.StoreID = Program.LocationID;
                CustomerRepositiry custrepo = new CustomerRepositiry();
                custrepo.AddCustomer(customer);
                MessageBox.Show("Customer Added");
                loadcustomer();
                clearcontrol();
            }
        }
        public void clearcontrol()
        {
            lbl_cutomerid.Text = "0";
            txt_name.Text = "";
            txt_mobnumber.Text = "";
            txt_address.Text = "";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {

        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lbl_cutomerid.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
          
            txt_name.Text = dgv.Rows[e.RowIndex].Cells["CustomerName"].Value.ToString();
            txt_mobnumber.Text = dgv.Rows[e.RowIndex].Cells["PhoneNumber"].Value.ToString();
            txt_address.Text = dgv.Rows[e.RowIndex].Cells["CustomerDetails"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lbl_cutomerid.Text != "0")
            {

                Customer CTGRY = new Customer() { CustomerName = txt_name.Text, CustomerID = int.Parse(lbl_cutomerid.Text),PhoneNumber = txt_mobnumber.Text, CustomerDetails = txt_address.Text ,StoreID=Program.LocationID};
                CustomerRepositiry custrepo = new CustomerRepositiry();
                custrepo.UpdateCustomer(CTGRY);
                MessageBox.Show("Sucessfully Updated");
                clearcontrol();
                loadcustomer();
            }
        }
    }
}
