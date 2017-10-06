using App.Extensions;
using App.Model;
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
    public partial class FrmTables : Form
    {
        public FrmTables()
        {
            InitializeComponent();
            SalesViewModal salesViewmodal = new SalesViewModal();
            LoadTable(salesViewmodal);
        }

        public void LoadTable(SalesViewModal salesViewmodal)
        {

            Panel parent = this.pnl_table;
            parent.Controls.Clear();
            int i = 0;
            int colcount = 0;
            int buttonheight = 0;
            int buttonwidth = 0;
            int buttonindex = 0;
            List<Table> tableList = salesViewmodal.TableList;



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

            foreach (Table product in tableList)
            {
                ValueButton temp = new ValueButton();

                // 
                temp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(121)))), ((int)(((byte)(166)))));
                temp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                temp.ForeColor = System.Drawing.Color.White;
                temp.Location = new System.Drawing.Point(6, 271);

                temp.Size = new System.Drawing.Size(126, 81);
                temp.TabIndex = 12;
                temp.Text = "button24";
                temp.UseVisualStyleBackColor = false;

                temp.Name = "button" + product.TableID.ToString();
                temp.Text = product.TableName;
                temp._value = product.TableID.ToString();
                // temp.AutoSize = true;

                temp.Font = new Font(temp.Font, FontStyle.Bold);

                //temp.Width = 200;
                //temp.Height = 150;
                try
                {
                    if (product.Color != null && product.Color.Trim() != "")
                    {
                        temp.BackColor = Color.FromName(product.Color);
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

                //temp.Click += new EventHandler(OnProductButtonClick);
                parent.Controls.Add(temp);
                i++;
            }


        }


    }
}
