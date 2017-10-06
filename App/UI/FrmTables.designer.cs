namespace App.UI
{
    partial class FrmTables
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTables));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnl_table = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.pnl_table.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "if_cart-empty_126588 (2).ico");
            this.imageList1.Images.SetKeyName(1, "if_cart-empty_126588 (1).ico");
            this.imageList1.Images.SetKeyName(2, "if_cart-empty_126588.ico");
            this.imageList1.Images.SetKeyName(3, "if_equipmentrental_2318443.png");
            this.imageList1.Images.SetKeyName(4, "256-256-d13cafbf17ecd8f2065c8842a6e4e228.png");
            this.imageList1.Images.SetKeyName(5, "45200.png");
            // 
            // pnl_table
            // 
            this.pnl_table.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(225)))), ((int)(((byte)(235)))));
            this.pnl_table.Controls.Add(this.button9);
            this.pnl_table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_table.Location = new System.Drawing.Point(0, 0);
            this.pnl_table.Name = "pnl_table";
            this.pnl_table.Size = new System.Drawing.Size(739, 420);
            this.pnl_table.TabIndex = 22;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(121)))), ((int)(((byte)(166)))));
            this.button9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(39, 35);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(126, 81);
            this.button9.TabIndex = 1;
            this.button9.Text = "TABLE 1";
            this.button9.UseVisualStyleBackColor = false;
            // 
            // FrmTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 420);
            this.Controls.Add(this.pnl_table);
            this.Name = "FrmTables";
            this.ShowIcon = false;
            this.Text = "Tables";
            this.pnl_table.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel pnl_table;
        private System.Windows.Forms.Button button9;
    }
}