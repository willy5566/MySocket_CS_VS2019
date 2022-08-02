using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace MySocket_CS_VS2019
{
    public class MyClient
    {
        private Socket socket;
        public Action<string> ReceivCallback;

        public MyClient()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Connect(string ip, int port)
        {
            IPAddress myIp = IPAddress.Parse(ip);

            IPEndPoint point = new IPEndPoint(myIp, port);

            socket.Connect(point);

            ShowMsg("Connect Succese! " + socket.RemoteEndPoint.ToString());

            Thread ReceiveMsg = new Thread(ReceiveMsgFromServer);

            ReceiveMsg.IsBackground = true;

            ReceiveMsg.Start();
        }

        private void ReceiveMsgFromServer()
        {
            while (true)
            {
                byte[] buffer = new byte[1024];

                int rec = socket.Receive(buffer);

                if (rec == 0)
                {
                    ShowMsg("Server Loss!");
                    break;
                }

                string receText = System.Text.Encoding.UTF8.GetString(buffer, 0, rec);
                if (ReceivCallback != null)
                    ReceivCallback(receText);

                ShowMsg("Server :" + receText);
            }
        }

        private void SendMsgToServer(string msg)
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(msg);
            socket.Send(buffer);
        }

        private static void ShowMsg(string s)
        {
            Console.WriteLine(s);
        }
    }
}
