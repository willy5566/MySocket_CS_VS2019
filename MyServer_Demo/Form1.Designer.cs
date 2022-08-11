
namespace MyServer_Demo
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.gbSocketInfo = new System.Windows.Forms.GroupBox();
            this.ckbAutoSocketInfo = new System.Windows.Forms.CheckBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lsbClientList = new System.Windows.Forms.ListBox();
            this.tbSendMsg = new System.Windows.Forms.TextBox();
            this.gbClientList = new System.Windows.Forms.GroupBox();
            this.tmUpdate = new System.Windows.Forms.Timer(this.components);
            this.lsbReceivMsg = new System.Windows.Forms.ListBox();
            this.lsbServerMsg = new System.Windows.Forms.ListBox();
            this.lsbMsg = new System.Windows.Forms.ListBox();
            this.gbBackground = new System.Windows.Forms.GroupBox();
            this.MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemReName = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSendMsg = new System.Windows.Forms.ToolStripMenuItem();
            this.gbSocketInfo.SuspendLayout();
            this.gbClientList.SuspendLayout();
            this.gbBackground.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(74, 66);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "確認";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // gbSocketInfo
            // 
            this.gbSocketInfo.Controls.Add(this.ckbAutoSocketInfo);
            this.gbSocketInfo.Controls.Add(this.tbPort);
            this.gbSocketInfo.Controls.Add(this.btnConfirm);
            this.gbSocketInfo.Controls.Add(this.tbIP);
            this.gbSocketInfo.Controls.Add(this.label2);
            this.gbSocketInfo.Controls.Add(this.label1);
            this.gbSocketInfo.Location = new System.Drawing.Point(12, 12);
            this.gbSocketInfo.Name = "gbSocketInfo";
            this.gbSocketInfo.Size = new System.Drawing.Size(158, 96);
            this.gbSocketInfo.TabIndex = 1;
            this.gbSocketInfo.TabStop = false;
            this.gbSocketInfo.Text = "連線資訊";
            // 
            // ckbAutoSocketInfo
            // 
            this.ckbAutoSocketInfo.AutoSize = true;
            this.ckbAutoSocketInfo.Location = new System.Drawing.Point(8, 70);
            this.ckbAutoSocketInfo.Name = "ckbAutoSocketInfo";
            this.ckbAutoSocketInfo.Size = new System.Drawing.Size(47, 16);
            this.ckbAutoSocketInfo.TabIndex = 2;
            this.ckbAutoSocketInfo.Text = "Auto";
            this.ckbAutoSocketInfo.UseVisualStyleBackColor = true;
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(49, 38);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(100, 22);
            this.tbPort.TabIndex = 1;
            this.tbPort.Text = "10001";
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(49, 15);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(100, 22);
            this.tbIP.TabIndex = 1;
            this.tbIP.Text = "192.168.1.105";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Port : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP : ";
            // 
            // lsbClientList
            // 
            this.lsbClientList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbClientList.FormattingEnabled = true;
            this.lsbClientList.ItemHeight = 12;
            this.lsbClientList.Location = new System.Drawing.Point(8, 21);
            this.lsbClientList.Name = "lsbClientList";
            this.lsbClientList.ScrollAlwaysVisible = true;
            this.lsbClientList.Size = new System.Drawing.Size(141, 292);
            this.lsbClientList.TabIndex = 2;
            // 
            // tbSendMsg
            // 
            this.tbSendMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSendMsg.Location = new System.Drawing.Point(176, 416);
            this.tbSendMsg.Name = "tbSendMsg";
            this.tbSendMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbSendMsg.Size = new System.Drawing.Size(278, 22);
            this.tbSendMsg.TabIndex = 1;
            // 
            // gbClientList
            // 
            this.gbClientList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbClientList.Controls.Add(this.lsbClientList);
            this.gbClientList.Location = new System.Drawing.Point(12, 114);
            this.gbClientList.Name = "gbClientList";
            this.gbClientList.Size = new System.Drawing.Size(158, 324);
            this.gbClientList.TabIndex = 3;
            this.gbClientList.TabStop = false;
            this.gbClientList.Text = "上線人員";
            // 
            // tmUpdate
            // 
            this.tmUpdate.Interval = 1000;
            this.tmUpdate.Tick += new System.EventHandler(this.tmUpdate_Tick);
            // 
            // lsbReceivMsg
            // 
            this.lsbReceivMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbReceivMsg.FormattingEnabled = true;
            this.lsbReceivMsg.HorizontalScrollbar = true;
            this.lsbReceivMsg.ItemHeight = 12;
            this.lsbReceivMsg.Location = new System.Drawing.Point(6, 21);
            this.lsbReceivMsg.Name = "lsbReceivMsg";
            this.lsbReceivMsg.ScrollAlwaysVisible = true;
            this.lsbReceivMsg.Size = new System.Drawing.Size(266, 196);
            this.lsbReceivMsg.TabIndex = 2;
            // 
            // lsbServerMsg
            // 
            this.lsbServerMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbServerMsg.FormattingEnabled = true;
            this.lsbServerMsg.HorizontalScrollbar = true;
            this.lsbServerMsg.ItemHeight = 12;
            this.lsbServerMsg.Location = new System.Drawing.Point(6, 221);
            this.lsbServerMsg.Name = "lsbServerMsg";
            this.lsbServerMsg.ScrollAlwaysVisible = true;
            this.lsbServerMsg.Size = new System.Drawing.Size(266, 196);
            this.lsbServerMsg.TabIndex = 2;
            // 
            // lsbMsg
            // 
            this.lsbMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbMsg.FormattingEnabled = true;
            this.lsbMsg.HorizontalScrollbar = true;
            this.lsbMsg.ItemHeight = 12;
            this.lsbMsg.Location = new System.Drawing.Point(176, 12);
            this.lsbMsg.Name = "lsbMsg";
            this.lsbMsg.ScrollAlwaysVisible = true;
            this.lsbMsg.Size = new System.Drawing.Size(278, 400);
            this.lsbMsg.TabIndex = 2;
            // 
            // gbBackground
            // 
            this.gbBackground.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBackground.Controls.Add(this.lsbReceivMsg);
            this.gbBackground.Controls.Add(this.lsbServerMsg);
            this.gbBackground.Location = new System.Drawing.Point(460, 10);
            this.gbBackground.Name = "gbBackground";
            this.gbBackground.Size = new System.Drawing.Size(278, 428);
            this.gbBackground.TabIndex = 4;
            this.gbBackground.TabStop = false;
            this.gbBackground.Text = "後臺資訊";
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemReName,
            this.itemSendMsg});
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(123, 48);
            // 
            // itemReName
            // 
            this.itemReName.Name = "itemReName";
            this.itemReName.Size = new System.Drawing.Size(180, 22);
            this.itemReName.Text = "改變名稱";
            // 
            // itemSendMsg
            // 
            this.itemSendMsg.Name = "itemSendMsg";
            this.itemSendMsg.Size = new System.Drawing.Size(180, 22);
            this.itemSendMsg.Text = "傳送訊息";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 446);
            this.Controls.Add(this.gbBackground);
            this.Controls.Add(this.lsbMsg);
            this.Controls.Add(this.gbClientList);
            this.Controls.Add(this.gbSocketInfo);
            this.Controls.Add(this.tbSendMsg);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.gbSocketInfo.ResumeLayout(false);
            this.gbSocketInfo.PerformLayout();
            this.gbClientList.ResumeLayout(false);
            this.gbBackground.ResumeLayout(false);
            this.MenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.GroupBox gbSocketInfo;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lsbClientList;
        private System.Windows.Forms.TextBox tbSendMsg;
        private System.Windows.Forms.GroupBox gbClientList;
        private System.Windows.Forms.CheckBox ckbAutoSocketInfo;
        private System.Windows.Forms.Timer tmUpdate;
        private System.Windows.Forms.ListBox lsbReceivMsg;
        private System.Windows.Forms.ListBox lsbServerMsg;
        private System.Windows.Forms.ListBox lsbMsg;
        private System.Windows.Forms.GroupBox gbBackground;
        private System.Windows.Forms.ContextMenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem itemReName;
        private System.Windows.Forms.ToolStripMenuItem itemSendMsg;
    }
}

