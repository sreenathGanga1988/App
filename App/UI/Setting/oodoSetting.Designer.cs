﻿namespace App.UI.Setting
{
    partial class oodoSetting
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_saveodoosetting = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbDataBaseName = new System.Windows.Forms.TextBox();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chk_fastloading = new System.Windows.Forms.CheckBox();
            this.chk_realtime = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txt_noofproductonrow = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_invoiceprefix = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_padding = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_buttonHeight = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_buttonwidth = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chk_autosizeproduct = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(985, 347);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 328);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_saveodoosetting);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.tbPort);
            this.groupBox2.Controls.Add(this.tbUser);
            this.groupBox2.Controls.Add(this.tbPass);
            this.groupBox2.Controls.Add(this.tbDataBaseName);
            this.groupBox2.Controls.Add(this.tbHost);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 316);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ODOO Settings";
            // 
            // btn_saveodoosetting
            // 
            this.btn_saveodoosetting.Enabled = false;
            this.btn_saveodoosetting.Location = new System.Drawing.Point(109, 254);
            this.btn_saveodoosetting.Name = "btn_saveodoosetting";
            this.btn_saveodoosetting.Size = new System.Drawing.Size(78, 31);
            this.btn_saveodoosetting.TabIndex = 14;
            this.btn_saveodoosetting.Text = "Save";
            this.btn_saveodoosetting.UseVisualStyleBackColor = true;
            this.btn_saveodoosetting.Click += new System.EventHandler(this.btn_saveodoosetting_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 285);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 31);
            this.button1.TabIndex = 13;
            this.button1.Text = "Test Connection";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(109, 69);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(100, 20);
            this.tbPort.TabIndex = 12;
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(109, 124);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(100, 20);
            this.tbUser.TabIndex = 11;
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(109, 171);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(100, 20);
            this.tbPass.TabIndex = 10;
            // 
            // tbDataBaseName
            // 
            this.tbDataBaseName.Location = new System.Drawing.Point(109, 228);
            this.tbDataBaseName.Name = "tbDataBaseName";
            this.tbDataBaseName.Size = new System.Drawing.Size(100, 20);
            this.tbDataBaseName.TabIndex = 9;
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(109, 30);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(100, 20);
            this.tbHost.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Port";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "User ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "PassWord";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "DataBase";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(294, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(688, 328);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chk_autosizeproduct);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.txt_buttonHeight);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txt_buttonwidth);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txt_padding);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txt_invoiceprefix);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.chk_fastloading);
            this.groupBox3.Controls.Add(this.chk_realtime);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.txt_noofproductonrow);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(21, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(306, 312);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Application Setting";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(18, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(169, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "(Willnot Update Inventory realtime)";
            // 
            // chk_fastloading
            // 
            this.chk_fastloading.AutoSize = true;
            this.chk_fastloading.Location = new System.Drawing.Point(235, 47);
            this.chk_fastloading.Name = "chk_fastloading";
            this.chk_fastloading.Size = new System.Drawing.Size(15, 14);
            this.chk_fastloading.TabIndex = 16;
            this.chk_fastloading.UseVisualStyleBackColor = true;
            // 
            // chk_realtime
            // 
            this.chk_realtime.AutoSize = true;
            this.chk_realtime.Location = new System.Drawing.Point(235, 19);
            this.chk_realtime.Name = "chk_realtime";
            this.chk_realtime.Size = new System.Drawing.Size(15, 14);
            this.chk_realtime.TabIndex = 15;
            this.chk_realtime.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(133, 269);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(78, 31);
            this.button3.TabIndex = 14;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // txt_noofproductonrow
            // 
            this.txt_noofproductonrow.Location = new System.Drawing.Point(235, 112);
            this.txt_noofproductonrow.Name = "txt_noofproductonrow";
            this.txt_noofproductonrow.Size = new System.Drawing.Size(41, 20);
            this.txt_noofproductonrow.TabIndex = 11;
            this.txt_noofproductonrow.Text = "6";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ennable Fast loading of product";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "No of Product Tab on a Row";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(151, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Real time Invoice Update";
            // 
            // txt_invoiceprefix
            // 
            this.txt_invoiceprefix.Location = new System.Drawing.Point(235, 140);
            this.txt_invoiceprefix.Name = "txt_invoiceprefix";
            this.txt_invoiceprefix.Size = new System.Drawing.Size(41, 20);
            this.txt_invoiceprefix.TabIndex = 19;
            this.txt_invoiceprefix.Text = "LI";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(101, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Invoice prefix";
            // 
            // txt_padding
            // 
            this.txt_padding.Location = new System.Drawing.Point(235, 176);
            this.txt_padding.Name = "txt_padding";
            this.txt_padding.Size = new System.Drawing.Size(41, 20);
            this.txt_padding.TabIndex = 21;
            this.txt_padding.Text = "3";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(65, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Bill  number padding";
            // 
            // txt_buttonHeight
            // 
            this.txt_buttonHeight.Location = new System.Drawing.Point(235, 240);
            this.txt_buttonHeight.Name = "txt_buttonHeight";
            this.txt_buttonHeight.Size = new System.Drawing.Size(41, 20);
            this.txt_buttonHeight.TabIndex = 25;
            this.txt_buttonHeight.Text = "3";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(58, 243);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Product Button Height";
            // 
            // txt_buttonwidth
            // 
            this.txt_buttonwidth.Location = new System.Drawing.Point(235, 204);
            this.txt_buttonwidth.Name = "txt_buttonwidth";
            this.txt_buttonwidth.Size = new System.Drawing.Size(41, 20);
            this.txt_buttonwidth.TabIndex = 23;
            this.txt_buttonwidth.Text = "6";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(57, 211);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(129, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Product Button Width";
            // 
            // chk_autosizeproduct
            // 
            this.chk_autosizeproduct.AutoSize = true;
            this.chk_autosizeproduct.Checked = true;
            this.chk_autosizeproduct.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_autosizeproduct.Location = new System.Drawing.Point(235, 89);
            this.chk_autosizeproduct.Name = "chk_autosizeproduct";
            this.chk_autosizeproduct.Size = new System.Drawing.Size(15, 14);
            this.chk_autosizeproduct.TabIndex = 27;
            this.chk_autosizeproduct.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(36, 89);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Auto Size button";
            // 
            // oodoSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 347);
            this.Controls.Add(this.groupBox1);
            this.Name = "oodoSetting";
            this.Text = "Setting";
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_saveodoosetting;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.TextBox tbDataBaseName;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chk_fastloading;
        private System.Windows.Forms.CheckBox chk_realtime;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txt_noofproductonrow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_invoiceprefix;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_padding;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chk_autosizeproduct;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_buttonHeight;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_buttonwidth;
        private System.Windows.Forms.Label label13;
    }
}