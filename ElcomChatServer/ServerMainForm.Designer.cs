namespace ElcomChatServer
{
    partial class ServerMainForm
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
            this.TopPanel = new System.Windows.Forms.Panel();
            this.sLabel = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.hostTextBox = new System.Windows.Forms.TextBox();
            this.stateLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.portLabel = new System.Windows.Forms.Label();
            this.hostLabel = new System.Windows.Forms.Label();
            this.TopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TopPanel.Controls.Add(this.sLabel);
            this.TopPanel.Controls.Add(this.portTextBox);
            this.TopPanel.Controls.Add(this.hostTextBox);
            this.TopPanel.Controls.Add(this.stateLabel);
            this.TopPanel.Controls.Add(this.startButton);
            this.TopPanel.Controls.Add(this.portLabel);
            this.TopPanel.Controls.Add(this.hostLabel);
            this.TopPanel.Location = new System.Drawing.Point(8, 12);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(387, 52);
            this.TopPanel.TabIndex = 2;
            // 
            // sLabel
            // 
            this.sLabel.AutoSize = true;
            this.sLabel.Location = new System.Drawing.Point(340, 8);
            this.sLabel.Name = "sLabel";
            this.sLabel.Size = new System.Drawing.Size(32, 13);
            this.sLabel.TabIndex = 10;
            this.sLabel.Text = "State";
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
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(333, 31);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(47, 13);
            this.stateLabel.TabIndex = 4;
            this.stateLabel.Text = "Stopped";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(225, 26);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Run";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
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
            // ServerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 75);
            this.Controls.Add(this.TopPanel);
            this.Name = "ServerMainForm";
            this.Text = "ElcomChat Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ServerMainForm_FormClosed);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.TextBox hostTextBox;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.Label sLabel;
    }
}

