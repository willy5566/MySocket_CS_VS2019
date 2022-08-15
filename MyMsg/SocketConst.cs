using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMsg
{
    public class SendType
    {
        public const char MESSAGE = '0';
        public const char CLIENT_LIST = '1';
        public const char MODIFY_NAME = '2'; // 加入名稱 20220811
        public const char SEND_CLINET_IP_PORT = '3'; // 送出client的IP跟Port 20220811
    }

    public enum ConnectType
    {
        Success,
        Failure,
        Disconnect,
    }
}
