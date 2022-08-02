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
        List<Socket> clientList;
        public Action<string> ReceivCallback;

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

        public void SetMaxClientNumber(int allowNum)
        {
            this.allowNum = allowNum;
        }

        public void Listen()
        {
            socketListener.Listen(allowNum);
            thServer = new Thread(ServerCommunity);
            thServer.Start(socketListener);
        }

        private void ServerCommunity(object obListener)
        {
            Socket temp = (Socket)obListener;

            while (true)
            {
                Socket socketSender = temp.Accept();
                clientList.Add(socketSender);
                ShowMsg(("Client IP = " + socketSender.RemoteEndPoint.ToString()) + " Connect Succese!");

                Thread ReceiveMsg = new Thread(ReceiveClient);
                ReceiveMsg.IsBackground = true;
                ReceiveMsg.Start(socketSender);
            }
        }

        private void ReceiveClient(object mySocketSender)
        {
            Socket socketSender = mySocketSender as Socket;

            while (true)
            {

                byte[] buffer = new byte[1024];

                int rece = socketSender.Receive(buffer);

                if (rece == 0)
                {
                    ShowMsg(string.Format("Client : {0} + 下線了", socketSender.RemoteEndPoint.ToString()));
                    clientList.Remove(socketSender);
                    break;
                }
                string clientMsg = Encoding.UTF8.GetString(buffer, 0, rece);
                if (ReceivCallback != null)
                    ReceivCallback(clientMsg);

                ShowMsg(string.Format("Client : {0}", clientMsg));
            }
        }

        private void SendMsgToClient(Socket socketSender, string msg)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(msg);

            socketSender.Send(buffer);
        }

        private static void ShowMsg(string s)
        {
            Console.WriteLine(s);
        }
    }
}
