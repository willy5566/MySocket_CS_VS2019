using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;

namespace MySocket
{
    public class MyServer
    {
        Socket socketListener;
        IPEndPoint point;
        int port;
        int allowNum;
        Thread thServer;
        public List<Socket> clientList;
        public Action<Socket, string> ReceivCallback;
        public Action<string> MsgCallback;
        public Action<string> UpdateClientList;

        public MyServer(int myPort = 10001, string myIP = "")
        {
            socketListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress ip = myIP == "" ? IPAddress.Any : IPAddress.Parse(myIP);

            port = myPort;

            point = new IPEndPoint(ip, port);

            socketListener.Bind(point);

            clientList = new List<Socket>();

            allowNum = 10;
        }

        ~MyServer()
        {
            Close();
        }

        #region private method

        private void ServerCommunity(object obListener)
        {
            Socket temp = (Socket)obListener;

            while (true)
            {
                try
                {
                    Socket socketSender = temp.Accept();
                    clientList.Add(socketSender);
                    ShowMsg(("Client IP = " + socketSender.RemoteEndPoint.ToString()) + " Connect Succese!");
                    //UpdateClientList(ClientListToString());
                    Thread ReceiveMsg = new Thread(ReceiveClient);
                    ReceiveMsg.IsBackground = true;
                    ReceiveMsg.Start(socketSender);
                }
                catch (Exception se)
                {
                    //ShowMsg("Thread Abort!");
                    //ShowMsg(se.Message);
                    break;
                }
            }
        }

        private void ReceiveClient(object mySocketSender)
        {
            Socket socketSender = mySocketSender as Socket;

            while (true)
            {

                byte[] buffer = new byte[1024];

                int rece = 0;

                try
                {
                    rece = socketSender.Receive(buffer);
                }
                catch (Exception se)
                {
                    ShowMsg(string.Format("Client Receive 失敗 : {0}", se.Message));
                }

                if (rece == 0)
                {
                    ShowMsg(string.Format("Client : {0} 下線了", socketSender.RemoteEndPoint.ToString()));
                    clientList.Remove(socketSender);
                    //UpdateClientList(ClientListToString());
                    break;
                }
                string clientMsg = Encoding.UTF8.GetString(buffer, 0, rece);
                if (ReceivCallback != null)
                    ReceivCallback(socketSender, clientMsg);

                ShowMsg(string.Format("Client : {0}", clientMsg));
            }
        }

        private string ClientListToString()
        {
            string cmd = "";
            cmd += clientList[0].RemoteEndPoint.ToString();
            for (int i = 1; i < clientList.Count; i++)
            {
                cmd += clientList[i].RemoteEndPoint.ToString() + ",";
            }

            return cmd;
        }

        private void ShowMsg(string s)
        {
            if (MsgCallback != null)
                MsgCallback(s);
            else
                Console.WriteLine(s);
        }

        #endregion

        #region public method

        public void SetMaxClientNumber(int allowNum)
        {
            this.allowNum = allowNum;
        }

        public void Listen()
        {
            socketListener.Listen(allowNum);
            thServer = new Thread(ServerCommunity);
            thServer.Start(socketListener);
            ShowMsg("IP: " + point.Address);
            ShowMsg("Port: " + point.Port);
            ShowMsg("Max number of connections: " + allowNum);
            ShowMsg("Listening...");
        }

        public void SendMsgToClient(Socket socketSender, string msg)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            socketSender.Send(buffer);
            ShowMsg("Send to " + socketSender.RemoteEndPoint.ToString() + ": " + msg);
        }

        public void SendMsgToAllClient(string msg)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            foreach (var client in clientList)
            {
                client.Send(buffer);
            }
            ShowMsg("Send to all: " + msg);
        }

        public void Close()
        {
            foreach (var client in clientList)
            {
                client.Close();
            }
            socketListener.Close();
        }

        #endregion
    }
}
