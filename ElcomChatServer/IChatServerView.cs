using ServerLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElcomChatServer
{
    public interface IChatServerView
    {
        void ViewAlarm(string alarm);

        void SetServerStateView(ServerState newState);
    }
}
