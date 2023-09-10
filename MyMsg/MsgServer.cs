using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MySocket;

namespace MyMsg
{
    public class MsgServer : MyServer
    {
        public Dictionary<Socket, string> clientNameDict; // client名稱

        //public Action<string> AddServerMsgInvoke;
        public Action<string> AddReceivMsgInvoke;
        public Action<string> AddMsgInvoke;
        public MsgServer(int myPort = 10001, string myIP = "") : base(myPort, myIP)
        {
            clientNameDict = new Dictionary<Socket, string>();
            base.ReceivCallback += ReceiveCallback;
            base.ClientListChange += SendClientList;
            base.ClientSuccessCallback += SendClientIPandPort;
            base.ClientSuccessCallback += SetClientName;
        }

        ~MsgServer()
        {
            Close();
        }

        private void ReceiveCallback(Socket client, string msg)
        {
            string sMsg = client.RemoteEndPoint.ToString() + " : " + msg;
            if (AddReceivMsgInvoke != null)
                AddReceivMsgInvoke(sMsg);

            var msgList = MsgCommon.CheckCombine(msg);

            foreach (var m in msgList)
            {
                if (m[1] == '#')
                {
                    string sMsg2 = m.Substring(2);
                    switch (m[0])
                    {
                        case SendType.MESSAGE:
                            SendMsgFromClient(client, sMsg2);
                            break;
                        case SendType.MODIFY_NAME:
                            SetClientName(client, sMsg2);
                            SendClientList("");
                            break;
                    }
                }
            }
            //SendMsgFromClient(client, msg);
        }

        private void SendMsgAll(char cType, string msg)
        {
            string sMsg = cType + "#" + msg;
            SendMsgToAllClient(sMsg);
        }

        // 送給單獨Client 20220811
        private void SendMsgClient(Socket client, char cType, string msg)
        {
            string sMsg = cType + "#" + msg;
            SendMsgToClient(client, sMsg);
        }

        private void SendClientList(string sClientList)
        {
            if (clientList.Count < 1)
                return;

            string sName, sRtn;
            bool bRtn = clientNameDict.TryGetValue(clientList[0], out sName);
            sRtn = bRtn ? sName : clientList[0].RemoteEndPoint.ToString();
            for (int i = 1; i < clientList.Count; i++)
            {
                bRtn = clientNameDict.TryGetValue(clientList[i], out sName);
                if (bRtn)
                    sRtn += "," + sName;
                else
                    sRtn += "," + clientList[i].RemoteEndPoint.ToString();
            }
            //server.clientList
            SendMsgAll(SendType.CLIENT_LIST, sRtn);
        }

        private void SendMsgFromClient(Socket client, string msg)
        {
            //string sMsg = client.RemoteEndPoint.ToString() + " :" + msg;
            string sMsg = clientNameDict[client] + " :" + msg;
            if (AddMsgInvoke != null)
                AddMsgInvoke(sMsg);
            SendMsgAll(SendType.MESSAGE, sMsg);
            //server.SendMsgToAllClient(sMsg);
        }

        public void SendMsgFromServer(string msg)
        {
            string sMsg = "Server :" + msg;
            if (AddMsgInvoke != null)
                AddMsgInvoke(sMsg);
            SendMsgAll(SendType.MESSAGE, sMsg);
            //server.SendMsgToAllClient(sMsg);           
        }

        // 告訴Client他的IP跟Port 20220811
        public void SendClientIPandPort(Socket client)
        {
            string msg = client.RemoteEndPoint.ToString();

            SendMsgClient(client, SendType.SEND_CLINET_IP_PORT, msg);

            Thread.Sleep(100);
        }

        public void SetClientName(Socket client)
        {
            string name = "匿名" + client.RemoteEndPoint.ToString().Split(':')[1];
            clientNameDict.Add(client, name);
        }

        private void SetClientName(Socket client, string sName)
        {
            string name = sName + client.RemoteEndPoint.ToString().Split(':')[1];
            clientNameDict[client] = name;
        }
    }
}
