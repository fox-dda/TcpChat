using ChatProtocol.Json;
using ChatProtocol.ProtocolLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Messages
{
    [Serializable]
    public class UserNetworkEvent
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public NetworkEvent NetworkEvent { get; set; }

        public UserNetworkEvent(string id, string name, NetworkEvent networkEvent)
        {
            if (name == null || id == null) throw new Exception();
            Name = name;
            Id = id;
            NetworkEvent = networkEvent;
        }

        public override string ToString()
        {
            return MessageJsonSerializer.SerializeMessage<UserNetworkEvent>(this);
        }
    }
}
