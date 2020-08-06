using ChatProtocol.Messages;
using ChatProtocol.ProtocolLogic;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerLogic
{
    public class UsersHandler : IMessageSender
    {
        public List<User> Users { get; set; }
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public UsersHandler()
        {
            Users = new List<User>();
        }

        public void AddUser(TcpClient tcpClient)
        {
            var user = new User(tcpClient, (this as IMessageSender));
            Users.Add(user);
            user.UserConnectionClosed += OnUserConnectionClosed;
            user.StartListen();
            _logger.Info($"Connected new User: {user.Name} - {user.Id}");
        }

        public void RemoveUser(string id)
        {
            var user = GetUserById(id);
            if(user != null)
            {
                user.Close();
            }
            Users.Remove(user);
        }

        public User GetUserById(string id)
        {
            return Users.FirstOrDefault(u => u.Id.Equals(id));
        }

        public void SendPrivateMessage(string message, string toId)
        {
            var toUser = GetUserById(toId);
            if(toUser != null)
            {
                Send(toUser, message);
            }
        }

        public void BroadcastMessage(string message, string senderId)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].Id != senderId) // если id клиента не равно id отправляющего
                {
                    Send(Users[i], message); //передача данных
                }
            }
        }

        // Метод для отправки новоподключенному пользователю списока других пользователй онлайн
        public void SendOnlineUsers(string toId)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].Id != toId) 
                {
                    var conEvent = new UserNetworkEvent(
                        Users[i].Id, Users[i].Name, NetworkEvent.Connect);

                    SendPrivateMessage(conEvent.ToString(), toId);
                }
            }
        }

        private void Send(User user, string message)
        {
            message = "$" + message;
            byte[] data = Encoding.UTF8.GetBytes(message);
            user.Stream.Write(data, 0, data.Length);
        }

        public void CloseAll()
        {
            foreach(var user in Users)
            {
                user.Close();
            }

            Users.Clear();
        }

        public void OnUserConnectionClosed(User closedUser)
        {
            Users.Remove(closedUser);
            _logger.Info($"Disconnected User: {closedUser.Name} - {closedUser.Id}");

            SendAllLeaveEvent(closedUser);
        }

        private void SendAllLeaveEvent(User leavedUser)
        {
            foreach (var user in Users)
            {
                Send(user, new UserNetworkEvent(
                    leavedUser.Id,
                    leavedUser.Name,
                    NetworkEvent.Leave)
                .ToString());
            }
        }

        public event Action<Exception> OnException;
    }
}
