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
            client = new MyClient();
            string ip = tbIP.Text;
            int port = Convert.ToInt32(tbPort.Text);
            client.ReceivCallback += ReceiveCallback;
            //client.MsgCallback += MsgCallback;
            client.Connect(ip, port);
        }

        private void ReceiveCallback(string msg)
        {
            SendMsgInvoke(msg);
        }

        private void MsgCallback(string msg)
        {
            string sMsg = "System :" + msg;
            SendMsgInvoke(sMsg);
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
            client.SendMsgToServer(msg);
        }        
    }
}
