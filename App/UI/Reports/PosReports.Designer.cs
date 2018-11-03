namespace App.UI.Reports
{
    partial class PosReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PosReports));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lbl_totalPaid = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel20 = new System.Windows.Forms.Panel();
            this.tc_report = new System.Windows.Forms.TabControl();
            this.tpg_credit = new System.Windows.Forms.TabPage();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.CreditMasterID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_searcharea = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel20.SuspendLayout();
            this.tc_report.SuspendLayout();
            this.tpg_credit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(926, 3);
            this.panel2.TabIndex = 26;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 457);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(926, 38);
            this.panel6.TabIndex = 31;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.panel7.Controls.Add(this.lbl_totalPaid);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(5, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(921, 38);
            this.panel7.TabIndex = 29;
            this.panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.panel7_Paint);
            // 
            // lbl_totalPaid
            // 
            this.lbl_totalPaid.AutoSize = true;
            this.lbl_totalPaid.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_totalPaid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(225)))), ((int)(((byte)(235)))));
            this.lbl_totalPaid.Location = new System.Drawing.Point(393, 8);
            this.lbl_totalPaid.Name = "lbl_totalPaid";
            this.lbl_totalPaid.Size = new System.Drawing.Size(226, 18);
            this.lbl_totalPaid.TabIndex = 1;
            this.lbl_totalPaid.Text = "Total Amount is AED 1000.00";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(5, 38);
            this.panel8.TabIndex = 28;
            // 
            // panel20
            // 
            this.panel20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.panel20.Controls.Add(this.tc_report);
            this.panel20.Controls.Add(this.panel6);
            this.panel20.Controls.Add(this.panel2);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel20.Location = new System.Drawing.Point(0, 0);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(926, 495);
            this.panel20.TabIndex = 5;
            // 
            // tc_report
            // 
            this.tc_report.Controls.Add(this.tpg_credit);
            this.tc_report.Controls.Add(this.tabPage2);
            this.tc_report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_report.ItemSize = new System.Drawing.Size(100, 30);
            this.tc_report.Location = new System.Drawing.Point(0, 3);
            this.tc_report.Name = "tc_report";
            this.tc_report.SelectedIndex = 0;
            this.tc_report.Size = new System.Drawing.Size(926, 454);
            this.tc_report.TabIndex = 32;
            // 
            // tpg_credit
            // 
            this.tpg_credit.Controls.Add(this.dgv);
            this.tpg_credit.Controls.Add(this.panel1);
            this.tpg_credit.Location = new System.Drawing.Point(4, 34);
            this.tpg_credit.Name = "tpg_credit";
            this.tpg_credit.Padding = new System.Windows.Forms.Padding(3);
            this.tpg_credit.Size = new System.Drawing.Size(918, 416);
            this.tpg_credit.TabIndex = 0;
            this.tpg_credit.Text = "Credits";
            this.tpg_credit.UseVisualStyleBackColor = true;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CreditMasterID,
            this.CustomerName,
            this.PhoneNumber,
            this.InvoiceDate,
            this.InvoiceNum,
            this.PaymentDue});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.GridColor = System.Drawing.Color.White;
            this.dgv.Location = new System.Drawing.Point(3, 68);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(912, 345);
            this.dgv.TabIndex = 28;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // CreditMasterID
            // 
            this.CreditMasterID.HeaderText = "CreditMasterID";
            this.CreditMasterID.Name = "CreditMasterID";
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "CustomerName";
            this.CustomerName.Name = "CustomerName";
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.HeaderText = "PhoneNumber";
            this.PhoneNumber.Name = "PhoneNumber";
            // 
            // InvoiceDate
            // 
            this.InvoiceDate.HeaderText = "Invoice Date ";
            this.InvoiceDate.Name = "InvoiceDate";
            // 
            // InvoiceNum
            // 
            this.InvoiceNum.HeaderText = "Invoice #";
            this.InvoiceNum.Name = "InvoiceNum";
            // 
            // PaymentDue
            // 
            this.PaymentDue.HeaderText = "PaymentDue";
            this.PaymentDue.Name = "PaymentDue";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(912, 65);
            this.panel1.TabIndex = 27;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_searcharea);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(912, 65);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criteria";
            // 
            // btn_searcharea
            // 
            this.btn_searcharea.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_searcharea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.btn_searcharea.Location = new System.Drawing.Point(6, 19);
            this.btn_searcharea.Multiline = true;
            this.btn_searcharea.Name = "btn_searcharea";
            this.btn_searcharea.Size = new System.Drawing.Size(611, 30);
            this.btn_searcharea.TabIndex = 1;
            this.btn_searcharea.Text = "Search Customer";
            this.btn_searcharea.TextChanged += new System.EventHandler(this.btn_searcharea_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(918, 416);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // PosReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 495);
            this.Controls.Add(this.panel20);
            this.Name = "PosReports";
            this.Text = "PosReports";
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel20.ResumeLayout(false);
            this.tc_report.ResumeLayout(false);
            this.tpg_credit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lbl_totalPaid;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.TabControl tc_report;
        private System.Windows.Forms.TabPage tpg_credit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox btn_searcharea;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditMasterID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentDue;
    }
}