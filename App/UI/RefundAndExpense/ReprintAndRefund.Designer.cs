namespace App.UI
{
    partial class ReprintAndRefund
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_invoiceId = new System.Windows.Forms.Label();
            this.lbl_invoice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_repreint = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_card = new System.Windows.Forms.Button();
            this.btn_cash = new System.Windows.Forms.Button();
            this.btn_zomato = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_paymentmode = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btn_repreint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 268);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(387, 94);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 101);
            this.button2.TabIndex = 3;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_paymentmode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbl_invoiceId);
            this.groupBox1.Controls.Add(this.lbl_invoice);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(564, 74);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Header";
            // 
            // lbl_invoiceId
            // 
            this.lbl_invoiceId.AutoSize = true;
            this.lbl_invoiceId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_invoiceId.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_invoiceId.Location = new System.Drawing.Point(267, 27);
            this.lbl_invoiceId.Name = "lbl_invoiceId";
            this.lbl_invoiceId.Size = new System.Drawing.Size(16, 20);
            this.lbl_invoiceId.TabIndex = 3;
            this.lbl_invoiceId.Text = "*";
            // 
            // lbl_invoice
            // 
            this.lbl_invoice.AutoSize = true;
            this.lbl_invoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_invoice.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_invoice.Location = new System.Drawing.Point(118, 19);
            this.lbl_invoice.Name = "lbl_invoice";
            this.lbl_invoice.Size = new System.Drawing.Size(16, 20);
            this.lbl_invoice.TabIndex = 2;
            this.lbl_invoice.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Invoice";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(195, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 101);
            this.button1.TabIndex = 1;
            this.button1.Text = "Refund";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_repreint
            // 
            this.btn_repreint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_repreint.Location = new System.Drawing.Point(12, 94);
            this.btn_repreint.Name = "btn_repreint";
            this.btn_repreint.Size = new System.Drawing.Size(156, 101);
            this.btn_repreint.TabIndex = 0;
            this.btn_repreint.Text = "RePrint";
            this.btn_repreint.UseVisualStyleBackColor = true;
            this.btn_repreint.Click += new System.EventHandler(this.btn_repreint_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSalmon;
            this.panel2.Controls.Add(this.btn_zomato);
            this.panel2.Controls.Add(this.btn_cash);
            this.panel2.Controls.Add(this.btn_card);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 204);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(564, 64);
            this.panel2.TabIndex = 4;
            // 
            // btn_card
            // 
            this.btn_card.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_card.Location = new System.Drawing.Point(12, 8);
            this.btn_card.Name = "btn_card";
            this.btn_card.Size = new System.Drawing.Size(152, 48);
            this.btn_card.TabIndex = 0;
            this.btn_card.Text = "Mark As Card";
            this.btn_card.UseVisualStyleBackColor = true;
            this.btn_card.Click += new System.EventHandler(this.btn_card_Click);
            // 
            // btn_cash
            // 
            this.btn_cash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_cash.Location = new System.Drawing.Point(195, 8);
            this.btn_cash.Name = "btn_cash";
            this.btn_cash.Size = new System.Drawing.Size(167, 48);
            this.btn_cash.TabIndex = 1;
            this.btn_cash.Text = "Mark As CASH";
            this.btn_cash.UseVisualStyleBackColor = true;
            this.btn_cash.Click += new System.EventHandler(this.btn_cash_Click);
            // 
            // btn_zomato
            // 
            this.btn_zomato.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_zomato.Location = new System.Drawing.Point(387, 8);
            this.btn_zomato.Name = "btn_zomato";
            this.btn_zomato.Size = new System.Drawing.Size(167, 48);
            this.btn_zomato.TabIndex = 2;
            this.btn_zomato.Text = "Mark As ZOMATO";
            this.btn_zomato.UseVisualStyleBackColor = true;
            this.btn_zomato.Click += new System.EventHandler(this.btn_zomato_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Payment :";
            // 
            // lbl_paymentmode
            // 
            this.lbl_paymentmode.AutoSize = true;
            this.lbl_paymentmode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_paymentmode.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_paymentmode.Location = new System.Drawing.Point(118, 51);
            this.lbl_paymentmode.Name = "lbl_paymentmode";
            this.lbl_paymentmode.Size = new System.Drawing.Size(16, 20);
            this.lbl_paymentmode.TabIndex = 5;
            this.lbl_paymentmode.Text = "*";
            // 
            // ReprintAndRefund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 268);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReprintAndRefund";
            this.Text = "ReprintAndRefund";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_repreint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_invoice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_invoiceId;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_card;
        private System.Windows.Forms.Button btn_zomato;
        private System.Windows.Forms.Button btn_cash;
        private System.Windows.Forms.Label lbl_paymentmode;
        private System.Windows.Forms.Label label2;
    }
}