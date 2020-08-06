using ChatProtocol.Messages;
using ServerLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElcomChatServer
{
    public class ServerPresenter
    {
        private IChatServerView _view;
        private Server _server;

        public ServerPresenter(IChatServerView view)
        {
            _view = view;
            _server = new Server();
            _server.ServerStateChanged += OnServerStateChanged;
        }

        public void ChangeServerState(string address, int port)
        {
            if (_server.State == ServerState.Stopped)
            {
                try
                {
                    _server.StartServer(address, port);                
                }
                catch (Exception e)
                {
                    _view.ViewAlarm(e.Message);
                }
            }
            else
            {
                _server.StopServer();
            }
        }

        private void OnServerStateChanged(ServerState newState)
        {
            _view.SetServerStateView(newState);
        }

        public void StopServer()
        {
            _server?.StopServer();
        }
    }
}
