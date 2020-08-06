using ChatProtocol.Messages;
using ChatProtocol.ProtocolLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLogic
{
    public class Session
    {
        public List<Dialog> Dialogs { get; private set; }

        public Session()
        {
            Dialogs = new List<Dialog>();
        }

        public bool TryCreateNewDialog(string id, string name)
        {
            if (Dialogs.FirstOrDefault(d => d.UserId == id) == null)
            {
                Dialogs.Add(new Dialog(id, name));
                return true;
            }

            return false;
        }

        public void RemoveDialog(string id)
        {
            var dialog = Dialogs.FirstOrDefault(d => d.UserId == id);
            if (dialog != null)
            {
                Dialogs.Remove(dialog);
            }
        }

        public Dialog GetDialogById(string id)
        {
            return Dialogs.FirstOrDefault(d => d.UserId == id);
        }

        public void AddIncomingLetter(Letter letter)
        {
            var dialog = GetDialogById(letter.FromId);
            if (dialog != null)
            {
                dialog.Chat += "<< " + letter.Message + "\n";
                SessionChanged?.Invoke(Dialogs);
            }
        }

        public void AddOutgoingLetter(Letter letter) // TODO: почти одинаковый метод с AddIncomingLetter!
        {
            var dialog = GetDialogById(letter.ToId);
            if (dialog != null)
            {
                dialog.Chat += ">> " + letter.Message + "\n";
                SessionChanged?.Invoke(Dialogs);
            }
        }

        public void HandleNetworkEven(UserNetworkEvent netEvent)
        {
            switch(netEvent.NetworkEvent)
            {
                case NetworkEvent.Connect:
                    TryCreateNewDialog(netEvent.Id, netEvent.Name);
                    break;
                case NetworkEvent.Leave:
                    RemoveDialog(netEvent.Id);
                    break;
            }

            SessionChanged?.Invoke(Dialogs);
        }

        public event Action<List<Dialog>> SessionChanged;
    }
}
