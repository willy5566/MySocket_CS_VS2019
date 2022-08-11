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

namespace MyServer_Demo
{
    public partial class Form1 : Form
    {
        MyServer server;
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
                lsbClientList.Items.Add(server.clientList[i].RemoteEndPoint.ToString());
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
                    SendMsgFromServer(tbSendMsg.Text);
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
                server = new MyServer();
            }
            else
            {
                string ip = tbIP.Text;
                int port = Convert.ToInt32(tbPort.Text);
                server = new MyServer(port, ip);
            }
            server.ReceivCallback += ReceiveCallback;
            server.MsgCallback += MsgCallback;
            server.ClientListChange += SendClientList;
        }       

        private void ReceiveCallback(Socket client, string msg)
        {
            string sMsg = client.RemoteEndPoint.ToString() + " : " + msg;
            if (this.InvokeRequired)
            {
                ShowMsg sInvokeMsg = new ShowMsg(AddReceivMsg);
                this.Invoke(sInvokeMsg, sMsg);
            }
            else
            {
                lsbReceivMsg.Items.Add(sMsg);
            }
            if(msg[1]=='#')
            {
                switch(msg[0])
                {
                    case SendType.MESSAGE:
                        SendMsgFromClient(client, msg.Substring(2));
                        break;
                }
            }
            //SendMsgFromClient(client, msg);
        }

        private void MsgCallback(string msg)
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

        private void SendMsg(char cType, string msg)
        {
            string sMsg = cType + "#" + msg;
            server.SendMsgToAllClient(sMsg);
        }

        private void SendClientList(string sClientList)
        {
            SendMsg(SendType.CLIENT_LIST, sClientList);
        }

        private void SendMsgFromClient(Socket client, string msg)
        {
            string sMsg = client.RemoteEndPoint.ToString() + " :" + msg;
            SendMsgInvoke(sMsg);
            SendMsg(SendType.MESSAGE, sMsg);
            //server.SendMsgToAllClient(sMsg);
        }

        private void SendMsgFromServer(string msg)
        {
            string sMsg = "Server :" + msg;
            SendMsgInvoke(sMsg);
            SendMsg(SendType.MESSAGE, sMsg);
            //server.SendMsgToAllClient(sMsg);           
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
