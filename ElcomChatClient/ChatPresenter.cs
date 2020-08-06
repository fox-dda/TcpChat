using ChatProtocol.Messages;
using ChatProtocol.ProtocolLogic;
using ClientLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElcomChatClient
{
    public class ChatPresenter
    {
        private IChatClientView _chatView;
        private Client _chatClient;
        private int _selectedDialog;
        private List<Dialog> _dialogs;

        public ChatPresenter(IChatClientView view)
        {
            _chatView = view;
            _chatClient = new Client();
            InitClient();
        }

        private void InitClient()
        {
            _chatClient = new Client();
            _chatClient.SessionChanged += OnSessionChanged;
            _chatClient.StateChanged += OnClientStateChanged;
            _chatClient.ErrorReceived += OnErrorReceived;
        }

        public void Connect(string host, int port, string userName)
        {
            new Thread(() => { _chatClient.StartClient(host, port, userName); }).Start();
        }

        public void SendMessage(string message)
        {
            if(_selectedDialog < 0)
            {
                _chatView.ViewAlarm("Please select dialogue and repeat");
                return;
            }

            var toUserId = _dialogs[_selectedDialog].UserId;

            _chatClient.SendLetter(toUserId, message);
        }

        public void SelectedUserChanged(int index)
        {
            if (index != _selectedDialog && index != -1)
            {
                _selectedDialog = index;
                string chat = "";

                if (_dialogs.Count > _selectedDialog)
                {
                    chat = _dialogs[_selectedDialog].Chat;
                }

                _chatView.RefreshChat(chat);
            }
            if(index == -1)
            {
                _chatView.RefreshChat("");
            }
        }

        public void OnSessionChanged(List<Dialog> dialogs)
        {
            _dialogs = dialogs;

            var names = new List<string>();
            foreach(var dialog in dialogs)
            {
                names.Add(dialog.UserName);
            }

            string chat = "";

            if(dialogs.Count > _selectedDialog)
            {
                chat = dialogs[_selectedDialog].Chat;
            }

            _chatView.RefreshChat(chat);
            _chatView.RefreshUsersList(names);
        }

        public void SelectedChatIndexChange(int index)
        {
            _selectedDialog = index;

            OnSessionChanged(_dialogs);
        }

        public void OnClientStateChanged(ClientState state)
        {
            switch(state)
            {
                case ClientState.Connected:
                    break;
                case ClientState.Disconnected:

                    InitClient();
                    _chatView.RefreshChat("");
                    _chatView.RefreshUsersList(new List<string>());
                    break;
            }
            _chatView.ChangeStatus(state);
        }

        public void OnErrorReceived(string exceptionMessage)
        {
            _chatView.ViewAlarm(exceptionMessage);
        }

        public void StopClient()
        {
            _chatClient.SessionChanged -= OnSessionChanged;
            _chatClient.StateChanged -= OnClientStateChanged;
            _chatClient.ErrorReceived -= OnErrorReceived;
            _chatClient.StopClient();
        }
    }
}
