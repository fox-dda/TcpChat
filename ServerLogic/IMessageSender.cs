using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLogic
{
    public interface IMessageSender
    {
        void BroadcastMessage(string message, string senderId);
        void SendPrivateMessage(string message, string toId);

        void SendOnlineUsers(string toId);
    }
}
