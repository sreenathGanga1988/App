namespace App.UI.RefundAndExpense
{
    partial class ValueInPut
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
            this.txt_PasscodeDisplay = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_message = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button13 = new System.Windows.Forms.Button();
            this.btn_Credit = new System.Windows.Forms.Button();
            this.btn_posAmount = new System.Windows.Forms.Button();
            this.btn_purchase = new System.Windows.Forms.Button();
            this.btn_refund = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_PasscodeDisplay);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 97);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Top";
            // 
            // txt_PasscodeDisplay
            // 
            this.txt_PasscodeDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PasscodeDisplay.Location = new System.Drawing.Point(0, 28);
            this.txt_PasscodeDisplay.Name = "txt_PasscodeDisplay";
            this.txt_PasscodeDisplay.Size = new System.Drawing.Size(467, 49);
            this.txt_PasscodeDisplay.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbl_message);
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 97);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(468, 393);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "KeyPad";
            // 
            // lbl_message
            // 
            this.lbl_message.AutoSize = true;
            this.lbl_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl_message.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_message.Location = new System.Drawing.Point(60, 340);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(18, 24);
            this.lbl_message.TabIndex = 1;
            this.lbl_message.Text = "*";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Info;
            this.panel2.Controls.Add(this.button13);
            this.panel2.Controls.Add(this.btn_Credit);
            this.panel2.Controls.Add(this.btn_posAmount);
            this.panel2.Controls.Add(this.btn_purchase);
            this.panel2.Controls.Add(this.btn_refund);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.button9);
            this.panel2.Controls.Add(this.button10);
            this.panel2.Controls.Add(this.button11);
            this.panel2.Controls.Add(this.button12);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(6, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(461, 328);
            this.panel2.TabIndex = 0;
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.Location = new System.Drawing.Point(103, 198);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 56);
            this.button13.TabIndex = 16;
            this.button13.Text = ".";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.buttonclicked_Click);
            // 
            // btn_Credit
            // 
            this.btn_Credit.Enabled = false;
            this.btn_Credit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Credit.Location = new System.Drawing.Point(278, 198);
            this.btn_Credit.Name = "btn_Credit";
            this.btn_Credit.Size = new System.Drawing.Size(171, 56);
            this.btn_Credit.TabIndex = 15;
            this.btn_Credit.Text = "Settle Credit";
            this.btn_Credit.UseVisualStyleBackColor = true;
            this.btn_Credit.Click += new System.EventHandler(this.btn_PosOut_Click);
            // 
            // btn_posAmount
            // 
            this.btn_posAmount.Enabled = false;
            this.btn_posAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_posAmount.Location = new System.Drawing.Point(278, 136);
            this.btn_posAmount.Name = "btn_posAmount";
            this.btn_posAmount.Size = new System.Drawing.Size(171, 56);
            this.btn_posAmount.TabIndex = 14;
            this.btn_posAmount.Text = "Cash In";
            this.btn_posAmount.UseVisualStyleBackColor = true;
            this.btn_posAmount.Click += new System.EventHandler(this.btn_posAmount_Click);
            // 
            // btn_purchase
            // 
            this.btn_purchase.Enabled = false;
            this.btn_purchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_purchase.Location = new System.Drawing.Point(278, 74);
            this.btn_purchase.Name = "btn_purchase";
            this.btn_purchase.Size = new System.Drawing.Size(171, 56);
            this.btn_purchase.TabIndex = 13;
            this.btn_purchase.Text = "Purchase";
            this.btn_purchase.UseVisualStyleBackColor = true;
            this.btn_purchase.Click += new System.EventHandler(this.btn_purchase_Click);
            // 
            // btn_refund
            // 
            this.btn_refund.Enabled = false;
            this.btn_refund.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refund.Location = new System.Drawing.Point(278, 12);
            this.btn_refund.Name = "btn_refund";
            this.btn_refund.Size = new System.Drawing.Size(171, 56);
            this.btn_refund.TabIndex = 12;
            this.btn_refund.Text = "Refund";
            this.btn_refund.UseVisualStyleBackColor = true;
            this.btn_refund.Click += new System.EventHandler(this.btn_refund_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(103, 136);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 56);
            this.button7.TabIndex = 11;
            this.button7.Text = "8";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.buttonclicked_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(193, 136);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 56);
            this.button8.TabIndex = 10;
            this.button8.Text = "9";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.buttonclicked_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(13, 198);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 56);
            this.button9.TabIndex = 9;
            this.button9.Text = "0";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.buttonclicked_Click);
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(193, 198);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 56);
            this.button10.TabIndex = 8;
            this.button10.Text = "OK";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.buttonclicked_Click);
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(13, 260);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(436, 56);
            this.button11.TabIndex = 7;
            this.button11.Text = "Back";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.buttonclicked_Click);
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Location = new System.Drawing.Point(13, 136);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 56);
            this.button12.TabIndex = 6;
            this.button12.Text = "7";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.buttonclicked_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(103, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 56);
            this.button6.TabIndex = 5;
            this.button6.Text = "2";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.buttonclicked_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(193, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 56);
            this.button5.TabIndex = 4;
            this.button5.Text = "3";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.buttonclicked_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(13, 74);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 56);
            this.button4.TabIndex = 3;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.buttonclicked_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(193, 74);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 56);
            this.button3.TabIndex = 2;
            this.button3.Text = "6";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.buttonclicked_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(103, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 56);
            this.button2.TabIndex = 1;
            this.button2.Text = "5";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonclicked_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(13, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 56);
            this.button1.TabIndex = 0;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonclicked_Click);
            // 
            // ValueInPut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 490);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "ValueInPut";
            this.Text = "ValueInPut";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_PasscodeDisplay;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Credit;
        private System.Windows.Forms.Button btn_posAmount;
        private System.Windows.Forms.Button btn_purchase;
        private System.Windows.Forms.Button btn_refund;
        private System.Windows.Forms.Label lbl_message;
        private System.Windows.Forms.Button button13;
    }
}