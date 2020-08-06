using ChatProtocol.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Messages
{
    [Serializable]
    public class Letter
    {
        public string FromId { get; set; }
        public string ToId { get; set; }
        public string Message { get; set; }

        //public Letter() { }

        public Letter(string fromId, string toId, string message)
        {
            if (fromId == null || toId == null || message == null) throw new Exception();
            FromId = fromId;
            ToId = toId;
            Message = message;
        }

        public override string ToString()
        {
            return MessageJsonSerializer.SerializeMessage<Letter>(this);
        }
    }
}
