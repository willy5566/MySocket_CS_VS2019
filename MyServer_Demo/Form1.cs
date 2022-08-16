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
using System.Threading;
using MySocket;
using MyMsg;

namespace MyServer_Demo
{
    public partial class Form1 : Form
    {
        MsgServer server;
        public Dictionary<Socket, string> clientNameDict; // client名稱
        delegate void ShowMsg(string msg);

        public Form1()
        {
            InitializeComponent();           
        }

        #region Control Events

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            btnConfirm.Enabled = false;
            InitialServer();
            server.Listen();
            tmUpdate.Enabled = true;
            this.KeyPreview = true;
        }

        private void tmUpdate_Tick(object sender, EventArgs e)
        {
            lsbClientList.Items.Clear();
            for (int i = 0; i < server.clientList.Count; i++)
            {
                var client = server.clientList[i];
                //string name;
                //clientNameDict.TryGetValue(client, out name);
                lsbClientList.Items.Add(client.RemoteEndPoint.ToString());
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (server != null)
                server.Close();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbSendMsg.Focused)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    server.SendMsgFromServer(tbSendMsg.Text);
                    tbSendMsg.Text = "";

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        #endregion

        public void InitialServer()
        {
            if (ckbAutoSocketInfo.Checked)
            {
                server = new MsgServer();
            }
            else
            {
                string ip = tbIP.Text;
                int port = Convert.ToInt32(tbPort.Text);
                server = new MsgServer(port, ip);
            }
            clientNameDict = new Dictionary<Socket, string>();

            server.MsgCallback += AddServerMsgInvoke;
            server.AddReceivMsgInvoke += AddReceivMsgInvoke;
            server.AddMsgInvoke += AddMsgInvoke;
        }                  

        private void AddServerMsgInvoke(string msg)
        {
            if (this.InvokeRequired)
            {
                ShowMsg sInvokeMsg = new ShowMsg(AddServerMsg);
                this.Invoke(sInvokeMsg, msg);
            }
            else
            {
                lsbServerMsg.Items.Add(msg);
            }
        }

        private void AddReceivMsgInvoke(string msg)
        {
            if (this.InvokeRequired)
            {
                ShowMsg sInvokeMsg = new ShowMsg(AddReceivMsg);
                this.Invoke(sInvokeMsg, msg);
            }
            else
            {
                lsbReceivMsg.Items.Add(msg);
            }
        }

        private void AddMsgInvoke(string msg)
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

        private void AddReceivMsg(string msg)
        {
            lsbReceivMsg.Items.Add(msg);
        }

        private void AddServerMsg(string msg)
        {
            lsbServerMsg.Items.Add(msg);
        }

        private void AddMsg(string msg)
        {
            lsbMsg.Items.Add(msg);
        }    
    }
}
