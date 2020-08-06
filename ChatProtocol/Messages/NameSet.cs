using ChatProtocol.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.Messages
{
    [Serializable]
    public class NameSet
    {
        //public string Id { get; set; }
        public string Name { get; set; }

        public NameSet(/*string id,*/ string name)
        {
            // Id = id;
            if (name == null) throw new Exception();
            Name = name;
        }

        public override string ToString()
        {
            return MessageJsonSerializer.SerializeMessage<NameSet>(this);
        }
    }
}
