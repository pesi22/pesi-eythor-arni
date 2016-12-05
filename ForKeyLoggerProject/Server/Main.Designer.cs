namespace ForKeyLoggerProject
{
    partial class Main
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
            this.lstBoxUsers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnListen = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtBoxMsgCaption = new System.Windows.Forms.TextBox();
            this.txtBoxMsg = new System.Windows.Forms.TextBox();
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.lblOnline = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnSpam = new System.Windows.Forms.Button();
            this.btnGetkeylog = new System.Windows.Forms.Button();
            this.txtBoxKeyLogs = new System.Windows.Forms.TextBox();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.btnChangeBG = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbllastupdate = new System.Windows.Forms.Label();
            this.tboxportnumber = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstBoxUsers
            // 
            this.lstBoxUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstBoxUsers.Location = new System.Drawing.Point(12, 25);
            this.lstBoxUsers.Name = "lstBoxUsers";
            this.lstBoxUsers.Size = new System.Drawing.Size(359, 155);
            this.lstBoxUsers.TabIndex = 0;
            this.lstBoxUsers.UseCompatibleStateImageBehavior = false;
            this.lstBoxUsers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IP Address";
            this.columnHeader1.Width = 108;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status";
            this.columnHeader2.Width = 160;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "User";
            this.columnHeader3.Width = 100;
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(15, 186);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(75, 23);
            this.btnListen.TabIndex = 1;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(96, 188);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(64, 20);
            this.txtPort.TabIndex = 2;
            this.txtPort.Text = "444";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(166, 186);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtBoxMsgCaption
            // 
            this.txtBoxMsgCaption.Location = new System.Drawing.Point(12, 220);
            this.txtBoxMsgCaption.Name = "txtBoxMsgCaption";
            this.txtBoxMsgCaption.Size = new System.Drawing.Size(356, 20);
            this.txtBoxMsgCaption.TabIndex = 4;
            // 
            // txtBoxMsg
            // 
            this.txtBoxMsg.Location = new System.Drawing.Point(12, 246);
            this.txtBoxMsg.Multiline = true;
            this.txtBoxMsg.Name = "txtBoxMsg";
            this.txtBoxMsg.Size = new System.Drawing.Size(356, 64);
            this.txtBoxMsg.TabIndex = 5;
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.Location = new System.Drawing.Point(131, 318);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(122, 23);
            this.btnSendMsg.TabIndex = 6;
            this.btnSendMsg.Text = "Send Message";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // lblOnline
            // 
            this.lblOnline.AutoSize = true;
            this.lblOnline.Location = new System.Drawing.Point(9, 9);
            this.lblOnline.Name = "lblOnline";
            this.lblOnline.Size = new System.Drawing.Size(49, 13);
            this.lblOnline.TabIndex = 8;
            this.lblOnline.Text = "Online: 0";
            // 
            // btnSpam
            // 
            this.btnSpam.Location = new System.Drawing.Point(259, 347);
            this.btnSpam.Name = "btnSpam";
            this.btnSpam.Size = new System.Drawing.Size(101, 23);
            this.btnSpam.TabIndex = 9;
            this.btnSpam.Text = "Spam popup";
            this.btnSpam.UseVisualStyleBackColor = true;
            this.btnSpam.Click += new System.EventHandler(this.btnSpam_Click);
            // 
            // btnGetkeylog
            // 
            this.btnGetkeylog.Location = new System.Drawing.Point(22, 347);
            this.btnGetkeylog.Name = "btnGetkeylog";
            this.btnGetkeylog.Size = new System.Drawing.Size(103, 23);
            this.btnGetkeylog.TabIndex = 10;
            this.btnGetkeylog.Text = "Get Keylogs";
            this.btnGetkeylog.UseVisualStyleBackColor = true;
            this.btnGetkeylog.Click += new System.EventHandler(this.btnGetkeylog_Click);
            // 
            // txtBoxKeyLogs
            // 
            this.txtBoxKeyLogs.Location = new System.Drawing.Point(22, 376);
            this.txtBoxKeyLogs.Multiline = true;
            this.txtBoxKeyLogs.Name = "txtBoxKeyLogs";
            this.txtBoxKeyLogs.Size = new System.Drawing.Size(349, 101);
            this.txtBoxKeyLogs.TabIndex = 11;
            // 
            // btnSaveData
            // 
            this.btnSaveData.Location = new System.Drawing.Point(131, 347);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(122, 23);
            this.btnSaveData.TabIndex = 12;
            this.btnSaveData.Text = "Save Klog data locally";
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // btnChangeBG
            // 
            this.btnChangeBG.Enabled = false;
            this.btnChangeBG.Location = new System.Drawing.Point(259, 512);
            this.btnChangeBG.Name = "btnChangeBG";
            this.btnChangeBG.Size = new System.Drawing.Size(101, 23);
            this.btnChangeBG.TabIndex = 13;
            this.btnChangeBG.Text = "Change BG";
            this.btnChangeBG.UseVisualStyleBackColor = true;
            this.btnChangeBG.Click += new System.EventHandler(this.btnChangeBG_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 512);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Choose Picture";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(147, 512);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Send picture";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(259, 187);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 22);
            this.button3.TabIndex = 16;
            this.button3.Text = "Restart Clients";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(22, 483);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(103, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "Upload to DB";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Yellow;
            this.panel1.Location = new System.Drawing.Point(131, 492);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 11);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Location = new System.Drawing.Point(131, 518);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 11);
            this.panel2.TabIndex = 19;
            // 
            // lbllastupdate
            // 
            this.lbllastupdate.AutoSize = true;
            this.lbllastupdate.Location = new System.Drawing.Point(128, 9);
            this.lbllastupdate.Name = "lbllastupdate";
            this.lbllastupdate.Size = new System.Drawing.Size(81, 13);
            this.lbllastupdate.TabIndex = 20;
            this.lbllastupdate.Text = "Last Broadcast:";
            // 
            // tboxportnumber
            // 
            this.tboxportnumber.Location = new System.Drawing.Point(147, 538);
            this.tboxportnumber.Name = "tboxportnumber";
            this.tboxportnumber.Size = new System.Drawing.Size(106, 20);
            this.tboxportnumber.TabIndex = 21;
            this.tboxportnumber.Text = "2014";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(259, 483);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(101, 23);
            this.button5.TabIndex = 22;
            this.button5.Text = "Erase DB";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 541);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Port for file transfer:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 570);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.tboxportnumber);
            this.Controls.Add(this.lbllastupdate);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnChangeBG);
            this.Controls.Add(this.btnSaveData);
            this.Controls.Add(this.txtBoxKeyLogs);
            this.Controls.Add(this.btnGetkeylog);
            this.Controls.Add(this.btnSpam);
            this.Controls.Add(this.lblOnline);
            this.Controls.Add(this.btnSendMsg);
            this.Controls.Add(this.txtBoxMsg);
            this.Controls.Add(this.txtBoxMsgCaption);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.lstBoxUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstBoxUsers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtBoxMsgCaption;
        private System.Windows.Forms.TextBox txtBoxMsg;
        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.Label lblOnline;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button btnSpam;
        private System.Windows.Forms.Button btnGetkeylog;
        private System.Windows.Forms.TextBox txtBoxKeyLogs;
        public System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnSaveData;
        private System.Windows.Forms.Button btnChangeBG;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbllastupdate;
        private System.Windows.Forms.TextBox tboxportnumber;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
    }
}

