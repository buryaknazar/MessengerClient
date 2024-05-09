namespace MessengerClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            tbAddress = new TextBox();
            label2 = new Label();
            tbPort = new TextBox();
            label1 = new Label();
            cbUsers = new ComboBox();
            tbMessages = new Panel();
            groupBox2 = new GroupBox();
            label3 = new Label();
            btnLogout = new Button();
            btnSend = new Button();
            btnLogin = new Button();
            tbName = new TextBox();
            tbMessage = new TextBox();
            btnSelect = new Button();
            btnArchive = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbAddress);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(tbPort);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(347, 60);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Settings:";
            // 
            // tbAddress
            // 
            tbAddress.Location = new Point(233, 22);
            tbAddress.Name = "tbAddress";
            tbAddress.Size = new Size(100, 23);
            tbAddress.TabIndex = 3;
            tbAddress.Text = "127.0.0.1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(175, 25);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 2;
            label2.Text = "Address:";
            // 
            // tbPort
            // 
            tbPort.Location = new Point(47, 22);
            tbPort.Name = "tbPort";
            tbPort.Size = new Size(100, 23);
            tbPort.TabIndex = 1;
            tbPort.Text = "9999";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 25);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 0;
            label1.Text = "Port:";
            // 
            // cbUsers
            // 
            cbUsers.FormattingEnabled = true;
            cbUsers.Location = new Point(6, 118);
            cbUsers.Name = "cbUsers";
            cbUsers.Size = new Size(125, 23);
            cbUsers.TabIndex = 1;
            // 
            // tbMessages
            // 
            tbMessages.AutoScroll = true;
            tbMessages.BackColor = Color.WhiteSmoke;
            tbMessages.Location = new Point(12, 130);
            tbMessages.Name = "tbMessages";
            tbMessages.Size = new Size(347, 150);
            tbMessages.TabIndex = 2;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnArchive);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(btnLogout);
            groupBox2.Controls.Add(btnSend);
            groupBox2.Controls.Add(btnLogin);
            groupBox2.Controls.Add(tbName);
            groupBox2.Controls.Add(cbUsers);
            groupBox2.Location = new Point(372, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(137, 268);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Actions:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 100);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 7;
            label3.Text = "Select user:";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(6, 237);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(125, 25);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(6, 147);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(125, 33);
            btnSend.TabIndex = 5;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(6, 50);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(125, 23);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // tbName
            // 
            tbName.Location = new Point(6, 21);
            tbName.Name = "tbName";
            tbName.PlaceholderText = "Your name";
            tbName.Size = new Size(125, 23);
            tbName.TabIndex = 2;
            // 
            // tbMessage
            // 
            tbMessage.BackColor = Color.WhiteSmoke;
            tbMessage.BorderStyle = BorderStyle.FixedSingle;
            tbMessage.Location = new Point(12, 78);
            tbMessage.Multiline = true;
            tbMessage.Name = "tbMessage";
            tbMessage.Size = new Size(295, 46);
            tbMessage.TabIndex = 1;
            // 
            // btnSelect
            // 
            btnSelect.Location = new Point(312, 76);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(47, 48);
            btnSelect.TabIndex = 4;
            btnSelect.Text = "Select file";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // btnArchive
            // 
            btnArchive.Location = new Point(6, 206);
            btnArchive.Name = "btnArchive";
            btnArchive.Size = new Size(125, 25);
            btnArchive.TabIndex = 8;
            btnArchive.Text = "Archive";
            btnArchive.UseVisualStyleBackColor = true;
            btnArchive.Click += btnArchive_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSeaGreen;
            ClientSize = new Size(521, 292);
            Controls.Add(btnSelect);
            Controls.Add(tbMessage);
            Controls.Add(groupBox2);
            Controls.Add(tbMessages);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox tbAddress;
        private Label label2;
        private TextBox tbPort;
        private Label label1;
        private ComboBox cbUsers;
        private Panel tbMessages;
        private GroupBox groupBox2;
        private Button btnLogin;
        private TextBox tbName;
        private Label label3;
        private Button btnLogout;
        private Button btnSend;
        private TextBox tbMessage;
        private Button btnSelect;
        private Button btnArchive;
    }
}