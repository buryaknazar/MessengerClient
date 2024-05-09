using MessangerData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessengerClient
{
    public partial class MessageControl : UserControl
    {
        MessageData message = null;
        string downloadDir = string.Empty;
        public MessageControl(MessageData message, string dir)
        {
            InitializeComponent();

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            this.message = message;
            this.downloadDir = dir;

            uctbMessage.Text = this.message.Text;
            uctbCreatedAt.Text = this.message.CreatedAt.ToString();
            uctbName.Text = this.message.From;

            ucbtnLoad.Visible = !string.IsNullOrEmpty(this.message.FileName);

            if (ucbtnLoad.Visible)
            {
                ucbtnLoad.Text = this.message.FileName;

                using (MemoryStream ms = new MemoryStream(message.FileData))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
        }

        private void ucbtnLoad_Click(object sender, EventArgs e)
        {
            if (message.FileData == null) return;

            using (FileStream fs = new FileStream(downloadDir + message.FileName, FileMode.Create))
            {
                fs.Write(message.FileData, 0, message.FileData.Length);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (message.FileData == null) return;

            DisplayPicture displayPicture = new DisplayPicture();
            displayPicture.Text = message.FileName;
            displayPicture.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            displayPicture.pictureBox1.Image = this.pictureBox1.Image;
            displayPicture.Show();
        }
    }
}
