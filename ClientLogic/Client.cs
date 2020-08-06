using ChatProtocol.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLogic
{
    public class Client
    {
        private ConnectManager _connectManager;
        private Session _session;
        private string Name;

        private ClientState _state;
        public ClientState State 
        { 
            get => _state; 
            private set
            {
                _state = value;
                StateChanged?.Invoke(_state);
            }
        }

        public Client()
        {
            _connectManager = new ConnectManager();
            _session = new Session();

            _connectManager.ProcessingConveyor.LetterReceived +=
                _session.AddIncomingLetter;
            _connectManager.ProcessingConveyor.NetworkEventReceived +=
                _session.HandleNetworkEven;
            _session.SessionChanged += ForwardSessionChanges;
            _connectManager.ConnectEstablished += OnConnectEstablished;
            _connectManager.ConnectFailed += OnConnectFailed;
        }

        public void StartClient(string host, int port, string name)
        {
            Name = name;
            try
            {
                _connectManager.StartListen(host, port);
            }
            catch(Exception ex)
            {
                ErrorReceived?.Invoke(ex.Message);
            }
        }

        private void ForwardSessionChanges(List<Dialog> dialogs)
        {
            SessionChanged?.Invoke(dialogs);
        }

        public void SendLetter(string toId, string message)
        {
            var letter = new Letter("", toId, message);
            _session.AddOutgoingLetter(letter);
            _connectManager.SendLetter(letter);
        }

        public void OnConnectFailed()
        {
            _connectManager.StopListen();
            State = ClientState.Disconnected;
        }

        private void OnConnectEstablished()
        {
            _connectManager.NameSet(Name);

            State = ClientState.Connected;
        }

        public void StopClient()
        {
            _connectManager.StopListen();
        }

        public event Action<List<Dialog>> SessionChanged;
        public event Action<ClientState> StateChanged;
        public event Action<string> ErrorReceived;
    }
}
