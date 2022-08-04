using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using MySocket;

namespace MyClient_Demo
{
    public partial class Form1 : Form
    {
        MyClient client;
        delegate void ShowMsg(string msg);
        delegate void ShowConnecting(ConnectType connectType);

        public Form1()
        {
            InitializeComponent();
        }

        #region Control Events

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client != null)
                client.Close();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbSendMsg.Focused)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendMsg(tbSendMsg.Text);
                    tbSendMsg.Text = "";

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            InitialClient();
            //tmUpdate.Enabled = true;
            this.KeyPreview = true;
        }

        #endregion
        public void InitialClient()
        {
            if (client != null)
            {
                client.Close();
                client = null;
            }
            client = new MyClient();
            string ip = tbIP.Text;
            int port = Convert.ToInt32(tbPort.Text);
            client.ReceivCallback += ReceiveCallback;
            //client.MsgCallback += MsgCallback;
            client.ConnectionStatusChange += ConnectingChange;
            client.Connect(ip, port);
        }

        private void ReceiveCallback(string msg)
        {
            if (msg[1] == '#')
            {
                switch (msg[0])
                {
                    case SendType.MESSAGE:
                        SendMsgInvoke(msg.Substring(2));
                        break;
                    case SendType.CLIENT_LIST:
                        UpdateClientListInvoke(msg.Substring(2));
                        break;
                }
            }
            //SendMsgInvoke(msg);
        }

        private void MsgCallback(string msg)
        {
            string sMsg = "System :" + msg;
            SendMsgInvoke(sMsg);
        }

        private void ConnectingChange(bool bConnecting)
        {
            if(bConnecting)
                UpdateConnectStateInvoke(ConnectType.Success);
            else
                UpdateConnectStateInvoke(ConnectType.Failure);
        }

        private void SendMsgInvoke(string msg)
        {
            if (this.InvokeRequired)
            {
                ShowMsg sInvokeMsg = new ShowMsg(AddMsg);
                this.Invoke(sInvokeMsg, msg);
            }
            else
            {
                lsbMsg.Items.Add(msg);
            }
        }

        private void AddMsg(string msg)
        {
            lsbMsg.Items.Add(msg);
        }

        private void SendMsg(string msg)
        {
            SendMsg(SendType.MESSAGE, msg);
        }

        private void SendMsg(char cType, string msg)
        {
            if (client.Connecting)
            {
                string sMsg = cType + "#" + msg;
                client.SendMsgToServer(sMsg);
            }
            else
            {
                AddMsg("目前尚未連線...");
            }
        }

        private void UpdateClientListInvoke(string sClientList)
        {
            if (this.InvokeRequired)
            {
                ShowMsg sInvokeMsg = new ShowMsg(UpdateClientList);
                this.Invoke(sInvokeMsg, sClientList);
            }
            else
            {
                UpdateClientList(sClientList);
            }
        }

        private void UpdateClientList(string sClientList)
        {
            var sClientArray = sClientList.Split(',');
            lsbClientList.Items.Clear();
            //foreach(var sClient in sClientArray)
            //{
            //    lsbClientList.Items.Add(sClient);
            //}
            lsbClientList.Items.AddRange(sClientArray);
        }

        private void UpdateConnectStateInvoke(ConnectType connectType)
        {
            if (this.InvokeRequired)
            {
                ShowConnecting sInvokeMsg = new ShowConnecting(UpdateConnectState);
                this.Invoke(sInvokeMsg, connectType);
            }
            else
            {
                UpdateConnectState(connectType);
            }
        }

        private void UpdateConnectState(ConnectType connectType)
        {
            switch(connectType)
            {
                case ConnectType.Success:
                    lbConnectType.Text = "已連線";
                    lbConnectType.BackColor = Color.LimeGreen;
                    break;
                case ConnectType.Failure:
                    lbConnectType.Text = "連線失敗";
                    lbConnectType.BackColor = Color.OrangeRed;
                    break;
                case ConnectType.Disconnect:
                    lbConnectType.Text = "已斷線";
                    lbConnectType.BackColor = Color.IndianRed;
                    break;
            }
        }
    }
}
