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
            this.grp_bottompanel = new System.Windows.Forms.GroupBox();
            this.lbl_tableID = new System.Windows.Forms.Label();
            this.lbl_custid = new System.Windows.Forms.Label();
            this.lbl_customer = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grp_Category = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grd_ProductDetails = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grp_btn = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button16 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.btn_addItembyCode = new System.Windows.Forms.Button();
            this.btn_changeQty = new System.Windows.Forms.Button();
            this.txt_producrtcode = new System.Windows.Forms.TextBox();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button17 = new System.Windows.Forms.Button();
            this.btn_printCheckOut = new System.Windows.Forms.Button();
            this.txt_change = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_cash = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_total = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_table = new System.Windows.Forms.TextBox();
            this.grp_table = new System.Windows.Forms.GroupBox();
            this.pnl_product = new System.Windows.Forms.Panel();
            this.button18 = new System.Windows.Forms.Button();
            this.grp_bottompanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_ProductDetails)).BeginInit();
            this.grp_btn.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_bottompanel
            // 
            this.grp_bottompanel.Controls.Add(this.lbl_tableID);
            this.grp_bottompanel.Controls.Add(this.lbl_custid);
            this.grp_bottompanel.Controls.Add(this.lbl_customer);
            this.grp_bottompanel.Controls.Add(this.label2);
            this.grp_bottompanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grp_bottompanel.Location = new System.Drawing.Point(0, 517);
            this.grp_bottompanel.Name = "grp_bottompanel";
            this.grp_bottompanel.Size = new System.Drawing.Size(809, 27);
            this.grp_bottompanel.TabIndex = 1;
            this.grp_bottompanel.TabStop = false;
            this.grp_bottompanel.Text = "Bottom";
            // 
            // lbl_tableID
            // 
            this.lbl_tableID.AutoSize = true;
            this.lbl_tableID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tableID.Location = new System.Drawing.Point(213, 13);
            this.lbl_tableID.Name = "lbl_tableID";
            this.lbl_tableID.Size = new System.Drawing.Size(16, 16);
            this.lbl_tableID.TabIndex = 3;
            this.lbl_tableID.Text = "1";
            this.lbl_tableID.Visible = false;
            // 
            // lbl_custid
            // 
            this.lbl_custid.AutoSize = true;
            this.lbl_custid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_custid.Location = new System.Drawing.Point(176, 13);
            this.lbl_custid.Name = "lbl_custid";
            this.lbl_custid.Size = new System.Drawing.Size(16, 16);
            this.lbl_custid.TabIndex = 2;
            this.lbl_custid.Text = "1";
            this.lbl_custid.Visible = false;
            // 
            // lbl_customer
            // 
            this.lbl_customer.AutoSize = true;
            this.lbl_customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_customer.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_customer.Location = new System.Drawing.Point(113, 13);
            this.lbl_customer.Name = "lbl_customer";
            this.lbl_customer.Size = new System.Drawing.Size(38, 16);
            this.lbl_customer.TabIndex = 1;
            this.lbl_customer.Text = "New";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Customer : ";
            // 
            // grp_Category
            // 
            this.grp_Category.Dock = System.Windows.Forms.DockStyle.Left;
            this.grp_Category.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_Category.Location = new System.Drawing.Point(0, 50);
            this.grp_Category.Name = "grp_Category";
            this.grp_Category.Size = new System.Drawing.Size(88, 467);
            this.grp_Category.TabIndex = 2;
            this.grp_Category.TabStop = false;
            this.grp_Category.Text = "Category";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.grp_btn);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(88, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 467);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bill";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grd_ProductDetails);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(438, 135);
            this.panel1.TabIndex = 1;
            // 
            // grd_ProductDetails
            // 
            this.grd_ProductDetails.AllowUserToAddRows = false;
            this.grd_ProductDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grd_ProductDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_ProductDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Item,
            this.Price,
            this.Qty,
            this.Discount,
            this.Total});
            this.grd_ProductDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_ProductDetails.Location = new System.Drawing.Point(0, 0);
            this.grd_ProductDetails.MultiSelect = false;
            this.grd_ProductDetails.Name = "grd_ProductDetails";
            this.grd_ProductDetails.RowHeadersVisible = false;
            this.grd_ProductDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grd_ProductDetails.Size = new System.Drawing.Size(438, 135);
            this.grd_ProductDetails.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Item
            // 
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            // 
            // Discount
            // 
            this.Discount.HeaderText = "Discount";
            this.Discount.Name = "Discount";
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // grp_btn
            // 
            this.grp_btn.Controls.Add(this.panel2);
            this.grp_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grp_btn.Location = new System.Drawing.Point(3, 151);
            this.grp_btn.Name = "grp_btn";
            this.grp_btn.Size = new System.Drawing.Size(438, 313);
            this.grp_btn.TabIndex = 0;
            this.grp_btn.TabStop = false;
            this.grp_btn.Text = "keyPad";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Info;
            this.panel2.Controls.Add(this.button18);
            this.panel2.Controls.Add(this.button16);
            this.panel2.Controls.Add(this.button14);
            this.panel2.Controls.Add(this.button13);
            this.panel2.Controls.Add(this.button15);
            this.panel2.Controls.Add(this.btn_addItembyCode);
            this.panel2.Controls.Add(this.btn_changeQty);
            this.panel2.Controls.Add(this.txt_producrtcode);
            this.panel2.Controls.Add(this.button11);
            this.panel2.Controls.Add(this.button10);
            this.panel2.Controls.Add(this.button12);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.button9);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(432, 294);
            this.panel2.TabIndex = 1;
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button16.Location = new System.Drawing.Point(319, 182);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(110, 39);
            this.button16.TabIndex = 20;
            this.button16.TabStop = false;
            this.button16.Text = "Cash";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.numericbuttonclicked_Click);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.Location = new System.Drawing.Point(160, 183);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(152, 43);
            this.button14.TabIndex = 19;
            this.button14.Text = "Clear";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.numericbuttonclicked_Click);
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.Location = new System.Drawing.Point(160, 121);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 56);
            this.button13.TabIndex = 18;
            this.button13.Text = ".";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.numericbuttonclicked_Click);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.Location = new System.Drawing.Point(320, 131);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(110, 39);
            this.button15.TabIndex = 17;
            this.button15.TabStop = false;
            this.button15.Text = "Customer";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.numericbuttonclicked_Click);
            // 
            // btn_addItembyCode
            // 
            this.btn_addItembyCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_addItembyCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addItembyCode.Location = new System.Drawing.Point(320, 38);
            this.btn_addItembyCode.Name = "btn_addItembyCode";
            this.btn_addItembyCode.Size = new System.Drawing.Size(110, 39);
            this.btn_addItembyCode.TabIndex = 16;
            this.btn_addItembyCode.TabStop = false;
            this.btn_addItembyCode.Text = "Add Item";
            this.btn_addItembyCode.UseVisualStyleBackColor = false;
            this.btn_addItembyCode.Click += new System.EventHandler(this.numericbuttonclicked_Click);
            // 
            // btn_changeQty
            // 
            this.btn_changeQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_changeQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_changeQty.Location = new System.Drawing.Point(320, 86);
            this.btn_changeQty.Name = "btn_changeQty";
            this.btn_changeQty.Size = new System.Drawing.Size(110, 39);
            this.btn_changeQty.TabIndex = 15;
            this.btn_changeQty.TabStop = false;
            this.btn_changeQty.Text = " Qty";
            this.btn_changeQty.UseVisualStyleBackColor = false;
            this.btn_changeQty.Click += new System.EventHandler(this.numericbuttonclicked_Click);
            // 
            // txt_producrtcode
            // 
            this.txt_producrtcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_producrtcode.Location = new System.Drawing.Point(325, 3);
            this.txt_producrtcode.Name = "txt_producrtcode";
            this.txt_producrtcode.Size = new System.Drawing.Size(100, 29);
            this.txt_producrtcode.TabIndex = 14;
            this.txt_producrtcode.Text = "0";
            this.txt_producrtcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Maroon;
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(4, 183);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(152, 43);
            this.button11.TabIndex = 13;
            this.button11.Text = "KOT";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.numericbuttonclicked_Click);
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(239, 121);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 56);
            this.button10.TabIndex = 12;
            this.button10.TabStop = false;
            this.button10.Text = "Back";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.numericbuttonclicked_Click);
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Location = new System.Drawing.Point(81, 121);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 56);
            this.button12.TabIndex = 10;
            this.button12.Text = "0";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.numericbuttonclicked_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(239, 62);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 56);
            this.button7.TabIndex = 9;
            this.button7.Text = "8";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.numericbuttonclicked_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(4, 122);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 56);
            this.button8.TabIndex = 8;
            this.button8.Text = "9";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.numericbuttonclicked_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(160, 61);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 56);
            this.button9.TabIndex = 7;
            this.button9.Text = "7";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.numericbuttonclicked_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(3, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 56);
            this.button2.TabIndex = 6;
            this.button2.Text = "5";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.numericbuttonclicked_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(82, 60);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 56);
            this.button5.TabIndex = 5;
            this.button5.Text = "6";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.numericbuttonclicked_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(239, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 56);
            this.button6.TabIndex = 4;
            this.button6.Text = "4";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.numericbuttonclicked_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(82, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 56);
            this.button4.TabIndex = 3;
            this.button4.Text = "2";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.numericbuttonclicked_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(160, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 56);
            this.button3.TabIndex = 2;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.numericbuttonclicked_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 56);
            this.button1.TabIndex = 0;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.numericbuttonclicked_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button17);
            this.groupBox2.Controls.Add(this.btn_printCheckOut);
            this.groupBox2.Controls.Add(this.txt_change);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_cash);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txt_total);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lbl_table);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(532, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(87, 467);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Summary";
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button17.Dock = System.Windows.Forms.DockStyle.Top;
            this.button17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.button17.Location = new System.Drawing.Point(3, 284);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(81, 80);
            this.button17.TabIndex = 8;
            this.button17.Text = "Check Out ";
            this.button17.UseVisualStyleBackColor = false;
            // 
            // btn_printCheckOut
            // 
            this.btn_printCheckOut.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_printCheckOut.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_printCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_printCheckOut.Location = new System.Drawing.Point(3, 204);
            this.btn_printCheckOut.Name = "btn_printCheckOut";
            this.btn_printCheckOut.Size = new System.Drawing.Size(81, 80);
            this.btn_printCheckOut.TabIndex = 7;
            this.btn_printCheckOut.Text = "Check Out (Bill)";
            this.btn_printCheckOut.UseVisualStyleBackColor = false;
            this.btn_printCheckOut.Click += new System.EventHandler(this.btn_printCheckOut_Click);
            // 
            // txt_change
            // 
            this.txt_change.Dock = System.Windows.Forms.DockStyle.Top;
            this.txt_change.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.txt_change.Location = new System.Drawing.Point(3, 175);
            this.txt_change.Name = "txt_change";
            this.txt_change.ReadOnly = true;
            this.txt_change.Size = new System.Drawing.Size(81, 29);
            this.txt_change.TabIndex = 6;
            this.txt_change.Text = "0";
            this.txt_change.TextChanged += new System.EventHandler(this.txt_change_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(3, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "Change";
            // 
            // txt_cash
            // 
            this.txt_cash.Dock = System.Windows.Forms.DockStyle.Top;
            this.txt_cash.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.txt_cash.Location = new System.Drawing.Point(3, 122);
            this.txt_cash.Name = "txt_cash";
            this.txt_cash.Size = new System.Drawing.Size(81, 29);
            this.txt_cash.TabIndex = 4;
            this.txt_cash.Text = "0";
            this.txt_cash.TextChanged += new System.EventHandler(this.txt_cash_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(3, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Cash";
            // 
            // txt_total
            // 
            this.txt_total.Dock = System.Windows.Forms.DockStyle.Top;
            this.txt_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.txt_total.Location = new System.Drawing.Point(3, 69);
            this.txt_total.Name = "txt_total";
            this.txt_total.ReadOnly = true;
            this.txt_total.Size = new System.Drawing.Size(81, 29);
            this.txt_total.TabIndex = 2;
            this.txt_total.Text = "0";
            this.txt_total.TextChanged += new System.EventHandler(this.txt_total_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total";
            // 
            // lbl_table
            // 
            this.lbl_table.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_table.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_table.Location = new System.Drawing.Point(3, 16);
            this.lbl_table.Name = "lbl_table";
            this.lbl_table.ReadOnly = true;
            this.lbl_table.Size = new System.Drawing.Size(81, 29);
            this.lbl_table.TabIndex = 0;
            // 
            // grp_table
            // 
            this.grp_table.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp_table.Location = new System.Drawing.Point(0, 0);
            this.grp_table.Name = "grp_table";
            this.grp_table.Size = new System.Drawing.Size(809, 50);
            this.grp_table.TabIndex = 0;
            this.grp_table.TabStop = false;
            this.grp_table.Text = "Tables";
            // 
            // pnl_product
            // 
            this.pnl_product.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_product.Location = new System.Drawing.Point(619, 50);
            this.pnl_product.Name = "pnl_product";
            this.pnl_product.Size = new System.Drawing.Size(190, 467);
            this.pnl_product.TabIndex = 8;
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.button18.Location = new System.Drawing.Point(5, 230);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(152, 43);
            this.button18.TabIndex = 21;
            this.button18.Text = "Table Bill";
            this.button18.UseVisualStyleBackColor = false;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // SalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(809, 544);
            this.Controls.Add(this.pnl_product);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grp_Category);
            this.Controls.Add(this.grp_bottompanel);
            this.Controls.Add(this.grp_table);
            this.KeyPreview = true;
            this.Name = "SalesForm";
            this.Text = "SalesForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SalesForm_KeyDown);
            this.grp_bottompanel.ResumeLayout(false);
            this.grp_bottompanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_ProductDetails)).EndInit();
            this.grp_btn.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grp_bottompanel;
        private System.Windows.Forms.GroupBox grp_Category;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grp_btn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView grd_ProductDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.TextBox txt_producrtcode;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button btn_addItembyCode;
        private System.Windows.Forms.Button btn_changeQty;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lbl_table;
        private System.Windows.Forms.TextBox txt_total;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.GroupBox grp_table;
        private System.Windows.Forms.Label lbl_custid;
        private System.Windows.Forms.Label lbl_customer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.TextBox txt_cash;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_change;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Panel pnl_product;
        private System.Windows.Forms.Label lbl_tableID;
        private System.Windows.Forms.Button btn_printCheckOut;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
    }
}