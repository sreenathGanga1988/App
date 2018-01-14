using App.Extensions;
using App.Model;
using App.Repository;
using App.ViewModal;
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
    public partial class FrmBuzzers : Form
    {
        public FrmBuzzers()
        {
            InitializeComponent();


            SalesViewModal salesViewmodal = new SalesViewModal();
            LoadTable(salesViewmodal);
        }
        public int SelectedBuzzerIDID { get; set; }
        public String SelectedBuzzername { get; set; }
        public void LoadTable(SalesViewModal salesViewmodal)
        {

            Panel parent = this.pnl_buzzer;
            parent.Controls.Clear();
            int i = 0;
            int colcount = 0;
            int buttonheight = 0;
            int buttonwidth = 0;
            int buttonindex = 0;
            BuzzerRepository buzzerrepo = new BuzzerRepository();
            salesViewmodal.BuzzerList= buzzerrepo.GetBuzzerList(Program.LocationID);
            List<Buzzer> tableList = salesViewmodal.BuzzerList;



            if (tableList != null)
            {
                if (tableList.Count > 0)
                {

                    int tablecount = tableList.Count;

                    float parentheight = float.Parse(parent.Height.ToString());
                    float parentwidth = float.Parse(parent.Width.ToString());
                    buttonwidth = (int)Math.Ceiling(parentwidth) / 4;

                    buttonheight = buttonwidth;
                }
            }

            foreach (Buzzer product in tableList)
            {
                ValueButton temp = new ValueButton();

                // 
                temp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(121)))), ((int)(((byte)(166)))));
                temp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                temp.ForeColor = System.Drawing.Color.White;
                temp.Location = new System.Drawing.Point(35, 19);

                temp.Size = new System.Drawing.Size(108, 81);
                temp.TabIndex = 12;
                temp.Text = "button24";
                temp.UseVisualStyleBackColor = false;

                temp.Name = "button" + product.BuzzerID.ToString();
                temp.Text = product.BuzzerName;
                temp._value = product.BuzzerID.ToString();
                

                temp.Font = new Font(temp.Font, FontStyle.Bold);

              
                try
                {
                    if (product.IsLocked != true)
                    {
                        //temp.BackColor = System.Drawing.Color.LightSalmon;
                    }
                    else
                    {
                        temp.BackColor = System.Drawing.Color.LightSalmon;
                    }
                }
                catch (Exception)
                {
                    
                }


                //   temp.Location = new System.Drawing.Point((buttonwidth * buttonindex), (buttonheight * colcount));//please adjust location as per your need
                temp.Location = new System.Drawing.Point((temp.Width * buttonindex), (temp.Height * colcount));//please adjust location as per your need
                if (buttonindex % 4 == 0 && buttonindex != 0)
                {
                    colcount++;
                    buttonindex = 0;


                }
                else
                {
                    buttonindex++;
                }
                temp.Tag = i;

                temp.Click += new EventHandler(OnTableButtonClick);

                parent.Controls.Add(temp);
                i++;
            }


        }



        public void BuzzerclickAction()
        {




        }

        private void OnTableButtonClick(object sender, EventArgs e)
        {

            BuzzerRepository buzzerrepo = new BuzzerRepository();

            if (buzzerrepo.IsBuzzerAlloted(int.Parse(((ValueButton)sender)._value),Program.LocationID))
            {
                buzzerrepo.MarkBuzzerLockedorUnlocked(int.Parse(((ValueButton)sender)._value), Program.LocationID, false);
                MessageBox.Show("SucCess  Fully DeAllocated the Buzzer");
            }
            else
            {
                buzzerrepo.MarkBuzzerLockedorUnlocked(int.Parse(((ValueButton)sender)._value), Program.LocationID, true);
                SelectedBuzzerIDID = int.Parse(((ValueButton)sender)._value);
                SelectedBuzzername = ((ValueButton)sender).Text;

            }

           
            this.Close();

            //your code for the event.
        }

    }
}




