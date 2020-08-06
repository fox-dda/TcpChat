using ChatProtocol.Json;
using ChatProtocol.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.ProtocolLogic
{
    public class ProcessingConveyor
    {
        public void Process(string message)
        {
            var letter = MessageJsonSerializer.DeserializeMessage<Letter>(message);
            if (letter != null)
            {
                LetterReceived?.Invoke(letter);
                return;
            }

            var userNetworkEvent = MessageJsonSerializer.DeserializeMessage<UserNetworkEvent>(message);
            if(userNetworkEvent != null)
            {
                NetworkEventReceived?.Invoke(userNetworkEvent);
                return;
            }


            var charUsers = MessageJsonSerializer.DeserializeMessage<ChatUsers>(message);
            if(charUsers != null)
            {
                ChatUsersReceived?.Invoke(charUsers);
                return;
            }

            var nameSet = MessageJsonSerializer.DeserializeMessage<NameSet>(message);
            if(nameSet != null)
            {
                NameSetReceived?.Invoke(nameSet);
                return;
            }
        }

        public event Action<Letter> LetterReceived; 
        public event Action<UserNetworkEvent> NetworkEventReceived; 
        public event Action<ChatUsers> ChatUsersReceived;
        public event Action<NameSet> NameSetReceived; 
    }
}
