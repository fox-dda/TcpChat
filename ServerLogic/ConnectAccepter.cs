using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerLogic
{
    public class ConnectAccepter
    {
        private TcpListener _tcpListener;

        private string _address;
        private int _port;
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public ConnectAccepter(string address, int port)
        {
            _address = address;
            _port = port;

            _tcpListener = new TcpListener(IPAddress.Parse(_address), _port);
        }

        public void StartWaitToAccept()
        {
            try
            {
                _tcpListener.Start();
                AccepterStateChanged?.Invoke(ServerState.Runned);

                while (true)
                {
                    TcpClient tcpClient = _tcpListener.AcceptTcpClient();
                    _logger.Info($"Accepted new TcpClient!");
                    ConnectAccepted?.Invoke(tcpClient);
                }
            }
            catch (Exception ex)
            {
                AccepterStateChanged?.Invoke(ServerState.Stopped);
            }
        }

        public void StopWaitAccept()
        {
            _tcpListener.Stop();
        }

        public event Action<TcpClient> ConnectAccepted;
        public event Action<ServerState> AccepterStateChanged;
    }
}
