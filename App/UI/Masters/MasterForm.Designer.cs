namespace App.UI.Masters
{
    partial class MasterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterForm));
            this.btn_customer = new System.Windows.Forms.Button();
            this.btn_product = new System.Windows.Forms.Button();
            this.panel25 = new System.Windows.Forms.Panel();
            this.btn_printer = new System.Windows.Forms.Button();
            this.btn_category = new System.Windows.Forms.Button();
            this.panel25.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_customer
            // 
            this.btn_customer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(121)))), ((int)(((byte)(166)))));
            this.btn_customer.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_customer.ForeColor = System.Drawing.Color.White;
            this.btn_customer.Image = ((System.Drawing.Image)(resources.GetObject("btn_customer.Image")));
            this.btn_customer.Location = new System.Drawing.Point(330, 52);
            this.btn_customer.Name = "btn_customer";
            this.btn_customer.Size = new System.Drawing.Size(198, 81);
            this.btn_customer.TabIndex = 22;
            this.btn_customer.Text = "CUSTOMER";
            this.btn_customer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_customer.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_customer.UseVisualStyleBackColor = false;
            this.btn_customer.Click += new System.EventHandler(this.btn_customer_Click);
            // 
            // btn_product
            // 
            this.btn_product.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(121)))), ((int)(((byte)(166)))));
            this.btn_product.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_product.ForeColor = System.Drawing.Color.White;
            this.btn_product.Image = ((System.Drawing.Image)(resources.GetObject("btn_product.Image")));
            this.btn_product.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_product.Location = new System.Drawing.Point(78, 52);
            this.btn_product.Name = "btn_product";
            this.btn_product.Size = new System.Drawing.Size(198, 81);
            this.btn_product.TabIndex = 21;
            this.btn_product.Text = "PRODUCT";
            this.btn_product.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_product.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_product.UseVisualStyleBackColor = false;
            this.btn_product.Click += new System.EventHandler(this.btn_product_Click);
            // 
            // panel25
            // 
            this.panel25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(225)))), ((int)(((byte)(235)))));
            this.panel25.Controls.Add(this.btn_printer);
            this.panel25.Controls.Add(this.btn_category);
            this.panel25.Controls.Add(this.btn_customer);
            this.panel25.Controls.Add(this.btn_product);
            this.panel25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel25.Location = new System.Drawing.Point(0, 0);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(675, 354);
            this.panel25.TabIndex = 24;
            // 
            // btn_printer
            // 
            this.btn_printer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(121)))), ((int)(((byte)(166)))));
            this.btn_printer.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_printer.ForeColor = System.Drawing.Color.White;
            this.btn_printer.Image = ((System.Drawing.Image)(resources.GetObject("btn_printer.Image")));
            this.btn_printer.Location = new System.Drawing.Point(330, 177);
            this.btn_printer.Name = "btn_printer";
            this.btn_printer.Size = new System.Drawing.Size(198, 81);
            this.btn_printer.TabIndex = 24;
            this.btn_printer.Text = "Printer";
            this.btn_printer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_printer.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_printer.UseVisualStyleBackColor = false;
            this.btn_printer.Click += new System.EventHandler(this.btn_printer_Click);
            // 
            // btn_category
            // 
            this.btn_category.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(121)))), ((int)(((byte)(166)))));
            this.btn_category.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_category.ForeColor = System.Drawing.Color.White;
            this.btn_category.Image = ((System.Drawing.Image)(resources.GetObject("btn_category.Image")));
            this.btn_category.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_category.Location = new System.Drawing.Point(78, 177);
            this.btn_category.Name = "btn_category";
            this.btn_category.Size = new System.Drawing.Size(198, 81);
            this.btn_category.TabIndex = 23;
            this.btn_category.Text = "Category";
            this.btn_category.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_category.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_category.UseVisualStyleBackColor = false;
            this.btn_category.Click += new System.EventHandler(this.btn_category_Click);
            // 
            // MasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 354);
            this.Controls.Add(this.panel25);
            this.Name = "MasterForm";
            this.Text = "MasterForm";
            this.panel25.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_customer;
        private System.Windows.Forms.Button btn_product;
        private System.Windows.Forms.Panel panel25;
        private System.Windows.Forms.Button btn_printer;
        private System.Windows.Forms.Button btn_category;
    }
}