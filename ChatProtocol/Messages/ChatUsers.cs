using ChatProtocol.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Messages
{
    [Serializable]
    public class ChatUsers
    {
        public Dictionary<string, string> Users { get; set; }

        public ChatUsers(Dictionary<string, string> users)
        {
            if (users == null) throw new Exception();
            Users = users;
        }

        public override string ToString()
        {
            return MessageJsonSerializer.SerializeMessage<ChatUsers>(this);
        }
    }
}
