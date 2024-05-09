using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessengerClient
{
    public partial class Archive : Form
    {
        SqlConnection conn = null;

        //DI - loose coupling
        public Archive(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void btShow_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "select * from archives where cast(mcreatedat as date) = @date";
            comm.Connection = conn;
            comm.Parameters.Add("@date", System.Data.SqlDbType.Date).Value = date;

            DataTable table = new DataTable();



        }
    }
}
