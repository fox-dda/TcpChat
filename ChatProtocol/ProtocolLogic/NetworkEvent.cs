using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProtocol.ProtocolLogic
{
    [Serializable]
    public enum NetworkEvent
    {
        Connect,
        Leave
    }
}
