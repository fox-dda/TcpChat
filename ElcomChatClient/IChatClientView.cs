using ClientLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElcomChatClient
{
    public interface IChatClientView
    {
        void ViewAlarm(string alarm);
        void RefreshChat(string chat);
        void ChangeStatus(ClientState state);
        void RefreshUsersList(List<string> userNames);
    }
}
