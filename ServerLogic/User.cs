﻿using ChatProtocol.Messages;
using ChatProtocol.ProtocolLogic;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerLogic
{
    public class User
    {
        public string Name { get; private set; }
        public string Id { get; private set; }

        private TcpClient _tcpClient;
        internal NetworkStream Stream { get; private set; }

        private Thread _userThread;

        private ProcessingConveyor _processingConveyor;

        private IMessageSender _sender;
        private Thread _sessionInterrupThread;
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public User(TcpClient tcpClient, IMessageSender sender)
        {
            _tcpClient = tcpClient;
            Stream = _tcpClient.GetStream();
            Id = Guid.NewGuid().ToString();
            Name = Constants.DefaultIserName;

            _sender = sender;

            _processingConveyor = new ProcessingConveyor();
            _processingConveyor.LetterReceived += OnMessageTransfer;
            _processingConveyor.NameSetReceived += OnSetName;
        }

        // Обновление жизненного цикла пользователя в сети
        private void RefreshLiveCycle()
        {
            _sessionInterrupThread?.Interrupt();
            _sessionInterrupThread = new Thread(new ThreadStart(Live));
            _sessionInterrupThread.Start();
        }

        // Пользователь автоматически отключается, если не активен 90сек
        // При активности данный метод прерывается и запускается заново см. RefreshLiveCycle
        private void Live()
        {
            try
            {
                Thread.Sleep(Constants.LiveTime);
            }
            catch (ThreadInterruptedException) { return; }
            Close();
        }

        public void StartListen()
        {
            _userThread = new Thread(new ThreadStart(ListenMessages));
            _userThread.Start();
        }

        // Метод прослушки исходящих сообщений от пользователя
        private void ListenMessages()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[512]; // буфер для получаемых данных
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
                            _logger.Info($"{Name} : {protocolMessage}");
                            _processingConveyor.Process(protocolMessage);
                        }
                    }
                }
                catch
                {
                    break;
                }
            }

            UserConnectionClosed?.Invoke(this);
        }

        // После подключения Tcp клиент шлет свое имя, чтобы его как то идентифицироваль остальные пользователи
        // Этот метод обрабатывает эту ситуацию
        private void OnSetName(NameSet nameSetMessage)
        {
            if (string.IsNullOrWhiteSpace(nameSetMessage.Name)) return;

            Name = nameSetMessage.Name;

            RefreshLiveCycle();

            // посылаем сообщение о входе в чат всем подключенным пользователям
            _sender.BroadcastMessage(new UserNetworkEvent(Id, Name, NetworkEvent.Connect).ToString(), Id);

            _sender.SendOnlineUsers(Id);
        }

        // Метод обработки отправки сообщения пользователь -> пользователь
        private void OnMessageTransfer(Letter letter)
        {
            // Сервер сам дописывает Id отправителя, чтобы получатель понял от кого сообщение
            letter.FromId = Id;
            RefreshLiveCycle();

            var stringLetter = letter.ToString();

            _sender.SendPrivateMessage(stringLetter, letter.ToId);
        }

        // Закрытие подключения
        protected internal void Close()
        {
            Stream?.Close();
            _tcpClient?.Close();
        }

        public event Action<User> UserConnectionClosed;
    }
}
