using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerLogic
{
    public class Server
    {
        private ConnectAccepter _connectAccepter;
        private UsersHandler _usersHandler;
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private ServerState _state;
        public ServerState State
        {
            get => _state;
            private set
            {
                if (_state != value)
                {
                    _state = value;
                    _logger.Info($"Server state changed: {State}");
                }
            }
        }

        public Server()
        {
            State = ServerState.Stopped;
        }

        public void StartServer(string address, int port)
        {
            _usersHandler = new UsersHandler();
            _connectAccepter = new ConnectAccepter(address, port);

            _connectAccepter.ConnectAccepted += _usersHandler.AddUser;
            _connectAccepter.AccepterStateChanged += OnAccepterStateChanged;

            var acceptThread = new Thread(new ThreadStart(_connectAccepter.StartWaitToAccept));
            acceptThread.Start();
        }

        public void StopServer()
        {
            _usersHandler?.CloseAll();
            _connectAccepter?.StopWaitAccept();
            State = ServerState.Stopped;
        }

        internal void OnAccepterStateChanged(ServerState state)
        {
            if (state == ServerState.Stopped)
            {
                StopServer();
            }
            else if (state == ServerState.Runned)
            {
                State = ServerState.Runned;
            }
            ServerStateChanged?.Invoke(state);
        }

        public event Action<ServerState> ServerStateChanged;
    }
}
