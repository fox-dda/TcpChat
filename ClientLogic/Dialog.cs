using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLogic
{
    public class Dialog
    {
        public string UserId { get; private set; }
        public string UserName { get; private set; }

        public string Chat { get; set; }

        public Dialog(string id, string name)
        {
            UserId = id;
            UserName = name;
            Chat = "";
        }
    }
}
