using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMsg
{
    public class MsgCommon
    {
        public static List<string> CheckCombine(string msg)
        {
            List<string> msgList = new List<string>();

            var msgArray = msg.Split('#');
            if (msgArray.Length > 2)
            {
                for (int i = 0; i < msgArray.Length - 1; i++)
                {
                    string sMsg = msgArray[i] + "#" + msgArray[i + 1].Substring(0, msgArray[i + 1].Length - 1);
                    msgList.Add(sMsg);
                }
            }
            else
            {
                msgList.Add(msg);
            }

            return msgList;
        }
    }
}
