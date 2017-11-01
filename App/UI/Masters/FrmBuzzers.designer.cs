namespace App.UI
{
    partial class FrmBuzzers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBuzzers));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnl_buzzer = new System.Windows.Forms.Panel();
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
            // pnl_buzzer
            // 
            this.pnl_buzzer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(225)))), ((int)(((byte)(235)))));
            this.pnl_buzzer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_buzzer.Location = new System.Drawing.Point(0, 0);
            this.pnl_buzzer.Name = "pnl_buzzer";
            this.pnl_buzzer.Size = new System.Drawing.Size(723, 381);
            this.pnl_buzzer.TabIndex = 22;
            // 
            // FrmBuzzers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 381);
            this.Controls.Add(this.pnl_buzzer);
            this.Name = "FrmBuzzers";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buzzers";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel pnl_buzzer;
    }
}