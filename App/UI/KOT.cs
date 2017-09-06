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
            ShowKot();
        }



        public void ShowKot()
        {

            KotRepository kotrepo = new KotRepository();
            List<KotMaster> kotmasters = kotrepo.GetKotPending(Program.LocationID);
            LoadKots(kotmasters);

        }



        public void LoadKots(List<KotMaster> Kotmasters)
        {

            Panel parent = this.pnl_kot;
            parent.Controls.Clear();
            int i = 0;
            int colcount = 0;
            int buttonheight = 0;
            int buttonwidth = 0;
            int buttonindex = 0;



            if (Kotmasters != null)
            {
                if (Kotmasters.Count > 0)
                {

                    int tablecount = Kotmasters.Count;

                    float parentheight = float.Parse(parent.Height.ToString());
                    float parentwidth = float.Parse(parent.Width.ToString());
                    buttonwidth = (int)Math.Ceiling(parentwidth) / 6;

                    buttonheight = buttonwidth;
                }
            }

            foreach (KotMaster kotMaster in Kotmasters)
            {
                ValueButton temp = new ValueButton();
                temp.Name = "button" + kotMaster.KotMasterID.ToString();
                temp.Text = kotMaster.KotNum+" / " +kotMaster.Table.TableName + " / " + kotMaster.KotDetails.Count()+"Items";
                temp._value = kotMaster.KotMasterID.ToString();
                // temp.AutoSize = true;
                temp.Width = buttonwidth;
                temp.Height = buttonheight;
                temp.Font = new Font(temp.Font, FontStyle.Bold);

                //temp.Width = 200;
                //temp.Height = 150;
                try
                {
                    if (kotMaster.Color != null && kotMaster.Color.Trim() != "")
                    {
                        temp.BackColor = Color.FromName(kotMaster.Color);
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

              //  temp.Click += new EventHandler(OnProductButtonClick);
                parent.Controls.Add(temp);
                i++;
            }
            parent.AutoScroll = true;
        }
    }
}
