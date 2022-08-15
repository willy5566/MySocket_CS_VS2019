using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace MySocket
{
    public class MyClient
    {
        private Socket socket;
        public Action<string> ReceivCallback;
        public Action<string> MsgCallback;
        public Action<bool> ConnectionStatusChange;
        private string ip;
        private int port;
        private bool connecting;

        public string IP
        {
            get
            {
                return ip;
            }
        }

        public int Port
        {
            get
            {
                return port;
            }
        }
        
        public bool Connecting 
        { 
            get 
            { 
                return connecting; 
            } 
        }

        public MyClient()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            connecting = false;
        }

        ~MyClient()
        {
            Close();
        }

        #region private method

        private void ReceiveMsgFromServer()
        {
            while (true)
            {
                byte[] buffer = new byte[1024];

                int rec = 0;

                try
                {
                    rec = socket.Receive(buffer);
                }
                catch (Exception se)
                {
                    ShowMsg(string.Format("Client Receive 失敗 : {0}", se.Message));
                }

                if (rec == 0)
                {
                    SetConnecting(false);
                    ShowMsg("Server Loss!");
                    break;
                }

                string receText = System.Text.Encoding.UTF8.GetString(buffer, 0, rec);
                if (ReceivCallback != null)
                    ReceivCallback(receText);

                ShowMsg("Server :" + receText);
            }
        }                

        protected void ShowMsg(string s)
        {
            if (MsgCallback != null)
                MsgCallback(s);
            else
                Console.WriteLine(s);
        }

        protected void SetConnecting(bool bConnecting)
        {
            connecting = bConnecting;
            if (ConnectionStatusChange != null)
                ConnectionStatusChange(connecting);
        }

        #endregion

        #region public method

        public bool Connect(string ip, int port)
        {
            IPAddress myIp = IPAddress.Parse(ip);

            IPEndPoint point = new IPEndPoint(myIp, port);

            bool rtn = false;

            try
            {
                socket.Connect(point);

                rtn = true;

                ShowMsg("Connect Succese! " + socket.RemoteEndPoint.ToString());

                Thread ReceiveMsg = new Thread(ReceiveMsgFromServer);

                ReceiveMsg.IsBackground = true;

                ReceiveMsg.Start();
            }
            catch(Exception se)
            {
                ShowMsg("Connect Fail! ");
                ShowMsg("Error Message :" + se.Message);
            }

            SetConnecting(rtn);

            return rtn;
        }

        public void SetIPandPort(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }

        public void SendMsgToServer(string msg)
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(msg);
            socket.Send(buffer);
        }

        public void Close()
        {
            socket.Close();
        }

        #endregion
    }
}
