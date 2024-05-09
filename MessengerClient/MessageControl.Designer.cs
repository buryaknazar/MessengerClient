namespace MessengerClient
{
    partial class MessageControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            uctbMessage = new TextBox();
            uctbName = new TextBox();
            uctbCreatedAt = new TextBox();
            pictureBox1 = new PictureBox();
            ucbtnLoad = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // uctbMessage
            // 
            uctbMessage.Location = new Point(14, 28);
            uctbMessage.Multiline = true;
            uctbMessage.Name = "uctbMessage";
            uctbMessage.Size = new Size(295, 29);
            uctbMessage.TabIndex = 0;
            // 
            // uctbName
            // 
            uctbName.BackColor = Color.DarkSeaGreen;
            uctbName.BorderStyle = BorderStyle.FixedSingle;
            uctbName.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            uctbName.ForeColor = Color.WhiteSmoke;
            uctbName.Location = new Point(14, 3);
            uctbName.Name = "uctbName";
            uctbName.Size = new Size(100, 20);
            uctbName.TabIndex = 1;
            // 
            // uctbCreatedAt
            // 
            uctbCreatedAt.BackColor = Color.DarkSeaGreen;
            uctbCreatedAt.BorderStyle = BorderStyle.FixedSingle;
            uctbCreatedAt.Font = new Font("Arial", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            uctbCreatedAt.ForeColor = Color.WhiteSmoke;
            uctbCreatedAt.Location = new Point(120, 3);
            uctbCreatedAt.Name = "uctbCreatedAt";
            uctbCreatedAt.Size = new Size(100, 20);
            uctbCreatedAt.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(315, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(83, 54);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // ucbtnLoad
            // 
            ucbtnLoad.BackColor = Color.WhiteSmoke;
            ucbtnLoad.FlatStyle = FlatStyle.Popup;
            ucbtnLoad.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ucbtnLoad.Location = new Point(226, 3);
            ucbtnLoad.Name = "ucbtnLoad";
            ucbtnLoad.Size = new Size(83, 23);
            ucbtnLoad.TabIndex = 4;
            ucbtnLoad.Text = "Load";
            ucbtnLoad.UseVisualStyleBackColor = false;
            ucbtnLoad.Click += ucbtnLoad_Click;
            // 
            // MessageControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SeaGreen;
            Controls.Add(ucbtnLoad);
            Controls.Add(pictureBox1);
            Controls.Add(uctbCreatedAt);
            Controls.Add(uctbName);
            Controls.Add(uctbMessage);
            Name = "MessageControl";
            Size = new Size(411, 66);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox uctbMessage;
        private TextBox uctbName;
        private TextBox uctbCreatedAt;
        private PictureBox pictureBox1;
        private Button ucbtnLoad;
    }
}
