using App.Context;
using App.Model;
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
    public partial class Login : Form
    {
        public Login()
        {

            InitializeComponent();

            Company objCompany = new Company();
            objCompany.CompanyId = DateTime.Now.ToString();
            objCompany.Name = "Sree";

          //  Create context object and then save company data.  
            POSDataContext objContext = new POSDataContext();
            objContext.Companies.Add(objCompany);
           objContext.SaveChanges();


        }


        public void KeyPressed(Button btn)
        {

            if(btn.Text=="OK")
            {

                try
                {
                    Repository.UserRepository usrrep = new Repository.UserRepository();

                    if (usrrep.IsuserValid(int.Parse(txt_PasscodeDisplay.Text)))
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
            else if(btn.Text == "Back")
            {
                txt_PasscodeDisplay.Text = Extensions.MyExtensions.TrimLastCharacter(txt_PasscodeDisplay.Text);
                    
            }
            else
            {
                txt_PasscodeDisplay.Text = txt_PasscodeDisplay.Text.Trim() + btn.Text.Trim();
            }
          
        }

        private void buttonclicked_Click(object sender, EventArgs e)
        {
            KeyPressed ((Button)sender);
        }
    }
}
