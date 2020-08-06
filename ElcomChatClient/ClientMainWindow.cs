using ClientLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElcomChatClient
{
    public partial class ClientMainWindow : Form, IChatClientView
    {
        private ChatPresenter _chatPresenter;
        public ClientMainWindow()
        {
            _chatPresenter = new ChatPresenter(this);
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            int port;

            if (int.TryParse(portTextBox.Text, out port))
            {
                _chatPresenter.Connect(hostTextBox.Text, port, userNameTextBox.Text);
            }
        }

        public void ViewAlarm(string textBoxMessage)
        {
            MessageBox.Show(
                textBoxMessage,
                "Alarm",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sendTextBox.Text)
                || onlineUsersListBox.SelectedItem == null) return;
        
            _chatPresenter.SendMessage(sendTextBox.Text);
            sendTextBox.Clear();
        }

        public void ChangeStatus(ClientState state)
        {
            switch(state)
            {
                case ClientState.Connected:
                    stateLabel.BeginInvoke((MethodInvoker)(() =>
                    {
                        stateLabel.Text = "Online";
                        stateLabel.ForeColor = Color.Green;
                    }));
                    break;
                case ClientState.Disconnected:
                    stateLabel.BeginInvoke((MethodInvoker)(() =>
                    {
                        stateLabel.Text = "Offline";
                        stateLabel.ForeColor = Color.Red;
                    }));
                    break;
            }
        }

        private void OnlineUsersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = (sender as ListBox).SelectedIndex;
            _chatPresenter.SelectedUserChanged(selectedIndex);
        }

        public void RefreshChat(string chat)
        {
            chatRichTextBox.BeginInvoke((MethodInvoker)(() =>
            {
                chatRichTextBox.Text = chat;
            }));
        }

        public void RefreshUsersList(List<string> userNames)
        {
            onlineUsersListBox.BeginInvoke((MethodInvoker)(() =>
            {
                var selectedIndex = onlineUsersListBox.SelectedIndex;
                onlineUsersListBox.Items.Clear();

                foreach (var name in userNames)
                {
                    onlineUsersListBox.Items.Add(name);
                }

                if(userNames.Count < selectedIndex + 1)
                {
                    selectedIndex = -1;
                }

                onlineUsersListBox.SelectedIndex = selectedIndex;
            }));
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            _chatPresenter.StopClient();
        }

        private void chatRichTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
