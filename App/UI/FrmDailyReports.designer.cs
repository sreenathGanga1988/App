namespace App.UI
{
    partial class FrmDailyReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDailyReports));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rbt_checkout = new System.Windows.Forms.RadioButton();
            this.rbt_hold = new System.Windows.Forms.RadioButton();
            this.rbt_KOT = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_todaysale = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbt_zomato = new System.Windows.Forms.RadioButton();
            this.rbt_all = new System.Windows.Forms.RadioButton();
            this.rbt_card = new System.Windows.Forms.RadioButton();
            this.rbt_credit = new System.Windows.Forms.RadioButton();
            this.rbt_cash = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.lbl_totalPaid = new System.Windows.Forms.TextBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel20 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panel21 = new System.Windows.Forms.Panel();
            this.panel19 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.btn_updateOdoo = new System.Windows.Forms.Button();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel18.SuspendLayout();
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
            this.panel2.Size = new System.Drawing.Size(985, 3);
            this.panel2.TabIndex = 26;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(985, 82);
            this.panel1.TabIndex = 27;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btn_todaysale);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(985, 82);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criteria";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Controls.Add(this.rbt_checkout);
            this.groupBox3.Controls.Add(this.rbt_hold);
            this.groupBox3.Controls.Add(this.rbt_KOT);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.groupBox3.Location = new System.Drawing.Point(391, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(272, 63);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(226, 21);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(39, 17);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "All";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_1);
            // 
            // rbt_checkout
            // 
            this.rbt_checkout.AutoSize = true;
            this.rbt_checkout.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_checkout.Location = new System.Drawing.Point(141, 21);
            this.rbt_checkout.Name = "rbt_checkout";
            this.rbt_checkout.Size = new System.Drawing.Size(79, 17);
            this.rbt_checkout.TabIndex = 6;
            this.rbt_checkout.TabStop = true;
            this.rbt_checkout.Text = "CheckOut";
            this.rbt_checkout.UseVisualStyleBackColor = true;
            this.rbt_checkout.CheckedChanged += new System.EventHandler(this.rbt_checkout_CheckedChanged);
            // 
            // rbt_hold
            // 
            this.rbt_hold.AutoSize = true;
            this.rbt_hold.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_hold.Location = new System.Drawing.Point(76, 21);
            this.rbt_hold.Name = "rbt_hold";
            this.rbt_hold.Size = new System.Drawing.Size(50, 17);
            this.rbt_hold.TabIndex = 5;
            this.rbt_hold.TabStop = true;
            this.rbt_hold.Text = "Hold";
            this.rbt_hold.UseVisualStyleBackColor = true;
            this.rbt_hold.CheckedChanged += new System.EventHandler(this.rbt_hold_CheckedChanged);
            // 
            // rbt_KOT
            // 
            this.rbt_KOT.AutoSize = true;
            this.rbt_KOT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_KOT.Location = new System.Drawing.Point(18, 21);
            this.rbt_KOT.Name = "rbt_KOT";
            this.rbt_KOT.Size = new System.Drawing.Size(47, 17);
            this.rbt_KOT.TabIndex = 4;
            this.rbt_KOT.TabStop = true;
            this.rbt_KOT.Text = "KOT";
            this.rbt_KOT.UseVisualStyleBackColor = true;
            this.rbt_KOT.CheckedChanged += new System.EventHandler(this.rbt_KOT_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Peru;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(121, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 50);
            this.button1.TabIndex = 11;
            this.button1.Text = "Shift Sale";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_todaysale
            // 
            this.btn_todaysale.BackColor = System.Drawing.Color.Peru;
            this.btn_todaysale.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btn_todaysale.Location = new System.Drawing.Point(12, 20);
            this.btn_todaysale.Name = "btn_todaysale";
            this.btn_todaysale.Size = new System.Drawing.Size(93, 50);
            this.btn_todaysale.TabIndex = 10;
            this.btn_todaysale.Text = "Todays Sale";
            this.btn_todaysale.UseVisualStyleBackColor = false;
            this.btn_todaysale.Click += new System.EventHandler(this.btn_todaysale_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbt_zomato);
            this.groupBox2.Controls.Add(this.rbt_all);
            this.groupBox2.Controls.Add(this.rbt_card);
            this.groupBox2.Controls.Add(this.rbt_credit);
            this.groupBox2.Controls.Add(this.rbt_cash);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.groupBox2.Location = new System.Drawing.Point(663, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 63);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mode";
            // 
            // rbt_zomato
            // 
            this.rbt_zomato.AutoSize = true;
            this.rbt_zomato.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_zomato.Location = new System.Drawing.Point(201, 19);
            this.rbt_zomato.Name = "rbt_zomato";
            this.rbt_zomato.Size = new System.Drawing.Size(69, 17);
            this.rbt_zomato.TabIndex = 8;
            this.rbt_zomato.TabStop = true;
            this.rbt_zomato.Text = "Zomato";
            this.rbt_zomato.UseVisualStyleBackColor = true;
            this.rbt_zomato.CheckedChanged += new System.EventHandler(this.rbt_zomato_CheckedChanged);
            // 
            // rbt_all
            // 
            this.rbt_all.AutoSize = true;
            this.rbt_all.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_all.Location = new System.Drawing.Point(276, 19);
            this.rbt_all.Name = "rbt_all";
            this.rbt_all.Size = new System.Drawing.Size(39, 17);
            this.rbt_all.TabIndex = 7;
            this.rbt_all.TabStop = true;
            this.rbt_all.Text = "All";
            this.rbt_all.UseVisualStyleBackColor = true;
            this.rbt_all.CheckedChanged += new System.EventHandler(this.rbt_all_CheckedChanged);
            // 
            // rbt_card
            // 
            this.rbt_card.AutoSize = true;
            this.rbt_card.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_card.Location = new System.Drawing.Point(144, 19);
            this.rbt_card.Name = "rbt_card";
            this.rbt_card.Size = new System.Drawing.Size(51, 17);
            this.rbt_card.TabIndex = 6;
            this.rbt_card.TabStop = true;
            this.rbt_card.Text = "Card";
            this.rbt_card.UseVisualStyleBackColor = true;
            this.rbt_card.CheckedChanged += new System.EventHandler(this.rbt_card_CheckedChanged);
            // 
            // rbt_credit
            // 
            this.rbt_credit.AutoSize = true;
            this.rbt_credit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_credit.Location = new System.Drawing.Point(79, 19);
            this.rbt_credit.Name = "rbt_credit";
            this.rbt_credit.Size = new System.Drawing.Size(59, 17);
            this.rbt_credit.TabIndex = 5;
            this.rbt_credit.TabStop = true;
            this.rbt_credit.Text = "Credit";
            this.rbt_credit.UseVisualStyleBackColor = true;
            this.rbt_credit.CheckedChanged += new System.EventHandler(this.rbt_credit_CheckedChanged);
            // 
            // rbt_cash
            // 
            this.rbt_cash.AutoSize = true;
            this.rbt_cash.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbt_cash.Location = new System.Drawing.Point(21, 19);
            this.rbt_cash.Name = "rbt_cash";
            this.rbt_cash.Size = new System.Drawing.Size(52, 17);
            this.rbt_cash.TabIndex = 4;
            this.rbt_cash.TabStop = true;
            this.rbt_cash.Text = "Cash";
            this.rbt_cash.UseVisualStyleBackColor = true;
            this.rbt_cash.CheckedChanged += new System.EventHandler(this.rbt_cash_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 85);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(985, 3);
            this.panel3.TabIndex = 28;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 88);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(985, 407);
            this.panel4.TabIndex = 29;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(985, 407);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "InvoiceMasterID";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 495);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(985, 3);
            this.panel5.TabIndex = 30;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.panel6.Controls.Add(this.panel10);
            this.panel6.Controls.Add(this.panel9);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 498);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(985, 38);
            this.panel6.TabIndex = 31;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.panel10.Controls.Add(this.panel15);
            this.panel10.Controls.Add(this.panel14);
            this.panel10.Controls.Add(this.panel13);
            this.panel10.Controls.Add(this.panel12);
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(816, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(169, 38);
            this.panel10.TabIndex = 30;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.panel15.Controls.Add(this.lbl_totalPaid);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(0, 6);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(169, 26);
            this.panel15.TabIndex = 31;
            // 
            // lbl_totalPaid
            // 
            this.lbl_totalPaid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_totalPaid.Location = new System.Drawing.Point(0, 0);
            this.lbl_totalPaid.Name = "lbl_totalPaid";
            this.lbl_totalPaid.Size = new System.Drawing.Size(169, 20);
            this.lbl_totalPaid.TabIndex = 0;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.panel14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel14.Location = new System.Drawing.Point(0, 32);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(169, 3);
            this.panel14.TabIndex = 30;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 3);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(169, 3);
            this.panel13.TabIndex = 29;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.panel12.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel12.Location = new System.Drawing.Point(0, 35);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(169, 3);
            this.panel12.TabIndex = 28;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(169, 3);
            this.panel11.TabIndex = 27;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.panel9.Controls.Add(this.label1);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(634, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(182, 38);
            this.panel9.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(65, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Sale Amount";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(629, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(5, 38);
            this.panel8.TabIndex = 28;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(629, 38);
            this.panel7.TabIndex = 27;
            // 
            // panel20
            // 
            this.panel20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.panel20.Controls.Add(this.panel17);
            this.panel20.Controls.Add(this.panel16);
            this.panel20.Controls.Add(this.panel6);
            this.panel20.Controls.Add(this.panel5);
            this.panel20.Controls.Add(this.panel4);
            this.panel20.Controls.Add(this.panel3);
            this.panel20.Controls.Add(this.panel1);
            this.panel20.Controls.Add(this.panel2);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel20.Location = new System.Drawing.Point(0, 0);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(985, 623);
            this.panel20.TabIndex = 4;
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.panel17.Controls.Add(this.panel21);
            this.panel17.Controls.Add(this.panel19);
            this.panel17.Controls.Add(this.panel18);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel17.Location = new System.Drawing.Point(0, 539);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(985, 84);
            this.panel17.TabIndex = 33;
            // 
            // panel21
            // 
            this.panel21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.panel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel21.Location = new System.Drawing.Point(0, 45);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(985, 39);
            this.panel21.TabIndex = 35;
            // 
            // panel19
            // 
            this.panel19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.panel19.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel19.Location = new System.Drawing.Point(0, 42);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(985, 3);
            this.panel19.TabIndex = 34;
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.panel18.Controls.Add(this.btn_updateOdoo);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel18.Location = new System.Drawing.Point(0, 0);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(985, 42);
            this.panel18.TabIndex = 33;
            // 
            // btn_updateOdoo
            // 
            this.btn_updateOdoo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_updateOdoo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_updateOdoo.Image = ((System.Drawing.Image)(resources.GetObject("btn_updateOdoo.Image")));
            this.btn_updateOdoo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_updateOdoo.Location = new System.Drawing.Point(0, 0);
            this.btn_updateOdoo.Name = "btn_updateOdoo";
            this.btn_updateOdoo.Size = new System.Drawing.Size(985, 42);
            this.btn_updateOdoo.TabIndex = 0;
            this.btn_updateOdoo.Text = "Update Odoo";
            this.btn_updateOdoo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_updateOdoo.UseVisualStyleBackColor = true;
            this.btn_updateOdoo.Click += new System.EventHandler(this.btn_updateOdoo_Click);
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.panel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(0, 536);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(985, 3);
            this.panel16.TabIndex = 32;
            // 
            // FrmDailyReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 623);
            this.Controls.Add(this.panel20);
            this.Name = "FrmDailyReports";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MIS Reports";
            this.Load += new System.EventHandler(this.FrmDailyReports_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel20.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_todaysale;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbt_all;
        private System.Windows.Forms.RadioButton rbt_card;
        private System.Windows.Forms.RadioButton rbt_credit;
        private System.Windows.Forms.RadioButton rbt_cash;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.TextBox lbl_totalPaid;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Button btn_updateOdoo;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.RadioButton rbt_zomato;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbt_checkout;
        private System.Windows.Forms.RadioButton rbt_hold;
        private System.Windows.Forms.RadioButton rbt_KOT;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}