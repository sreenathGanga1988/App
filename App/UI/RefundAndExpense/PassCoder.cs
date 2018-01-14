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
    public partial class PassCoder : Form
    {
        public Boolean IsAuthenticated { get; set; }
        public String ApprovedCode { get; set; }
        public PassCoder()
        {
            InitializeComponent();
        }

        private void txt_PasscodeDisplay_TextChanged(object sender, EventArgs e)
        {

        }
        public void KeyPressed(Button btn)
        {

            if (btn.Text == "OK")
            {
                try
                {
                    if (txt_PasscodeDisplay.Text == "655443")
                {
                    IsAuthenticated = true;
                    ApprovedCode = txt_PasscodeDisplay.Text;
                    this.Close();
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_PasscodeDisplay.Text == "655443")
            {
                IsAuthenticated = true;
                this.Close();
            }
        }
        private void buttonclicked_Click(object sender, EventArgs e)
        {
            KeyPressed((Button)sender);
        }
      
    }
}
