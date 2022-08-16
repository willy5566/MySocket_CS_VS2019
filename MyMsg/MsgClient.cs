using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySocket;

namespace MyMsg
{
    public class MsgClient : MyClient
    {
        public Action<string> AddMsgInvoke;
        public Action<string> UpdateClientListInvoke;

        public MsgClient() : base()
        {
            this.ReceivCallback += ReceiveCallback;
        }

        ~MsgClient()
        {
            Close();
        }

        private void ReceiveCallback(string msg)
        {
            var msgList = MsgCommon.CheckCombine(msg);

            foreach (var m in msgList)
            {
                if (m[1] == '#')
                {
                    var sMsg = m.Substring(2);
                    switch (m[0])
                    {
                        case SendType.MESSAGE:
                            if (AddMsgInvoke != null)
                                AddMsgInvoke(sMsg);
                            break;
                        case SendType.CLIENT_LIST:
                            if (UpdateClientListInvoke != null)
                                UpdateClientListInvoke(sMsg);
                            break;
                        case SendType.SEND_CLINET_IP_PORT:
                            UpdateIPandPort(sMsg);
                            break;
                    }
                }
            }
            //SendMsgInvoke(msg);
        }        

        private void UpdateIPandPort(string sIPandPort)
        {
            var split = sIPandPort.Split(':');
            SetIPandPort(split[0], Convert.ToInt32(split[1]));
        }

        public void SendMsg(string msg)
        {
            SendMsg(SendType.MESSAGE, msg);
        }

        public void SendMsg(char cType, string msg)
        {
            if (Connecting)
            {
                string sMsg = cType + "#" + msg;
                SendMsgToServer(sMsg);
            }
            else
            {
                if (AddMsgInvoke != null)
                    AddMsgInvoke("目前尚未連線...");
            }
        }

        public void ModifyName(string sName)
        {
            SendMsg(SendType.MODIFY_NAME, sName);
        }
    }
}
