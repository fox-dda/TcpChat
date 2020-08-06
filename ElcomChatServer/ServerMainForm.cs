using ServerLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElcomChatServer
{
    public partial class ServerMainForm : Form, IChatServerView
    {
        private ServerPresenter _presenter;
        public ServerMainForm()
        {
            _presenter = new ServerPresenter(this);

            InitializeComponent();

            stateLabel.Text = "Stopped";
            stateLabel.ForeColor = Color.Red;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            int port;

            if (int.TryParse(portTextBox.Text, out port))
            {
                _presenter.ChangeServerState(hostTextBox.Text, port);
            }
        }

        public void ViewAlarm(string alarm)
        {
            var messageBox = MessageBox.Show(alarm, "Alarm");
        }

        public void SetServerStateView(ServerState newState)
        {
            switch (newState)
            {
                case ServerState.Runned:
                    stateLabel.BeginInvoke((MethodInvoker)(() =>
                   {
                       stateLabel.Text = "Runned";
                       stateLabel.ForeColor = Color.Green;
                   }));
                    startButton.BeginInvoke((MethodInvoker)(() =>
                   {
                       startButton.Text = "Stop";
                   }));
                    break;
                case ServerState.Stopped:
                    stateLabel.BeginInvoke((MethodInvoker)(() =>
                    {
                        stateLabel.Text = "Stopped";
                        stateLabel.ForeColor = Color.Red;
                    }));
                    startButton.BeginInvoke((MethodInvoker)(() =>
                    {
                        startButton.Text = "Run";
                    }));
                    break;
            }
        }

        private void ServerMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _presenter.StopServer();
        }
    }
}
