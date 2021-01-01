namespace EventStatusCheck
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbxVisitorHistory = new System.Windows.Forms.ListBox();
            this.lblVisitorStatus = new System.Windows.Forms.Label();
            this.btnShowVisitorInfo = new System.Windows.Forms.Button();
            this.tbVisitorID = new System.Windows.Forms.TextBox();
            this.lblVisitorID = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnVisitorsinfo = new System.Windows.Forms.Button();
            this.lbxVisitorspresent = new System.Windows.Forms.ListBox();
            this.btnShowvisitors = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbxCampingstats = new System.Windows.Forms.ListBox();
            this.btnCampstats = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbItem = new System.Windows.Forms.TextBox();
            this.lblAmountsold = new System.Windows.Forms.Label();
            this.btnAmountsold = new System.Windows.Forms.Button();
            this.lblItemID = new System.Windows.Forms.Label();
            this.lblMoneymade = new System.Windows.Forms.Label();
            this.btnMoneymade = new System.Windows.Forms.Button();
            this.lbxShops = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnManual = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.rlbManual = new System.Windows.Forms.RichTextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbxVisitorHistory);
            this.groupBox1.Controls.Add(this.lblVisitorStatus);
            this.groupBox1.Controls.Add(this.btnShowVisitorInfo);
            this.groupBox1.Controls.Add(this.tbVisitorID);
            this.groupBox1.Controls.Add(this.lblVisitorID);
            this.groupBox1.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(162, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 258);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Visitor";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lbxVisitorHistory
            // 
            this.lbxVisitorHistory.FormattingEnabled = true;
            this.lbxVisitorHistory.ItemHeight = 18;
            this.lbxVisitorHistory.Location = new System.Drawing.Point(6, 145);
            this.lbxVisitorHistory.Name = "lbxVisitorHistory";
            this.lbxVisitorHistory.Size = new System.Drawing.Size(388, 94);
            this.lbxVisitorHistory.TabIndex = 5;
            // 
            // lblVisitorStatus
            // 
            this.lblVisitorStatus.AutoSize = true;
            this.lblVisitorStatus.Location = new System.Drawing.Point(24, 93);
            this.lblVisitorStatus.Name = "lblVisitorStatus";
            this.lblVisitorStatus.Size = new System.Drawing.Size(52, 18);
            this.lblVisitorStatus.TabIndex = 4;
            this.lblVisitorStatus.Text = "Status";
            // 
            // btnShowVisitorInfo
            // 
            this.btnShowVisitorInfo.BackColor = System.Drawing.Color.Black;
            this.btnShowVisitorInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowVisitorInfo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnShowVisitorInfo.Location = new System.Drawing.Point(236, 36);
            this.btnShowVisitorInfo.Name = "btnShowVisitorInfo";
            this.btnShowVisitorInfo.Size = new System.Drawing.Size(112, 32);
            this.btnShowVisitorInfo.TabIndex = 3;
            this.btnShowVisitorInfo.Text = "Show Info";
            this.btnShowVisitorInfo.UseVisualStyleBackColor = false;
            this.btnShowVisitorInfo.Click += new System.EventHandler(this.btnShowVisitorInfo_Click);
            // 
            // tbVisitorID
            // 
            this.tbVisitorID.Location = new System.Drawing.Point(86, 39);
            this.tbVisitorID.Name = "tbVisitorID";
            this.tbVisitorID.Size = new System.Drawing.Size(112, 21);
            this.tbVisitorID.TabIndex = 2;
            // 
            // lblVisitorID
            // 
            this.lblVisitorID.AutoSize = true;
            this.lblVisitorID.Location = new System.Drawing.Point(6, 39);
            this.lblVisitorID.Name = "lblVisitorID";
            this.lblVisitorID.Size = new System.Drawing.Size(72, 18);
            this.lblVisitorID.TabIndex = 1;
            this.lblVisitorID.Text = "VisitorID:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnVisitorsinfo);
            this.groupBox2.Controls.Add(this.lbxVisitorspresent);
            this.groupBox2.Controls.Add(this.btnShowvisitors);
            this.groupBox2.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(162, 293);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(402, 316);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Visitors";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnVisitorsinfo
            // 
            this.btnVisitorsinfo.BackColor = System.Drawing.Color.Black;
            this.btnVisitorsinfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVisitorsinfo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnVisitorsinfo.Location = new System.Drawing.Point(228, 48);
            this.btnVisitorsinfo.Name = "btnVisitorsinfo";
            this.btnVisitorsinfo.Size = new System.Drawing.Size(120, 54);
            this.btnVisitorsinfo.TabIndex = 6;
            this.btnVisitorsinfo.Text = "View Visitors\' Statistics";
            this.btnVisitorsinfo.UseVisualStyleBackColor = false;
            this.btnVisitorsinfo.Click += new System.EventHandler(this.btnVisitorsinfo_Click);
            // 
            // lbxVisitorspresent
            // 
            this.lbxVisitorspresent.FormattingEnabled = true;
            this.lbxVisitorspresent.ItemHeight = 18;
            this.lbxVisitorspresent.Location = new System.Drawing.Point(12, 123);
            this.lbxVisitorspresent.Name = "lbxVisitorspresent";
            this.lbxVisitorspresent.Size = new System.Drawing.Size(385, 184);
            this.lbxVisitorspresent.TabIndex = 2;
            // 
            // btnShowvisitors
            // 
            this.btnShowvisitors.BackColor = System.Drawing.Color.Black;
            this.btnShowvisitors.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowvisitors.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnShowvisitors.Location = new System.Drawing.Point(40, 48);
            this.btnShowvisitors.Name = "btnShowvisitors";
            this.btnShowvisitors.Size = new System.Drawing.Size(123, 54);
            this.btnShowvisitors.TabIndex = 0;
            this.btnShowvisitors.Text = "Show Visitors Present";
            this.btnShowvisitors.UseVisualStyleBackColor = false;
            this.btnShowvisitors.Click += new System.EventHandler(this.btnShowvisitors_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbxCampingstats);
            this.groupBox3.Controls.Add(this.btnCampstats);
            this.groupBox3.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(579, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(450, 258);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Camping Spots";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // lbxCampingstats
            // 
            this.lbxCampingstats.FormattingEnabled = true;
            this.lbxCampingstats.ItemHeight = 18;
            this.lbxCampingstats.Location = new System.Drawing.Point(33, 104);
            this.lbxCampingstats.Name = "lbxCampingstats";
            this.lbxCampingstats.Size = new System.Drawing.Size(388, 148);
            this.lbxCampingstats.TabIndex = 10;
            // 
            // btnCampstats
            // 
            this.btnCampstats.BackColor = System.Drawing.Color.Black;
            this.btnCampstats.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCampstats.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCampstats.Location = new System.Drawing.Point(138, 39);
            this.btnCampstats.Name = "btnCampstats";
            this.btnCampstats.Size = new System.Drawing.Size(183, 57);
            this.btnCampstats.TabIndex = 9;
            this.btnCampstats.Text = "View Camping Statistics";
            this.btnCampstats.UseVisualStyleBackColor = false;
            this.btnCampstats.Click += new System.EventHandler(this.btnCampstats_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.lblMoneymade);
            this.groupBox4.Controls.Add(this.btnMoneymade);
            this.groupBox4.Controls.Add(this.lbxShops);
            this.groupBox4.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(579, 293);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(456, 316);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Stands";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbItem);
            this.groupBox5.Controls.Add(this.lblAmountsold);
            this.groupBox5.Controls.Add(this.btnAmountsold);
            this.groupBox5.Controls.Add(this.lblItemID);
            this.groupBox5.Location = new System.Drawing.Point(10, 197);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(440, 112);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Shop Items";
            // 
            // tbItem
            // 
            this.tbItem.Location = new System.Drawing.Point(57, 24);
            this.tbItem.Name = "tbItem";
            this.tbItem.Size = new System.Drawing.Size(112, 21);
            this.tbItem.TabIndex = 6;
            // 
            // lblAmountsold
            // 
            this.lblAmountsold.AutoSize = true;
            this.lblAmountsold.Location = new System.Drawing.Point(201, 55);
            this.lblAmountsold.Name = "lblAmountsold";
            this.lblAmountsold.Size = new System.Drawing.Size(97, 18);
            this.lblAmountsold.TabIndex = 4;
            this.lblAmountsold.Text = "Amount Sold";
            // 
            // btnAmountsold
            // 
            this.btnAmountsold.BackColor = System.Drawing.Color.Black;
            this.btnAmountsold.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAmountsold.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAmountsold.Location = new System.Drawing.Point(6, 55);
            this.btnAmountsold.Name = "btnAmountsold";
            this.btnAmountsold.Size = new System.Drawing.Size(186, 44);
            this.btnAmountsold.TabIndex = 4;
            this.btnAmountsold.Text = "Show Amount Sold";
            this.btnAmountsold.UseVisualStyleBackColor = false;
            this.btnAmountsold.Click += new System.EventHandler(this.btnAmountsold_Click);
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Location = new System.Drawing.Point(6, 26);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(44, 18);
            this.lblItemID.TabIndex = 5;
            this.lblItemID.Text = "Item:";
            // 
            // lblMoneymade
            // 
            this.lblMoneymade.AutoSize = true;
            this.lblMoneymade.Location = new System.Drawing.Point(210, 138);
            this.lblMoneymade.Name = "lblMoneymade";
            this.lblMoneymade.Size = new System.Drawing.Size(95, 18);
            this.lblMoneymade.TabIndex = 4;
            this.lblMoneymade.Text = "Money made";
            // 
            // btnMoneymade
            // 
            this.btnMoneymade.BackColor = System.Drawing.Color.Black;
            this.btnMoneymade.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMoneymade.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMoneymade.Location = new System.Drawing.Point(264, 28);
            this.btnMoneymade.Name = "btnMoneymade";
            this.btnMoneymade.Size = new System.Drawing.Size(138, 97);
            this.btnMoneymade.TabIndex = 1;
            this.btnMoneymade.Text = "Show Total Amount of Money Made";
            this.btnMoneymade.UseVisualStyleBackColor = false;
            this.btnMoneymade.Click += new System.EventHandler(this.btnMoneymade_Click);
            // 
            // lbxShops
            // 
            this.lbxShops.FormattingEnabled = true;
            this.lbxShops.ItemHeight = 18;
            this.lbxShops.Location = new System.Drawing.Point(6, 24);
            this.lbxShops.Name = "lbxShops";
            this.lbxShops.Size = new System.Drawing.Size(196, 166);
            this.lbxShops.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Black;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBack.Location = new System.Drawing.Point(12, 564);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(142, 45);
            this.btnBack.TabIndex = 33;
            this.btnBack.Text = "⮘  BACK";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(-26, 282);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1071, 5);
            this.panel1.TabIndex = 36;
            // 
            // btnManual
            // 
            this.btnManual.BackColor = System.Drawing.Color.Black;
            this.btnManual.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnManual.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManual.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnManual.Location = new System.Drawing.Point(10, 136);
            this.btnManual.Margin = new System.Windows.Forms.Padding(2);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(147, 36);
            this.btnManual.TabIndex = 37;
            this.btnManual.Text = "Manual";
            this.btnManual.UseVisualStyleBackColor = false;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // rlbManual
            // 
            this.rlbManual.BackColor = System.Drawing.Color.White;
            this.rlbManual.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rlbManual.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rlbManual.Location = new System.Drawing.Point(1063, 12);
            this.rlbManual.Name = "rlbManual";
            this.rlbManual.ReadOnly = true;
            this.rlbManual.Size = new System.Drawing.Size(428, 566);
            this.rlbManual.TabIndex = 41;
            this.rlbManual.Text = "";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Location = new System.Drawing.Point(1041, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(5, 595);
            this.panel5.TabIndex = 42;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1058, 623);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.rlbManual);
            this.Controls.Add(this.btnManual);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "EventStatusCheck";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbVisitorID;
        private System.Windows.Forms.Label lblVisitorID;
        private System.Windows.Forms.ListBox lbxVisitorHistory;
        private System.Windows.Forms.Label lblVisitorStatus;
        private System.Windows.Forms.Button btnShowVisitorInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbxVisitorspresent;
        private System.Windows.Forms.Button btnShowvisitors;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnMoneymade;
        private System.Windows.Forms.ListBox lbxShops;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.Label lblMoneymade;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tbItem;
        private System.Windows.Forms.Label lblAmountsold;
        private System.Windows.Forms.Button btnAmountsold;
        private System.Windows.Forms.ListBox lbxCampingstats;
        private System.Windows.Forms.Button btnCampstats;
        private System.Windows.Forms.Button btnVisitorsinfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.RichTextBox rlbManual;
        private System.Windows.Forms.Panel panel5;
    }
}

