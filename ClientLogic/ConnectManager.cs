using ChatProtocol.Messages;
using ChatProtocol.ProtocolLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientLogic
{
    public class ConnectManager
    {
        internal ProcessingConveyor ProcessingConveyor { get; private set; }
        internal string Host { get; private set; }
        internal int Port { get; private set; }

        internal TcpClient TcpClient { get; set; }
        internal NetworkStream Stream { get; set; }
        public ConnectManager()
        {
            ProcessingConveyor = new ProcessingConveyor();
            TcpClient = new TcpClient(); 
        }

        public void StartListen(string host, int port)
        {
            Host = host;
            Port = port;

            TcpClient.Connect(Host, Port); 
            Stream = TcpClient.GetStream();             

            var listenThread = new Thread(new ThreadStart(Listen));
            listenThread.Start();

            ConnectEstablished?.Invoke();
        }

        private void Listen()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[512]; 
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = Stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.UTF8.GetString(data, 0, bytes));
                    }
                    while (Stream.DataAvailable);

                    var message = builder.ToString();
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        var messages = message.Split('$');
                        foreach (var protocolMessage in messages)
                        {
                            if (string.IsNullOrWhiteSpace(protocolMessage)) continue;
                            ProcessingConveyor.Process(protocolMessage);
                        }
                    }
                }
                catch (Exception e)
                {
                    ConnectFailed?.Invoke();
                    break;
                }
            }
        }

        internal void SendLetter(Letter letter)
        {            
            Send(letter.ToString());
        }

        private void Send(string message)
        {
            message = "$" + message;
            byte[] data = Encoding.UTF8.GetBytes(message);
            try
            {
                Stream.Write(data, 0, data.Length);
            } catch(IOException)
            {
                ConnectFailed();
            }
        }

        internal void NameSet(string name)
        {
            var nameSetMessage = new NameSet(name);
            Send(nameSetMessage.ToString());
        }

        public void StopListen()
        {
            Stream?.Close();
            TcpClient?.Close();            
        }

        public event Action ConnectFailed;
        public event Action ConnectEstablished;
    }
}
