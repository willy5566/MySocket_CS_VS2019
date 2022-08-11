
namespace MyClient_Demo
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
            this.lsbMsg = new System.Windows.Forms.ListBox();
            this.gbClientList = new System.Windows.Forms.GroupBox();
            this.lsbClientList = new System.Windows.Forms.ListBox();
            this.gbSocketInfo = new System.Windows.Forms.GroupBox();
            this.lbConnectType = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSendMsg = new System.Windows.Forms.TextBox();
            this.MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.gbClientList.SuspendLayout();
            this.gbSocketInfo.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
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
            this.lsbMsg.TabIndex = 6;
            // 
            // gbClientList
            // 
            this.gbClientList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbClientList.Controls.Add(this.lsbClientList);
            this.gbClientList.Location = new System.Drawing.Point(12, 114);
            this.gbClientList.Name = "gbClientList";
            this.gbClientList.Size = new System.Drawing.Size(158, 324);
            this.gbClientList.TabIndex = 7;
            this.gbClientList.TabStop = false;
            this.gbClientList.Text = "上線人員";
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
            this.lsbClientList.SelectedIndexChanged += new System.EventHandler(this.lsbClientList_SelectedIndexChanged);
            this.lsbClientList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lsbClientList_MouseUp);
            // 
            // gbSocketInfo
            // 
            this.gbSocketInfo.Controls.Add(this.lbConnectType);
            this.gbSocketInfo.Controls.Add(this.tbPort);
            this.gbSocketInfo.Controls.Add(this.btnConfirm);
            this.gbSocketInfo.Controls.Add(this.tbIP);
            this.gbSocketInfo.Controls.Add(this.label2);
            this.gbSocketInfo.Controls.Add(this.label1);
            this.gbSocketInfo.Location = new System.Drawing.Point(12, 12);
            this.gbSocketInfo.Name = "gbSocketInfo";
            this.gbSocketInfo.Size = new System.Drawing.Size(158, 96);
            this.gbSocketInfo.TabIndex = 4;
            this.gbSocketInfo.TabStop = false;
            this.gbSocketInfo.Text = "連線資訊";
            // 
            // lbConnectType
            // 
            this.lbConnectType.BackColor = System.Drawing.Color.Silver;
            this.lbConnectType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbConnectType.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbConnectType.ForeColor = System.Drawing.Color.White;
            this.lbConnectType.Location = new System.Drawing.Point(8, 66);
            this.lbConnectType.Name = "lbConnectType";
            this.lbConnectType.Size = new System.Drawing.Size(60, 23);
            this.lbConnectType.TabIndex = 2;
            this.lbConnectType.Text = "未連線";
            this.lbConnectType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(49, 38);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(100, 22);
            this.tbPort.TabIndex = 1;
            this.tbPort.Text = "10001";
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
            // tbSendMsg
            // 
            this.tbSendMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSendMsg.Location = new System.Drawing.Point(176, 416);
            this.tbSendMsg.Name = "tbSendMsg";
            this.tbSendMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbSendMsg.Size = new System.Drawing.Size(278, 22);
            this.tbSendMsg.TabIndex = 5;
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(181, 48);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "123";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 446);
            this.Controls.Add(this.lsbMsg);
            this.Controls.Add(this.gbClientList);
            this.Controls.Add(this.gbSocketInfo);
            this.Controls.Add(this.tbSendMsg);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.gbClientList.ResumeLayout(false);
            this.gbSocketInfo.ResumeLayout(false);
            this.gbSocketInfo.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsbMsg;
        private System.Windows.Forms.GroupBox gbClientList;
        private System.Windows.Forms.ListBox lsbClientList;
        private System.Windows.Forms.GroupBox gbSocketInfo;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSendMsg;
        private System.Windows.Forms.Label lbConnectType;
        private System.Windows.Forms.ContextMenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}

