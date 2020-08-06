namespace ElcomChatClient
{
    partial class ClientMainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.onlineUsersListBox = new System.Windows.Forms.ListBox();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.hostTextBox = new System.Windows.Forms.TextBox();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.stateLabel = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.hostLabel = new System.Windows.Forms.Label();
            this.chatRichTextBox = new System.Windows.Forms.RichTextBox();
            this.sendTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.uLabel = new System.Windows.Forms.Label();
            this.cLabel = new System.Windows.Forms.Label();
            this.TopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // onlineUsersListBox
            // 
            this.onlineUsersListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.onlineUsersListBox.FormattingEnabled = true;
            this.onlineUsersListBox.Location = new System.Drawing.Point(12, 83);
            this.onlineUsersListBox.Name = "onlineUsersListBox";
            this.onlineUsersListBox.Size = new System.Drawing.Size(120, 368);
            this.onlineUsersListBox.TabIndex = 0;
            this.onlineUsersListBox.SelectedIndexChanged += new System.EventHandler(this.OnlineUsersListBox_SelectedIndexChanged);
            // 
            // TopPanel
            // 
            this.TopPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TopPanel.Controls.Add(this.portTextBox);
            this.TopPanel.Controls.Add(this.hostTextBox);
            this.TopPanel.Controls.Add(this.userNameTextBox);
            this.TopPanel.Controls.Add(this.stateLabel);
            this.TopPanel.Controls.Add(this.connectButton);
            this.TopPanel.Controls.Add(this.userNameLabel);
            this.TopPanel.Controls.Add(this.portLabel);
            this.TopPanel.Controls.Add(this.hostLabel);
            this.TopPanel.Location = new System.Drawing.Point(12, 12);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(780, 52);
            this.TopPanel.TabIndex = 1;
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(109, 28);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(100, 20);
            this.portTextBox.TabIndex = 9;
            this.portTextBox.Text = "8000";
            // 
            // hostTextBox
            // 
            this.hostTextBox.Location = new System.Drawing.Point(3, 28);
            this.hostTextBox.Name = "hostTextBox";
            this.hostTextBox.Size = new System.Drawing.Size(100, 20);
            this.hostTextBox.TabIndex = 8;
            this.hostTextBox.Text = "127.0.0.1";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(215, 28);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.userNameTextBox.TabIndex = 7;
            this.userNameTextBox.Text = "Dmitry";
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(727, 8);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(37, 13);
            this.stateLabel.TabIndex = 4;
            this.stateLabel.Text = "Offline";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(321, 26);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 3;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(236, 8);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(60, 13);
            this.userNameLabel.TabIndex = 2;
            this.userNameLabel.Text = "User Name";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(149, 8);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(26, 13);
            this.portLabel.TabIndex = 1;
            this.portLabel.Text = "Port";
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.Location = new System.Drawing.Point(41, 8);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(29, 13);
            this.hostLabel.TabIndex = 0;
            this.hostLabel.Text = "Host";
            // 
            // chatRichTextBox
            // 
            this.chatRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatRichTextBox.Location = new System.Drawing.Point(138, 83);
            this.chatRichTextBox.Name = "chatRichTextBox";
            this.chatRichTextBox.Size = new System.Drawing.Size(654, 340);
            this.chatRichTextBox.TabIndex = 2;
            this.chatRichTextBox.Text = "";
            this.chatRichTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chatRichTextBox_KeyPress);
            // 
            // sendTextBox
            // 
            this.sendTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sendTextBox.Location = new System.Drawing.Point(138, 429);
            this.sendTextBox.Name = "sendTextBox";
            this.sendTextBox.Size = new System.Drawing.Size(568, 20);
            this.sendTextBox.TabIndex = 3;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(712, 427);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(80, 23);
            this.sendButton.TabIndex = 4;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // uLabel
            // 
            this.uLabel.AutoSize = true;
            this.uLabel.Location = new System.Drawing.Point(12, 67);
            this.uLabel.Name = "uLabel";
            this.uLabel.Size = new System.Drawing.Size(65, 13);
            this.uLabel.TabIndex = 5;
            this.uLabel.Text = "Users online";
            // 
            // cLabel
            // 
            this.cLabel.AutoSize = true;
            this.cLabel.Location = new System.Drawing.Point(135, 67);
            this.cLabel.Name = "cLabel";
            this.cLabel.Size = new System.Drawing.Size(117, 13);
            this.cLabel.TabIndex = 6;
            this.cLabel.Text = "Chat with selected user";
            // 
            // ClientMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 461);
            this.Controls.Add(this.cLabel);
            this.Controls.Add(this.uLabel);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.sendTextBox);
            this.Controls.Add(this.chatRichTextBox);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.onlineUsersListBox);
            this.MaximumSize = new System.Drawing.Size(820, 500);
            this.MinimumSize = new System.Drawing.Size(820, 500);
            this.Name = "ClientMainWindow";
            this.Text = "ElcomChat Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox onlineUsersListBox;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.RichTextBox chatRichTextBox;
        private System.Windows.Forms.TextBox sendTextBox;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.TextBox hostTextBox;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label uLabel;
        private System.Windows.Forms.Label cLabel;
    }
}

