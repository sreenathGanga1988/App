namespace App.UI
{
    partial class SalesForm
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
            this.grp_table = new System.Windows.Forms.GroupBox();
            this.pnl_left = new System.Windows.Forms.Panel();
            this.pnl_category = new System.Windows.Forms.Panel();
            this.Paneltable = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pnl_product = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.grp_table.SuspendLayout();
            this.pnl_left.SuspendLayout();
            this.Paneltable.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_table
            // 
            this.grp_table.Controls.Add(this.button4);
            this.grp_table.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp_table.Location = new System.Drawing.Point(0, 0);
            this.grp_table.Name = "grp_table";
            this.grp_table.Size = new System.Drawing.Size(809, 50);
            this.grp_table.TabIndex = 0;
            this.grp_table.TabStop = false;
            this.grp_table.Text = "Action";
            // 
            // pnl_left
            // 
            this.pnl_left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.pnl_left.Controls.Add(this.pnl_category);
            this.pnl_left.Controls.Add(this.Paneltable);
            this.pnl_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_left.Location = new System.Drawing.Point(0, 50);
            this.pnl_left.Name = "pnl_left";
            this.pnl_left.Size = new System.Drawing.Size(250, 542);
            this.pnl_left.TabIndex = 2;
            // 
            // pnl_category
            // 
            this.pnl_category.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_category.Location = new System.Drawing.Point(0, 36);
            this.pnl_category.Name = "pnl_category";
            this.pnl_category.Size = new System.Drawing.Size(250, 506);
            this.pnl_category.TabIndex = 3;
            // 
            // Paneltable
            // 
            this.Paneltable.Controls.Add(this.panel6);
            this.Paneltable.Dock = System.Windows.Forms.DockStyle.Top;
            this.Paneltable.Location = new System.Drawing.Point(0, 0);
            this.Paneltable.Name = "Paneltable";
            this.Paneltable.Size = new System.Drawing.Size(250, 36);
            this.Paneltable.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(187)))), ((int)(((byte)(166)))));
            this.panel6.Controls.Add(this.label5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(250, 31);
            this.panel6.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(60, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Category";
            // 
            // pnl_product
            // 
            this.pnl_product.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_product.Location = new System.Drawing.Point(250, 50);
            this.pnl_product.Name = "pnl_product";
            this.pnl_product.Size = new System.Drawing.Size(559, 542);
            this.pnl_product.TabIndex = 15;
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.DarkRed;
            this.button4.Location = new System.Drawing.Point(12, 7);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(258, 37);
            this.button4.TabIndex = 18;
            this.button4.Text = "Update Availability";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // SalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(809, 592);
            this.Controls.Add(this.pnl_product);
            this.Controls.Add(this.pnl_left);
            this.Controls.Add(this.grp_table);
            this.KeyPreview = true;
            this.Name = "SalesForm";
            this.Text = "Product Availability";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.grp_table.ResumeLayout(false);
            this.pnl_left.ResumeLayout(false);
            this.Paneltable.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grp_table;
        private System.Windows.Forms.Panel pnl_left;
        private System.Windows.Forms.Panel pnl_category;
        private System.Windows.Forms.Panel Paneltable;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnl_product;
        private System.Windows.Forms.Button button4;
    }
}