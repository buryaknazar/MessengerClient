using MessangerData;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms.Design;
using Microsoft.Extensions.Configuration;

namespace MessengerClient
{
    public partial class Form1 : Form
    {
        TcpClient socket = null;
        string selectedFile = string.Empty;
        string downloadDir = string.Empty;
        string name = string.Empty;
        BinaryFormatter formatter = null;
        NetworkStream ns = null;
        bool IsActive = false;
        int top = 5;
        SqlConnection conn = null;

        public Form1()
        {
            InitializeComponent();

            cbUsers.Items.Add("All");
            formatter = new BinaryFormatter();
            downloadDir = Directory.GetCurrentDirectory();
            downloadDir += "\\Downloads\\";
            Directory.CreateDirectory(downloadDir);
            ConnectToDb();
        }

        private void ConnectToDb()
        {
            //var configuration = new ConfigurationBuilder().AddJsonFile("config.json").Build();
            //string connectionString = configuration["MyConnString"];
            //conn = new SqlConnection(connectionString);
            //conn.Open();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedFile = ofd.FileName;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tbName.Text))
            {
                socket = new TcpClient();
                socket.Connect(tbAddress.Text.Trim(), Convert.ToInt32(tbPort.Text.Trim()));
                ns = socket.GetStream();

                MessageData message = new MessageData()
                {
                    From = tbName.Text.Trim(),
                    To = string.Empty,
                    Action = "Login",
                    FileData = null,
                    FileName = string.Empty,
                    CreatedAt = DateTime.Now
                };

                IsActive = true;
                SendMessage(message);

                StreamReader reader = new StreamReader(ns, Encoding.UTF8);

                MessageData response = (MessageData)formatter.Deserialize(reader.BaseStream);

                MemoryStream ms = new MemoryStream(response.FileData);
                List<string> users = (List<string>)formatter.Deserialize(ms);
                ms.Close();

                foreach (string user in users)
                {
                    cbUsers.Items.Add(user);
                }

                cbUsers.SelectedIndex = 0;

                if (response.Action.Equals("Error.Name"))
                {
                    MessageControl mc = new MessageControl(response, downloadDir);
                    mc.Location = new Point(10, top);
                    tbMessages.Controls.Add(mc);
                    top += mc.Height + 2;

                    IsActive = false;
                }

                Thread thread = new Thread(ReceiveResponses);
                thread.IsBackground = true;
                thread.Start();
            }
        }

        private void ReceiveResponses(object? obj)
        {
            try
            {
                while (IsActive)
                {
                    StreamReader reader = new StreamReader(ns, Encoding.UTF8);
                    MessageData response = (MessageData)formatter.Deserialize(reader.BaseStream);

                    if (response != null)
                    {
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            MessageControl mc = new MessageControl(response, downloadDir);
                            mc.Location = new Point(10, top);
                            tbMessages.Controls.Add(mc);
                            top += mc.Height + 2;

                            if (response.Action.Equals("Login"))
                            {
                                cbUsers.Items.Add(response.From);
                            }

                            if (response.Action.Equals("Logout"))
                            {
                                cbUsers.Items.Remove(response.From);
                            }

                            if (response.Action.Equals("Error.Name"))
                            {
                                IsActive = false;
                            }
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Client ReceiveResponses:" + ex.Message);
            }
        }

        private void SendMessage(MessageData message)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    formatter.Serialize(ms, message);
                    ns.Write(ms.ToArray(), 0, (int)ms.Length);
                    ns.Flush();
                }
                AddMessageToDb(message);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Client SendMessage:" + ex.Message);
            }
        }

        private void AddMessageToDb(MessageData message)
        {
            try
            {
                string ins =
                "insert into archives (mfrom, mto, mtext, maction, mfiledata, mfilename, mcreatedat) " +
                "values (@from, @to, @text, @action, @filedata, @filename, @createdat)";
                SqlCommand comm = new SqlCommand(ins, conn);

                comm.Parameters.Add("@from", System.Data.SqlDbType.NVarChar, 32).Value = message.From;
                comm.Parameters.Add("@to", System.Data.SqlDbType.NVarChar, 32).Value = message.To;
                comm.Parameters.Add("@text", System.Data.SqlDbType.NVarChar, 255).Value = message.Text;
                comm.Parameters.Add("@action", System.Data.SqlDbType.NVarChar, 32).Value = message.Action;
                if (message.FileData != null)
                {
                    comm.Parameters.Add("@filedata", System.Data.SqlDbType.Image, message.FileData.Length).Value = message.FileData;
                }
                else
                {
                    comm.Parameters.Add("@filedata", System.Data.SqlDbType.Image, 0).Value = SqlInt32.Null;
                }
                comm.Parameters.Add("@filename", System.Data.SqlDbType.NVarChar, 32).Value = message.FileName;
                comm.Parameters.Add("@createdat", System.Data.SqlDbType.DateTime).Value = message.CreatedAt;

                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Client AddMessageToDb:" + ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!IsActive) return;
            if (tbMessage.Text.Trim().Length == 0) return;
            try
            {
                MessageData message = new MessageData()
                {
                    From = tbName.Text.Trim(),
                    To = cbUsers.SelectedItem.ToString(),
                    Action = "Message",
                    FileData = GetFileData(),
                    FileName = String.IsNullOrEmpty(selectedFile) ? string.Empty : Path.GetFileName(selectedFile),
                    CreatedAt = DateTime.Now,
                    Text = tbMessage.Text.Trim()
                };
                SendMessage(message);
                selectedFile = string.Empty;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Client btnSend_Click:" + ex.Message);
            }
        }

        private byte[] GetFileData()
        {
            if (String.IsNullOrEmpty(selectedFile)) return null;
            try
            {
                using (FileStream fs = new FileStream(selectedFile, FileMode.Open))
                {
                    BinaryReader reader = new BinaryReader(fs);
                    byte[] buffer = reader.ReadBytes((int)reader.BaseStream.Length);
                    reader.Close();
                    return buffer;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Client GetFileData:" + ex.Message);
                return null;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MessageData message = new MessageData()
            {
                From = tbName.Text.Trim(),
                To = string.Empty,
                Action = "Logout",
                FileData = null,
                FileName = string.Empty,
                CreatedAt = DateTime.Now
            };

            SendMessage(message);
            IsActive = false;

            ns.Close();
            socket.Close();
            conn.Close();

            tbName.Text = string.Empty;
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            if (conn == null) return;
            Archive archive = new Archive(conn);
            archive.Show();
        }
    }
}