using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.UI.POS
{
    public partial class FrmNotes : Form
    {
        public FrmNotes()
        {
            InitializeComponent();
        }
        public FrmNotes(String Notes)
        {
            InitializeComponent();
            richTextBox1.Text = Notes;
        }
        public String Selectednote { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Selectednote = richTextBox1.Text;
            this.Close();
        }
    }
}
