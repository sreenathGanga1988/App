namespace App.UI
{
    partial class FrmMainForm
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_action = new System.Windows.Forms.Button();
            this.btn_masters = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btn_misreport = new System.Windows.Forms.Button();
            this.btn_pos = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_Location = new System.Windows.Forms.Label();
            this.lbl_welcome = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(949, 566);
            this.panel1.TabIndex = 12;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel5.Controls.Add(this.btn_action);
            this.panel5.Controls.Add(this.btn_masters);
            this.panel5.Controls.Add(this.btnSettings);
            this.panel5.Controls.Add(this.btn_misreport);
            this.panel5.Controls.Add(this.btn_pos);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 86);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(949, 480);
            this.panel5.TabIndex = 3;
            // 
            // btn_action
            // 
            this.btn_action.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_action.BackColor = System.Drawing.Color.White;
            this.btn_action.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_action.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_action.Location = new System.Drawing.Point(491, 239);
            this.btn_action.Name = "btn_action";
            this.btn_action.Size = new System.Drawing.Size(159, 117);
            this.btn_action.TabIndex = 5;
            this.btn_action.Text = "Actions";
            this.btn_action.UseVisualStyleBackColor = false;
            this.btn_action.Click += new System.EventHandler(this.btn_action_Click);
            // 
            // btn_masters
            // 
            this.btn_masters.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_masters.BackColor = System.Drawing.Color.White;
            this.btn_masters.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_masters.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_masters.Location = new System.Drawing.Point(360, 45);
            this.btn_masters.Name = "btn_masters";
            this.btn_masters.Size = new System.Drawing.Size(159, 117);
            this.btn_masters.TabIndex = 4;
            this.btn_masters.Text = "Masters";
            this.btn_masters.UseVisualStyleBackColor = false;
            this.btn_masters.Click += new System.EventHandler(this.btn_masters_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSettings.BackColor = System.Drawing.Color.White;
            this.btnSettings.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.DarkRed;
            this.btnSettings.Location = new System.Drawing.Point(606, 45);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(159, 117);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btn_misreport
            // 
            this.btn_misreport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_misreport.BackColor = System.Drawing.Color.White;
            this.btn_misreport.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_misreport.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_misreport.Location = new System.Drawing.Point(233, 239);
            this.btn_misreport.Name = "btn_misreport";
            this.btn_misreport.Size = new System.Drawing.Size(159, 117);
            this.btn_misreport.TabIndex = 2;
            this.btn_misreport.Text = "MIS Reports";
            this.btn_misreport.UseVisualStyleBackColor = false;
            this.btn_misreport.Click += new System.EventHandler(this.btn_misreport_Click);
            // 
            // btn_pos
            // 
            this.btn_pos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_pos.BackColor = System.Drawing.Color.White;
            this.btn_pos.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pos.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_pos.Location = new System.Drawing.Point(116, 45);
            this.btn_pos.Name = "btn_pos";
            this.btn_pos.Size = new System.Drawing.Size(159, 117);
            this.btn_pos.TabIndex = 1;
            this.btn_pos.Text = "Point of Sale";
            this.btn_pos.UseVisualStyleBackColor = false;
            this.btn_pos.Click += new System.EventHandler(this.btn_pos_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 76);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(949, 10);
            this.panel4.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkRed;
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(949, 71);
            this.panel3.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.groupBox1.Controls.Add(this.lbl_Location);
            this.groupBox1.Controls.Add(this.lbl_welcome);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(949, 71);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // lbl_Location
            // 
            this.lbl_Location.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_Location.AutoSize = true;
            this.lbl_Location.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Location.ForeColor = System.Drawing.Color.White;
            this.lbl_Location.Location = new System.Drawing.Point(718, 33);
            this.lbl_Location.Name = "lbl_Location";
            this.lbl_Location.Size = new System.Drawing.Size(228, 19);
            this.lbl_Location.TabIndex = 3;
            this.lbl_Location.Text = "LIMS CAFE AL KHAIL GATE";
            // 
            // lbl_welcome
            // 
            this.lbl_welcome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_welcome.AutoSize = true;
            this.lbl_welcome.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_welcome.ForeColor = System.Drawing.Color.White;
            this.lbl_welcome.Location = new System.Drawing.Point(73, 18);
            this.lbl_welcome.Name = "lbl_welcome";
            this.lbl_welcome.Size = new System.Drawing.Size(163, 33);
            this.lbl_welcome.TabIndex = 2;
            this.lbl_welcome.Text = "WELCOME ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(949, 5);
            this.panel2.TabIndex = 0;
            // 
            // FrmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(949, 566);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMainForm";
            this.ShowIcon = false;
            this.Text = "Main Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StartForm_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_Location;
        private System.Windows.Forms.Label lbl_welcome;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btn_misreport;
        private System.Windows.Forms.Button btn_pos;
        private System.Windows.Forms.Button btn_action;
        private System.Windows.Forms.Button btn_masters;
    }
}